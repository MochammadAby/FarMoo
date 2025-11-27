using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Project_PBO___FarMoo.Models
{
    public class M_StokBatch
    {
        public int StokId { get; set; }
        public int ProdukId { get; set; }
        public DateTime TanggalProduksi { get; set; }
        public int JumlahBotol { get; set; }
        public DateTime TanggalExpired { get; set; }

        public string? NamaProduk { get; set; }
        public int? SatuanMl { get; set; }
        public int? Harga { get; set; }
        public byte[]? Images { get; set; }
    }

}

