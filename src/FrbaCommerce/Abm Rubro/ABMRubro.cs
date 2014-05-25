using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;

namespace FrbaCommerce.Abm_Rubro
{
    public partial class ABMRubro : Form
    {
        public class itemComboBox
        {
            public string Nombre_Rubro { get; set; }
            public int ID_Rubro { get; set; }

            public itemComboBox(string nombre, int id)
            {
                Nombre_Rubro = nombre;
                ID_Rubro = id;
            }
            public override string ToString()
            {
                return Nombre_Rubro;
            }
        }

        public ABMRubro()
        {
            InitializeComponent();
            cbRubros.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarCbRubros();
        }

        public void llenarCbRubros()
        {
            List<SqlParameter> listaParametros1 = new List<SqlParameter>();
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Rubros", listaParametros1, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    this.cbRubros.Items.Add(new itemComboBox(lector["Descripcion"].ToString(), Convert.ToInt32(lector["ID_Rubro"])));
                }
            }
            BDSQL.cerrarConexion();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {

        }

        private void modificar_Click(object sender, EventArgs e)
        {

        }

        private void eliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
