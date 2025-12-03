using Microsoft.VisualBasic.ApplicationServices;
using Project_PBO___FarMoo.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_PBO___FarMoo.Models
{
    public class M_Peternak : M_Pengguna
    {
        public M_Peternak(int id, string nama, string username,
                          string email, string nomorHp, byte[]? foto)
        {
            UserId = id;
            NamaLengkap = nama;
            Username = username;
            Email = email;
            NomorHp = nomorHp;
            Foto = foto;
        }

        public override Form BuatHalamanBeranda()
        {
            // mapping M_Peternak -> User (DTO lama yang dipakai form)
            var user = new User
            {
                UserId = this.UserId,
                NamaLengkap = this.NamaLengkap,
                Username = this.Username,
                Email = this.Email,
                NomorHp = this.NomorHp,
                Role = "peternak",
                Foto = this.Foto ?? Array.Empty<byte>()
            };

            return new V_HalBerandaAdmin(user);
        }
    }
}
