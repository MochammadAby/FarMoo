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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            lblWelcome_M = new Label();
            panel4 = new Panel();
            lblPenghasilan = new Label();
            label1 = new Label();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(22, 175);
            button1.Name = "button1";
            button1.Size = new Size(298, 55);
            button1.TabIndex = 0;
            button1.Text = "   Halaman Beranda";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(22, 246);
            button2.Name = "button2";
            button2.Size = new Size(298, 55);
            button2.TabIndex = 1;
            button2.Text = "   Akun";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += this.button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(22, 317);
            button3.Name = "button3";
            button3.Size = new Size(298, 55);
            button3.TabIndex = 2;
            button3.Text = "   Stok Susu";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(22, 388);
            button4.Name = "button4";
            button4.Size = new Size(298, 55);
            button4.TabIndex = 3;
            button4.Text = "   Permintaan Susu";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(22, 459);
            button5.Name = "button5";
            button5.Size = new Size(298, 55);
            button5.TabIndex = 4;
            button5.Text = "   Laporan Penjualan";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
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
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label lblWelcome_M;
        private Panel panel4;
        private Label lblPenghasilan;
        private Label label1;
    }
}