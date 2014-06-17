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

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class ResponderPreguntas : Form
    {
      
        public ResponderPreguntas()
        {
            InitializeComponent();
            this.CenterToScreen();
            cargarPreguntas();
        }

        private void cargarPreguntas()
        {
            preguntasDataGrid.DataSource = Pregunta.obtenerPreguntas(Interfaz.usuario.ID_User);
            preguntasDataGrid.Columns["ID_User"].Visible = false;
            preguntasDataGrid.Columns["ID_Pregunta"].Visible = false;
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            if (preguntasDataGrid.SelectedRows.Count > 0)
            {
                Pregunta unaPregunta = preguntasDataGrid.CurrentRow.DataBoundItem as Pregunta;

                ResponderDlg responderDlg = new ResponderDlg(unaPregunta);
                responderDlg.ShowDialog();

                cargarPreguntas();
            }
            else MessageBox.Show("Seleccione un elemento de la lista por favor.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
