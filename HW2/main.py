import tkinter as tk
from tkinter import messagebox


def Encryption1(message, key):
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


def Decryption1(message, key):
    try:
        shift = int(key)
    except ValueError:
        messagebox.showerror("Invalid key", "The key must be a whole number.")
        return

    Encryption1(message, -shift)


def open_new_window_encrypt_1():
    new_window = tk.Toplevel(root)
    new_window.title("Encrypt 1")
    new_window.geometry("300x200")

    title = tk.Label(new_window, text="Welcome to ...")
    entry_label = tk.Label(new_window, text="Enter message regularly")
    entry = tk.Entry(new_window)
    entry_shift = tk.Label(new_window, text="Enter key")
    entry1 = tk.Entry(new_window)

    submit_btn = tk.Button(
        new_window,
        text="Submit",
        command=lambda: Encryption1(entry.get(),entry1.get()),
    )

    title.grid(row=0, column=0, columnspan=2, pady=20)
    entry_label.grid(row=1, column=0, padx=5, pady=10)
    entry.grid(row=1, column=1, padx=5, pady=10)
    entry_shift.grid(row=2, column=0, padx=5, pady=10)
    entry1.grid(row=2, column=1, padx=5, pady=10)
    submit_btn.grid(row=3, column=0, columnspan=2, pady=20)

def open_new_window_encrypt_2():
    new_window = tk.Toplevel(root)
    new_window.title("Encryption 2")
    new_window.geometry("300x200")

    label = tk.Label(new_window, text="Welcome to Encryption 2")
    label.pack(pady=20)


def open_new_window_decrypt_2():
    new_window = tk.Toplevel(root)
    new_window.title("Decryption 2")
    new_window.geometry("300x200")

    label = tk.Label(new_window, text="Welcome to Decryption 2")
    label.pack(pady=20)


def open_new_window_decrypt_1():
    new_window = tk.Toplevel(root)
    new_window.title("Decrypt")
    new_window.geometry("300x200")

    title = tk.Label(new_window, text="Decrypt a message")
    entry_label = tk.Label(new_window, text="Enter encrypted message")
    entry = tk.Entry(new_window)
    entry_shift = tk.Label(new_window, text="Enter key")
    entry1 = tk.Entry(new_window)
    submit_btn = tk.Button(
        new_window,
        text="Submit",
        command=lambda: Decryption1(entry.get(), entry1.get()),
    )

    title.grid(row=0, column=0, columnspan=2, pady=20)
    entry_label.grid(row=1, column=0, padx=5, pady=10)
    entry.grid(row=1, column=1, padx=5, pady=10)
    entry_shift.grid(row=2, column=0, padx=5, pady=10)
    entry1.grid(row=2, column=1, padx=5, pady=10)
    submit_btn.grid(row=3, column=0, columnspan=2, pady=20)


root = tk.Tk()
root.title("Main Window")
root.geometry("400x300")

labelmain = tk.Label(root,text="Choose the correct encryption ")
labelmain.pack()
button_row_1 = tk.Frame(root)
button_row_1.pack(pady=20)
btn_encryption_1 = tk.Button(
    button_row_1, text="Encryption 1", command=open_new_window_encrypt_1
)
btn_decryption_1 = tk.Button(
    button_row_1, text="Decryption 1", command=open_new_window_decrypt_1
)
btn_encryption_1.pack(side=tk.LEFT, padx=5)
btn_decryption_1.pack(side=tk.LEFT, padx=5)

button_row_2 = tk.Frame(root)
button_row_2.pack()
btn_encryption_2 = tk.Button(
    button_row_2, text="Encryption 2", command=open_new_window_encrypt_2
)
btn_decryption_2 = tk.Button(
    button_row_2, text="Decryption 2", command=open_new_window_decrypt_2
)
btn_encryption_2.pack(side=tk.LEFT, padx=5)
btn_decryption_2.pack(side=tk.LEFT, padx=5)
root.mainloop()
