using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Clases;

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class ListadoEstadisticoForm : Form
    {

        public ListadoEstadisticoForm()
        {
            InitializeComponent();

            this.trimestreCombo.Items.Add(1);
            this.trimestreCombo.Items.Add(2);
            this.trimestreCombo.Items.Add(3);
            this.trimestreCombo.Items.Add(4);

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
            int trimestre = this.trimestreCombo.SelectedIndex + 1;
            int anio = Convert.ToInt32(this.anioTextbox.Text);
            int opcionElegida = this.trimestreCombo.SelectedIndex + 1;

            ListadoEstadistico listado = new ListadoEstadistico(trimestre, anio);

            this.top5DataGriedView.DataSource = listado.buscar(opcionElegida);
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
    }
}
