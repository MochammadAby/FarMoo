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
        public int StokId { get; set; }           // stok_id
        public int ProdukId { get; set; }         // produk_id (FK ke produk_susu)
        public DateTime TanggalProduksi { get; set; }  // tanggal_produksi
        public int JumlahBotol { get; set; }           // jumlah_botol
        public DateTime TanggalExpired { get; set; }   // tanggal_expired


        public string? NamaProduk { get; set; }   // p.nama_produk
        public int? SatuanMl { get; set; }        // p.satuan_ml
        public int? Harga { get; set; }           // p.harga
        public byte[]? Images { get; set; }       // p.images
    }
}

