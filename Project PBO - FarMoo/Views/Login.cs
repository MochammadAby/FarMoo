using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PBO___FarMoo.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = tbUsername.Text;
            string pass = tbPassword.Text;

            // Contoh data login (bisa diganti dari database)
            string userValid = "admin";
            string passValid = "12345";

            if (user == userValid && pass == passValid)
            {
                MessageBox.Show("Login Berhasil!", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Contoh: buka form baru
                // FormMenu menu = new FormMenu();
                // menu.Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password salah!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
