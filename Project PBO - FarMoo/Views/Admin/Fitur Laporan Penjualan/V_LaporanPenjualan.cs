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

namespace Project_PBO___FarMoo.Views.Admin.Fitur_Laporan_Penjualan
{
    public partial class V_LaporanPenjualan : Form
    {
        private C_LaporanPenjualan laporan;
        public V_LaporanPenjualan()
        {
            InitializeComponent();
            laporan = new C_LaporanPenjualan();
            LoadLaporan();
        }
        private void LoadLaporan()
        {
            var data = laporan.GetLaporanPenjualan();
            dataGridView1.DataSource = data;
        }
    }
}
