using System;
using System.Data;
using System.Windows.Forms;
using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Models;
using AppUser = Project_PBO___FarMoo.Models.User;

namespace Project_PBO___FarMoo.Views.Tengkulak.Fitur_riwayat_pembelian
{
    public partial class V_RiwayatPembelian : Form
    {
        private readonly AppUser _user;
        private readonly C_Transaksi _transaksi = new C_Transaksi();

        // constructor yang dipakai waktu pindah halaman
        public V_RiwayatPembelian(AppUser user) : this()
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }

        // constructor default untuk Designer – JANGAN dihapus
        public V_RiwayatPembelian()
        {
            InitializeComponent();
            this.Load += V_RiwayatPembelian_Load;
        }

        private void V_RiwayatPembelian_Load(object? sender, EventArgs e)
        {

            KonfigurasiGrid();
            MuatData();
        }

        private void KonfigurasiGrid()
        {
            dgvRiwayat.ReadOnly = true;
            dgvRiwayat.AllowUserToAddRows = false;
            dgvRiwayat.RowHeadersVisible = false;
            dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void MuatData()
        {
            if (_user == null) return;   // biar aman kalau kebuka dari designer

            try
            {
                var table = _transaksi.GetRiwayatPembelianTable(_user.UserId);

                dgvRiwayat.AutoGenerateColumns = true;
                dgvRiwayat.DataSource = table;

                // DEBUG: lihat dulu ada baris apa nggak
                // MessageBox.Show($"Rows: {table.Rows.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat: " + ex.Message);
            }
        }
    }
}