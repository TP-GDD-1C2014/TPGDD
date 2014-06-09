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
            calificacionesDataGrid.DataSource = Calificacion.obtenerCalificaciones(Interfaz.usuario.ID_User);
        }

        
    }
}
