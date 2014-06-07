using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class EditorDeVisibilidades : Form
    {
        public EditorDeVisibilidades()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            if (this.nombreTextBox.Equals("") || this.costoTextBox.Equals("") || this.porcentajeTextBox.Equals(""))
            {
                MessageBox.Show("Por favor complete los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
