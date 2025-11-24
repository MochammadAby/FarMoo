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
            // 1. Ucapan welcome
            lblWelcome.Text = $"Halo, {currentUser.NamaLengkap} 👋";

            // 2. Ambil stok susu
            int stok = dashboard.GetStokSusu();
            lblStok.Text = $"{stok} Liter";

            // 3. Ambil total pengeluaran user
            int totalPengeluaran = dashboard.GetTotalPengeluaran(currentUser.UserId);
            lblPengeluaran.Text = $"Rp {totalPengeluaran:N0}";
        }

        private void Halaman_Beranda_Load(object sender, EventArgs e)
        {

        }
    }
}
