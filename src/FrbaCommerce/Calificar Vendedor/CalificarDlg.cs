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
    public partial class CalificarDlg : Form
    {
        int Cod_Calificacion;
        
        public CalificarDlg(int codCalificacion)
        {
            Cod_Calificacion = codCalificacion;
            InitializeComponent();
            this.CenterToScreen();
            cargarCombos();
            rbOpciones.Checked = true;
        }

        private void cargarCombos()
        {
            for (int i = 1; i < 6; i++)
            {
                cmbEstrellas.Items.Add(Convert.ToString(i));
            }

            cmbOpciones.Items.Add("Muy malo");
            cmbOpciones.Items.Add("Malo");
            cmbOpciones.Items.Add("Regular");
            cmbOpciones.Items.Add("Bueno");
            cmbOpciones.Items.Add("Muy bueno");
        }

        private void rbOpciones_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOpciones.Checked)
            {
                txtTextoLibre.Enabled = false;
                cmbOpciones.Enabled = true;
                btnBorrar.Enabled = false;
                txtTextoLibre.Clear();
            }
        }

        private void rbTextoLibre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTextoLibre.Checked)
            {
                txtTextoLibre.Enabled = true;
                cmbOpciones.Enabled = false;
                btnBorrar.Enabled = true;
                cmbOpciones.SelectedIndex = -1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbEstrellas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la cantidad de estrellas que desea puntuar.", "Falta llenar algun campo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                string descripcion;

                if (rbOpciones.Checked)
                {
                    if (cmbOpciones.SelectedIndex != -1)
                        descripcion = cmbOpciones.SelectedItem.ToString();
                    else descripcion = "";
                }
                else descripcion = txtTextoLibre.Text;

                Calificacion calific = new Calificacion(Cod_Calificacion, Convert.ToInt32(cmbEstrellas.SelectedItem.ToString()), descripcion, Interfaz.obtenerFecha());

                Calificacion.updateCalificacion(calific);

                MessageBox.Show("Calificación realizada con éxito!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtTextoLibre.Text = "";
        }
    }
}
