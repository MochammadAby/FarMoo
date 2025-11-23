using Project_PBO___FarMoo.Controllers;
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

        private AuthController auth;
        public Login()
        {
            InitializeComponent();
            auth = new AuthController();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            var user = auth.Login(username, password);

            if (user != null)
            {
                MessageBox.Show("Login Berhasil! Selamat datang, " + user.NamaLengkap);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password salah!");
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
