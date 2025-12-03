namespace Project_PBO___FarMoo.Views.Admin
{
    partial class V_HalBerandaAdmin
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
            btnHalamanAdmin = new Button();
            btnAkunAdmin = new Button();
            btnStokAdmin = new Button();
            btnPermintaanAdmin = new Button();
            btnLaporanPenjualan = new Button();
            lblWelcome_M = new Label();
            panel4 = new Panel();
            lblPenghasilan = new Label();
            label1 = new Label();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnHalamanAdmin
            // 
            btnHalamanAdmin.BackColor = Color.CornflowerBlue;
            btnHalamanAdmin.Location = new Point(22, 175);
            btnHalamanAdmin.Name = "btnHalamanAdmin";
            btnHalamanAdmin.Size = new Size(298, 55);
            btnHalamanAdmin.TabIndex = 0;
            btnHalamanAdmin.Text = "   Halaman Beranda";
            btnHalamanAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnHalamanAdmin.UseVisualStyleBackColor = false;
            btnHalamanAdmin.Click += btnHalamanAdmin_Click;
            // 
            // btnAkunAdmin
            // 
            btnAkunAdmin.Location = new Point(22, 246);
            btnAkunAdmin.Name = "btnAkunAdmin";
            btnAkunAdmin.Size = new Size(298, 55);
            btnAkunAdmin.TabIndex = 1;
            btnAkunAdmin.Text = "   Akun";
            btnAkunAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnAkunAdmin.UseVisualStyleBackColor = true;
            btnAkunAdmin.Click += button2_Click;
            // 
            // btnStokAdmin
            // 
            btnStokAdmin.Location = new Point(22, 317);
            btnStokAdmin.Name = "btnStokAdmin";
            btnStokAdmin.Size = new Size(298, 55);
            btnStokAdmin.TabIndex = 2;
            btnStokAdmin.Text = "   Produk";
            btnStokAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnStokAdmin.UseVisualStyleBackColor = true;
            btnStokAdmin.Click += button3_Click;
            // 
            // btnPermintaanAdmin
            // 
            btnPermintaanAdmin.Location = new Point(22, 388);
            btnPermintaanAdmin.Name = "btnPermintaanAdmin";
            btnPermintaanAdmin.Size = new Size(298, 55);
            btnPermintaanAdmin.TabIndex = 3;
            btnPermintaanAdmin.Text = "   Permintaan Susu";
            btnPermintaanAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnPermintaanAdmin.UseVisualStyleBackColor = true;
            // 
            // btnLaporanPenjualan
            // 
            btnLaporanPenjualan.Location = new Point(22, 459);
            btnLaporanPenjualan.Name = "btnLaporanPenjualan";
            btnLaporanPenjualan.Size = new Size(298, 55);
            btnLaporanPenjualan.TabIndex = 4;
            btnLaporanPenjualan.Text = "   Laporan Penjualan";
            btnLaporanPenjualan.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporanPenjualan.UseVisualStyleBackColor = true;
            btnLaporanPenjualan.Click += btnLaporanPenjualan_Click;
            // 
            // lblWelcome_M
            // 
            lblWelcome_M.AutoSize = true;
            lblWelcome_M.BackColor = Color.Transparent;
            lblWelcome_M.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome_M.Location = new Point(406, 175);
            lblWelcome_M.Name = "lblWelcome_M";
            lblWelcome_M.Size = new Size(110, 37);
            lblWelcome_M.TabIndex = 5;
            lblWelcome_M.Text = "label1";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.BackgroundImage = Properties.Resources.Kotak_Beranda;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Controls.Add(lblPenghasilan);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(1381, 113);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 150);
            panel4.TabIndex = 6;
            // 
            // lblPenghasilan
            // 
            lblPenghasilan.AutoSize = true;
            lblPenghasilan.Font = new Font("Arial", 10F);
            lblPenghasilan.Location = new Point(122, 89);
            lblPenghasilan.Name = "lblPenghasilan";
            lblPenghasilan.Size = new Size(62, 23);
            lblPenghasilan.TabIndex = 1;
            lblPenghasilan.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(63, 15);
            label1.Name = "label1";
            label1.Size = new Size(178, 24);
            label1.TabIndex = 0;
            label1.Text = "Total Penghasilan";
            // 
            // V_HalBerandaAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Beranda_Peternak;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(panel4);
            Controls.Add(lblWelcome_M);
            Controls.Add(btnLaporanPenjualan);
            Controls.Add(btnPermintaanAdmin);
            Controls.Add(btnStokAdmin);
            Controls.Add(btnAkunAdmin);
            Controls.Add(btnHalamanAdmin);
            DoubleBuffered = true;
            Name = "V_HalBerandaAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BerandaAdmin";
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHalamanAdmin;
        private Button btnAkunAdmin;
        private Button btnStokAdmin;
        private Button btnPermintaanAdmin;
        private Button btnLaporanPenjualan;
        private Label lblWelcome_M;
        private Panel panel4;
        private Label lblPenghasilan;
        private Label label1;
    }
}