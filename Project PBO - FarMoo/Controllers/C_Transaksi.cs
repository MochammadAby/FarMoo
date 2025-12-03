using Npgsql;
using Project_PBO___FarMoo.Database;
using Project_PBO___FarMoo.Models;
using System;
using System.Collections.Generic;
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
                    cmdDetail.Parameters.AddWithValue("@harga", item.Harga);                      // <<< WAJIB
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
   
    }
}

