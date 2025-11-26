namespace Project_PBO___FarMoo.Views.Tengkulak.Fitur_permintaan_susu
{
    partial class Membuat_Permintaan_Susu_Tengkulak
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
            button3 = new Button();
            btnRiwayat = new Button();
            btnPermintaan = new Button();
            btnAkun = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(12, 176);
            button3.Name = "button3";
            button3.Size = new Size(310, 54);
            button3.TabIndex = 10;
            button3.Text = "Halaman Beranda";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            // 
            // btnRiwayat
            // 
            btnRiwayat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(12, 390);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(310, 54);
            btnRiwayat.TabIndex = 9;
            btnRiwayat.Text = " Riwayat pemesanan";
            btnRiwayat.TextAlign = ContentAlignment.MiddleLeft;
            btnRiwayat.UseVisualStyleBackColor = true;
            // 
            // btnPermintaan
            // 
            btnPermintaan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPermintaan.Location = new Point(12, 319);
            btnPermintaan.Name = "btnPermintaan";
            btnPermintaan.Size = new Size(310, 54);
            btnPermintaan.TabIndex = 8;
            btnPermintaan.Text = "Permintaan susu";
            btnPermintaan.TextAlign = ContentAlignment.MiddleLeft;
            btnPermintaan.UseVisualStyleBackColor = true;
            // 
            // btnAkun
            // 
            btnAkun.Cursor = Cursors.Hand;
            btnAkun.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAkun.Location = new Point(12, 247);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(310, 54);
            btnAkun.TabIndex = 7;
            btnAkun.Text = "  Akun";
            btnAkun.TextAlign = ContentAlignment.MiddleLeft;
            btnAkun.UseVisualStyleBackColor = true;
            // 
            // Membuat_Permintaan_Susu_Tengkulak
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Templet_Tengkulak;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(button3);
            Controls.Add(btnRiwayat);
            Controls.Add(btnPermintaan);
            Controls.Add(btnAkun);
            DoubleBuffered = true;
            Name = "Membuat_Permintaan_Susu_Tengkulak";
            Text = "Membuat_Permintaan_Susu_Tengkulak";
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private Button btnRiwayat;
        private Button btnPermintaan;
        private Button btnAkun;
    }
}