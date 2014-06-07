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

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class ListadoEstadisticoForm : Form
    {

   

        public ListadoEstadisticoForm()
        {
            InitializeComponent();

          

            //Cargando combo de trimestre
            this.trimestreCombo.Items.Add(1);
            this.trimestreCombo.Items.Add(2);
            this.trimestreCombo.Items.Add(3);
            this.trimestreCombo.Items.Add(4);

            //Cargando Combo de tipos de listados
            this.tipoListadoCombo.Items.Add("Vendedores con Mayor Cantidad de Productos no Vendidos");
            this.tipoListadoCombo.Items.Add("Vendedores con Mayor Facturación");
            this.tipoListadoCombo.Items.Add("Vendedores con Mayor Reputación");
            this.tipoListadoCombo.Items.Add("Clientes con Mayor Cantidad de Publicaciones sin Calificar");


        }

        private void anioLabel_Click(object sender, EventArgs e)
        {

        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {

        }

        private void tipoListadoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void anioTextbox_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void trimestreCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buscarButton_Click(object sender, EventArgs e)
        {

            if (this.verificarCampos(this.groupBox1))
            {
                
                int anio = Convert.ToInt32(this.anioTextbox.Text);
                int trimestre = this.trimestreCombo.SelectedIndex + 1;
                int opcionElegida = this.tipoListadoCombo.SelectedIndex + 1;

                ListadoEstadistico listado = new ListadoEstadistico(trimestre, anio);

                this.top5DataGriedView.DataSource = listado.buscar(opcionElegida);

                if (this.top5DataGriedView.DataSource == null)
                {
                    MessageBox.Show("¡No se encontraron resultados!. Por favor, verifique los filtros seleccionados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.top5DataGriedView.Refresh();


                this.top5DataGriedView = Interfaz.bloquearDataGridView(this.top5DataGriedView);

            }
        }


        private void anioTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void top5DataGriedView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
                         
        }

        private bool verificarCampos(Control control)
        {
            

            foreach(Control c in control.Controls)
            {
                var anioYTrimestre = c as TextBox;
                var tipoListado = c as ComboBox;


                if (anioYTrimestre != null && anioYTrimestre.Text == "")
                {
                    string str = "Los campos no pueden destar vacios";
                    DialogResult result = MessageBox.Show(str, "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

        

                if (tipoListado != null && tipoListado.SelectedIndex == -1)
                {
                    string str = "Los campos no pueden destar vacios";
                    DialogResult result = MessageBox.Show(str, "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                    
                }

            }

            return true;

        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
