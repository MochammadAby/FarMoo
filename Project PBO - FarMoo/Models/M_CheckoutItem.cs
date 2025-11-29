using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_PBO___FarMoo.Models;

namespace Project_PBO___FarMoo.Models
{
   public  class M_CheckoutItem
    {
            public int ProdukId { get; set; }
            public int StokId { get; set; }

            public string NamaProduk { get; set; } = string.Empty;
            public string JenisBotol { get; set; } = string.Empty; // contoh: "Original 250 ml"
            public int SatuanMl { get; set; }

            public int Harga { get; set; }      // harga per botol
            public int Jumlah { get; set; }     // qty yang dipesan

            public byte[]? ImageBytes { get; set; }  // gambar produk

            public int Subtotal => Harga * Jumlah;
    }
}
