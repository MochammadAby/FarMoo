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
        public int BuatTransaksi(AppUser user, List<M_DetailTransaksi> detailList)
        {
            if (detailList == null || detailList.Count == 0)
                throw new ArgumentException("Detail transaksi kosong.");

            using var db = new DbContext();
            db.Open();
            using var tx = db.Connection.BeginTransaction();

            try
            {
                int total = detailList.Sum(d => d.Subtotal);

                const string sqlHeader = @"
                    INSERT INTO transaksi (user_id, tanggal_transaksi, total_harga, status_transaksi)
                    VALUES (@user_id, @tanggal, @total, @status)
                    RETURNING transaksi_id;";

                int transaksiId;
                using (var cmdHeader = new NpgsqlCommand(sqlHeader, db.Connection, tx))
                {
                    cmdHeader.Parameters.AddWithValue("@user_id", user.UserId);
                    cmdHeader.Parameters.AddWithValue("@tanggal", DateTime.Today);
                    cmdHeader.Parameters.AddWithValue("@total", total);
                    cmdHeader.Parameters.AddWithValue("@status", "Menunggu");
                    transaksiId = Convert.ToInt32(cmdHeader.ExecuteScalar());
                }

                const string sqlDetail = @"
                    INSERT INTO detail_transaksi (transaksi_id, produk_id, jumlah, subtotal)
                    VALUES (@transaksi_id, @produk_id, @jumlah, @subtotal);";

                const string sqlUpdateStok = @"
                    UPDATE stok_batch
                    SET jumlah_botol = jumlah_botol - @qty
                    WHERE stok_id = @stok_id;";

                foreach (var d in detailList)
                {
                    // insert detail
                    using (var cmdDetail = new NpgsqlCommand(sqlDetail, db.Connection, tx))
                    {
                        cmdDetail.Parameters.AddWithValue("@transaksi_id", transaksiId);
                        cmdDetail.Parameters.AddWithValue("@produk_id", d.ProdukId);
                        cmdDetail.Parameters.AddWithValue("@jumlah", d.Jumlah);
                        cmdDetail.Parameters.AddWithValue("@subtotal", d.Subtotal);
                        cmdDetail.ExecuteNonQuery();
                    }

                    // kurangi stok di batch terkait
                    using (var cmdStok = new NpgsqlCommand(sqlUpdateStok, db.Connection, tx))
                    {
                        cmdStok.Parameters.AddWithValue("@qty", d.Jumlah);
                        cmdStok.Parameters.AddWithValue("@stok_id", d.StokId);
                        cmdStok.ExecuteNonQuery();
                    }
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
