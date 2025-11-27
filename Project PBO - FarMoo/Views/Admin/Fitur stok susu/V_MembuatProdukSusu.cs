using Project_PBO___FarMoo.Helper;
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


namespace Project_PBO___FarMoo.Views.Admin.Fitur_stok_susu
{
    public partial class V_MembuatProdukSusu : Form
    {
        private readonly AppUser _user;

        public V_MembuatProdukSusu(AppUser user)
        {
            _user = user;
            InitializeComponent();
            btnTambahProduk.Click += btnTambahProduk_Click;

        }


        private void btnTambahProduk_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_TambahProduk(_user));
        }

        private void btnAkun_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_AkunAdmin(_user));

        }

        private void btnHalAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_HalBerandaAdmin(_user));

        }

        private void btnStokAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}
