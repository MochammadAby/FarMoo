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
            panel4 = new Panel();
            lblPengeluaran = new Label();
            label1 = new Label();
            lblWelcome = new Label();
            btnAkun = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel4.SuspendLayout();
            SuspendLayout();
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
            // btnAkun
            // 
            btnAkun.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAkun.Location = new Point(12, 246);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(310, 54);
            btnAkun.TabIndex = 3;
            btnAkun.Text = "  Akun";
            btnAkun.TextAlign = ContentAlignment.MiddleLeft;
            btnAkun.UseVisualStyleBackColor = true;
            btnAkun.Click += btnAkun_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 318);
            button1.Name = "button1";
            button1.Size = new Size(310, 54);
            button1.TabIndex = 4;
            button1.Text = "  Akun";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 389);
            button2.Name = "button2";
            button2.Size = new Size(310, 54);
            button2.TabIndex = 5;
            button2.Text = "  Akun";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(12, 175);
            button3.Name = "button3";
            button3.Size = new Size(310, 54);
            button3.TabIndex = 6;
            button3.Text = "  Akun";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            // 
            // Halaman_Beranda
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Beranda_Terbaru;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnAkun);
            Controls.Add(lblWelcome);
            Controls.Add(panel4);
            DoubleBuffered = true;
            Name = "Halaman_Beranda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Halaman_Beranda";
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel4;
        private Label label1;
        private Label lblPengeluaran;
        private Label lblWelcome;
        private Button btnAkun;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}