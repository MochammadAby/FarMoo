using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using AppUser = Project_PBO___FarMoo.Models.User;

namespace Project_PBO___FarMoo.Views.Admin.Fitur_stok_susu
{
    public partial class V_EditProduk : Form
    {
        private readonly AppUser _user;
        private readonly M_StokBatch _stokLama;

        private readonly C_Produk _produkController = new C_Produk();
        private readonly C_Stok _stokController = new C_Stok();

        private byte[]? _previewImageBytes;   // gambar sementara di RAM

        public V_EditProduk(AppUser user, M_StokBatch stokLama)
        {
            _user = user;
            _stokLama = stokLama;

            InitializeComponent();

            btnSimpan.Click += btnSimpan_Click;
            btnBatal.Click += btnBatal_Click;
            picPreview.Click += picPreview_Click;
            this.Load += V_EditProduk_Load;
        }

        private void V_EditProduk_Load(object? sender, EventArgs e)
        {
            // Kalau kamu mau, bisa panggil LoadJenisBotol(); tapi combobox bisa di-disable kalau jenis tidak boleh diubah
            cmbJenisBotol.Enabled = false; // misal: jenis botol tidak diubah lewat form ini

            // Prefill data dari stok & produk
            txtNamaProduk.Text = _stokLama.NamaProduk ?? "";
            numHarga.Text = _stokLama.Harga?.ToString() ?? "";
            umJumlahBotol.Text = _stokLama.JumlahBotol.ToString();
            dtpTanggalProduksi.Value = _stokLama.TanggalProduksi;
            dtpTanggalExpired.Value = _stokLama.TanggalExpired;

            if (_stokLama.Images != null && _stokLama.Images.Length > 0)
            {
                _previewImageBytes = _stokLama.Images;
                picPreview.Image = ImageHelper.BinaryToImage(_stokLama.Images);
                picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // === pilih ulang gambar ===
        private void picPreview_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg";
            ofd.Title = "Pilih Gambar Produk";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            using (var img = Image.FromFile(ofd.FileName))
            {
                _previewImageBytes = ImageHelper.ImageToBinary(img);
            }

            if (picPreview.Image != null)
                picPreview.Image.Dispose();

            picPreview.Image = ImageHelper.BinaryToImage(_previewImageBytes);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // === SIMPAN (UPDATE) ===
        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            try
            {
                string namaProduk = txtNamaProduk.Text.Trim();
                if (string.IsNullOrWhiteSpace(namaProduk))
                {
                    MessageBox.Show("Nama produk harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(numHarga.Text, out int harga))
                {
                    MessageBox.Show("Harga per botol harus berupa angka.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(umJumlahBotol.Text, out int jumlahBotol))
                {
                    MessageBox.Show("Jumlah botol harus berupa angka.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_previewImageBytes == null || _previewImageBytes.Length == 0)
                {
                    MessageBox.Show("Gambar produk belum dipilih.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime tglProduksi = dtpTanggalProduksi.Value.Date;
                DateTime tglExpired = dtpTanggalExpired.Value.Date;

                // 1. UPDATE produk_susu
                var produkBaru = new M_ProdukSusu
                {
                    ProdukId = _stokLama.ProdukId,
                    NamaProduk = namaProduk,
                    Harga = harga,
                    Images = _previewImageBytes
                    // JenisId / SatuanMl dibiarkan seperti semula
                };

                _produkController.UpdateProduk(produkBaru);

                // 2. UPDATE stok_batch
                var stokBaru = new M_StokBatch
                {
                    StokId = _stokLama.StokId,
                    ProdukId = _stokLama.ProdukId,
                    TanggalProduksi = tglProduksi,
                    JumlahBotol = jumlahBotol,
                    TanggalExpired = tglExpired
                };

                _stokController.UpdateStokBatch(stokBaru);

                MessageBox.Show("Produk & stok berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui produk/stok: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
