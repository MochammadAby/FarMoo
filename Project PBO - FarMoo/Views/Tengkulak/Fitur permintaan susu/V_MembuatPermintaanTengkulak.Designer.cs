namespace Project_PBO___FarMoo.Views.Tengkulak.Fitur_permintaan_susu
{
    partial class V_MembuatPermintaanTengkulak
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
            btnHalTengkulak = new Button();
            btnRiwayat = new Button();
            btnPermintaan = new Button();
            btnAkun = new Button();
            flpProduk = new FlowLayoutPanel();
            btnCheckout = new Button();
            SuspendLayout();
            // 
            // btnHalTengkulak
            // 
            btnHalTengkulak.BackColor = SystemColors.ButtonHighlight;
            btnHalTengkulak.BackgroundImageLayout = ImageLayout.Center;
            btnHalTengkulak.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHalTengkulak.Location = new Point(12, 176);
            btnHalTengkulak.Name = "btnHalTengkulak";
            btnHalTengkulak.Size = new Size(310, 54);
            btnHalTengkulak.TabIndex = 10;
            btnHalTengkulak.Text = "   Halaman Beranda";
            btnHalTengkulak.TextAlign = ContentAlignment.MiddleLeft;
            btnHalTengkulak.UseVisualStyleBackColor = false;
            btnHalTengkulak.Click += btnHalTengkulak_Click;
            // 
            // btnRiwayat
            // 
            btnRiwayat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(12, 390);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(310, 54);
            btnRiwayat.TabIndex = 9;
            btnRiwayat.Text = "   Riwayat pemesanan";
            btnRiwayat.TextAlign = ContentAlignment.MiddleLeft;
            btnRiwayat.UseVisualStyleBackColor = true;
            btnRiwayat.Click += btnRiwayat_Click;
            // 
            // btnPermintaan
            // 
            btnPermintaan.BackColor = Color.CornflowerBlue;
            btnPermintaan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPermintaan.Location = new Point(12, 319);
            btnPermintaan.Name = "btnPermintaan";
            btnPermintaan.Size = new Size(310, 54);
            btnPermintaan.TabIndex = 8;
            btnPermintaan.Text = "   Permintaan susu";
            btnPermintaan.TextAlign = ContentAlignment.MiddleLeft;
            btnPermintaan.UseVisualStyleBackColor = false;
            // 
            // btnAkun
            // 
            btnAkun.Cursor = Cursors.Hand;
            btnAkun.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAkun.Location = new Point(12, 247);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(310, 54);
            btnAkun.TabIndex = 7;
            btnAkun.Text = "   Akun";
            btnAkun.TextAlign = ContentAlignment.MiddleLeft;
            btnAkun.UseVisualStyleBackColor = true;
            btnAkun.Click += btnAkun_Click;
            // 
            // flpProduk
            // 
            flpProduk.AutoScroll = true;
            flpProduk.Location = new Point(353, 153);
            flpProduk.Name = "flpProduk";
            flpProduk.Size = new Size(1533, 704);
            flpProduk.TabIndex = 11;
            flpProduk.Paint += flpProduk_Paint;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(958, 903);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(358, 75);
            btnCheckout.TabIndex = 12;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            // 
            // V_MembuatPermintaanTengkulak
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Template_Membuat_Produk_Admin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnCheckout);
            Controls.Add(flpProduk);
            Controls.Add(btnHalTengkulak);
            Controls.Add(btnRiwayat);
            Controls.Add(btnPermintaan);
            Controls.Add(btnAkun);
            DoubleBuffered = true;
            Name = "V_MembuatPermintaanTengkulak";
            Text = "V_MembuatPermintaanTengkulak";
            ResumeLayout(false);
        }

        #endregion

        private Button btnHalTengkulak;
        private Button btnRiwayat;
        private Button btnPermintaan;
        private Button btnAkun;
        private FlowLayoutPanel flpProduk;
        private Button btnCheckout;
    }
}