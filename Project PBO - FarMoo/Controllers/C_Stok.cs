using Npgsql;
using Project_PBO___FarMoo.Database;
using Project_PBO___FarMoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO___FarMoo.Controllers
{
    internal class C_Stok
    {
        // INSERT stok_batch
        public int InsertStokBatch(M_StokBatch stok)
        {
            using var db = new DbContext();
            db.Open();
            using var transaksi = db.Connection.BeginTransaction();
            try
            {
                const string sql = @"
                    INSERT INTO stok_batch (produk_id, tanggal_produksi, jumlah_botol, tanggal_expired)
                    VALUES (@produk_id, @tanggal_produksi, @jumlah_botol, @tanggal_expired)
                    RETURNING stok_id;";

                using var perintah = new NpgsqlCommand(sql, db.Connection, transaksi);
                perintah.Parameters.AddWithValue("@produk_id", stok.ProdukId);
                perintah.Parameters.AddWithValue("@tanggal_produksi", stok.TanggalProduksi);
                perintah.Parameters.AddWithValue("@jumlah_botol", stok.JumlahBotol);
                perintah.Parameters.AddWithValue("@tanggal_expired", stok.TanggalExpired);

                int stokId = Convert.ToInt32(perintah.ExecuteScalar());

                transaksi.Commit();
                return stokId;
            }
            catch
            {
                transaksi.Rollback();
                throw;
            }
        }

        // Ambil daftar stok batch terbaru (join dengan produk_susu) untuk ditampilkan di UI
        public List<M_StokBatch> GetStokBatchTerbaru(int batas = 50)
        {
            var daftarStok = new List<M_StokBatch>();

            using var db = new DbContext();
            db.Open();

            const string sql = @"
                SELECT s.stok_id,s.produk_id, s.tanggal_produksi, s.jumlah_botol, s.tanggal_expired, p.nama_produk, p.satuan_ml,p.harga, p.image AS images
                FROM stok_batch s
                JOIN produk_susu p ON p.produk_id = s.produk_id
                ORDER BY s.stok_id DESC
                LIMIT @batas;";

            using var perintah = new NpgsqlCommand(sql, db.Connection);
            perintah.Parameters.AddWithValue("@batas", batas);

            using var pembaca = perintah.ExecuteReader();
            while (pembaca.Read())
            {
                var stok = new M_StokBatch
                {
                    StokId = pembaca.GetInt32(pembaca.GetOrdinal("stok_id")),
                    ProdukId = pembaca.GetInt32(pembaca.GetOrdinal("produk_id")),
                    TanggalProduksi = pembaca.GetDateTime(pembaca.GetOrdinal("tanggal_produksi")),
                    JumlahBotol = pembaca.GetInt32(pembaca.GetOrdinal("jumlah_botol")),
                    TanggalExpired = pembaca.GetDateTime(pembaca.GetOrdinal("tanggal_expired")),
                    NamaProduk = pembaca.GetString(pembaca.GetOrdinal("nama_produk")),
                    SatuanMl = pembaca.GetInt32(pembaca.GetOrdinal("satuan_ml")),   // hapus jika kolomnya ga ada
                    Harga = pembaca.GetInt32(pembaca.GetOrdinal("harga")),
                    Images = pembaca.IsDBNull(pembaca.GetOrdinal("images"))
                                      ? null
                                      : pembaca.GetFieldValue<byte[]>(pembaca.GetOrdinal("images"))
                };

                daftarStok.Add(stok);
            }

            return daftarStok;

        }
        public void UpdateStokBatch(M_StokBatch stok)
        {
            using var db = new DbContext();
            db.Open();

            const string sql = @"
            UPDATE stok_batch
            SET tanggal_produksi = @tanggal_produksi,
            jumlah_botol     = @jumlah_botol,
            tanggal_expired  = @tanggal_expired
            WHERE stok_id = @stok_id;";

            using var cmd = new NpgsqlCommand(sql, db.Connection);
            cmd.Parameters.AddWithValue("@stok_id", stok.StokId);
            cmd.Parameters.AddWithValue("@tanggal_produksi", stok.TanggalProduksi);
            cmd.Parameters.AddWithValue("@jumlah_botol", stok.JumlahBotol);
            cmd.Parameters.AddWithValue("@tanggal_expired", stok.TanggalExpired);

            cmd.ExecuteNonQuery();
        }

        public bool DeleteStokById(int stokId)
        {
            using var db = new DbContext();
            db.Open();

            const string sql = @"DELETE FROM stok_batch WHERE stok_id = @id;";

            using var cmd = new NpgsqlCommand(sql, db.Connection);
            cmd.Parameters.AddWithValue("@id", stokId);

            int rows = cmd.ExecuteNonQuery();
            return rows > 0;  // true jika berhasil
        }
    }
}
