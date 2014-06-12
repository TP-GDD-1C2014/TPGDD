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
        int idUser;

        public ResponderPreguntas(int id_user)
        {
            InitializeComponent();
            idUser = id_user;
            cargarPreguntas();
        }

        private void cargarPreguntas()
        {
            preguntasDataGrid.DataSource = Pregunta.obtenerPreguntas(Interfaz.usuario.ID_User);

        }
    }
}
