import tkinter as tk
from tkinter import messagebox
def Cesar_Cypher_Encryption(message, key):
    try:
        shift = int(key)
    except ValueError:
        messagebox.showerror("Invalid key", "The key must be a whole number.")
        return

    encrypted_message = ""
    for character in message:
        if character.isalpha() and character.isascii():
            first_letter = ord("A") if character.isupper() else ord("a")
            encrypted_character = chr(
                (ord(character) - first_letter + shift) % 26 + first_letter
            )
            encrypted_message += encrypted_character
        else:
            encrypted_message += character

    messagebox.showinfo("Encrypted message", encrypted_message)


def Cesar_Cypher_Decryption(message, key):
    try:
        shift = int(key)
    except ValueError:
        messagebox.showerror("Invalid key", "The key must be a whole number.")
        return

    Cesar_Cypher_Encryption(message, -shift)


def Vigenere_Cypher_Encryption(message, key):
    # Validate that the key only contains letters and is not empty
    if not key.isalpha():
        messagebox.showerror(
            "Invalid key", "The Vigenère key must contain letters only."
        )
        return

    key = key.upper()
    encrypted_message = ""
    key_index = 0

    for character in message:
        if character.isalpha() and character.isascii():
            first_letter = ord("A") if character.isupper() else ord("a")
            shift = ord(key[key_index % len(key)]) - ord("A")

            encrypted_character = chr(
                (ord(character) - first_letter + shift) % 26 + first_letter
            )
            encrypted_message += encrypted_character
            key_index += 1
        else:
            encrypted_message += character

    messagebox.showinfo("Encrypted message", encrypted_message)


def Vigenere_Cypher_Decryption(message, key):
    if not key.isalpha():
        messagebox.showerror(
            "Invalid key", "The Vigenère key must contain letters only."
        )
        return

    key = key.upper()
    decrypted_message = ""
    key_index = 0

    for character in message:
        if character.isalpha() and character.isascii():
            first_letter = ord("A") if character.isupper() else ord("a")
            shift = ord(key[key_index % len(key)]) - ord("A")

            decrypted_character = chr(
                (ord(character) - first_letter - shift + 26) % 26 + first_letter
            )
            decrypted_message += decrypted_character
            key_index += 1
        else:
            decrypted_message += character

    messagebox.showinfo("Decrypted message", decrypted_message)

def open_new_window_encrypt_1():
    new_window = tk.Toplevel(root)
    new_window.title("Cesar Cypher Encryption")
    new_window.geometry("300x200")

    title = tk.Label(new_window, text="Welcome to Caesar Encryption")
    entry_label = tk.Label(new_window, text="Enter message regularly")
    entry = tk.Entry(new_window)
    entry_shift = tk.Label(new_window, text="Enter key")
    entry1 = tk.Entry(new_window)

    submit_btn = tk.Button(
        new_window,
        text="Submit",
        command=lambda: Cesar_Cypher_Encryption(entry.get(), entry1.get()),
    )

    title.grid(row=0, column=0, columnspan=2, pady=20)
    entry_label.grid(row=1, column=0, padx=5, pady=10)
    entry.grid(row=1, column=1, padx=5, pady=10)
    entry_shift.grid(row=2, column=0, padx=5, pady=10)
    entry1.grid(row=2, column=1, padx=5, pady=10)
    submit_btn.grid(row=3, column=0, columnspan=2, pady=20)


def open_new_window_decrypt_1():
    new_window = tk.Toplevel(root)
    new_window.title("Decrypt")
    new_window.geometry("300x200")

    title = tk.Label(new_window, text="Cesar Cypher Decryption")
    entry_label = tk.Label(new_window, text="Enter encrypted message")
    entry = tk.Entry(new_window)
    entry_shift = tk.Label(new_window, text="Enter key")
    entry1 = tk.Entry(new_window)
    submit_btn = tk.Button(
        new_window,
        text="Submit",
        command=lambda: Cesar_Cypher_Decryption(entry.get(), entry1.get()),
    )

    title.grid(row=0, column=0, columnspan=2, pady=20)
    entry_label.grid(row=1, column=0, padx=5, pady=10)
    entry.grid(row=1, column=1, padx=5, pady=10)
    entry_shift.grid(row=2, column=0, padx=5, pady=10)
    entry1.grid(row=2, column=1, padx=5, pady=10)
    submit_btn.grid(row=3, column=0, columnspan=2, pady=20)


def open_new_window_encrypt_2():
    new_window = tk.Toplevel(root)
    new_window.title("Vigenère Encryption")
    new_window.geometry("300x200")

    title = tk.Label(new_window, text="Vigenère Cipher Encryption")
    entry_label = tk.Label(new_window, text="Enter message regularly")
    entry = tk.Entry(new_window)
    entry_key_lbl = tk.Label(new_window, text="Enter text key")
    entry1 = tk.Entry(new_window)

    submit_btn = tk.Button(
        new_window,
        text="Submit",
        command=lambda: Vigenere_Cypher_Encryption(entry.get(), entry1.get()),
    )

    title.grid(row=0, column=0, columnspan=2, pady=20)
    entry_label.grid(row=1, column=0, padx=5, pady=10)
    entry.grid(row=1, column=1, padx=5, pady=10)
    entry_key_lbl.grid(row=2, column=0, padx=5, pady=10)
    entry1.grid(row=2, column=1, padx=5, pady=10)
    submit_btn.grid(row=3, column=0, columnspan=2, pady=20)


def open_new_window_decrypt_2():
    new_window = tk.Toplevel(root)
    new_window.title("Vigenère Decryption")
    new_window.geometry("300x200")

    title = tk.Label(new_window, text="Vigenère Cipher Decryption")
    entry_label = tk.Label(new_window, text="Enter encrypted message")
    entry = tk.Entry(new_window)
    entry_key_lbl = tk.Label(new_window, text="Enter text key")
    entry1 = tk.Entry(new_window)

    submit_btn = tk.Button(
        new_window,
        text="Submit",
        command=lambda: Vigenere_Cypher_Decryption(entry.get(), entry1.get()),
    )

    title.grid(row=0, column=0, columnspan=2, pady=20)
    entry_label.grid(row=1, column=0, padx=5, pady=10)
    entry.grid(row=1, column=1, padx=5, pady=10)
    entry_key_lbl.grid(row=2, column=0, padx=5, pady=10)
    entry1.grid(row=2, column=1, padx=5, pady=10)
    submit_btn.grid(row=3, column=0, columnspan=2, pady=20)


root = tk.Tk()
root.title("Main Window")
root.geometry("400x300")

labelmain = tk.Label(root, text="Choose the correct encryption ")
labelmain.pack()

button_row_1 = tk.Frame(root)
button_row_1.pack(pady=20)
btn_encryption_1 = tk.Button(
    button_row_1, text="Cesar Cypher Encryption", command=open_new_window_encrypt_1
)
btn_decryption_1 = tk.Button(
    button_row_1, text="Cesar Cypher Decryption", command=open_new_window_decrypt_1
)
btn_encryption_1.pack(side=tk.LEFT, padx=5)
btn_decryption_1.pack(side=tk.LEFT, padx=5)

button_row_2 = tk.Frame(root)
button_row_2.pack()
btn_encryption_2 = tk.Button(
    button_row_2, text="Vigenère Encryption", command=open_new_window_encrypt_2
)
btn_decryption_2 = tk.Button(
    button_row_2, text="Vigenère Decryption", command=open_new_window_decrypt_2
)
btn_encryption_2.pack(side=tk.LEFT, padx=5)
btn_decryption_2.pack(side=tk.LEFT, padx=5)

root.mainloop()
