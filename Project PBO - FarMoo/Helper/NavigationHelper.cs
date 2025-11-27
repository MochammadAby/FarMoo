using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO___FarMoo.Helper
{
    public static class NavigationHelper
    {
        public static void NavigateTo(Form current, Form next)
        {
            if (current == null) throw new ArgumentNullException(nameof(current));
            if (next == null) throw new ArgumentNullException(nameof(next));

            next.StartPosition = FormStartPosition.CenterScreen;
            next.Show();
            current.Hide();

            // ketika form tujuan ditutup, form sekarang ikut ditutup
            next.FormClosed += (s, e) => current.Close();
        }
    }
}
