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

            this.tipoListadoCombo.Items.Add("Vendedores con mayor cantidad de Productos no Vendidos");
            this.tipoListadoCombo.Items.Add("Vendedores con mayor Facturación");
            this.tipoListadoCombo.Items.Add("Vendedores con mayor Reputación");
            this.tipoListadoCombo.Items.Add("Clientes con mayor cantidad de publicaciones sin calificar");
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

            ListadoEstadistico listadoEstadistico = new Listado_Estadistico();
        }
    }
}
