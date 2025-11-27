using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO___FarMoo.Models
{
    public class M_ProdukSusu
    {
        public int ProdukId { get; set; }
        public int JenisId { get; set; }
        public string NamaProduk { get; set; } = string.Empty;
        public int SatuanMl { get; set; }
        public int Harga { get; set; }
        public byte[]? Images
        {
            get; set;
        }
    }
}
