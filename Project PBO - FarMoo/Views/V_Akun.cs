using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Database;
using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Models;
using Project_PBO___FarMoo.Views.Tengkulak.Fitur_permintaan_susu;
using Project_PBO___FarMoo.Views.Tengkulak.Fitur_riwayat_pembelian;
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
    public partial class V_Akun : Form
    {
        private Models.User currentUser;

        public V_Akun()
        {
            InitializeComponent();
        }
        public V_Akun(Models.User user)
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

            if (currentUser.Foto != null && currentUser.Foto.Length > 0)
            {
                pbFotoProfil.Image = ImageHelper.BinaryToImage(currentUser.Foto);
                pbFotoProfil.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void btnubahprofil_Click(object sender, EventArgs e)
        {
            byte[] fotoBytes = null;

            if (pbFotoProfil.Image != null)
            {
                fotoBytes = ImageHelper.ImageToBinary(pbFotoProfil.Image);
            }

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
            cmd.Parameters.AddWithValue("@id", currentUser.UserId);

            if (fotoBytes == null)
                cmd.Parameters.AddWithValue("@foto", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@foto", fotoBytes);

            cmd.ExecuteNonQuery();
            db.Close();

            currentUser.NamaLengkap = tbNamaLengkap.Text;
            currentUser.Username = tbUsername.Text;
            currentUser.Password = tbPassword.Text;
            currentUser.Email = tbEmail.Text;
            currentUser.NomorHp = tbNoTelp.Text;
            currentUser.Foto = fotoBytes;

            MessageBox.Show("Profil berhasil diubah!");
        }

        private void btnBeranda_Click(object sender, EventArgs e)
        {
            var home = new Halaman_Beranda(currentUser);
            home.Show();
            home.UpdateWelcome();
            this.Hide();
        }

        private void btnPermintaan_Click(object sender, EventArgs e)
        {
            var profil = new V_MembuatPermintaanTengkulak(currentUser);
            profil.Show();
            this.Hide();
        }

        private void pbFotoProfil_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                pbFotoProfil.Image = img;

                currentUser.Foto = ImageHelper.ImageToBinary(img);
            }
        }

        private void btnRiwayat_Click (object sender, EventArgs e)
        {
            var riwayat = new V_RiwayatPembelian(currentUser);
            riwayat.Show();
            this.Hide();
        }
    }
}
