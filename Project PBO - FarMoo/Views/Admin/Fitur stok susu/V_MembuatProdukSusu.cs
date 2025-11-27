using Project_PBO___FarMoo.Helper;
using Project_PBO___FarMoo.Controllers;
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


namespace Project_PBO___FarMoo.Views.Admin.Fitur_stok_susu
{
    public partial class V_MembuatProdukSusu : Form
    {
        private readonly AppUser _user;
        private readonly C_Stok _stokController = new C_Stok();
        public V_MembuatProdukSusu(AppUser user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            InitializeComponent();

            MuatDataStok();
        }

        private void MuatDataStok()
        {
            flpProduk.Controls.Clear();   // flpProduk = FlowLayoutPanel di Designer

            var daftarStok = _stokController.GetStokBatchTerbaru(); // ambil data stok + produk

            foreach (var s in daftarStok)   // s = M_StokBatch
            {
                // ====== CARD ======
                var card = new Panel
                {
                    Width = 280,
                    Height = 220,
                    BackColor = Color.FromArgb(0, 70, 150),
                    Margin = new Padding(20)
                };

                // ====== GAMBAR KIRI ======
                var pic = new PictureBox
                {
                    Width = 90,
                    Height = 170,
                    Location = new Point(15, 30),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                if (s.Images != null && s.Images.Length > 0)
                {
                    pic.Image = ImageHelper.BinaryToImage(s.Images);
                }

                // ====== LABEL2 ======
                var lblNama = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                    Location = new Point(120, 15),
                    Text = s.NamaProduk ?? "-"
                };

                var lblJumlah = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9f),
                    Location = new Point(120, 55),
                    Text = $"Jumlah : {s.JumlahBotol}"
                };

                var lblTglProd = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9f),
                    Location = new Point(120, 80),
                    Text = $"Tanggal Produksi : {s.TanggalProduksi:dd/MM/yyyy}"
                };

                var lblTglExp = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9f),
                    Location = new Point(120, 105),
                    Text = $"Tanggal Expired : {s.TanggalExpired:dd/MM/yyyy}"
                };

                var lblMl = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                    Location = new Point(20, 190),
                    Text = $"{(s.SatuanMl ?? 0)} ml"
                };

                // ====== INI DIA: TOMBOL EDIT ======
                var btnEdit = new PictureBox
                {
                    Width = 40,
                    Height = 40,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(card.Width - 50, card.Height - 50),
                    Cursor = Cursors.Hand,
                    Tag = s   // simpan M_StokBatch di Tag
                };

                // kalau punya icon edit di Resources
                // btnEdit.Image = Properties.Resources.icon_edit;

                btnEdit.Click += BtnEdit_Click;   // <-- event handler-nya di bawah

                // ====== MASUKKAN KE CARD ======
                card.Controls.Add(pic);
                card.Controls.Add(lblNama);
                card.Controls.Add(lblJumlah);
                card.Controls.Add(lblTglProd);
                card.Controls.Add(lblTglExp);
                card.Controls.Add(lblMl);
                card.Controls.Add(btnEdit);

                // ====== TAMBAHKAN CARD KE FLOWLAYOUT ======
                flpProduk.Controls.Add(card);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            var stok = pb.Tag as M_StokBatch;
            if (stok == null) return;

            using (var form = new V_EditProduk(_user, stok))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MuatDataStok();  
                }
            }
        }


        private void btnTambahProduk_Click(object sender, EventArgs e)
        {
            {
                using (var form = new V_TambahProduk(_user))
                {
                    var result = form.ShowDialog();   // <-- PENTING: ShowDialog, BUKAN NavigateTo

                    if (result == DialogResult.OK)
                    {
                        MuatDataStok();  // refresh setelah berhasil simpan
                    }
                }
            }
        }

        private void btnAkun_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_AkunAdmin(_user));

        }

        private void btnHalAdmin_Click(object sender, EventArgs e)
        {
            NavigationHelper.NavigateTo(this, new V_HalBerandaAdmin(_user));

        }

        private void btnStokAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}
