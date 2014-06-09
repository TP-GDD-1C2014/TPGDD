using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Clases;
using FrbaCommerce.Common;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class EditorDeVisibilidades : Form
    {
        private Button botonSeleccionado { get; set; }
        private DataGridView dgv { get; set; }
   


        public EditorDeVisibilidades(Button botonSeleccionado, DataGridView dgv)
        {
            InitializeComponent();
            CenterToScreen();

            this.botonSeleccionado = botonSeleccionado;
            this.dgv = dgv;


          

            if (botonSeleccionado.Text == "Modificar")
            {
                Visibilidad visibilidad = dgv.CurrentRow.DataBoundItem as Visibilidad;

                //agregando al combo los codigos de visibilidad
                this.cargarComboBoxCodigos();

                this.cargarForm(visibilidad);

            }
            else if (botonSeleccionado.Text == "Nueva")
            {
                this.label7.Hide();
                this.codigoComboBox.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cargarForm(Visibilidad visibilidad)
        {
            this.nombreTextBox.Text = visibilidad.Descripcion;
            this.costoTextBox.Text = Convert.ToString(visibilidad.Costo_Publicacion);
            this.porcentajeTextBox.Text = Convert.ToString(visibilidad.Porcentaje_Venta);
            this.checkBox.Checked = visibilidad.habilitada;

        ;

        }


        private void cargarComboBoxCodigos()
        {
           
            int i = Convert.ToInt32(this.dgv.Rows[0].Cells[0].Value);

            while (i < this.dgv.RowCount)
            {
                this.codigoComboBox.Items.Add(i);
                i++;
            }

     

        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            bool chequeado = false;

            //chequeo de campos obligatorios
            if (this.nombreTextBox.Text.Equals("") || this.costoTextBox.Text.Equals("") || this.porcentajeTextBox.Text.Equals(""))
            {
                MessageBox.Show("Por favor complete los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                chequeado = true;

            //si la visibilidad es nueva
            if (this.botonSeleccionado.Text == "Nueva" && chequeado)
            {
                    int habilitada = 0;

                    if (this.checkBox.Checked)
                        habilitada = 1;


                    List<SqlParameter> parametros = new List<SqlParameter>();
                  
                    BDSQL.agregarParametro(parametros, "@descripcion", Convert.ToString(this.nombreTextBox.Text));
                    BDSQL.agregarParametro(parametros, "@costoPublicacion", Convert.ToDecimal(this.costoTextBox.Text));
                    BDSQL.agregarParametro(parametros, "@porcentajeVenta", Convert.ToDecimal(this.porcentajeTextBox.Text) / 100);
                    BDSQL.agregarParametro(parametros, "@habilitada", habilitada);

                    

                   BDSQL.ExecStoredProcedureSinRet("MERCADONEGRO.AgregarVisibilidad", parametros);
                   BDSQL.cerrarConexion();


                   MessageBox.Show("¡Visibilidad Agregada!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   this.Close();

                
            }




        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
