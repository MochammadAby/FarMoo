namespace Project_PBO___FarMoo.Views.Admin.Fitur_Permintaan_Susu
{
    partial class V_PermintaanSusu
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
            dgvPermintaan = new DataGridView();
            BtnLaporanPenjualan = new Button();
            BtnPermintaanAdmin = new Button();
            BtnStokAdmin = new Button();
            BtnAkunAdmin = new Button();
            BtnHalamanAdmin = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPermintaan).BeginInit();
            SuspendLayout();
            // 
            // dgvPermintaan
            // 
            dgvPermintaan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPermintaan.Location = new Point(403, 332);
            dgvPermintaan.Name = "dgvPermintaan";
            dgvPermintaan.RowHeadersWidth = 62;
            dgvPermintaan.Size = new Size(1455, 633);
            dgvPermintaan.TabIndex = 0;
            dgvPermintaan.CellContentClick += dgvPermintaan_CellContentClick;
            // 
            // BtnLaporanPenjualan
            // 
            BtnLaporanPenjualan.Location = new Point(22, 459);
            BtnLaporanPenjualan.Name = "BtnLaporanPenjualan";
            BtnLaporanPenjualan.Size = new Size(298, 55);
            BtnLaporanPenjualan.TabIndex = 9;
            BtnLaporanPenjualan.Text = "   Laporan Penjualan";
            BtnLaporanPenjualan.TextAlign = ContentAlignment.MiddleLeft;
            BtnLaporanPenjualan.UseVisualStyleBackColor = true;
            BtnLaporanPenjualan.Click += BtnLaporanPenjualan_Click;
            // 
            // BtnPermintaanAdmin
            // 
            BtnPermintaanAdmin.BackColor = Color.CornflowerBlue;
            BtnPermintaanAdmin.Location = new Point(21, 387);
            BtnPermintaanAdmin.Name = "BtnPermintaanAdmin";
            BtnPermintaanAdmin.Size = new Size(298, 55);
            BtnPermintaanAdmin.TabIndex = 8;
            BtnPermintaanAdmin.Text = "   Permintaan Susu";
            BtnPermintaanAdmin.TextAlign = ContentAlignment.MiddleLeft;
            BtnPermintaanAdmin.UseVisualStyleBackColor = false;
            BtnPermintaanAdmin.Click += BtnPermintaanAdmin_Click;
            // 
            // BtnStokAdmin
            // 
            BtnStokAdmin.Location = new Point(22, 317);
            BtnStokAdmin.Name = "BtnStokAdmin";
            BtnStokAdmin.Size = new Size(298, 55);
            BtnStokAdmin.TabIndex = 7;
            BtnStokAdmin.Text = "   Produk";
            BtnStokAdmin.TextAlign = ContentAlignment.MiddleLeft;
            BtnStokAdmin.UseVisualStyleBackColor = true;
            // 
            // BtnAkunAdmin
            // 
            BtnAkunAdmin.Location = new Point(22, 246);
            BtnAkunAdmin.Name = "BtnAkunAdmin";
            BtnAkunAdmin.Size = new Size(298, 55);
            BtnAkunAdmin.TabIndex = 6;
            BtnAkunAdmin.Text = "   Akun";
            BtnAkunAdmin.TextAlign = ContentAlignment.MiddleLeft;
            BtnAkunAdmin.UseVisualStyleBackColor = true;
            BtnAkunAdmin.Click += BtnAkunAdmin_Click;
            // 
            // BtnHalamanAdmin
            // 
            BtnHalamanAdmin.BackColor = SystemColors.Control;
            BtnHalamanAdmin.Location = new Point(22, 175);
            BtnHalamanAdmin.Name = "BtnHalamanAdmin";
            BtnHalamanAdmin.Size = new Size(298, 55);
            BtnHalamanAdmin.TabIndex = 5;
            BtnHalamanAdmin.Text = "   Halaman Beranda";
            BtnHalamanAdmin.TextAlign = ContentAlignment.MiddleLeft;
            BtnHalamanAdmin.UseVisualStyleBackColor = false;
            BtnHalamanAdmin.Click += BtnHalamanAdmin_Click;
            // 
            // V_PermintaanSusu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fitur_Permintaan_Susu;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(BtnLaporanPenjualan);
            Controls.Add(BtnPermintaanAdmin);
            Controls.Add(BtnStokAdmin);
            Controls.Add(BtnAkunAdmin);
            Controls.Add(BtnHalamanAdmin);
            Controls.Add(dgvPermintaan);
            DoubleBuffered = true;
            Name = "V_PermintaanSusu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_PermintaanSusu";
            Load += V_PermintaanSusu_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvPermintaan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPermintaan;
        private Button BtnLaporanPenjualan;
        private Button BtnPermintaanAdmin;
        private Button BtnStokAdmin;
        private Button BtnAkunAdmin;
        private Button BtnHalamanAdmin;
    }
}