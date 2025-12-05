using Npgsql;
using Project_PBO___FarMoo.Database;
using Project_PBO___FarMoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_PBO___FarMoo.Controllers
{
    public class AuthController
    {
        private DbContext _db;

        public AuthController()
        {
            _db = new DbContext();
        }
        public User Login(string username, string password)
        {
            _db.Open();

            string query = "SELECT * FROM akun WHERE username = @u AND password = @p";

            using var cmd = new NpgsqlCommand(query, _db.Connection);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                var user = new User
                {
                    UserId = (int)reader["user_id"],
                    NamaLengkap = reader["nama_lengkap"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString(),
                    Email = reader["email"].ToString(),
                    NomorHp = reader["nomor_hp"].ToString(),
                    Role = reader["role"].ToString(),
                    Foto = reader["foto"] == DBNull.Value
                    ? null
                     : (byte[])reader["foto"]
                };

                _db.Close();
                return user;
            }

            _db.Close();
            return null;
        }

        public bool Register(User user)
        {
            _db.Open();

            string query = @"INSERT INTO akun 
                             (nama_lengkap, username, password, email, nomor_hp, role) 
                             VALUES (@n, @u, @p, @e, @hp, @r)";

            using var cmd = new NpgsqlCommand(query, _db.Connection);

            cmd.Parameters.AddWithValue("@n", user.NamaLengkap);
            cmd.Parameters.AddWithValue("@u", user.Username);
            cmd.Parameters.AddWithValue("@p", user.Password);
            cmd.Parameters.AddWithValue("@e", user.Email);
            cmd.Parameters.AddWithValue("@hp", user.NomorHp);
            cmd.Parameters.AddWithValue("@r", user.Role);

            int result = cmd.ExecuteNonQuery();
            _db.Close();

            return result > 0;
        }

        public bool IsUsernameTaken (string username)
        {
            using var db = new DbContext();
            db.Open();

            string query = "SELECT COUNT(*) FROM akun WHERE username = @u";

            using var cmd = new NpgsqlCommand(query, db.Connection);
            cmd.Parameters.AddWithValue("@u", username);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public bool IsEmailExist(string email)
        {
            using var db = new DbContext();
            db.Open();

            string query = "SELECT COUNT(*) FROM akun WHERE email = @e";

            using var cmd = new NpgsqlCommand(query, db.Connection);
            cmd.Parameters.AddWithValue("@e", email);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;
        }
        public bool UpdateProfile(User user)
        {
            using var db = new DbContext();
            db.Open();

            string query = @"
        UPDATE akun
        SET 
            nama_lengkap = @n,
            username = @u,
            email = @e,
            nomor_hp = @hp,
            password = @p
        WHERE user_id = @id";

            using var cmd = new NpgsqlCommand(query, db.Connection);

            cmd.Parameters.AddWithValue("@n", user.NamaLengkap);
            cmd.Parameters.AddWithValue("@u", user.Username);
            cmd.Parameters.AddWithValue("@e", user.Email);
            cmd.Parameters.AddWithValue("@hp", user.NomorHp);
            cmd.Parameters.AddWithValue("@p", user.Password);
            cmd.Parameters.AddWithValue("@id", user.UserId);

            return cmd.ExecuteNonQuery() > 0;
        }

        public void UpdateFoto(int userId, byte[] foto)
        {
            using var db = new DbContext();
            db.Open();

            string query = @"UPDATE akun SET foto = @f WHERE user_id = @id";

            using var cmd = new NpgsqlCommand(query, db.Connection);
            cmd.Parameters.AddWithValue("@f", (object)foto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id", userId);

            cmd.ExecuteNonQuery();

        }

        public M_Pengguna? LoginSebagaiPengguna(string username, string password)
        {
            var user = Login(username, password);   

            if (user == null)
                return null;

            return user.Role switch
            {
                "peternak" => new M_Peternak(user.UserId, user.NamaLengkap,
                                            user.Username, user.Email,
                                            user.NomorHp, user.Foto),
                "tengkulak" => new M_Tengkulak(user.UserId, user.NamaLengkap,
                                             user.Username, user.Email,
                                             user.NomorHp, user.Foto),
                _ => null
            };
        }
    }
}
