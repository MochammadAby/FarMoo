using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using Project_PBO___FarMoo.Database;

namespace Project_PBO___FarMoo.Controllers
{
    internal class C_LaporanPenjualan
    {
        public DataTable GetLaporanPenjualan()
        {
            using var db = new DbContext();
            db.Open();

            string query = @"
        SELECT 
    ROW_NUMBER() OVER (ORDER BY t.transaksi_id) AS nomor,
    t.transaksi_id,
    a.nama_lengkap,
    t.tanggal_transaksi,
    p.nama_produk,
    d.jumlah,
    d.subtotal,
    t.total_harga
    FROM detail_transaksi d
    JOIN produk_susu p ON d.produk_id = p.produk_id
    JOIN transaksi t ON d.transaksi_id = t.transaksi_id
    JOIN akun a ON t.user_id = a.user_id
    WHERE t.status_transaksi = 'Selesai'
    ORDER BY t.transaksi_id;
";

            using var cmd = new NpgsqlCommand(query, db.Connection);
            using var da = new NpgsqlDataAdapter(cmd);

            DataTable dtResult = new DataTable();
            da.Fill(dtResult);

            return dtResult;
        }
    }
}
