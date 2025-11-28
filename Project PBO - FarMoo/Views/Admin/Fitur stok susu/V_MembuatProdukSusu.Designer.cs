namespace Project_PBO___FarMoo.Views.Admin.Fitur_stok_susu
{
    partial class V_MembuatProdukSusu
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
            btnLaporanAdmin = new Button();
            btnPermintaanAdmin = new Button();
            btnStokAdmin = new Button();
            btnAkun = new Button();
            btnHalAdmin = new Button();
            btnTambahProduk = new Button();
            flpProduk = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnLaporanAdmin
            // 
            btnLaporanAdmin.Location = new Point(22, 459);
            btnLaporanAdmin.Name = "btnLaporanAdmin";
            btnLaporanAdmin.Size = new Size(298, 55);
            btnLaporanAdmin.TabIndex = 9;
            btnLaporanAdmin.Text = "   Laporan Penjualan";
            btnLaporanAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporanAdmin.UseVisualStyleBackColor = true;
            // 
            // btnPermintaanAdmin
            // 
            btnPermintaanAdmin.Location = new Point(22, 388);
            btnPermintaanAdmin.Name = "btnPermintaanAdmin";
            btnPermintaanAdmin.Size = new Size(298, 55);
            btnPermintaanAdmin.TabIndex = 8;
            btnPermintaanAdmin.Text = "   Permintaan Susu";
            btnPermintaanAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnPermintaanAdmin.UseVisualStyleBackColor = true;
            // 
            // btnStokAdmin
            // 
            btnStokAdmin.Location = new Point(22, 317);
            btnStokAdmin.Name = "btnStokAdmin";
            btnStokAdmin.Size = new Size(298, 55);
            btnStokAdmin.TabIndex = 7;
            btnStokAdmin.Text = " Produk";
            btnStokAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnStokAdmin.UseVisualStyleBackColor = true;
            btnStokAdmin.Click += btnStokAdmin_Click;
            // 
            // btnAkun
            // 
            btnAkun.Location = new Point(22, 246);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(298, 55);
            btnAkun.TabIndex = 6;
            btnAkun.Text = "   Akun";
            btnAkun.TextAlign = ContentAlignment.MiddleLeft;
            btnAkun.UseVisualStyleBackColor = true;
            btnAkun.Click += btnAkun_Click;
            // 
            // btnHalAdmin
            // 
            btnHalAdmin.Location = new Point(22, 172);
            btnHalAdmin.Name = "btnHalAdmin";
            btnHalAdmin.Size = new Size(298, 55);
            btnHalAdmin.TabIndex = 10;
            btnHalAdmin.Text = "   Halaman Beranda";
            btnHalAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnHalAdmin.UseVisualStyleBackColor = true;
            btnHalAdmin.Click += btnHalAdmin_Click;
            // 
            // btnTambahProduk
            // 
            btnTambahProduk.Location = new Point(1641, 73);
            btnTambahProduk.Name = "btnTambahProduk";
            btnTambahProduk.Size = new Size(240, 56);
            btnTambahProduk.TabIndex = 11;
            btnTambahProduk.Text = "Tambah";
            btnTambahProduk.UseVisualStyleBackColor = true;
            btnTambahProduk.Click += btnTambahProduk_Click;
            // 
            // flpProduk
            // 
            flpProduk.AutoScroll = true;
            flpProduk.Location = new Point(355, 159);
            flpProduk.Name = "flpProduk";
            flpProduk.Size = new Size(1531, 832);
            flpProduk.TabIndex = 12;
            // 
            // V_MembuatProdukSusu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Template_Membuat_Produk_Admin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(flpProduk);
            Controls.Add(btnTambahProduk);
            Controls.Add(btnHalAdmin);
            Controls.Add(btnLaporanAdmin);
            Controls.Add(btnPermintaanAdmin);
            Controls.Add(btnStokAdmin);
            Controls.Add(btnAkun);
            DoubleBuffered = true;
            Name = "V_MembuatProdukSusu";
            Text = "V_MembuatProdukSusu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnLaporanAdmin;
        private Button btnPermintaanAdmin;
        private Button btnStokAdmin;
        private Button btnAkun;
        private Button btnHalAdmin;
        private Button btnTambahProduk;
        private FlowLayoutPanel flpProduk;
    }
}