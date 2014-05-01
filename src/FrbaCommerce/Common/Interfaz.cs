using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Common
{
    public class Interfaz
    {
        public static void limpiarInterfaz(Control con)
        {
            foreach (Control c in con.Controls)
            {
                var box = c as TextBox;

                if (box != null)
                {
                    box.Text = string.Empty;
                }

                limpiarInterfaz(c);
            }

        }

    }
}
