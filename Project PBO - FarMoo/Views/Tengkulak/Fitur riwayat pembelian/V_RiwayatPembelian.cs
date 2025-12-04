using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Models;
using Project_PBO___FarMoo.Views.Tengkulak.Fitur_permintaan_susu;
using System;
using System.Data;
using System.Windows.Forms;
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
            btnBatalPermintaan.Click += BtnBatalPermintaan_Click;
        }

        private void BatalkanTransaksi(int transaksiId, string status)
        {
            if (!status.Equals("Menunggu Konfirmasi", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Hanya transaksi dengan status 'Menunggu Konfirmasi' yang bisa dibatalkan.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var konfirmasi = MessageBox.Show(
                $"Batalkan transaksi ID {transaksiId}?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi != DialogResult.Yes)
                return;

            try
            {
                bool ok = _transaksi.BatalkanTransaksiDenganRollback(transaksiId, _user.UserId);
                if (!ok)
                {
                    MessageBox.Show(
                        "Transaksi sudah tidak bisa dibatalkan (mungkin statusnya sudah diproses).",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Transaksi berhasil dibatalkan dan stok dikembalikan.",
                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MuatData(); // refresh tabel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membatalkan transaksi: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBatalPermintaan_Click(object? sender, EventArgs e)
        {
            if (dgvRiwayat.CurrentRow == null)
            {
                MessageBox.Show("Pilih dulu transaksi yang mau dibatalkan.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ambil transaksi_id & status dari baris yang dipilih
            var row = dgvRiwayat.CurrentRow;

            if (!int.TryParse(row.Cells["ID"].Value?.ToString(), out int transaksiId))
            {
                MessageBox.Show("Gagal membaca ID transaksi dari tabel.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string status = row.Cells["Status_Transaksi"].Value?.ToString() ?? "";

            BatalkanTransaksi(transaksiId, status);
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

        private void btnAkun_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_Akun(_user));
        }

        private void btnBeranda_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new Halaman_Beranda(_user));
        }

        private void btnPermintaan_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_MembuatPermintaanTengkulak(_user));
        }
    }
}