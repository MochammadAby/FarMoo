using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO___FarMoo.Models
{
    public abstract class M_Pengguna
    {
        public int UserId { get; protected set; }
        public string NamaLengkap { get; protected set; } = "";
        public string Username { get; protected set; } = "";
        public string Email { get; protected set; } = "";
        public string NomorHp { get; protected set; } = "";
        public byte[]? Foto { get; protected set; }

        public abstract Form BuatHalamanBeranda();
    }
}
