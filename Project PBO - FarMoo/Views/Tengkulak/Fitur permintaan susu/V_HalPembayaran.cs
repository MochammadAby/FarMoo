using Project_PBO___FarMoo.Models;
using AppUser = Project_PBO___FarMoo.Models.User;
using Npgsql;
using Project_PBO___FarMoo.Database;
using Project_PBO___FarMoo.Helper;

namespace Project_PBO___FarMoo.Views.Tengkulak.Fitur_permintaan_susu
{
    public partial class V_HalPembayaran : Form
    {
        private readonly AppUser _user;
        private readonly List<M_CheckoutItem> _items;
        private int _total;

        public V_HalPembayaran(AppUser user, List<M_CheckoutItem> items)
        {
            _user = user;
            _items = items;

            InitializeComponent();

            this.Load += V_HalPembayaran_Load;
        }

        private void V_HalPembayaran_Load(object sender, EventArgs e)
        {
            flpRingkasan.Controls.Clear();  

            _total = 0;

            foreach (var item in _items)
            {
                // ===== hitung total =====
                int subtotal = item.Subtotal;
                _total += subtotal;

                // ===== panel card =====
                var card = new Panel
                {
                    Width = 400,
                    Height = 140,
                    BackColor = Color.FromArgb(0, 70, 150),
                    Margin = new Padding(10)
                };

                // gambar kiri
                var pic = new PictureBox
                {
                    Width = 80,
                    Height = 110,
                    Location = new Point(10, 15),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                if (item.ImageBytes != null && item.ImageBytes.Length > 0)
                {
                    pic.Image = ImageHelper.BinaryToImage(item.ImageBytes);
                }

                // Nama + jenis botol (1 baris)
                var lblNamaJenis = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    Location = new Point(100, 10),
                    Text = $"{item.NamaProduk} - {item.JenisBotol} {item.SatuanMl} ml"
                };

                // Harga + jumlah (1 baris)
                var lblHargaJumlah = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9f),
                    Location = new Point(100, 40),
                    Text = $"Harga: Rp {item.Harga:N0} x {item.Jumlah}"
                };

                // Subtotal
                var lblSubtotal = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    Location = new Point(100, 70),
                    Text = $"Subtotal: Rp {subtotal:N0}"
                };

                card.Controls.Add(pic);
                card.Controls.Add(lblNamaJenis);
                card.Controls.Add(lblHargaJumlah);
                card.Controls.Add(lblSubtotal);

                flpRingkasan.Controls.Add(card);
            }

            // tampilkan total di label
            lblTotal.Text = $"Total: Rp {_total:N0}";

            // default tanggal pengambilan = besok
            dtpTanggalPengambilan.Value = DateTime.Today.AddDays(1);
        }

        private void BtnBayar_Click(object sender, EventArgs e)
        {
            // validasi tanggal pengambilan
            DateTime tglPengambilan = dtpTanggalPengambilan.Value.Date;
            if (tglPengambilan < DateTime.Today)
            {
                MessageBox.Show("Tanggal pengambilan tidak boleh di masa lalu.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validasi jumlah bayar
            // validasi jumlah bayar
            if (!int.TryParse(txtJumlahPembayaran.Text.Trim(), out int jumlahBayar))
            {
                MessageBox.Show("Jumlah pembayaran harus berupa angka.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (jumlahBayar < _total)
            {
                MessageBox.Show(
                    $"Uang yang dibayarkan kurang.\n" +
                    $"Total: Rp {_total:N0}\n" +
                    $"Dibayar: Rp {jumlahBayar:N0}",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new DbContext();
                db.Open();

                using var tx = db.Connection.BeginTransaction();

                // 1. INSERT ke transaksi
                const string sqlTrans = @"
                INSERT INTO transaksi
                (user_id, tanggal_transaksi, total_harga, status_transaksi, tanggal_pengambilan)
                VALUES (@user_id, @tgl_trans, @total, @status, @tgl_ambil)
                RETURNING transaksi_id;";

                int transaksiId;
                using (var cmd = new NpgsqlCommand(sqlTrans, db.Connection, tx))
                {
                    cmd.Parameters.AddWithValue("@user_id", _user.UserId);
                    cmd.Parameters.AddWithValue("@tgl_trans", DateTime.Today);
                    cmd.Parameters.AddWithValue("@total", _total);
                    cmd.Parameters.AddWithValue("@status", "Menunggu Konfirmasi");
                    cmd.Parameters.AddWithValue("@tgl_ambil", tglPengambilan);

                    transaksiId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2. INSERT detail + update stok
                const string sqlDetail = @"
                INSERT INTO detail_transaksi
                (produk_id, transaksi_id, stok_id, harga, jumlah, subtotal, is_delete)
                VALUES
                (@produk_id, @transaksi_id, @stok_id, @harga, @jumlah, @subtotal, FALSE);";

                const string sqlUpdateStok = @"
                UPDATE stok_batch
                SET jumlah_botol = jumlah_botol - @qty
                WHERE stok_id = @stok_id
                AND is_delete = FALSE;";

                foreach (var item in _items)
                {
                    int subtotal = item.Subtotal; // = item.Harga * item.Jumlah

                    using (var cmdDet = new NpgsqlCommand(sqlDetail, db.Connection, tx))
                    {
                        cmdDet.Parameters.AddWithValue("@produk_id", item.ProdukId);
                        cmdDet.Parameters.AddWithValue("@transaksi_id", transaksiId);
                        cmdDet.Parameters.AddWithValue("@stok_id", item.StokId);   // <<< TAMBAHAN PENTING
                        cmdDet.Parameters.AddWithValue("@harga", item.Harga);
                        cmdDet.Parameters.AddWithValue("@jumlah", item.Jumlah);
                        cmdDet.Parameters.AddWithValue("@subtotal", subtotal);
                        cmdDet.ExecuteNonQuery();
                    }

                    using (var cmdStok = new NpgsqlCommand(sqlUpdateStok, db.Connection, tx))
                    {
                        cmdStok.Parameters.AddWithValue("@qty", item.Jumlah);
                        cmdStok.Parameters.AddWithValue("@stok_id", item.StokId);
                        cmdStok.ExecuteNonQuery();
                    }
                }

                tx.Commit();

                // ==== DI SINI TADI KOSONG, MAKANYA KAYAK GA NGAPA-NGAPAIN ====

                string pesan;
                if (jumlahBayar == _total)
                {
                    pesan =
                        $"Pembayaran berhasil.\n" +
                        $"Total: Rp {_total:N0}\n" +
                        $"Dibayar: Rp {jumlahBayar:N0}\n" +
                        $"Kembalian: Rp 0";
                }
                else // jumlahBayar > _total
                {
                    int kembalian = jumlahBayar - _total;
                    pesan =
                        $"Pembayaran berhasil.\n" +
                        $"Total: Rp {_total:N0}\n" +
                        $"Dibayar: Rp {jumlahBayar:N0}\n" +
                        $"Kembalian: Rp {kembalian:N0}";
                }

                MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memproses pembayaran:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnKembali_Click(object sender, EventArgs e) 
        {
            this.DialogResult = DialogResult.Cancel; // optional, default juga Cancel
            this.Close();
        }

    }
}

