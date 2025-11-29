namespace Project_PBO___FarMoo.Views.Tengkulak.Fitur_permintaan_susu
{
    partial class V_HalPembayaran
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
            flpRingkasan = new FlowLayoutPanel();
            label1 = new Label();
            dtpTanggalPengambilan = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            lblTotal = new Label();
            txtJumlahPembayaran = new TextBox();
            btnKembali = new Button();
            btnBayar = new Button();
            SuspendLayout();
            // 
            // flpRingkasan
            // 
            flpRingkasan.Location = new Point(355, 156);
            flpRingkasan.Name = "flpRingkasan";
            flpRingkasan.Size = new Size(1531, 405);
            flpRingkasan.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(362, 579);
            label1.Name = "label1";
            label1.Size = new Size(256, 32);
            label1.TabIndex = 1;
            label1.Text = "Tanggal_Pengambilan :";
            // 
            // dtpTanggalPengambilan
            // 
            dtpTanggalPengambilan.Location = new Point(633, 583);
            dtpTanggalPengambilan.Name = "dtpTanggalPengambilan";
            dtpTanggalPengambilan.Size = new Size(445, 31);
            dtpTanggalPengambilan.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(362, 635);
            label2.Name = "label2";
            label2.Size = new Size(77, 32);
            label2.TabIndex = 3;
            label2.Text = "Total :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(363, 692);
            label3.Name = "label3";
            label3.Size = new Size(354, 32);
            label3.TabIndex = 4;
            label3.Text = "Masukkan Jumlah Pembayaran :";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(490, 641);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(59, 25);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "label4";
            // 
            // txtJumlahPembayaran
            // 
            txtJumlahPembayaran.Location = new Point(755, 695);
            txtJumlahPembayaran.Name = "txtJumlahPembayaran";
            txtJumlahPembayaran.Size = new Size(500, 31);
            txtJumlahPembayaran.TabIndex = 6;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(584, 871);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(268, 85);
            btnKembali.TabIndex = 7;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            // 
            // btnBayar
            // 
            btnBayar.Location = new Point(1238, 871);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(319, 85);
            btnBayar.TabIndex = 8;
            btnBayar.Text = "Bayar";
            btnBayar.UseVisualStyleBackColor = true;
            // 
            // V_HalPembayaran
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.HalamanPembayaran;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnBayar);
            Controls.Add(btnKembali);
            Controls.Add(txtJumlahPembayaran);
            Controls.Add(lblTotal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpTanggalPengambilan);
            Controls.Add(label1);
            Controls.Add(flpRingkasan);
            DoubleBuffered = true;
            Name = "V_HalPembayaran";
            Text = "V_HalPembayaran";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpRingkasan;
        private Label label1;
        private DateTimePicker dtpTanggalPengambilan;
        private Label label2;
        private Label label3;
        private Label lblTotal;
        private TextBox txtJumlahPembayaran;
        private Button btnKembali;
        private Button btnBayar;
    }
}