using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO___FarMoo.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string NamaLengkap { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NomorHp { get; set; }
        public string Role { get; set; }
        public byte[] Foto { get; set; }
    }
}
