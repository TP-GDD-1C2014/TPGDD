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
        public Login.SeleccionFuncionalidades formAnterior { get; set; }

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

        public ABMRubro(Login.SeleccionFuncionalidades formAnt)
        {
            this.formAnterior = formAnt;

            InitializeComponent();
            this.CenterToScreen();

            cbRubros.DropDownStyle = ComboBoxStyle.DropDownList;
            llenarCbRubros();
        }

        public void llenarCbRubros()
        {
            List<SqlParameter> listaParametros1 = new List<SqlParameter>();
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Rubros", listaParametros1, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read(); // Me salteo el primer rubro, que es el default
                while (lector.Read())
                {
                    this.cbRubros.Items.Add(new itemComboBox(lector["Descripcion"].ToString(), Convert.ToInt32(lector["ID_Rubro"])));
                }
            }
            BDSQL.cerrarConexion();
        }

        public void actualizarCbRubros()
        {
            this.cbRubros.Items.Clear();
            llenarCbRubros();
        }

        public void eliminarRubro(int id, object item)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_Rubro", id);
            BDSQL.ejecutarQuery("EXEC MERCADONEGRO.eliminarRubro @ID_Rubro", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
            cbRubros.Items.Remove(item);
        }

        public void agregarRubro(string nombre)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Descripcion", nombre);
            BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Rubros VALUES (@Descripcion)", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();

            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros2, "@Descripcion", nombre);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_Rubro FROM MERCADONEGRO.Rubros WHERE Descripcion = @Descripcion", listaParametros2, BDSQL.iniciarConexion());
            lector.Read();
            cbRubros.Items.Add(new itemComboBox(nombre, Convert.ToInt32(lector["ID_Rubro"])));
            BDSQL.cerrarConexion();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            if (!nuevoRubro.Text.Equals(""))
            {
                if (!BDSQL.existeString(nuevoRubro.Text, "MERCADONEGRO.Rubros", "Descripcion"))
                {
                    agregarRubro(nuevoRubro.Text);
                    MessageBox.Show("Rubro " + nuevoRubro.Text + " agregado.");
                }
                else
                {
                    MessageBox.Show("El rubro ya existe.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre.", "Error");
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            if (cbRubros.SelectedIndex != -1)
            {
                itemComboBox seleccion = cbRubros.SelectedItem as itemComboBox;
                Modificar formMod = new Modificar(seleccion.ID_Rubro, this);
                formMod.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rubro.", "Error");
            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (cbRubros.SelectedIndex != -1)
            {
                DialogResult confirmacion = MessageBox.Show("El rubro " + cbRubros.SelectedItem.ToString() + " será eliminado.\n\n ¿Está seguro?", "Confirmación", MessageBoxButtons.YesNo);
                if (confirmacion == DialogResult.Yes)
                {
                    itemComboBox seleccion = cbRubros.SelectedItem as itemComboBox;
                    eliminarRubro(seleccion.ID_Rubro, cbRubros.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rubro.", "Error");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            formAnterior.Show();
        }
    }
}
