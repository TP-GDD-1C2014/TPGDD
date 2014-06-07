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

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class ABMVisibilidad : Form
    {
        public ABMVisibilidad()
        {
            InitializeComponent();
            this.cargarVisibilidades();
            Interfaz.bloquearDataGridView(this.dgvVisibilidades);
            
        }


        private void cargarVisibilidades()
        {
            this.dgvVisibilidades.DataSource = Visibilidad.ObtenerVisibilidades();
            this.dgvVisibilidades.Refresh();
               
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevaButton_Click(object sender, EventArgs e)
        {
            EditorDeVisibilidades editForm = new EditorDeVisibilidades();
            editForm.ShowDialog();

        }


    }
}
