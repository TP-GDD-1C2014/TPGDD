using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Abm_Rubro
{
    public partial class Modificar : Form
    {
        public int id { get; set; }
        public ABMRubro formAnterior { get; set; }

        public Modificar(int idRubro, ABMRubro formAnt)
        {
            this.formAnterior = formAnt;
            this.id = idRubro;
            InitializeComponent();
            this.CenterToScreen();
        }

        public void modificarRubro(int id, string nuevoNombre)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_Rubro", id);
            BDSQL.agregarParametro(listaParametros, "@Descripcion", nuevoNombre);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Rubros SET Descripcion = @Descripcion WHERE ID_Rubro = @ID_Rubro", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
            formAnterior.actualizarCbRubros();
        }

        private void mod_Click(object sender, EventArgs e)
        {
            if (!nuevoNombre.Text.Equals(""))
            {
                if (!BDSQL.existeString(nuevoNombre.Text, "MERCADONEGRO.Rubros", "Descripcion"))
                {
                    modificarRubro(this.id, nuevoNombre.Text);
                    MessageBox.Show("Rubro modificado.");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("El rubro ya existe.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos solicitados.", "Error");
            }
        }
    }
}
