using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.Common
{
    public class Interfaz
    {
        public static Clases.Usuario usuario { get; set; }

        public static void loguearUsuario(Clases.Usuario usuarioActual)
        {
            usuario = usuarioActual;
        }

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

        public static bool esNumerico(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public static void mostrarForm(Form formNueva, Form viejaForm)
        {
            formNueva.Show();
            viejaForm.Hide();
        }

        public static DateTime obtenerFecha()
        {
            return DateTime.ParseExact(ConfigurationManager.AppSettings["Fecha"], "dd/MM/yyyy", null);
        }

        public static Clases.Usuario usuarioActual()
        {
            return usuario;
        }
    }
}
