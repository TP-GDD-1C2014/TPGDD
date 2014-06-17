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
            this.CenterToScreen();
            actualizar();
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            if (calificacionesDataGrid.SelectedRows.Count > 0)
            {
                Calificacion calif = calificacionesDataGrid.CurrentRow.DataBoundItem as Calificacion;

                if (calif.Puntaje == null)
                {
                    CalificarDlg calificarDlg = new CalificarDlg(calif.Cod_Calificacion);
                    calificarDlg.ShowDialog();
                }
                else MessageBox.Show("Esta compra ya fue calificada, no puede volver a hacerlo.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                actualizar();

                if (calificacionesDataGrid.RowCount == 0 && (!Usuario.habilitadoCompra(Interfaz.usuario.ID_User)))
                {
                    Usuario.updateHabilitadoCompra(Interfaz.usuario.ID_User, true);
                    MessageBox.Show("Gracias por calificar a los vendedores! Está nuevamente habilitado para comprar.", "Congratz!", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }

        private void actualizar()
        {
            calificacionesDataGrid.DataSource = Calificacion.obtenerCalificaciones(Interfaz.usuario.ID_User);
        }

        private void btnVerPublicacion_Click(object sender, EventArgs e)
        {
            if (calificacionesDataGrid.SelectedRows.Count > 0)
            {

                Calificacion calif = calificacionesDataGrid.CurrentRow.DataBoundItem as Calificacion;

                int codPublicacion = Calificacion.getCodPublicacion(calif.Cod_Calificacion);
                Historial_Cliente.VerPublicacion verPublicacionForm = new FrbaCommerce.Historial_Cliente.VerPublicacion(codPublicacion);
                verPublicacionForm.ShowDialog();
              
            }
        }

        
    }
}
