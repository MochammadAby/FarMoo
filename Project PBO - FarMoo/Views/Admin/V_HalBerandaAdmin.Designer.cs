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
            // V_HalBerandaAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Beranda_Peternak;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "V_HalBerandaAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BerandaAdmin";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}