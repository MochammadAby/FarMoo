using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Models;
using Project_PBO___FarMoo.Views.Admin.Fitur_stok_susu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Project_PBO___FarMoo.Views.Admin.Fitur_Permintaan_Susu
{
    public partial class V_PermintaanSusu : Form
    {
        private readonly User _user;
        private readonly C_Transaksi _transaksiController = new C_Transaksi();

        public V_PermintaanSusu(User user)
        {
            _user = user;

            InitializeComponent();


            // event tombol
            BtnHalamanAdmin.Click += BtnHalamanAdmin_Click;
            BtnAkunAdmin.Click += BtnAkunAdmin_Click;
            BtnStokAdmin.Click += BtnStokAdmin_Click;
            BtnPermintaanAdmin.Click += BtnPermintaanAdmin_Click; // tombol ini reload tabel
            BtnLaporanPenjualan.Click += BtnLaporanPenjualan_Click;

            // load saat form dibuka
            this.Load += V_PermintaanSusu_Load;

        }

        private void V_PermintaanSusu_Load(object sender, EventArgs e)
        {
            MuatTabelPermintaanSusu();
            

        }

        // ============================================================
        //  METHOD UTAMA MENAMPILKAN DATA KE DATAGRIDVIEW
        // ============================================================
        private void MuatTabelPermintaanSusu()
        {
            try
            {
                var daftarPermintaan = _transaksiController.GetSemuaPermintaanSusu();

                var tabel = new DataTable();
                tabel.Columns.Add("Jumlah Botol");
                tabel.Columns.Add("Nama Produk");
                tabel.Columns.Add("Volume (ml)");
                tabel.Columns.Add("Total Harga");
                tabel.Columns.Add("Tanggal Pembelian");
                tabel.Columns.Add("Tanggal Permintaan");
                tabel.Columns.Add("Status Pembayaran");

                foreach (var p in daftarPermintaan)
                {
                    tabel.Rows.Add(
                        p.JumlahBotol,
                        p.NamaProduk,
                        p.Volume,
                        $"Rp {p.TotalHarga:N0}",
                        p.TanggalPembelian.ToString("dd/MM/yyyy"),
                        p.TanggalPermintaan.ToString("dd/MM/yyyy"),
                        p.StatusPembayaran
                    );
                }

                dgvPermintaan.DataSource = tabel;
                // Ubah kolom terakhir menjadi ComboBox
                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                combo.HeaderText = "Status Pembayaran";
                combo.Items.Add("Menunggu Konfirmasi");
                combo.Items.Add("Sudah Dibayar");
                combo.Items.Add("Belum Dibayar");
                combo.DataPropertyName = "Status Pembayaran";
                combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                combo.FlatStyle = FlatStyle.Popup;

                // Hapus kolom teks lama (kolom paling akhir)
                dgvPermintaan.Columns.RemoveAt(6);

                // Tambahkan combobox ke kolom 6
                dgvPermintaan.Columns.Insert(6, combo);


                AturStyleDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data permintaan susu.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Styling DGV biar rapih
        private void AturStyleDGV()
        {
            dgvPermintaan.EnableHeadersVisualStyles = false;
            dgvPermintaan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 60, 130);
            dgvPermintaan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPermintaan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvPermintaan.RowTemplate.Height = 32;
            dgvPermintaan.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvPermintaan.DefaultCellStyle.ForeColor = Color.Black;
            dgvPermintaan.DefaultCellStyle.BackColor = Color.White;
            dgvPermintaan.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvPermintaan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        //              NAVIGASI MENU BUTTON
        // ============================================================
        private void BtnHalamanAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_HalBerandaAdmin(_user));
        }

        private void BtnAkunAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_AkunAdmin(_user));
        }

        private void BtnStokAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_MembuatProdukSusu(_user));
        }

        private void BtnPermintaanAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_PermintaanSusu(_user));
            
        }

        private void BtnLaporanPenjualan_Click(object sender, EventArgs e)
        {

        }

        private void dgvPermintaan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void V_PermintaanSusu_Load_1(object sender, EventArgs e)
        {

        }
    }
}
