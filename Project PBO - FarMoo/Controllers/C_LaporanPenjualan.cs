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
            t.transaksi_id,
            t.tanggal_transaksi,
            dt.produk_id,
            dt.harga,
            dt.jumlah,
            dt.subtotal,
            t.total_harga,
            t.status_transaksi
        FROM detail_transaksi dt
        JOIN transaksi t ON dt.transaksi_id = t.transaksi_id
        WHERE t.status_transaksi = 'Selesai' 
              AND dt.is_delete = false
        ORDER BY t.tanggal_transaksi DESC;
    ";

            using var cmd = new NpgsqlCommand(query, db.Connection);
            using var adapter = new NpgsqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
