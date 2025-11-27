using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Project_PBO___FarMoo.Views.Admin.Fitur_stok_susu
{
    public partial class V_TambahProduk : Form
    {
        // gambar disimpan sementara di RAM
        private byte[] _previewImageBytes;

        private readonly C_Produk _produkController = new C_Produk();
        private readonly C_Stok _stokController = new C_Stok();

        public V_TambahProduk()
        {
            InitializeComponent();

            // Jadikan picturebox sebagai tombol upload gambar
            picPreview.Cursor = Cursors.Hand;
            picPreview.Click += picPreview_Click;

            btnSimpan.Click += btnSimpan_Click;
            btnBatal.Click += btnBatal_Click;
        }

        private void V_TambahProduk_Load(object sender, EventArgs e)
        {
            btnSimpan.Text = "Simpan";
            btnBatal.Text = "Batal";

            LoadJenisBotol();
        }

        // ======================= PREVIEW GAMBAR =========================

        private void picPreview_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg";
                ofd.Title = "Pilih Gambar Produk";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                using (var img = Image.FromFile(ofd.FileName))
                {
                    // simpan ke RAM, belum ke DB
                    _previewImageBytes = ImageHelper.ImageToBinary(img);
                }

                // tampilkan di picturebox
                if (picPreview.Image != null)
                    picPreview.Image.Dispose();

                picPreview.Image = ImageHelper.BinaryToImage(_previewImageBytes);
                picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // ======================= SIMPAN =========================

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                string namaProduk = txtNamaProduk.Text.Trim();
                if (string.IsNullOrWhiteSpace(namaProduk))
                {
                    MessageBox.Show("Nama produk harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbJenisBotol.SelectedItem == null)
                {
                    MessageBox.Show("Pilih jenis botol.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                var itemJenis = (JenisBotolItem)cmbJenisBotol.SelectedItem;
                int jenisId = itemJenis.JenisId;
                int satuanMl = itemJenis.SatuanMl;

                DateTime tglProduksi = dtpTanggalProduksi.Value.Date;
                DateTime tglExpired = dtpTanggalExpired.Value.Date;

                // 1. cari produk existing berdasarkan nama + jenis
                var existing = _produkController.GetProdukByNameAndJenis(namaProduk, jenisId);
                int produkId;

                if (existing is null)   // pakai 'is null' biar aman
                {
                    // produk baru
                    var p = new M_ProdukSusu
                    {
                        JenisId = jenisId,
                        NamaProduk = namaProduk,
                        SatuanMl = satuanMl,
                        Harga = harga,
                        Images = _previewImageBytes
                    };

                    produkId = _produkController.InsertProduk(p);
                }
                else
                {
                    // produk sudah ada → pakai produk_id existing
                    produkId = existing.ProdukId;
                }

                // 2. insert stok_batch
                var stok = new M_StokBatch
                {
                    ProdukId = produkId,
                    TanggalProduksi = tglProduksi,
                    JumlahBotol = jumlahBotol,
                    TanggalExpired = tglExpired
                };

                _stokController.InsertStokBatch(stok);


                MessageBox.Show("Produk & stok berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan produk/stok: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ======================= LOAD JENIS BOTOL =========================

        private void LoadJenisBotol()
        {
            try
            {
                cmbJenisBotol.Items.Clear();

                var list = _produkController.GetJenisBotol();
                foreach (var (jenis_id, nama_jenis, satuan_ml) in list)
                {
                    cmbJenisBotol.Items.Add(new JenisBotolItem
                    {
                        JenisId = jenis_id,
                        NamaJenis = nama_jenis,
                        SatuanMl = satuan_ml
                    });
                }

                if (cmbJenisBotol.Items.Count > 0)
                    cmbJenisBotol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat jenis botol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Item wrapper untuk combobox
        private class JenisBotolItem
        {
            public int JenisId { get; set; }
            public string NamaJenis { get; set; } = string.Empty;
            public int SatuanMl { get; set; }

            public override string ToString() => $"{NamaJenis} - {SatuanMl} ml";
        }
    }
}
