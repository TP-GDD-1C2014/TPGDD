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

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class GestionPreguntas : Form
    {
       
        public GestionPreguntas()
        {
            InitializeComponent();
            this.CenterToScreen();
            txtUsuario.Text = Interfaz.usuario.Username;
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            ResponderPreguntas responderForm = new ResponderPreguntas();
            responderForm.ShowDialog();
        }

        private void btnRespuestas_Click(object sender, EventArgs e)
        {
            VerRespuestas respuestasForm = new VerRespuestas();
            respuestasForm.ShowDialog();
        }
    }
}
