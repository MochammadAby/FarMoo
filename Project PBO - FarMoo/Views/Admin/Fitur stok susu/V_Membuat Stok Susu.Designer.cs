namespace Project_PBO___FarMoo.Views.Admin.Fitur_stok_susu
{
    partial class V_Membuat_Stok_Susu
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
            BtnHalBeranda = new Button();
            btnRiwayat = new Button();
            btnPermintaan = new Button();
            btnAkun = new Button();
            btnTambahBarang = new Button();
            SuspendLayout();
            // 
            // BtnHalBeranda
            // 
            BtnHalBeranda.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnHalBeranda.Location = new Point(12, 174);
            BtnHalBeranda.Name = "BtnHalBeranda";
            BtnHalBeranda.Size = new Size(310, 54);
            BtnHalBeranda.TabIndex = 14;
            BtnHalBeranda.Text = "Halaman Beranda";
            BtnHalBeranda.TextAlign = ContentAlignment.MiddleLeft;
            BtnHalBeranda.UseVisualStyleBackColor = true;
            // 
            // btnRiwayat
            // 
            btnRiwayat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(12, 388);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(310, 54);
            btnRiwayat.TabIndex = 13;
            btnRiwayat.Text = " Riwayat pemesanan";
            btnRiwayat.TextAlign = ContentAlignment.MiddleLeft;
            btnRiwayat.UseVisualStyleBackColor = true;
            // 
            // btnPermintaan
            // 
            btnPermintaan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPermintaan.Location = new Point(12, 317);
            btnPermintaan.Name = "btnPermintaan";
            btnPermintaan.Size = new Size(310, 54);
            btnPermintaan.TabIndex = 12;
            btnPermintaan.Text = "Permintaan susu";
            btnPermintaan.TextAlign = ContentAlignment.MiddleLeft;
            btnPermintaan.UseVisualStyleBackColor = true;
            // 
            // btnAkun
            // 
            btnAkun.Cursor = Cursors.Hand;
            btnAkun.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAkun.Location = new Point(12, 245);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(310, 54);
            btnAkun.TabIndex = 11;
            btnAkun.Text = "  Akun";
            btnAkun.TextAlign = ContentAlignment.MiddleLeft;
            btnAkun.UseVisualStyleBackColor = true;
            // 
            // btnTambahBarang
            // 
            btnTambahBarang.Location = new Point(1694, 58);
            btnTambahBarang.Name = "btnTambahBarang";
            btnTambahBarang.Size = new Size(179, 54);
            btnTambahBarang.TabIndex = 15;
            btnTambahBarang.Text = "Tambah";
            btnTambahBarang.UseVisualStyleBackColor = true;
            // 
            // V_Membuat_Stok_Susu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Templet_Permintaan_susu_tengkulak;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnTambahBarang);
            Controls.Add(BtnHalBeranda);
            Controls.Add(btnRiwayat);
            Controls.Add(btnPermintaan);
            Controls.Add(btnAkun);
            DoubleBuffered = true;
            Name = "V_Membuat_Stok_Susu";
            Text = "V_Membuat_Stok_Susu";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnHalBeranda;
        private Button btnRiwayat;
        private Button btnPermintaan;
        private Button btnAkun;
        private Button btnTambahBarang;
    }
}