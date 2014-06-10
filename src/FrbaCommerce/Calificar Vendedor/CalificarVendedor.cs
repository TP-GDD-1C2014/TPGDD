using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using FrbaCommerce.Clases;
using System.Data.SqlClient;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class CalificarVendedor : Form
    {
        public CalificarVendedor()
        {
            InitializeComponent();
            actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calificacion calif = calificacionesDataGrid.CurrentRow.DataBoundItem as Calificacion;

            if (calif.Puntaje == null)
            {
                CalificarDlg calificarDlg = new CalificarDlg(calif.Cod_Calificacion);
                calificarDlg.ShowDialog();
            }
            else MessageBox.Show("Esta compra ya fue calificada, no puede volver a hacerlo.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

            actualizar();
        }

        private void actualizar()
        {
            calificacionesDataGrid.DataSource = Calificacion.obtenerCalificaciones(Interfaz.usuario.ID_User);
        }

        
    }
}
