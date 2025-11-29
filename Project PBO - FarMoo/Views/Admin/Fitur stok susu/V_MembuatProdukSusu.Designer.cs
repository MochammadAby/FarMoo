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
            btnLaporanAdmin.Location = new Point(15, 275);
            btnLaporanAdmin.Margin = new Padding(2);
            btnLaporanAdmin.Name = "btnLaporanAdmin";
            btnLaporanAdmin.Size = new Size(209, 33);
            btnLaporanAdmin.TabIndex = 9;
            btnLaporanAdmin.Text = "   Laporan Penjualan";
            btnLaporanAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporanAdmin.UseVisualStyleBackColor = true;
            // 
            // btnPermintaanAdmin
            // 
            btnPermintaanAdmin.Location = new Point(15, 233);
            btnPermintaanAdmin.Margin = new Padding(2);
            btnPermintaanAdmin.Name = "btnPermintaanAdmin";
            btnPermintaanAdmin.Size = new Size(209, 33);
            btnPermintaanAdmin.TabIndex = 8;
            btnPermintaanAdmin.Text = "   Permintaan Susu";
            btnPermintaanAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnPermintaanAdmin.UseVisualStyleBackColor = true;
            // 
            // btnStokAdmin
            // 
            btnStokAdmin.BackColor = Color.CornflowerBlue;
            btnStokAdmin.Location = new Point(15, 190);
            btnStokAdmin.Margin = new Padding(2);
            btnStokAdmin.Name = "btnStokAdmin";
            btnStokAdmin.Size = new Size(209, 33);
            btnStokAdmin.TabIndex = 7;
            btnStokAdmin.Text = "   Produk";
            btnStokAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnStokAdmin.UseVisualStyleBackColor = false;
            btnStokAdmin.Click += btnStokAdmin_Click;
            // 
            // btnAkun
            // 
            btnAkun.Location = new Point(15, 148);
            btnAkun.Margin = new Padding(2);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(209, 33);
            btnAkun.TabIndex = 6;
            btnAkun.Text = "   Akun";
            btnAkun.TextAlign = ContentAlignment.MiddleLeft;
            btnAkun.UseVisualStyleBackColor = true;
            btnAkun.Click += btnAkun_Click;
            // 
            // btnHalAdmin
            // 
            btnHalAdmin.Location = new Point(15, 103);
            btnHalAdmin.Margin = new Padding(2);
            btnHalAdmin.Name = "btnHalAdmin";
            btnHalAdmin.Size = new Size(209, 33);
            btnHalAdmin.TabIndex = 10;
            btnHalAdmin.Text = "   Halaman Beranda";
            btnHalAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnHalAdmin.UseVisualStyleBackColor = true;
            btnHalAdmin.Click += btnHalAdmin_Click;
            // 
            // btnTambahProduk
            // 
            btnTambahProduk.BackColor = Color.White;
            btnTambahProduk.ForeColor = Color.Black;
            btnTambahProduk.Location = new Point(1149, 44);
            btnTambahProduk.Margin = new Padding(2);
            btnTambahProduk.Name = "btnTambahProduk";
            btnTambahProduk.Size = new Size(168, 34);
            btnTambahProduk.TabIndex = 11;
            btnTambahProduk.Text = "Tambah";
            btnTambahProduk.UseVisualStyleBackColor = false;
            btnTambahProduk.Click += btnTambahProduk_Click;
            // 
            // flpProduk
            // 
            flpProduk.AutoScroll = true;
            flpProduk.Location = new Point(248, 95);
            flpProduk.Margin = new Padding(2);
            flpProduk.Name = "flpProduk";
            flpProduk.Size = new Size(1072, 499);
            flpProduk.TabIndex = 12;
            // 
            // V_MembuatProdukSusu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Template_Membuat_Produk_Admin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1329, 614);
            Controls.Add(flpProduk);
            Controls.Add(btnTambahProduk);
            Controls.Add(btnHalAdmin);
            Controls.Add(btnLaporanAdmin);
            Controls.Add(btnPermintaanAdmin);
            Controls.Add(btnStokAdmin);
            Controls.Add(btnAkun);
            DoubleBuffered = true;
            Margin = new Padding(2);
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