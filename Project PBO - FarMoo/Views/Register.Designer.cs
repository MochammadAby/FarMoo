namespace Project_PBO___FarMoo.Views
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbNama = new TextBox();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            tbEmail = new TextBox();
            tbNomor = new TextBox();
            btnRegister = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // tbNama
            // 
            tbNama.Location = new Point(1320, 349);
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(350, 31);
            tbNama.TabIndex = 0;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(1320, 441);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(350, 31);
            tbUsername.TabIndex = 1;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(1320, 538);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(350, 31);
            tbPassword.TabIndex = 2;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(1320, 631);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(350, 31);
            tbEmail.TabIndex = 3;
            // 
            // tbNomor
            // 
            tbNomor.Location = new Point(1320, 733);
            tbNomor.Name = "tbNomor";
            tbNomor.Size = new Size(350, 31);
            tbNomor.TabIndex = 4;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(1423, 860);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(147, 47);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(1320, 321);
            label1.Name = "label1";
            label1.Size = new Size(131, 25);
            label1.TabIndex = 6;
            label1.Text = "Nama Lengkap";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(1320, 413);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 7;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(1320, 510);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 8;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(1320, 603);
            label4.Name = "label4";
            label4.Size = new Size(54, 25);
            label4.TabIndex = 9;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(1320, 705);
            label5.Name = "label5";
            label5.Size = new Size(98, 25);
            label5.TabIndex = 10;
            label5.Text = "Nomor Hp";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = Properties.Resources.Register__2_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            Controls.Add(tbNomor);
            Controls.Add(tbEmail);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(tbNama);
            DoubleBuffered = true;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNama;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private TextBox tbEmail;
        private TextBox tbNomor;
        private Button btnRegister;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}