using Npgsql;
using Project_PBO___FarMoo.Database;
using Project_PBO___FarMoo.Models;
using Project_PBO___FarMoo.Views.Admin.Fitur_Permintaan_Susu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AppUser = Project_PBO___FarMoo.Models.User;

namespace Project_PBO___FarMoo.Controllers
{
    internal class C_Transaksi
    {
        public int BuatTransaksi(User user, DateTime tglTransaksi, DateTime tglAmbil, List<M_CheckoutItem> items)
        {
            using var db = new DbContext();
            db.Open();
            using var tx = db.Connection.BeginTransaction();

            try
            {
                var total = items.Sum(i => i.Harga * i.Jumlah);

                const string sqlHeader = @"
                INSERT INTO transaksi   (user_id, tanggal_transaksi, total_harga, status_transaksi, tanggal_pengambilan)
                VALUES  (@user_id, @tgl_trans, @total, @status, @tgl_ambil)
                RETURNING transaksi_id;";

                using var cmdHeader = new NpgsqlCommand(sqlHeader, db.Connection, tx);
                cmdHeader.Parameters.AddWithValue("@user_id", user.UserId);
                cmdHeader.Parameters.AddWithValue("@tgl", tglTransaksi);
                cmdHeader.Parameters.AddWithValue("@total", total);
                cmdHeader.Parameters.AddWithValue("@status", "Menunggu");
                cmdHeader.Parameters.AddWithValue("@tgl_ambil", tglAmbil);

                int transaksiId = Convert.ToInt32(cmdHeader.ExecuteScalar());

                const string sqlDetail = @"
                INSERT INTO detail_transaksi (produk_id, transaksi_id, harga, jumlah, subtotal, is_delete)
                VALUES (@produk_susu, @transaksi_id, @harga, @jumlah, @subtotal, FALSE);";

                foreach (var item in items)
                {
                    using var cmdDetail = new NpgsqlCommand(sqlDetail, db.Connection, tx);
                    cmdDetail.Parameters.AddWithValue("@produk_susu", item.ProdukId);
                    cmdDetail.Parameters.AddWithValue("@transaksi_id", transaksiId);
                    cmdDetail.Parameters.AddWithValue("@harga", item.Harga);                     
                    cmdDetail.Parameters.AddWithValue("@jumlah", item.Jumlah);
                    cmdDetail.Parameters.AddWithValue("@subtotal", item.Harga * item.Jumlah);
                    cmdDetail.ExecuteNonQuery();
                }

                tx.Commit();
                return transaksiId;
            }

            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public DataTable GetRiwayatPembelianTable(int userId)
        {
            using var db = new DbContext();
            db.Open();

            const string sql = @"
        SELECT 
        t.transaksi_id      AS ""ID"",
        t.tanggal_transaksi AS ""Tanggal_transaksi"",
        t.total_harga       AS ""Total_transaksi"",
        p.nama_produk       AS ""Nama_produk"",
        d.harga             AS ""Harga"",
        d.jumlah            AS ""Jumlah_botol"",
        t.status_transaksi  AS ""Status_Transaksi""
        FROM transaksi t
        JOIN detail_transaksi d 
        ON d.transaksi_id = t.transaksi_id 
        AND d.is_delete = FALSE
        JOIN produk_susu p 
        ON p.produk_id = d.produk_id
        WHERE t.user_id = @uid
        ORDER BY t.tanggal_transaksi DESC, t.transaksi_id DESC;";


            using var cmd = new NpgsqlCommand(sql, db.Connection);
            cmd.Parameters.AddWithValue("@uid", userId);

            using var da = new NpgsqlDataAdapter(cmd);
            var table = new DataTable();
            da.Fill(table);
            return table;
        }

        public List<M_PermintaanSusu> GetSemuaPermintaanSusu()
        {
            var hasil = new List<M_PermintaanSusu>();

            using var db = new DbContext();
            db.Open();

            const string query = @"
                    SELECT 
                        dt.jumlah AS jumlah_botol,
                        p.nama_produk AS nama_produk,
                        p.satuan_ml AS volume,
                        dt.subtotal AS total_harga,
                        t.tanggal_transaksi AS tanggal_pembelian,
                        t.tanggal_pengambilan AS tanggal_permintaan,
                        t.status_transaksi AS status_pembayaran
                    FROM detail_transaksi dt
                    JOIN transaksi t ON dt.transaksi_id = t.transaksi_id
                    JOIN produk_susu p ON dt.produk_id = p.produk_id
                    WHERE dt.is_delete = FALSE
                    ORDER BY t.tanggal_transaksi DESC;
                ";

            using var cmd = new NpgsqlCommand(query, db.Connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                hasil.Add(new M_PermintaanSusu
                {
                    JumlahBotol = reader.GetInt32(0),
                    NamaProduk = reader.GetString(1),
                    Volume = reader.GetInt32(2),
                    TotalHarga = reader.GetDecimal(3),
                    TanggalPembelian = reader.GetDateTime(4),
                    TanggalPermintaan = reader.GetDateTime(5),
                    StatusPembayaran = reader.GetString(6)
                });
            }

            return hasil;
        }
        public bool BatalkanTransaksi(int transaksiId, int userId)
        {
            using var db = new DbContext();
            db.Open();

            const string sql = @"
                UPDATE transaksi
                SET status_transaksi = 'Dibatalkan'
                WHERE transaksi_id = @id
                  AND user_id = @uid
                  AND status_transaksi = 'Menunggu Konfirmasi';";

            using var cmd = new NpgsqlCommand(sql, db.Connection);
            cmd.Parameters.AddWithValue("@id", transaksiId);
            cmd.Parameters.AddWithValue("@uid", userId);

            int rows = cmd.ExecuteNonQuery();
            return rows > 0;   // true kalau memang ada yang ke-update
        }
        public bool BatalkanTransaksiDenganRollback(int transaksiId, int userId)
        {
            using var db = new DbContext();
            db.Open();

            using var tx = db.Connection.BeginTransaction();

            // 1. Pastikan transaksi milik user ini & masih bisa dibatalkan
            const string sqlCek = @"
                SELECT status_transaksi
                FROM transaksi
                WHERE transaksi_id = @id AND user_id = @uid
                FOR UPDATE;";

            string? statusSekarang;
            using (var cmdCek = new NpgsqlCommand(sqlCek, db.Connection, tx))
            {
                cmdCek.Parameters.AddWithValue("@id", transaksiId);
                cmdCek.Parameters.AddWithValue("@uid", userId);

                statusSekarang = cmdCek.ExecuteScalar()?.ToString();
            }

            if (statusSekarang == null || !statusSekarang.Equals("Menunggu Konfirmasi", StringComparison.OrdinalIgnoreCase))
            {
                tx.Rollback();
                return false; // tidak bisa dibatalkan
            }

            // 2. Ambil detail transaksi (stok_id + jumlah)
            const string sqlDetail = @"
                SELECT stok_id, jumlah
                FROM detail_transaksi
                WHERE transaksi_id = @id
                  AND is_delete = FALSE;";

            var daftarDetail = new List<(long stokId, int jumlah)>();

            using (var cmdDet = new NpgsqlCommand(sqlDetail, db.Connection, tx))
            {
                cmdDet.Parameters.AddWithValue("@id", transaksiId);
                using var reader = cmdDet.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(0)) continue; // stok_id null -> skip (data lama)

                    long stokId = reader.GetInt64(0);
                    int jumlah = reader.GetInt32(1);
                    daftarDetail.Add((stokId, jumlah));
                }
            }

            // 3. Kembalikan stok ke masing-masing batch
            const string sqlUpdateStok = @"
                UPDATE stok_batch
                SET jumlah_botol = jumlah_botol + @qty
                WHERE stok_id = @stok_id
                  AND is_delete = FALSE;";

            foreach (var d in daftarDetail)
            {
                using var cmdStok = new NpgsqlCommand(sqlUpdateStok, db.Connection, tx);
                cmdStok.Parameters.AddWithValue("@qty", d.jumlah);
                cmdStok.Parameters.AddWithValue("@stok_id", d.stokId);
                cmdStok.ExecuteNonQuery();
            }

            // 4. Ubah status transaksi jadi Dibatalkan
            const string sqlUpdateTrans = @"
                UPDATE transaksi
                SET status_transaksi = 'Dibatalkan'
                WHERE transaksi_id = @id;";

            using (var cmdUpd = new NpgsqlCommand(sqlUpdateTrans, db.Connection, tx))
            {
                cmdUpd.Parameters.AddWithValue("@id", transaksiId);
                cmdUpd.ExecuteNonQuery();
            }

            tx.Commit();
            return true;
        }
    }
}


