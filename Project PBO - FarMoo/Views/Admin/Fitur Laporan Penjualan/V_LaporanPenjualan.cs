using Microsoft.VisualBasic.ApplicationServices;
using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Models;
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
using AppUser = Project_PBO___FarMoo.Models.User;

namespace Project_PBO___FarMoo.Views.Admin.Fitur_Laporan_Penjualan
{
    public partial class V_LaporanPenjualan : Form
    {
        private C_LaporanPenjualan laporan;
        private readonly AppUser _user;
        public V_LaporanPenjualan(AppUser user)
        {
            InitializeComponent();
            laporan = new C_LaporanPenjualan();
            LoadLaporan();
            _user = user;
        }
        private void LoadLaporan()
        {
            var data = laporan.GetLaporanPenjualan();
            dataGridView1.DataSource = data;
        }

        private void btnPermintaanAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_PermintaanSusu(_user));
        }
        private void btnProduk_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_MembuatProdukSusu(_user));
        }

        private void btnAkunAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_AkunAdmin(_user));
        }

        private void btnHalamanAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_HalBerandaAdmin(_user));
        }
    }
}
