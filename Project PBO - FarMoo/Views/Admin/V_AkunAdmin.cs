using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PBO___FarMoo.Views.Admin
{
    public partial class V_AkunAdmin : Form
    {
        private Models.User currentUser;
        public V_AkunAdmin(Models.User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadAkun();
        }
        private void LoadAkun()
        {
            tbNamaLengkap.Text = currentUser.NamaLengkap;
            tbUsername.Text = currentUser.Username;
            tbPassword.Text = currentUser.Password;
            tbEmail.Text = currentUser.Email;
            tbNoTelp.Text = currentUser.NomorHp;
        }

        private void btnUbahProfilAdmin_Click(object sender, EventArgs e)
        {
            currentUser.NamaLengkap = tbNamaLengkap.Text;
            currentUser.Username = tbUsername.Text;
            currentUser.Email = tbEmail.Text;
            currentUser.NomorHp = tbNoTelp.Text;
            currentUser.Password = tbPassword.Text;

            var auth = new AuthController();

            bool result = auth.UpdateProfile(currentUser);

            if (result)
            {
                MessageBox.Show("Profil berhasil diperbarui!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Gagal memperbarui profil!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
