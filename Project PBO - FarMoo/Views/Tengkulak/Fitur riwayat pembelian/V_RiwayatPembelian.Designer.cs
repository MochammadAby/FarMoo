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
            btnBeranda = new Button();
            btnRiwayat = new Button();
            btnPermintaan = new Button();
            btnAkun = new Button();
            dgvRiwayat = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            SuspendLayout();
            // 
            // btnBeranda
            // 
            btnBeranda.BackColor = SystemColors.ButtonHighlight;
            btnBeranda.BackgroundImageLayout = ImageLayout.Center;
            btnBeranda.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBeranda.Location = new Point(12, 177);
            btnBeranda.Name = "btnBeranda";
            btnBeranda.Size = new Size(310, 54);
            btnBeranda.TabIndex = 14;
            btnBeranda.Text = "   Halaman Beranda";
            btnBeranda.TextAlign = ContentAlignment.MiddleLeft;
            btnBeranda.UseVisualStyleBackColor = false;
            btnBeranda.Click += btnBeranda_Click;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.CornflowerBlue;
            btnRiwayat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(12, 391);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(310, 54);
            btnRiwayat.TabIndex = 13;
            btnRiwayat.Text = "   Riwayat pemesanan";
            btnRiwayat.TextAlign = ContentAlignment.MiddleLeft;
            btnRiwayat.UseVisualStyleBackColor = false;
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
            btnPermintaan.Click += btnPermintaan_Click;
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
            btnAkun.Click += btnAkun_Click;
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
            Controls.Add(btnBeranda);
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
        private Button btnBeranda;
    }
}