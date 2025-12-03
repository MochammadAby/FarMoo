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
using AppUser = Project_PBO___FarMoo.Models.User;

namespace Project_PBO___FarMoo.Views.Tengkulak.Fitur_riwayat_pembelian
{
    public partial class V_RiwayatPembelian : Form
    {
        private readonly C_Transaksi _transaksiController = new C_Transaksi();
        private readonly AppUser _user;
        public V_RiwayatPembelian()
        {
            InitializeComponent();

        }
        private void V_RiwayatPembelian_Load(object? sender, EventArgs e)
        {
            MuatData();
        }

        private void MuatData()
        {
            try
            {
                var table = _transaksiController.GetRiwayatPembelianTable(_user.UserId);
                dgvRiwayat.AutoGenerateColumns = true; 
                dgvRiwayat.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat transaksi: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
