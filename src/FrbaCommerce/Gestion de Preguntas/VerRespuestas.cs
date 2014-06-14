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
            respuestasDataGrid.DataSource = Pregunta.obtenerPreguntas(Interfaz.usuario.ID_User, "respuestas");  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerRespuestaDlg verRespeustasDlg = new VerRespuestaDlg();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
