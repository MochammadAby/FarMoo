using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Models;

namespace Project_PBO___FarMoo.Views
{
    public partial class Halaman_Beranda : Form
    {
        private User currentUser;
        private HalamanController dashboard;
        public Halaman_Beranda(User user)
        {
            InitializeComponent();
            currentUser = user;
            dashboard = new HalamanController();
            lblWelcome.Text = $"Selamat datang, {currentUser.NamaLengkap}!";

            LoadDashboard();
        }
        private void LoadDashboard()
        {
            lblWelcome.Text = $"Halo, {currentUser.NamaLengkap} 👋";

            int totalPengeluaran = dashboard.GetTotalPenghasilan(currentUser.UserId);
            lblPengeluaran.Text = $"Rp {totalPengeluaran:N0}";
        }

        private void Halaman_Beranda_Load(object sender, EventArgs e)
        {

        }

        private void btnAkun_Click(object sender, EventArgs e)
        {
            var profil = new V_Akun(currentUser);
            profil.Show();
            this.Hide();
        }
        public void UpdateWelcome()
        {
            lblWelcome.Text = $"Halo, {currentUser.NamaLengkap} 👋";
        }
    }
}
