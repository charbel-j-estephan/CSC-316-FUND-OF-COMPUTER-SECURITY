namespace VigenereCipher
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.lblColKey = new System.Windows.Forms.Label();
            this.txtColKey = new System.Windows.Forms.TextBox();
            this.lblRowKey = new System.Windows.Forms.Label();
            this.txtRowKey = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblSteps = new System.Windows.Forms.Label();
            this.txtSteps = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(20, 20);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(64, 15);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Input Text:";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(20, 40);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(440, 80);
            this.txtInput.TabIndex = 1;
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Location = new System.Drawing.Point(20, 135);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(200, 15);
            this.lblKeyword.TabIndex = 2;
            this.lblKeyword.Text = "Keyword (letters only, e.g., LEMON):";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(20, 155);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(440, 23);
            this.txtKeyword.TabIndex = 3;
            // 
            // lblColKey
            // 
            this.lblColKey.AutoSize = true;
            this.lblColKey.Location = new System.Drawing.Point(20, 190);
            this.lblColKey.Name = "lblColKey";
            this.lblColKey.Size = new System.Drawing.Size(300, 15);
            this.lblColKey.TabIndex = 4;
            this.lblColKey.Text = "Column Key (distinct integers, e.g., 5, 3, 4):";
            // 
            // txtColKey
            // 
            this.txtColKey.Location = new System.Drawing.Point(20, 210);
            this.txtColKey.Name = "txtColKey";
            this.txtColKey.Size = new System.Drawing.Size(440, 23);
            this.txtColKey.TabIndex = 5;
            // 
            // lblRowKey
            // 
            this.lblRowKey.AutoSize = true;
            this.lblRowKey.Location = new System.Drawing.Point(20, 245);
            this.lblRowKey.Name = "lblRowKey";
            this.lblRowKey.Size = new System.Drawing.Size(300, 15);
            this.lblRowKey.TabIndex = 6;
            this.lblRowKey.Text = "Row Key (distinct integers, e.g., 3, 1, 2):";
            // 
            // txtRowKey
            // 
            this.txtRowKey.Location = new System.Drawing.Point(20, 265);
            this.txtRowKey.Name = "txtRowKey";
            this.txtRowKey.Size = new System.Drawing.Size(440, 23);
            this.txtRowKey.TabIndex = 7;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(20, 305);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(210, 35);
            this.btnEncrypt.TabIndex = 8;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(250, 305);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(210, 35);
            this.btnDecrypt.TabIndex = 9;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(20, 355);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(81, 15);
            this.lblOutput.TabIndex = 10;
            this.lblOutput.Text = "Output Result:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(20, 375);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(440, 80);
            this.txtOutput.TabIndex = 11;
            // 
            // lblSteps
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Location = new System.Drawing.Point(20, 470);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new System.Drawing.Size(110, 15);
            this.lblSteps.TabIndex = 12;
            this.lblSteps.Text = "Intermediate Rounds:";
            // 
            // txtSteps
            // 
            this.txtSteps.Location = new System.Drawing.Point(20, 490);
            this.txtSteps.Multiline = true;
            this.txtSteps.Name = "txtSteps";
            this.txtSteps.ReadOnly = true;
            this.txtSteps.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSteps.Size = new System.Drawing.Size(440, 140);
            this.txtSteps.TabIndex = 13;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(480, 650);
            this.Controls.Add(this.txtSteps);
            this.Controls.Add(this.lblSteps);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtRowKey);
            this.Controls.Add(this.lblRowKey);
            this.Controls.Add(this.txtColKey);
            this.Controls.Add(this.lblColKey);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.lblKeyword);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi-Round Permutation Vigenere";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label lblColKey;
        private System.Windows.Forms.TextBox txtColKey;
        private System.Windows.Forms.Label lblRowKey;
        private System.Windows.Forms.TextBox txtRowKey;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblSteps;
        private System.Windows.Forms.TextBox txtSteps;
    }
}