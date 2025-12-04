using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Database;
using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Models;
using Project_PBO___FarMoo.Views.Admin.Fitur_Laporan_Penjualan;
using Project_PBO___FarMoo.Views.Admin.Fitur_Permintaan_Susu;
using Project_PBO___FarMoo.Views.Admin.Fitur_stok_susu;
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

            if (currentUser.Foto != null)
                pbFotoPeternak.Image = ImageHelper.BinaryToImage(currentUser.Foto);
            else
                pbFotoPeternak.Image = null;
        }

        private void btnUbahProfilAdmin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNamaLengkap.Text) ||
        string.IsNullOrWhiteSpace(tbUsername.Text) ||
        string.IsNullOrWhiteSpace(tbPassword.Text) ||
        string.IsNullOrWhiteSpace(tbEmail.Text) ||
        string.IsNullOrWhiteSpace(tbNoTelp.Text))
            {
                MessageBox.Show("Semua field wajib diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!tbEmail.Text.Contains("@") || !tbEmail.Text.Contains("."))
            {
                MessageBox.Show("Format email tidak valid!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] fotoBytes = null;

            if (pbFotoPeternak.Image != null)
                fotoBytes = ImageHelper.ImageToBinary(pbFotoPeternak.Image);

            using var db = new DbContext();
            db.Open();

            string query = @"UPDATE akun 
                     SET nama_lengkap = @nama,
                         username = @user,
                         password = @pass,
                         email = @mail,
                         nomor_hp = @hp,
                         foto = @foto
                     WHERE user_id = @id";

            using var cmd = new NpgsqlCommand(query, db.Connection);
            cmd.Parameters.AddWithValue("@nama", tbNamaLengkap.Text);
            cmd.Parameters.AddWithValue("@user", tbUsername.Text);
            cmd.Parameters.AddWithValue("@pass", tbPassword.Text);
            cmd.Parameters.AddWithValue("@mail", tbEmail.Text);
            cmd.Parameters.AddWithValue("@hp", tbNoTelp.Text);

            if (fotoBytes == null)
                cmd.Parameters.AddWithValue("@foto", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@foto", fotoBytes);

            cmd.Parameters.AddWithValue("@id", currentUser.UserId);

            cmd.ExecuteNonQuery();
            db.Close();

            currentUser.NamaLengkap = tbNamaLengkap.Text;
            currentUser.Username = tbUsername.Text;
            currentUser.Password = tbPassword.Text;
            currentUser.Email = tbEmail.Text;
            currentUser.NomorHp = tbNoTelp.Text;

            MessageBox.Show("Profil berhasil diubah!", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBerandaAdmin_Click(object sender, EventArgs e)
        {
            var profil = new V_HalBerandaAdmin(currentUser);
            profil.Show();
            this.Hide();
        }

        private void btnStokSusu_Click(object sender, EventArgs e)
        {
            var profil = new V_MembuatProdukSusu(currentUser);
            profil.Show();
            this.Hide();
        }

        private void btnUbahFoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                pbFotoPeternak.Image = img;

                currentUser.Foto = ImageHelper.ImageToBinary(img);
            }
        }

        private void btnPermintaanSusu_Click(object sender, EventArgs e)
        {
            var profil = new V_PermintaanSusu(currentUser);
            profil.Show();
            this.Hide();
        }

        private void btnLaporanPenjualan_Click(object sender, EventArgs e)
        {
            var profil = new V_LaporanPenjualan(currentUser);
            profil.Show();
            this.Hide();
        }
    }
}
