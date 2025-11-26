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

namespace Project_PBO___FarMoo.Views.Admin
{
    public partial class V_HalBerandaAdmin : Form
    {
        private User currentUser;
        private HalamanController dashboard;
        public V_HalBerandaAdmin(User user)
        {
            InitializeComponent();
            currentUser = user;
            dashboard = new HalamanController();
            lblWelcome_M.Text = $"Selamat datang, {currentUser.NamaLengkap}!";

            LoadDashboard_M();
        }
        private void LoadDashboard_M()
        {
            lblWelcome_M.Text = $"Halo, {currentUser.NamaLengkap} 👋";

            int totalPengeluaran = dashboard.GetTotalPenghasilan(currentUser.UserId);
            lblPenghasilan.Text = $"Rp {totalPengeluaran:N0}";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            var profil = new V_AkunAdmin(currentUser);
            profil.Show();
            this.Hide();
        }
    }
}
