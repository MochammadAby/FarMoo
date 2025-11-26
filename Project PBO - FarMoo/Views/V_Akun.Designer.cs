namespace Project_PBO___FarMoo.Views
{
    partial class V_Akun
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
            tbNamaLengkap = new TextBox();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            tbEmail = new TextBox();
            tbNoTelp = new TextBox();
            btnubahprofil = new Button();
            SuspendLayout();
            // 
            // tbNamaLengkap
            // 
            tbNamaLengkap.BackColor = Color.White;
            tbNamaLengkap.Location = new Point(1203, 197);
            tbNamaLengkap.Name = "tbNamaLengkap";
            tbNamaLengkap.Size = new Size(400, 31);
            tbNamaLengkap.TabIndex = 0;
            // 
            // tbUsername
            // 
            tbUsername.BackColor = Color.White;
            tbUsername.Location = new Point(1203, 293);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(400, 31);
            tbUsername.TabIndex = 1;
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.White;
            tbPassword.Location = new Point(1203, 402);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(400, 31);
            tbPassword.TabIndex = 2;
            // 
            // tbEmail
            // 
            tbEmail.BackColor = Color.White;
            tbEmail.Location = new Point(1203, 501);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(400, 31);
            tbEmail.TabIndex = 3;
            // 
            // tbNoTelp
            // 
            tbNoTelp.BackColor = Color.White;
            tbNoTelp.Location = new Point(1203, 613);
            tbNoTelp.Name = "tbNoTelp";
            tbNoTelp.Size = new Size(400, 31);
            tbNoTelp.TabIndex = 4;
            // 
            // btnubahprofil
            // 
            btnubahprofil.BackColor = Color.LightSkyBlue;
            btnubahprofil.Font = new Font("Arial Narrow", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnubahprofil.ForeColor = Color.White;
            btnubahprofil.Location = new Point(978, 720);
            btnubahprofil.Name = "btnubahprofil";
            btnubahprofil.Size = new Size(260, 46);
            btnubahprofil.TabIndex = 5;
            btnubahprofil.Text = "Edit Profil";
            btnubahprofil.UseVisualStyleBackColor = false;
            btnubahprofil.Click += btnubahprofil_Click;
            // 
            // V_Akun
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.Profil__5_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnubahprofil);
            Controls.Add(tbNoTelp);
            Controls.Add(tbEmail);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(tbNamaLengkap);
            DoubleBuffered = true;
            Name = "V_Akun";
            Text = "V_Akun";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNamaLengkap;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private TextBox tbEmail;
        private TextBox tbNoTelp;
        private Button btnubahprofil;
    }
}