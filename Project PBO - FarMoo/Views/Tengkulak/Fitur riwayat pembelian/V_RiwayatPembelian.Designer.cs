namespace Project_PBO___FarMoo.Views.Tengkulak.Fitur_riwayat_pembelian
{
    partial class V_RiwayatPembelian
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
            dgvRiwayat = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            SuspendLayout();
            // 
            // btnHalTengkulak
            // 
            btnHalTengkulak.BackColor = SystemColors.ButtonHighlight;
            btnHalTengkulak.BackgroundImageLayout = ImageLayout.Center;
            btnHalTengkulak.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHalTengkulak.Location = new Point(12, 177);
            btnHalTengkulak.Name = "btnHalTengkulak";
            btnHalTengkulak.Size = new Size(310, 54);
            btnHalTengkulak.TabIndex = 14;
            btnHalTengkulak.Text = "   Halaman Beranda";
            btnHalTengkulak.TextAlign = ContentAlignment.MiddleLeft;
            btnHalTengkulak.UseVisualStyleBackColor = false;
            // 
            // btnRiwayat
            // 
            btnRiwayat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(12, 391);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(310, 54);
            btnRiwayat.TabIndex = 13;
            btnRiwayat.Text = "   Riwayat pemesanan";
            btnRiwayat.TextAlign = ContentAlignment.MiddleLeft;
            btnRiwayat.UseVisualStyleBackColor = true;
            // 
            // btnPermintaan
            // 
            btnPermintaan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPermintaan.Location = new Point(12, 320);
            btnPermintaan.Name = "btnPermintaan";
            btnPermintaan.Size = new Size(310, 54);
            btnPermintaan.TabIndex = 12;
            btnPermintaan.Text = "   Permintaan susu";
            btnPermintaan.TextAlign = ContentAlignment.MiddleLeft;
            btnPermintaan.UseVisualStyleBackColor = true;
            // 
            // btnAkun
            // 
            btnAkun.Cursor = Cursors.Hand;
            btnAkun.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAkun.Location = new Point(12, 248);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(310, 54);
            btnAkun.TabIndex = 11;
            btnAkun.Text = "   Akun";
            btnAkun.TextAlign = ContentAlignment.MiddleLeft;
            btnAkun.UseVisualStyleBackColor = true;
            // 
            // dgvRiwayat
            // 
            dgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRiwayat.Location = new Point(354, 149);
            dgvRiwayat.Name = "dgvRiwayat";
            dgvRiwayat.RowHeadersWidth = 62;
            dgvRiwayat.Size = new Size(1532, 843);
            dgvRiwayat.TabIndex = 15;
            // 
            // V_RiwayatPembelian
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Template_Riwayat_Pembelian_Tengkulak;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(dgvRiwayat);
            Controls.Add(btnHalTengkulak);
            Controls.Add(btnRiwayat);
            Controls.Add(btnPermintaan);
            Controls.Add(btnAkun);
            DoubleBuffered = true;
            Name = "V_RiwayatPembelian";
            Text = "V_RiwayatPembelian";
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnHalTengkulak;
        private Button btnRiwayat;
        private Button btnPermintaan;
        private Button btnAkun;
        private DataGridView dgvRiwayat;
    }
}