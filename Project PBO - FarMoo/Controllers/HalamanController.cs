using Npgsql;
using Project_PBO___FarMoo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO___FarMoo.Controllers
{
    public class HalamanController
    {
        public int GetTotalPenghasilan(int userId)
        {
            using var db = new DbContext();
            db.Open();

            string query = @"SELECT COALESCE(SUM(""total_harga""), 0) 
                            FROM transaksi
                             WHERE user_id = @id";

            using var cmd = new NpgsqlCommand(query, db.Connection);
            cmd.Parameters.AddWithValue("@id", userId);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public int GetTotalPenghasilan()
        {
            using var db = new DbContext();
            db.Open();

            string query = @"SELECT COALESCE(SUM(total_harga), 0) 
                         FROM transaksi";

            using var cmd = new NpgsqlCommand(query, db.Connection);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
