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

        private void V_MembuatProdukSusu_Load(object sender, EventArgs e)
        {
            // 1) tandai stok yang sudah expired → is_delete = true
            _stokController.SoftDeleteExpiredBatches();

            // 2) muat ulang card stok (SELECT sudah pakai WHERE is_delete = false & expired >= today)
            MuatDataStok();
        }
        private void MuatDataStok()
        {
            flpProduk.Controls.Clear();

            var daftarStok = _stokController.GetStokBatchTerbaru();

            foreach (var s in daftarStok)
            {
                // ==== CARD ====
                var card = new Panel
                {
                    Width = 400,  // diperbesar
                    Height = 230,
                    BackColor = Color.FromArgb(0, 70, 150),
                    Margin = new Padding(20)
                };

                // ==== GAMBAR KIRI ====
                var pic = new PictureBox
                {
                    Width = 95,
                    Height = 150,
                    Location = new Point(15, 35),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                if (s.Images != null && s.Images.Length > 0)
                    pic.Image = ImageHelper.BinaryToImage(s.Images);

                // area teks di kanan gambar
                int textLeft = 130;
                int textWidth = card.Width - textLeft - 15; // sisa lebar card

                var lblNama = new Label
                {
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                    Location = new Point(textLeft, 15),
                    AutoSize = false,
                    Size = new Size(textWidth, 28)
                };
                lblNama.Text = s.NamaProduk ?? "-";

                var lblJumlah = new Label
                {
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9f),
                    Location = new Point(textLeft, 55),
                    AutoSize = false,
                    Size = new Size(textWidth, 20),
                    Text = $"Jumlah : {s.JumlahBotol}"
                };

                var lblTglProd = new Label
                {
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9f),
                    Location = new Point(textLeft, 80),
                    AutoSize = false,
                    Size = new Size(textWidth, 20),
                    Text = $"Tanggal Produksi : {s.TanggalProduksi:dd/MM/yyyy}"
                };

                var lblTglExp = new Label
                {
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9f),
                    Location = new Point(textLeft, 105),
                    AutoSize = false,
                    Size = new Size(textWidth, 20),
                    Text = $"Tanggal Expired : {s.TanggalExpired:dd/MM/yyyy}"
                };

                var lblMl = new Label
                {
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                    Location = new Point(20, 190),
                    AutoSize = true,
                    Text = $"{(s.SatuanMl ?? 0)} ml"
                };

                // tombol hapus (kotak merah)
                var btnHapusProduk = new PictureBox
                {
                    Width = 30,
                    Height = 30,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(card.Width - 45, card.Height - 45),
                    Cursor = Cursors.Hand,
                    Tag = s,
                    Image = Properties.Resources.logo_sampah_removebg_preview
                };
                // optional: beri warna merah biar kelihatan
                btnHapusProduk.Click += btnHapusProduk_Click;


                // tombol edit tetap
                // tombol edit (kotak kuning)
                var btnEditProduk = new PictureBox
                {
                    Width = 30,
                    Height = 30,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(card.Width - 85, card.Height - 45),
                    Cursor = Cursors.Hand,
                    Tag = s,
                    Image = Properties.Resources.logo_edit_removebg_preview
                };
                btnEditProduk.Click += BtnEditProduk_Click;


                card.Controls.Add(pic);
                card.Controls.Add(lblNama);
                card.Controls.Add(lblJumlah);
                card.Controls.Add(lblTglProd);
                card.Controls.Add(lblTglExp);
                card.Controls.Add(lblMl);
                card.Controls.Add(btnHapusProduk);
                card.Controls.Add(btnEditProduk);


                flpProduk.Controls.Add(card);
            }
        }

        private void BtnEditProduk_Click(object sender, EventArgs e)
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

        private void btnHapusProduk_Click(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            var stok = pb.Tag as M_StokBatch;
            if (stok == null) return;

            var konfirm = MessageBox.Show(
                $"Yakin ingin menghapus produk '{stok.NamaProduk}'?",
                "Konfirmasi Hapus Produk",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (konfirm == DialogResult.Yes)
            {
                bool sukses = _stokController.DeleteStokById(stok.StokId);

                if (sukses)
                {
                    MessageBox.Show("Produk berhasil dihapus.", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MuatDataStok(); // refresh UI
                }
                else
                {
                    MessageBox.Show("Gagal menghapus produk.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
