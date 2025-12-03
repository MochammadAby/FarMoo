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
        private readonly M_StokBatch _stokAwal;

        private readonly C_Produk _produkController = new C_Produk();
        private readonly C_Stok _stokController = new C_Stok();

        // buffer gambar di RAM
        private byte[] _previewImageBytes;

        public V_EditProduk(AppUser user, M_StokBatch stok)
        {
            _user = user;
            _stokAwal = stok;

            InitializeComponent();

            // event
            btnSimpan.Click += btnSimpan_Click;
            btnBatal.Click += btnBatal_Click;

            picPreview.Cursor = Cursors.Hand;
            picPreview.Click += picPreview_Click;

            // isi combo + isi field
            LoadJenisBotol();
            IsiFormDariModel();
        }

        // ==================== ISI FORM DARI MODEL ====================

        private void IsiFormDariModel()
        {
            txtNamaProduk.Text = _stokAwal.NamaProduk ?? "";
            numHarga.Text = _stokAwal.Harga.ToString();
            umJumlahBotol.Text = _stokAwal.JumlahBotol.ToString();

            dtpTanggalProduksi.Value = _stokAwal.TanggalProduksi;
            dtpTanggalExpired.Value = _stokAwal.TanggalExpired;

            // gambar
            if (_stokAwal.Images != null && _stokAwal.Images.Length > 0)
            {
                _previewImageBytes = _stokAwal.Images;
                picPreview.Image = ImageHelper.BinaryToImage(_previewImageBytes);
                picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            }

            // pilih item combobox sesuai jenis / satuan ml

            for (int i = 0; i < cmbJenisBotol.Items.Count; i++)
            {
                var item = (JenisBotolItem)cmbJenisBotol.Items[i];

                // kalau SatuanMl di M_StokBatch bertipe int?
                if (_stokAwal != null && item.SatuanMl == _stokAwal.SatuanMl)
                {
                    cmbJenisBotol.SelectedIndex = i;
                    break;
                }

                // kalau bertipe int biasa, pakai ini
                // if (item.SatuanMl == _stokAwal.SatuanMl)
                // {
                //     cmbJenisBotol.SelectedIndex = i;
                //     break;
                //
            }
        }
        // ==================== LOAD JENIS BOTOL ====================

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

                if (cmbJenisBotol.Items.Count > 0 && cmbJenisBotol.SelectedIndex < 0)
                    cmbJenisBotol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat jenis botol: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class JenisBotolItem
        {
            public int JenisId { get; set; }
            public string NamaJenis { get; set; } = string.Empty;
            public int SatuanMl { get; set; }

            public override string ToString() => $"{NamaJenis} - {SatuanMl} ml";
        }

        // ==================== PREVIEW GAMBAR ====================

        private void picPreview_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg",
                Title = "Pilih Gambar Produk"
            };

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

        // ==================== SIMPAN ====================

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                string namaProduk = txtNamaProduk.Text.Trim();
                if (string.IsNullOrWhiteSpace(namaProduk))
                {
                    MessageBox.Show("Nama produk harus diisi.", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbJenisBotol.SelectedItem == null)
                {
                    MessageBox.Show("Pilih jenis botol.", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(numHarga.Text, out int harga))
                {
                    MessageBox.Show("Harga per botol harus angka.", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(umJumlahBotol.Text, out int jumlahBotol))
                {
                    MessageBox.Show("Jumlah botol harus angka.", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_previewImageBytes == null || _previewImageBytes.Length == 0)
                {
                    MessageBox.Show("Gambar produk belum dipilih.", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var itemJenis = (JenisBotolItem)cmbJenisBotol.SelectedItem;
                int jenisId = itemJenis.JenisId;
                int satuanMl = itemJenis.SatuanMl;

                DateTime tglProduksi = dtpTanggalProduksi.Value.Date;
                DateTime tglExpired = dtpTanggalExpired.Value.Date;

                // --- update produk ---
                var produk = new M_ProdukSusu
                {
                    ProdukId = _stokAwal.ProdukId,
                    JenisId = jenisId,
                    NamaProduk = namaProduk,
                    SatuanMl = satuanMl,
                    Harga = harga,
                    Images = _previewImageBytes
                };
                _produkController.UpdateProduk(produk);

                // --- update stok_batch ---
                var stokBaru = new M_StokBatch
                {
                    StokId = _stokAwal.StokId,
                    ProdukId = _stokAwal.ProdukId,
                    TanggalProduksi = tglProduksi,
                    JumlahBotol = jumlahBotol,
                    TanggalExpired = tglExpired
                };
                _stokController.UpdateStokBatch(stokBaru);

                MessageBox.Show("Produk & stok berhasil diperbarui.",
                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui produk/stok: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
