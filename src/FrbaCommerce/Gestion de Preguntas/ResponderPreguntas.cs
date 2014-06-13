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
            cargarPreguntas();
        }

        private void cargarPreguntas()
        {
            preguntasDataGrid.DataSource = Pregunta.obtenerPreguntas(Interfaz.usuario.ID_User, "preguntas");

        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            Pregunta unaPregunta = preguntasDataGrid.CurrentRow.DataBoundItem as Pregunta;


            ResponderDlg responderDlg = new ResponderDlg(unaPregunta);
            responderDlg.ShowDialog();

            cargarPreguntas();
        }
    }
}
