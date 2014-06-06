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
        public static Dictionary<int, string> diccionarioVisibilidades = new Dictionary<int, string>();
        //public static Dictionary<int, string> diccionarioEstadosPublicacion = new Dictionary<int, string>();
        //public static Dictionary<int, string> diccionarioTiposPublicacion = new Dictionary<int, string>();

        public static void loguearUsuario(Clases.Usuario usuarioActual)
        {
            usuario = usuarioActual;
            generarDiccionario();
        }

        public static void limpiarInterfaz(Control con)
        {

            
            foreach (Control c in con.Controls)
            {
                var box = c as TextBox;
                var combo = c as ComboBox;
                var datagridview = c as DataGridView;
                
                //Limpia textbox
                if (box != null)
                {
                    box.Text = string.Empty;
                }

                //Limpia comboBox
                if (combo != null)
                {
                    combo.SelectedIndex = -1;
                }

                //Limpia DataGridView
                if (datagridview != null)
                {
                    datagridview.DataSource = null;
                    datagridview.Refresh();
                }

                limpiarInterfaz(c);

            }


        }

        public static void limpiarCheckboxList(CheckedListBox cbl)
        {
            foreach (int i in cbl.CheckedIndices)
            {
                cbl.SetItemCheckState(i, CheckState.Unchecked);
                cbl.SetSelected(i,false);
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


        //Esto bloquea el ordenamiento del datagrid cuando se toca en algun header de las columnas
        public static DataGridView bloquearDataGridView(DataGridView dgv)
        {

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            return dgv;
        }

        public static void generarDiccionario()
        {
            SqlDataReader lector = BDSQL.ObtenerDataReader("SELECT COD_VISIBILIDAD, DESCRIPCION FROM MERCADONEGRO.VISIBILIDADES ORDER BY COD_VISIBILIDAD",
                                                            "T");

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    diccionarioVisibilidades.Add((int)(decimal)lector["COD_VISIBILIDAD"], (string)lector["DESCRIPCION"]);
                }
            }
            /*
            lector.Dispose();
            lector = BDSQL.ObtenerDataReader("SELECT Estado_Publicacion, Descripcion FROM MERCADONEGRO.Estados_Publicacion ORDER BY Estado_Publicacion",
            
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    diccionarioEstadosPublicacion.Add((int)(decimal)lector["Estado_Publicacion"], (string)lector["Descripcion"]);
                }
            }

            lector.Dispose();
            lector = BDSQL.ObtenerDataReader("SELECT Tipo_Publicacion, Descripcion FROM MERCADONEGRO.Tipos_Publicacion ORDER BY Tipo_Publicacion",
            
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    diccionarioTiposPublicacion.Add((int)(decimal)lector["Tipo_Publicacion"], (string)lector["Descripcion"]);
                }
            }
            */
            BDSQL.cerrarConexion();

        }

        //Metodo para obtener el "String" de la publicacion
        public static string getDescripcion(int cod, string tabla)
        {
            string descripcion;

            switch (tabla)
            {
                case "visibilidad":
                    diccionarioVisibilidades.TryGetValue(cod, out descripcion);
                    return descripcion;
                /*
                case "tipo":
                    diccionarioTiposPublicacion.TryGetValue(cod, out descripcion);
                    return descripcion;
                case "estado":
                    diccionarioEstadosPublicacion.TryGetValue(cod, out descripcion);
                    return descripcion;
                 * */
                default:
                    return "";
            }

            

            
        }
    }
}
