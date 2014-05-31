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

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FacturarForm : Form
    {
        public FacturarForm()
        {
            InitializeComponent();

            this.generarDataGrid(Interfaz.usuarioActual());

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvOperaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void generarDataGrid(Usuario usuario)
        {
            Facturacion factura = new Facturacion();

            this.dgvOperaciones.DataSource = factura.obtenerOperaciones(usuario);
            this.dgvOperaciones.Refresh();
            
        }



    }
}
