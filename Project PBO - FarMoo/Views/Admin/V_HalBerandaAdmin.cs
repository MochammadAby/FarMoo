using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Models;
using Project_PBO___FarMoo.Views.Admin.Fitur_Laporan_Penjualan;
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
using AppUser = Project_PBO___FarMoo.Models.User;

namespace Project_PBO___FarMoo.Views.Admin
{
    public partial class V_HalBerandaAdmin : Form
    {
        private readonly AppUser _user;
        private User currentUser;
        private HalamanController dashboard;

        public V_HalBerandaAdmin(AppUser user)
        {
            _user = user;
            InitializeComponent();
            currentUser = user;
            dashboard = new HalamanController();
            lblWelcome_M.Text = $"Selamat datang, {currentUser.NamaLengkap}!";

            LoadDashboard_M();
        }
        private void LoadDashboard_M()
        {
            lblWelcome_M.Text = $"Halo, {currentUser.NamaLengkap} 👋";

            int totalPengeluaran = dashboard.GetTotalPenghasilan(currentUser.UserId);
            lblPenghasilan.Text = $"Rp {totalPengeluaran:N0}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_MembuatProdukSusu(_user));

        }
        private void button2_Click(object sender, EventArgs e)
        {
            var profil = new V_AkunAdmin(currentUser);
            profil.Show();
            this.Hide();
        }

        private void btnHalamanAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_HalBerandaAdmin(_user));

        }

        private void V_HalBerandaAdmin_Load(object sender, EventArgs e)
        {

        }
        private void btnStokAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_MembuatProdukSusu(_user));
        }
        private void BtnPermintaanAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_PermintaanSusu(_user));// tombol "Permintaan Susu" → reload data tabel

        }

        private void btnLaporanPenjualan_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_LaporanPenjualan());
        }
    }
}
