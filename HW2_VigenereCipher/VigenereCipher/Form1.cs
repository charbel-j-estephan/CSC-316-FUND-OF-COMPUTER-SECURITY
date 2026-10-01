using System;
using System.Linq;
using System.Windows.Forms;

namespace VigenereCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Execute(true);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            Execute(false);
        }

        private void Execute(bool encrypt)
        {
            try
            {
                var steps = VigenereService.Run(txtInput.Text, txtKeyword.Text, txtColKey.Text, txtRowKey.Text, encrypt);

                // Final result only, so it can be copied straight back into the input box
                txtOutput.Text = steps.Last().Text;

                // Every round, one after the other
                txtSteps.Text = string.Join(
                    Environment.NewLine + Environment.NewLine,
                    steps.Select(s => s.Label + Environment.NewLine + s.Text));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}