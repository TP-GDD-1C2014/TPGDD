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
        public static Dictionary<int, string> diccionarioEstadosPublicacion = new Dictionary<int, string>();
        public static Dictionary<int, string> diccionarioTiposPublicacion = new Dictionary<int, string>();
        public static Dictionary<int, string> diccionarioTiposOperacion = new Dictionary<int, string>();

        public static void loguearUsuario(Clases.Usuario usuarioActual)
        {
            usuario = usuarioActual;
        }

        public static void limpiarInterfaz(Control con)
        {

            
            foreach (Control c in con.Controls)
            {
                var box = c as TextBox;
                var combo = c as ComboBox;
                var datagridview = c as DataGridView;
                var datetimepicker = c as DateTimePicker;
                var checkbox = c as CheckBox;
                
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

                //Limpiar DateTimePicker
                if (datetimepicker != null)
                {
                    /*datetimepicker.CustomFormat = " ";
                    datetimepicker.Format = DateTimePickerFormat.Custom;*/
                    //datetimepicker.Refresh();
                    /*datetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                    datetimepicker.CustomFormat = " ";*/
                }

                //Limpiar Checkbox
                if (checkbox != null)
                {
                    checkbox.Checked = false;
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

        public static void generarDiccionarios()
        {
            //Visibilidades
            SqlDataReader lector = BDSQL.ObtenerDataReader("SELECT COD_VISIBILIDAD, DESCRIPCION FROM MERCADONEGRO.VISIBILIDADES ORDER BY COD_VISIBILIDAD",
                                                            "T");

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    diccionarioVisibilidades.Add((int)(decimal)lector["COD_VISIBILIDAD"], (string)lector["DESCRIPCION"]);
                }
            }
            
            lector.Dispose();
            lector.Close();
            BDSQL.cerrarConexion();

            //Estado_Publicacion
            lector = BDSQL.ObtenerDataReader("SELECT Cod_EstadoPublicacion, Descripcion FROM MERCADONEGRO.Estados_Publicacion ORDER BY Cod_EstadoPublicacion",
                                                "T");
            
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    diccionarioEstadosPublicacion.Add((int)(decimal)lector["Cod_EstadoPublicacion"], (string)lector["Descripcion"]);
                }
            }

            lector.Dispose();
            lector.Close();
            BDSQL.cerrarConexion();

            //Tipos_Publicacion
            lector = BDSQL.ObtenerDataReader("SELECT Cod_TipoPublicacion, Descripcion FROM MERCADONEGRO.Tipos_Publicacion ORDER BY Cod_TipoPublicacion",
                                                "T");
            
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    diccionarioTiposPublicacion.Add((int)(decimal)lector["Cod_TipoPublicacion"], (string)lector["Descripcion"]);
                }
            }
            lector.Dispose();
            lector.Close();
            BDSQL.cerrarConexion();

            //Tipos_Operacion
            lector = BDSQL.ObtenerDataReader("SELECT Cod_TipoOperacion, Descripcion FROM MERCADONEGRO.Tipos_Operacion ORDER BY Cod_TipoOperacion",
                                               "T");

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    diccionarioTiposOperacion.Add((int)(decimal)lector["Cod_TipoOperacion"], (string)lector["Descripcion"]);
                }
            }
            lector.Dispose();
            lector.Close();


            BDSQL.cerrarConexion();

        }

        //Metodo para obtener el "String" del diccionario
        public static string getDescripcion(int cod, string tabla)
        {
            string descripcion;

            switch (tabla)
            {
                case "visibilidad":
                    diccionarioVisibilidades.TryGetValue(cod, out descripcion);
                    return descripcion;
                case "tipoOperacion":
                    diccionarioTiposPublicacion.TryGetValue(cod, out descripcion);
                    return descripcion;
                case "estado":
                    diccionarioEstadosPublicacion.TryGetValue(cod, out descripcion);
                    return descripcion;
                case "tipoPublicacion":
                    diccionarioTiposPublicacion.TryGetValue(cod, out descripcion);
                    return descripcion;
                default:
                    return "";
            }
            
        }

        /*
        public static void actualizarDiccionarioVisibilidades(string descripcionNueva, string descripcionVieja)
        {
            for (int i = 0; i < diccionarioVisibilidades.Count; i++)
            {
                if (diccionarioVisibilidades[i].Contains(descripcionVieja))
                    diccionarioVisibilidades[i] = descripcionNueva;
            }
        }
        */
    }
}
