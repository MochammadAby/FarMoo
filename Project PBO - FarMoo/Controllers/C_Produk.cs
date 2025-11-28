using Npgsql;
using NpgsqlTypes;
using Project_PBO___FarMoo.Database;
using Project_PBO___FarMoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO___FarMoo.Controllers
{
    internal class C_Produk
    {
        public List<(int jenis_id, string nama_jenis, int satuan_ml)> GetJenisBotol()
        {
            var res = new List<(int, string, int)>();
            using var db = new DbContext();
            db.Open();

            const string sql = "SELECT jenis_id, nama_jenis, satuan_ml FROM jenis_botol ORDER BY nama_jenis, satuan_ml;";
            using var cmd = new NpgsqlCommand(sql, db.Connection);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                res.Add((
                    r.GetInt32(r.GetOrdinal("jenis_id")),
                    r.GetString(r.GetOrdinal("nama_jenis")),
                    r.GetInt32(r.GetOrdinal("satuan_ml"))
                ));
            }
            return res;
        }

        public M_ProdukSusu? GetProdukByNameAndJenis(string namaProduk, int jenisId)
        {
            using var db = new DbContext();
            db.Open();
            const string sql = @"
            SELECT produk_id, jenis_id, nama_produk, satuan_ml, harga, image AS images
            FROM produk_susu
            WHERE lower(nama_produk) = lower(@nama) AND jenis_id = @jenis
            LIMIT 1;";
            using var cmd = new NpgsqlCommand(sql, db.Connection);
            cmd.Parameters.AddWithValue("@nama", namaProduk);
            cmd.Parameters.AddWithValue("@jenis", jenisId);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            return new M_ProdukSusu
            {
                ProdukId = r.GetInt32(r.GetOrdinal("produk_id")),
                JenisId = r.GetInt32(r.GetOrdinal("jenis_id")),
                NamaProduk = r.GetString(r.GetOrdinal("nama_produk")),
                SatuanMl = r.GetInt32(r.GetOrdinal("satuan_ml")),
                Harga = r.GetInt32(r.GetOrdinal("harga")),
                Images = r.IsDBNull(r.GetOrdinal("images"))
                    ? null
                    : r.GetFieldValue<byte[]>(r.GetOrdinal("images"))
            };
        }

        public int InsertProduk(M_ProdukSusu p)
        {
            using var db = new DbContext();
            db.Open();
            const string sql = @"
            INSERT INTO produk_susu (jenis_id, nama_produk, satuan_ml, harga, image)
            VALUES (@jenis_id, @nama_produk, @satuan_ml, @harga, @images)
            RETURNING produk_id;";
            using var cmd = new NpgsqlCommand(sql, db.Connection);
            cmd.Parameters.AddWithValue("@jenis_id", p.JenisId);
            cmd.Parameters.AddWithValue("@nama_produk", p.NamaProduk);
            cmd.Parameters.AddWithValue("@satuan_ml", p.SatuanMl);
            cmd.Parameters.AddWithValue("@harga", p.Harga);
            cmd.Parameters.Add("@images", NpgsqlDbType.Bytea).Value = (object?)p.Images ?? DBNull.Value;

            var id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }

        public void UpdateProduk(M_ProdukSusu p)
        {
            using var db = new DbContext();
            db.Open();

            const string sql = @"
                UPDATE produk_susu
                SET nama_produk = @nama_produk,
                    harga       = @harga,
                    images      = @image
                WHERE produk_id = @produk_id;";

            using var cmd = new NpgsqlCommand(sql, db.Connection);
            cmd.Parameters.AddWithValue("@produk_id", p.ProdukId);
            cmd.Parameters.AddWithValue("@nama_produk", p.NamaProduk);
            cmd.Parameters.AddWithValue("@harga", p.Harga);
            cmd.Parameters.Add("@image", NpgsqlDbType.Bytea)
                          .Value = (object?)p.Images ?? DBNull.Value;

            cmd.ExecuteNonQuery();
        }
    }
}
