using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_PBO___FarMoo.Views
{
    public partial class Register : Form
    {
        private AuthController auth;
        public Register()
        {
            InitializeComponent();
            auth = new AuthController();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbNama.Text == "" || tbUsername.Text == "" ||
        tbPassword.Text == "" || tbEmail.Text == "" || tbNomor.Text == "")
            {
                MessageBox.Show("Semua field wajib diisi!");
                return;
            }

            if (auth.IsEmailExist(tbEmail.Text))
            {
                MessageBox.Show("Email sudah terpakai! Gunakan email lain.");
                return;
            }

            if (auth.IsUsernameTaken(tbUsername.Text))
            {
                MessageBox.Show("Username sudah digunakan, Tolong isi Form Kembali!");
                return;
            }

            var user = new User
            {
                NamaLengkap = tbNama.Text,
                Username = tbUsername.Text,
                Password = tbPassword.Text,
                Email = tbEmail.Text,
                NomorHp = tbNomor.Text,

                Role = "tengkulak"
            };

            bool result = auth.Register(user);

            if (result)
            {
                MessageBox.Show("Registrasi berhasil! Silakan login.");
                new Login().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Registrasi gagal!");
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
    }
}
