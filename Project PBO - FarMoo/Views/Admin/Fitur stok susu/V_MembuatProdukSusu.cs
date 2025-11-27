using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PBO___FarMoo.Views.Admin.Fitur_stok_susu
{
    public partial class V_MembuatProdukSusu : Form
    {
        public V_MembuatProdukSusu()
        {
            InitializeComponent();
            btnTambahProduk.Click += btnTambahProduk_Click;
        }


        private void btnTambahProduk_Click(object sender, EventArgs e)
        {
            using (var form = new V_TambahProdukSusu())   // atau V_TambahStokSusu, terserah nama kamu
            {
                // Buka sebagai dialog, biar setelah save balik lagi ke halaman stok
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // setelah user berhasil simpan stok, refresh tampilan kartu stok di sini
                    MuatDataStok();   // isi sendiri: query stok_batch + produk_susu lalu generate card
                }
            }
        }
    }
}
