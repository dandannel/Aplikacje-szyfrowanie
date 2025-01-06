namespace Szyfr_Cezara
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtInput = new TextBox();
            txtOutput = new TextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            numKey = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numKey).BeginInit();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.BackColor = Color.LightBlue;
            txtInput.Font = new Font("Calibri", 12F);
            txtInput.ForeColor = Color.Black;
            txtInput.Location = new Point(46, 109);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(479, 27);
            txtInput.TabIndex = 0;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = Color.LightBlue;
            txtOutput.Font = new Font("Calibri", 12F);
            txtOutput.ForeColor = Color.Black;
            txtOutput.Location = new Point(46, 276);
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(479, 27);
            txtOutput.TabIndex = 1;
            // 
            // btnEncrypt
            // 
            btnEncrypt.BackColor = Color.LightBlue;
            btnEncrypt.FlatAppearance.BorderSize = 0;
            btnEncrypt.FlatStyle = FlatStyle.Flat;
            btnEncrypt.Font = new Font("Calibri", 10F, FontStyle.Bold);
            btnEncrypt.ForeColor = Color.Black;
            btnEncrypt.Location = new Point(46, 164);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(100, 30);
            btnEncrypt.TabIndex = 2;
            btnEncrypt.Text = "SZYFRUJ";
            btnEncrypt.UseVisualStyleBackColor = false;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.BackColor = Color.LightBlue;
            btnDecrypt.FlatAppearance.BorderSize = 0;
            btnDecrypt.FlatStyle = FlatStyle.Flat;
            btnDecrypt.Font = new Font("Calibri", 10F, FontStyle.Bold);
            btnDecrypt.ForeColor = Color.Black;
            btnDecrypt.Location = new Point(171, 164);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(100, 30);
            btnDecrypt.TabIndex = 3;
            btnDecrypt.Text = "ODSZYFRUJ";
            btnDecrypt.UseVisualStyleBackColor = false;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // numKey
            // 
            numKey.BackColor = Color.LightBlue;
            numKey.Font = new Font("Calibri", 12F);
            numKey.ForeColor = Color.Black;
            numKey.Location = new Point(471, 67);
            numKey.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numKey.Name = "numKey";
            numKey.Size = new Size(54, 27);
            numKey.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 10F, FontStyle.Bold);
            label1.Location = new Point(46, 72);
            label1.Name = "label1";
            label1.Size = new Size(266, 17);
            label1.TabIndex = 5;
            label1.Text = "Szyfrowanie (tekst jawny lub zaszyfrowany)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 10F, FontStyle.Bold);
            label2.Location = new Point(46, 241);
            label2.Name = "label2";
            label2.Size = new Size(46, 17);
            label2.TabIndex = 6;
            label2.Text = "Wynik";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 10F, FontStyle.Bold);
            label3.Location = new Point(426, 72);
            label3.Name = "label3";
            label3.Size = new Size(39, 17);
            label3.TabIndex = 7;
            label3.Text = "Klucz";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(46, 36);
            label4.Name = "label4";
            label4.Size = new Size(116, 21);
            label4.TabIndex = 8;
            label4.Text = "SZYFR CEZARA";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(584, 361);
            Controls.Add(label4);
            Controls.Add(txtInput);
            Controls.Add(txtOutput);
            Controls.Add(btnEncrypt);
            Controls.Add(btnDecrypt);
            Controls.Add(numKey);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            ForeColor = Color.LightBlue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Szyfr Cezara";
            ((System.ComponentModel.ISupportInitialize)numKey).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox txtInput;
        private TextBox txtOutput;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private NumericUpDown numKey;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
