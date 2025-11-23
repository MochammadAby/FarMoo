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
using Project_PBO___FarMoo.Models;

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
    }
}
