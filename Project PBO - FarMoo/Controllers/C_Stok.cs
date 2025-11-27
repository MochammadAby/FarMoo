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
        public int InsertStokBatch(M_StokBatch s)
        {
            using var db = new DbContext();
            db.Open();
            using var tx = db.Connection.BeginTransaction();
            try
            {
                const string sql = @"
                    INSERT INTO stok_batch (produk_id, tanggal_produksi, jumlah_botol, tanggal_expired)
                    VALUES (@produk_id, @tanggal_produksi, @jumlah_botol, @tanggal_expired)
                    RETURNING stok_id;";
                using var cmd = new NpgsqlCommand(sql, db.Connection, tx);
                cmd.Parameters.AddWithValue("@produk_id", s.ProdukId);
                cmd.Parameters.AddWithValue("@tanggal_produksi", s.TanggalProduksi);
                cmd.Parameters.AddWithValue("@jumlah_botol", s.JumlahBotol);
                cmd.Parameters.AddWithValue("@tanggal_expired", s.TanggalExpired);

                int stokId = Convert.ToInt32(cmd.ExecuteScalar());

                tx.Commit();
                return stokId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public List<M_StokBatch> GetLatestStokBatches(int limit = 50)
        {
            var res = new List<M_StokBatch>();
            using var db = new DbContext();
            db.Open();
            const string sql = @"
                SELECT s.stok_id, s.produk_id, s.tanggal_produksi, s.jumlah_botol, s.tanggal_expired,
                       p.nama_produk, p.satuan_ml, p.harga, p.images
                FROM stok_batch s
                JOIN produk_susu p ON p.produk_id = s.produk_id
                ORDER BY s.stok_id DESC
                LIMIT @limit;";
            using var cmd = new NpgsqlCommand(sql, db.Connection);
            cmd.Parameters.AddWithValue("@limit", limit);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                var sb = new M_StokBatch
                {
                    StokId = r.GetInt32(r.GetOrdinal("stok_id")),
                    ProdukId = r.GetInt32(r.GetOrdinal("produk_id")),
                    TanggalProduksi = r.GetDateTime(r.GetOrdinal("tanggal_produksi")),
                    JumlahBotol = r.GetInt32(r.GetOrdinal("jumlah_botol")),
                    TanggalExpired = r.GetDateTime(r.GetOrdinal("tanggal_expired")),
                    NamaProduk = r.GetString(r.GetOrdinal("nama_produk")),
                    SatuanMl = r.GetInt32(r.GetOrdinal("satuan_ml")),
                    Harga = r.GetInt32(r.GetOrdinal("harga")),
                    Images = r.IsDBNull(r.GetOrdinal("images"))
                        ? null
                        : r.GetFieldValue<byte[]>(r.GetOrdinal("images"))
                };
                res.Add(sb);
            }
            return res;
        }
    }
}

