namespace Project_PBO___FarMoo.Models
{
    public class M_PermintaanSusu
    {
        public int TransaksiId { get; set; }
        public int JumlahBotol { get; set; }
        public string NamaProduk { get; set; } = "";
        public int Volume { get; set; }
        public decimal TotalHarga { get; set; }
        public DateTime TanggalPembelian { get; set; }
        public DateTime TanggalPermintaan { get; set; }
        public string StatusPembayaran { get; set; } = "";
    }
}
