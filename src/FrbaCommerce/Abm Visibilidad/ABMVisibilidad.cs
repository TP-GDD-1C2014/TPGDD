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
            CenterToScreen();
            this.cargarVisibilidades();
            Interfaz.bloquearDataGridView(this.dgvVisibilidades);
            
        }


        private void cargarVisibilidades()
        {
            this.dgvVisibilidades.DataSource = Visibilidad.ObtenerVisibilidades();

            //cambiando nombre de las columnas...

            foreach (DataGridViewColumn columna in this.dgvVisibilidades.Columns)
            {
                if (columna.Name == "Porcentaje_Venta")
                    columna.HeaderText = "Porcentaje por Venta";
                else if (columna.Name == "habilitada")
                    columna.HeaderText = "Habilitada";
                else if (columna.HeaderText == "Cod_Visibilidad")
                    columna.HeaderText = "Código de la Visibilidad";
                else if (columna.HeaderText == "Costo_Publicacion")
                    columna.HeaderText = "Costo por Publicar";
             
            }


            this.dgvVisibilidades.Refresh();
               
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevaButton_Click(object sender, EventArgs e)
        {
            EditorDeVisibilidades editForm = new EditorDeVisibilidades(this.nuevaButton, this.dgvVisibilidades);
            editForm.ShowDialog();

            this.cargarVisibilidades();
            this.dgvVisibilidades.Refresh();

        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            EditorDeVisibilidades editForm = new EditorDeVisibilidades(this.modificarButton, this.dgvVisibilidades);
            editForm.ShowDialog();

            this.cargarVisibilidades();
            this.dgvVisibilidades.Refresh();


        }

        private void dgvVisibilidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ABMVisibilidad_Load(object sender, EventArgs e)
        {

        }


    }
}
