using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VigenereCipher
{
    /// <summary>One stage of the pipeline, shown in the "Intermediate Rounds" box.</summary>
    public class CipherStep
    {
        public string Label { get; }
        public string Text { get; }

        public CipherStep(string label, string text)
        {
            Label = label;
            Text = text;
        }
    }

    public static class VigenereService
    {
        private const char Pad = '&';
        private const int MaxKey = 1000;

        // ------------------------------------------------------------------
        // Key handling
        // ------------------------------------------------------------------

        /// <summary>
        /// Converts the keyword into shifts where A = 1, B = 2, ... Z = 26.
        /// Only letters are allowed.
        /// </summary>
        public static int[] ParseKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Keyword cannot be empty.");

            string k = keyword.Trim();
            int[] shifts = new int[k.Length];

            for (int i = 0; i < k.Length; i++)
            {
                char c = char.ToUpperInvariant(k[i]);
                if (c < 'A' || c > 'Z')
                    throw new ArgumentException($"Invalid keyword character '{k[i]}'. Use letters A to Z only.");

                shifts[i] = c - 'A' + 1;
            }

            return shifts;
        }

        /// <summary>Parses a whole number from 1 to 1000.</summary>
        public static int ParseKey(string raw, string keyName)
        {
            if (string.IsNullOrWhiteSpace(raw))
                throw new ArgumentException($"The {keyName} cannot be empty.");

            if (!int.TryParse(raw.Trim(), out int value))
                throw new ArgumentException($"The {keyName} must be a whole number.");

            if (value < 1 || value > MaxKey)
                throw new ArgumentException($"The {keyName} must be between 1 and {MaxKey}.");

            return value;
        }

        // ------------------------------------------------------------------
        // Pipeline
        // Encryption: Substitution -> Column permutation -> Row permutation
        // Decryption: Row permutation (reverse) -> Column permutation (reverse) -> Substitution (reverse)
        // ------------------------------------------------------------------

        /// <summary>Runs the full pipeline and returns every stage, last item is the final result.</summary>
        public static List<CipherStep> Run(string input, string keyword, string columnKey, string rowKey, bool encrypt)
        {
            int[] shifts = ParseKeyword(keyword);
            int cols = ParseKey(columnKey, "column key");
            int rows = ParseKey(rowKey, "row key");

            // Capitals only, spaces removed
            string text = new string((input ?? "").Where(c => !char.IsWhiteSpace(c)).ToArray()).ToUpperInvariant();
            if (text.Length == 0)
                throw new ArgumentException("Input text cannot be empty.");

            var steps = new List<CipherStep>();

            if (encrypt)
            {
                if (text.Contains(Pad))
                    throw new ArgumentException("The text cannot contain the & symbol, because & is used for padding.");

                text = Substitute(text, shifts, true);
                steps.Add(new CipherStep("Round 1 (Vigenere substitution)", text));

                // Round 2: pad so the grid is full, write by rows, read by columns
                text = text.PadRight(CeilDiv(text.Length, cols) * cols, Pad);
                text = ReadByColumns(text, cols);
                steps.Add(new CipherStep("Round 2 (column permutation, & padding added)", text));

                // Round 3: pad so the grid is full, write by columns, read by rows
                int rowCols = CeilDiv(text.Length, rows);
                text = text.PadRight(rowCols * rows, Pad);
                text = FillColumns(text, rowCols);
                steps.Add(new CipherStep("Round 3 (row permutation, & padding added), final ciphertext", text));
            }
            else
            {
                int size = text.Length;
                if (size % rows != 0)
                    throw new ArgumentException(
                        $"The ciphertext has {size} characters. That length must divide evenly by the row key ({rows}).");

                // Undo round 3
                string padded = ReadByColumns(text, size / rows);
                steps.Add(new CipherStep("Undo round 3 (row permutation)", padded));

                // Undo round 2. The length before round 3 padding is not stored,
                // so the program tests each possible length and keeps the one that fits.
                string gridText = null;
                string trimmed = null;
                for (int len = cols; len <= size; len += cols)
                {
                    if (len <= size - rows) continue; // round 3 adds fewer than 'rows' characters

                    if (padded.Substring(len).Any(ch => ch != Pad)) continue; // extra characters must be padding

                    string candidate = FillColumns(padded.Substring(0, len), cols);
                    string stripped = candidate.TrimEnd(Pad);

                    if (stripped.Length == 0) continue;
                    if (stripped.Contains(Pad)) continue;                 // padding only sits at the end
                    if (candidate.Length - stripped.Length >= cols) continue; // last row keeps a real character

                    gridText = candidate;
                    trimmed = stripped;
                    break;
                }

                if (gridText == null)
                    throw new ArgumentException("This ciphertext does not match the column key and the row key you entered.");

                steps.Add(new CipherStep("Undo round 2 (column permutation)", gridText));

                text = Substitute(trimmed, shifts, false);
                steps.Add(new CipherStep("Undo round 1 (Vigenere substitution), padding removed, final plaintext", text));
            }

            return steps;
        }

        /// <summary>Returns only the final result.</summary>
        public static string Process(string input, string keyword, string columnKey, string rowKey, bool encrypt)
        {
            return Run(input, keyword, columnKey, rowKey, encrypt).Last().Text;
        }

        // ------------------------------------------------------------------
        // Round 1: Vigenere substitution (A = 1 ... Z = 26)
        // ------------------------------------------------------------------
        private static string Substitute(string input, int[] shifts, bool encrypt)
        {
            var sb = new StringBuilder(input.Length);
            int keyIndex = 0;

            foreach (char c in input)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    int shift = shifts[keyIndex % shifts.Length];
                    if (!encrypt) shift = -shift;

                    int offset = (((c - 'A') + shift) % 26 + 26) % 26;
                    sb.Append((char)('A' + offset));
                    keyIndex++; // only letters use up a keyword position
                }
                else
                {
                    sb.Append(c); // digits and punctuation stay as they are
                }
            }

            return sb.ToString();
        }

        // ------------------------------------------------------------------
        // Rounds 2 and 3: grid transposition
        // Round 2 writes the text row by row into a grid that is 'column key' wide
        // and reads it column by column.
        // Round 3 writes the text column by column into a grid that has 'row key' rows
        // and reads it row by row.
        // Both rounds pad with & so that their grid is completely full.
        // ------------------------------------------------------------------

        /// <summary>
        /// Writes the text row by row into a grid that is 'width' columns wide
        /// and reads it back column by column. The length must divide evenly by width.
        /// </summary>
        private static string ReadByColumns(string input, int width)
        {
            int rows = input.Length / width;
            char[] result = new char[input.Length];

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < width; c++)
                    result[c * rows + r] = input[r * width + c];

            return new string(result);
        }

        /// <summary>
        /// Writes the text column by column into a grid that is 'width' columns wide
        /// and reads it back row by row. This is the exact reverse of ReadByColumns.
        /// </summary>
        private static string FillColumns(string input, int width)
        {
            int rows = input.Length / width;
            char[] result = new char[input.Length];

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < width; c++)
                    result[r * width + c] = input[c * rows + r];

            return new string(result);
        }

        private static int CeilDiv(int a, int b)
        {
            return (a + b - 1) / b;
        }
    }
}