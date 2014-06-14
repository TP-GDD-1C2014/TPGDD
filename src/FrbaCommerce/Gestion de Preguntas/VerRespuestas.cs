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
    public partial class VerRespuestas : Form
    {
        public VerRespuestas()
        {
            InitializeComponent();
            cargarRespuestas();
        }

        private void cargarRespuestas()
        {
            respuestasDataGrid.DataSource = Pregunta.obtenerRespuestas(Interfaz.usuario.ID_User);
            respuestasDataGrid.Columns["ID_User"].Visible = false;
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (respuestasDataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow row = respuestasDataGrid.CurrentRow;

                string pregunta = Convert.ToString(row.Cells[4].Value);
                string respuesta = Convert.ToString(row.Cells[5].Value);
                DateTime fechaRespuesta = Convert.ToDateTime(row.Cells[6].Value);

                VerRespuestaDlg verRespeustasDlg = new VerRespuestaDlg(pregunta, respuesta, fechaRespuesta);

                verRespeustasDlg.ShowDialog();
            }
            else MessageBox.Show("Seleccione un elemento de la lista por favor.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    

        
    }
}
