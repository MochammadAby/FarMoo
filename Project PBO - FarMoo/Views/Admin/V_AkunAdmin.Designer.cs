namespace Project_PBO___FarMoo.Views.Admin
{
    partial class V_AkunAdmin
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
            btnLaporanPenjualan = new Button();
            btnPermintaanSusu = new Button();
            btnStokSusu = new Button();
            btnAkunAdmin = new Button();
            btnBerandaAdmin = new Button();
            tbNamaLengkap = new TextBox();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            tbEmail = new TextBox();
            tbNoTelp = new TextBox();
            btnUbahProfilAdmin = new Button();
            btnUbahFoto = new Button();
            pbFotoPeternak = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbFotoPeternak).BeginInit();
            SuspendLayout();
            // 
            // btnLaporanPenjualan
            // 
            btnLaporanPenjualan.Location = new Point(22, 459);
            btnLaporanPenjualan.Name = "btnLaporanPenjualan";
            btnLaporanPenjualan.Size = new Size(298, 55);
            btnLaporanPenjualan.TabIndex = 9;
            btnLaporanPenjualan.Text = "   Laporan Penjualan";
            btnLaporanPenjualan.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporanPenjualan.UseVisualStyleBackColor = true;
            // 
            // btnPermintaanSusu
            // 
            btnPermintaanSusu.Location = new Point(22, 388);
            btnPermintaanSusu.Name = "btnPermintaanSusu";
            btnPermintaanSusu.Size = new Size(298, 55);
            btnPermintaanSusu.TabIndex = 8;
            btnPermintaanSusu.Text = "   Permintaan Susu";
            btnPermintaanSusu.TextAlign = ContentAlignment.MiddleLeft;
            btnPermintaanSusu.UseVisualStyleBackColor = true;
            // 
            // btnStokSusu
            // 
            btnStokSusu.Location = new Point(22, 317);
            btnStokSusu.Name = "btnStokSusu";
            btnStokSusu.Size = new Size(298, 55);
            btnStokSusu.TabIndex = 7;
            btnStokSusu.Text = "   Produk";
            btnStokSusu.TextAlign = ContentAlignment.MiddleLeft;
            btnStokSusu.UseVisualStyleBackColor = true;
            btnStokSusu.Click += btnStokSusu_Click;
            // 
            // btnAkunAdmin
            // 
            btnAkunAdmin.BackColor = Color.CornflowerBlue;
            btnAkunAdmin.Location = new Point(22, 246);
            btnAkunAdmin.Name = "btnAkunAdmin";
            btnAkunAdmin.Size = new Size(298, 55);
            btnAkunAdmin.TabIndex = 6;
            btnAkunAdmin.Text = "   Akun";
            btnAkunAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnAkunAdmin.UseVisualStyleBackColor = false;
            // 
            // btnBerandaAdmin
            // 
            btnBerandaAdmin.Location = new Point(22, 175);
            btnBerandaAdmin.Name = "btnBerandaAdmin";
            btnBerandaAdmin.Size = new Size(298, 55);
            btnBerandaAdmin.TabIndex = 5;
            btnBerandaAdmin.Text = "   Halaman Beranda";
            btnBerandaAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnBerandaAdmin.UseVisualStyleBackColor = true;
            btnBerandaAdmin.Click += btnBerandaAdmin_Click;
            // 
            // tbNamaLengkap
            // 
            tbNamaLengkap.Location = new Point(1227, 226);
            tbNamaLengkap.Name = "tbNamaLengkap";
            tbNamaLengkap.Size = new Size(400, 31);
            tbNamaLengkap.TabIndex = 10;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(1227, 320);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(400, 31);
            tbUsername.TabIndex = 11;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(1227, 432);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(400, 31);
            tbPassword.TabIndex = 12;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(1227, 531);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(400, 31);
            tbEmail.TabIndex = 13;
            // 
            // tbNoTelp
            // 
            tbNoTelp.Location = new Point(1227, 649);
            tbNoTelp.Name = "tbNoTelp";
            tbNoTelp.Size = new Size(400, 31);
            tbNoTelp.TabIndex = 14;
            // 
            // btnUbahProfilAdmin
            // 
            btnUbahProfilAdmin.Location = new Point(977, 751);
            btnUbahProfilAdmin.Name = "btnUbahProfilAdmin";
            btnUbahProfilAdmin.Size = new Size(258, 46);
            btnUbahProfilAdmin.TabIndex = 15;
            btnUbahProfilAdmin.Text = "Ubah Profil";
            btnUbahProfilAdmin.UseVisualStyleBackColor = true;
            btnUbahProfilAdmin.Click += btnUbahProfilAdmin_Click;
            // 
            // btnUbahFoto
            // 
            btnUbahFoto.Location = new Point(596, 695);
            btnUbahFoto.Name = "btnUbahFoto";
            btnUbahFoto.Size = new Size(112, 34);
            btnUbahFoto.TabIndex = 17;
            btnUbahFoto.Text = "Ubah Foto";
            btnUbahFoto.UseVisualStyleBackColor = true;
            btnUbahFoto.Click += btnUbahFoto_Click;
            // 
            // pbFotoPeternak
            // 
            pbFotoPeternak.BackColor = Color.White;
            pbFotoPeternak.BackgroundImageLayout = ImageLayout.Stretch;
            pbFotoPeternak.Location = new Point(486, 323);
            pbFotoPeternak.Name = "pbFotoPeternak";
            pbFotoPeternak.Size = new Size(349, 336);
            pbFotoPeternak.SizeMode = PictureBoxSizeMode.Zoom;
            pbFotoPeternak.TabIndex = 16;
            pbFotoPeternak.TabStop = false;
            // 
            // V_AkunAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Profil_Peternak;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnUbahFoto);
            Controls.Add(pbFotoPeternak);
            Controls.Add(btnUbahProfilAdmin);
            Controls.Add(tbNoTelp);
            Controls.Add(tbEmail);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(tbNamaLengkap);
            Controls.Add(btnLaporanPenjualan);
            Controls.Add(btnPermintaanSusu);
            Controls.Add(btnStokSusu);
            Controls.Add(btnAkunAdmin);
            Controls.Add(btnBerandaAdmin);
            DoubleBuffered = true;
            Name = "V_AkunAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_AkunAdmin";
            ((System.ComponentModel.ISupportInitialize)pbFotoPeternak).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLaporanPenjualan;
        private Button btnPermintaanSusu;
        private Button btnStokSusu;
        private Button btnAkunAdmin;
        private Button btnBerandaAdmin;
        private TextBox tbNamaLengkap;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private TextBox tbEmail;
        private TextBox tbNoTelp;
        private Button btnUbahProfilAdmin;
        private Button btnUbahFoto;
        private PictureBox pbFotoPeternak;
    }
}