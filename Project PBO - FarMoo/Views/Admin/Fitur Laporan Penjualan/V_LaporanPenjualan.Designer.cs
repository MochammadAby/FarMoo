namespace Project_PBO___FarMoo.Views.Admin.Fitur_Laporan_Penjualan
{
    partial class V_LaporanPenjualan
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
            btnPermintaanAdmin = new Button();
            btnStokAdmin = new Button();
            btnAkunAdmin = new Button();
            btnHalamanAdmin = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLaporanPenjualan
            // 
            btnLaporanPenjualan.BackColor = Color.CornflowerBlue;
            btnLaporanPenjualan.Location = new Point(21, 459);
            btnLaporanPenjualan.Name = "btnLaporanPenjualan";
            btnLaporanPenjualan.Size = new Size(298, 55);
            btnLaporanPenjualan.TabIndex = 9;
            btnLaporanPenjualan.Text = "   Laporan Penjualan";
            btnLaporanPenjualan.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporanPenjualan.UseVisualStyleBackColor = false;
            // 
            // btnPermintaanAdmin
            // 
            btnPermintaanAdmin.Location = new Point(21, 388);
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
            btnStokAdmin.Text = "   Produk";
            btnStokAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnStokAdmin.UseVisualStyleBackColor = true;
            // 
            // btnAkunAdmin
            // 
            btnAkunAdmin.Location = new Point(22, 246);
            btnAkunAdmin.Name = "btnAkunAdmin";
            btnAkunAdmin.Size = new Size(298, 55);
            btnAkunAdmin.TabIndex = 6;
            btnAkunAdmin.Text = "   Akun";
            btnAkunAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnAkunAdmin.UseVisualStyleBackColor = true;
            // 
            // btnHalamanAdmin
            // 
            btnHalamanAdmin.BackColor = SystemColors.Control;
            btnHalamanAdmin.Location = new Point(22, 175);
            btnHalamanAdmin.Name = "btnHalamanAdmin";
            btnHalamanAdmin.Size = new Size(298, 55);
            btnHalamanAdmin.TabIndex = 5;
            btnHalamanAdmin.Text = "   Halaman Beranda";
            btnHalamanAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnHalamanAdmin.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(380, 175);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1476, 815);
            dataGridView1.TabIndex = 10;
            // 
            // V_LaporanPenjualan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Laporan_Penjualan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(dataGridView1);
            Controls.Add(btnLaporanPenjualan);
            Controls.Add(btnPermintaanAdmin);
            Controls.Add(btnStokAdmin);
            Controls.Add(btnAkunAdmin);
            Controls.Add(btnHalamanAdmin);
            Name = "V_LaporanPenjualan";
            Text = "V_LaporanPenjualan";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLaporanPenjualan;
        private Button btnPermintaanAdmin;
        private Button btnStokAdmin;
        private Button btnAkunAdmin;
        private Button btnHalamanAdmin;
        private DataGridView dataGridView1;
    }
}