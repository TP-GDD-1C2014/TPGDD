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
        Usuario user;
        
        public GestionPreguntas()
        {
            InitializeComponent();
            user = Interfaz.usuario;
            txtUsuario.Text = user.Username;
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            ResponderPreguntas responderForm = new ResponderPreguntas(user.ID_User);
            responderForm.ShowDialog();
        }
    }
}
