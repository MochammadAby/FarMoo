using Microsoft.VisualBasic.ApplicationServices;
using Project_PBO___FarMoo.Controllers;
using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppUser = Project_PBO___FarMoo.Models.User;

namespace Project_PBO___FarMoo.Views.Tengkulak.Fitur_permintaan_susu
{
    public partial class V_MembuatPermintaanTengkulak : Form
    {
        private readonly AppUser _user;
        private readonly C_Stok _stokController = new C_Stok();
        private readonly C_Transaksi _transaksiController = new C_Transaksi();
        public V_MembuatPermintaanTengkulak(AppUser user)
        {
            _user = user;
            InitializeComponent();

            this.Load += V_PermintaanSusuTengkulak_Load;
            btnCheckout.Click += btnCheckout_Click;
        }

        private class CardData
        {
            public M_StokBatch Stok { get; set; } = default!;
            public TextBox TxtJumlah { get; set; } = default!;
            public CheckBox Check { get; set; } = default!;
        }

        private void V_PermintaanSusuTengkulak_Load(object? sender, EventArgs e)
        {
            MuatProdukUntukPermintaan();
        }

        private void MuatProdukUntukPermintaan()
        {
            flpProduk.Controls.Clear();

            var daftarStok = _stokController
                             .GetStokBatchTerbaru()
                             .Where(s => s.JumlahBotol > 0)  // cuma yang ada stok
                             .ToList();

            foreach (var s in daftarStok)
            {
                var card = new Panel
                {
                    Width = 260,
                    Height = 320,
                    BackColor = Color.FromArgb(0, 60, 130),
                    Margin = new Padding(30, 20, 0, 20)
                };

                // Checkbox di pojok kanan atas
                var chk = new CheckBox
                {
                    Width = 18,
                    Height = 18,
                    Location = new Point(card.Width - 28, 8),
                    BackColor = Color.Transparent
                };

                // Nama susu (misal: "Susu Original")
                var lblNama = new Label
                {
                    AutoSize = false,
                    Width = card.Width - 20,
                    Height = 24,
                    Location = new Point(10, 10),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = s.NamaProduk ?? "-"
                };

                // Jenis botol (contoh: "250 ML")
                var lblBotol = new Label
                {
                    AutoSize = true,
                    Location = new Point(10, 34),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Text = $"{(s.SatuanMl ?? 0)} ML"
                };

                // Gambar di tengah
                var pic = new PictureBox
                {
                    Width = 90,
                    Height = 140,
                    Location = new Point((card.Width - 90) / 2, 55),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                if (s.Images != null && s.Images.Length > 0)
                    pic.Image = ImageHelper.BinaryToImage(s.Images);

                // Harga
                var lblHarga = new Label
                {
                    AutoSize = true,
                    Location = new Point(10, 200),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Text = $"Rp. {s.Harga:N0}"
                };

                // Stok
                var lblStok = new Label
                {
                    AutoSize = true,
                    Location = new Point(10, 225),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8),
                    Text = $"Stok : {s.JumlahBotol} Botol"
                };

                // Expired
                var lblExp = new Label
                {
                    AutoSize = true,
                    Location = new Point(10, 240),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8),
                    Text = $"Exp : {s.TanggalExpired:dd/MM/yy}"
                };

                // Label "Jumlah :"
                var lblJumlah = new Label
                {
                    AutoSize = true,
                    Location = new Point(10, 280),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8),
                    Text = "Jumlah :"
                };

                // TextBox jumlah
                var txtJumlah = new TextBox
                {
                    Width = 100,
                    Location = new Point(90, 280)
                };

                var data = new CardData
                {
                    Stok = s,
                    TxtJumlah = txtJumlah,
                    Check = chk
                };
                card.Tag = data;

                card.Controls.Add(chk);
                card.Controls.Add(lblNama);
                card.Controls.Add(lblBotol);
                card.Controls.Add(pic);
                card.Controls.Add(lblHarga);
                card.Controls.Add(lblStok);
                card.Controls.Add(lblExp);
                card.Controls.Add(lblJumlah);
                card.Controls.Add(txtJumlah);

                flpProduk.Controls.Add(card);
            }
        }

        private void btnCheckout_Click(object? sender, EventArgs e)
        {
            try
            {
                var detailList = new List<M_DetailTransaksi>();

                foreach (Panel card in flpProduk.Controls.OfType<Panel>())
                {
                    if (card.Tag is not CardData data)
                        continue;

                    if (!data.Check.Checked)
                        continue;

                    if (!int.TryParse(data.TxtJumlah.Text, out int qty) || qty <= 0)
                    {
                        MessageBox.Show("Jumlah harus angka > 0 untuk produk yang dipilih.",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (qty > data.Stok.JumlahBotol)
                    {
                        MessageBox.Show(
                            $"Stok tidak cukup untuk {data.Stok.NamaProduk}. " +
                            $"Stok tersedia: {data.Stok.JumlahBotol}",
                            "Stok Kurang", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int subtotal = qty * data.Stok.Harga;

                    detailList.Add(new M_DetailTransaksi
                    {
                        ProdukId = data.Stok.ProdukId,
                        Jumlah = qty,
                        Subtotal = subtotal,
                        StokId = data.Stok.StokId
                    });
                }

                if (detailList.Count == 0)
                {
                    MessageBox.Show("Belum ada produk yang dipilih / diisi jumlahnya.",
                        "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int transaksiId = _transaksiController.BuatTransaksi(_user, detailList);

                MessageBox.Show(
                    $"Permintaan susu berhasil dibuat.\nID Transaksi: {transaksiId}",
                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // refresh stok di layar setelah stok berkurang
                MuatProdukUntukPermintaan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuat permintaan susu: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHalTengkulak_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new Halaman_Beranda(_user));
        }

        private void btnAkun_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new Halaman_Beranda(_user));
        }


    }
}
