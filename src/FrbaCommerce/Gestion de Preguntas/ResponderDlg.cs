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
    public partial class ResponderDlg : Form
    {
        Pregunta pregunta;

        public ResponderDlg(Pregunta preg)
        {
            InitializeComponent();
            this.CenterToScreen();
            pregunta = preg;
            txtPregunta.Text = pregunta._Pregunta;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtRespuesta.Clear();
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            if (txtRespuesta.Text == "")
                MessageBox.Show("Por favor escriba su respuesta.", "Falta llenar algun campo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                pregunta.Respuesta = txtRespuesta.Text;
                bool respuesta = Pregunta.actualizarRespuesta(pregunta);

                if (!respuesta)
                    MessageBox.Show("No se puedo responder la pregunta.", "Error no esperado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Respuesta enviada con éxito!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.DialogResult = DialogResult.OK;
                }
            }

        }
    }
}
