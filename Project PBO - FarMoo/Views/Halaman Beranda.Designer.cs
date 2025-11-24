namespace Project_PBO___FarMoo.Views
{
    partial class Halaman_Beranda
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
            panel3 = new Panel();
            lblStok = new Label();
            lblStokTitle = new Label();
            panel4 = new Panel();
            lblPengeluaran = new Label();
            label1 = new Label();
            lblWelcome = new Label();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = Properties.Resources.Kotak_Beranda;
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Controls.Add(lblStok);
            panel3.Controls.Add(lblStokTitle);
            panel3.Location = new Point(900, 50);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 150);
            panel3.TabIndex = 1;
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.Font = new Font("Arial", 10F);
            lblStok.Location = new Point(118, 89);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(62, 23);
            lblStok.TabIndex = 1;
            lblStok.Text = "label1";
            // 
            // lblStokTitle
            // 
            lblStokTitle.AutoSize = true;
            lblStokTitle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStokTitle.Location = new Point(98, 15);
            lblStokTitle.Name = "lblStokTitle";
            lblStokTitle.Size = new Size(107, 24);
            lblStokTitle.TabIndex = 0;
            lblStokTitle.Text = "Stok Susu";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.BackgroundImage = Properties.Resources.Kotak_Beranda;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Controls.Add(lblPengeluaran);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(1400, 50);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 150);
            panel4.TabIndex = 2;
            // 
            // lblPengeluaran
            // 
            lblPengeluaran.AutoSize = true;
            lblPengeluaran.Font = new Font("Arial", 10F);
            lblPengeluaran.Location = new Point(122, 89);
            lblPengeluaran.Name = "lblPengeluaran";
            lblPengeluaran.Size = new Size(62, 23);
            lblPengeluaran.TabIndex = 1;
            lblPengeluaran.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(63, 15);
            label1.Name = "label1";
            label1.Size = new Size(181, 24);
            label1.TabIndex = 0;
            label1.Text = "Total Pengeluaran";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(385, 85);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(110, 37);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "label1";
            // 
            // Halaman_Beranda
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Beranda__8_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(lblWelcome);
            Controls.Add(panel4);
            Controls.Add(panel3);
            DoubleBuffered = true;
            Name = "Halaman_Beranda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Halaman_Beranda";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel3;
        private Panel panel4;
        private Label lblStokTitle;
        private Label lblStok;
        private Label label1;
        private Label lblPengeluaran;
        private Label lblWelcome;
    }
}