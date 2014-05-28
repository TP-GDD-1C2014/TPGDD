using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Clases;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FacturarForm : Form
    {
        public FacturarForm(Usuario user)
        {
            InitializeComponent();



        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void generarDataGrid(Usuario usuario)
        {
            Facturacion factura = new Facturacion();

        }



    }
}
