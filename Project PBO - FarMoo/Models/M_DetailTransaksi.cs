using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO___FarMoo.Models
{
        public class M_DetailTransaksi
        {
            public int DetailId { get; set; }
            public int TransaksiId { get; set; }
            public int ProdukId { get; set; }
            public int Jumlah { get; set; }
            public int Subtotal { get; set; }

          
            public int StokId { get; set; }
        }
}
