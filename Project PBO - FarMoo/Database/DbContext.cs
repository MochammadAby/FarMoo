
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotNetEnv;
using Npgsql;
using System;
using System.Data;

namespace Project_PBO___FarMoo.Database
{
    public class DbContext : IDisposable
    {
        public NpgsqlConnection Connection { get; }

        public DbContext()
        {

            try
            {
                Env.Load();   
            }
            catch
            {
                
            }

            var connString = Environment.GetEnvironmentVariable("NEON_DB_URL");

            if (string.IsNullOrEmpty(connString))
            {
                connString = Environment.GetEnvironmentVariable("DATABASE_URL");
            }

            if (string.IsNullOrEmpty(connString))
            {
                throw new InvalidOperationException(
                    "Connection string Neon tidak ditemukan. Set NEON_DB_URL atau DATABASE_URL di .env / environment.");
            }

            Connection = new NpgsqlConnection(connString);
        }

        public void Open()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
        }

        public void Close()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

        public void Dispose()
        {
            Close();
            Connection.Dispose();
        }
    }
}