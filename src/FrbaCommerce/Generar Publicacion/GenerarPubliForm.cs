using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Clases;
using System.Data.SqlClient;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class GenerarPubliForm : Form
    {

        public GenerarPubliForm()
        {
            InitializeComponent();

            //dummy (BORRAR DSP)
            TipoPubli_ComboBox.Items.Add("Compra Inmediata");
            TipoPubli_ComboBox.Items.Add("Subasta");
            TipoPubli_ComboBox.Sorted = true;
            TipoPubli_ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            permitirPreg_combobox.Items.Add("Sí");
            permitirPreg_combobox.Items.Add("No");
            permitirPreg_combobox.Sorted = true;
            permitirPreg_combobox.DropDownStyle = ComboBoxStyle.DropDown;


            OcultarAdicionales();
        }

        private void OcultarAdicionales()
        {            
                PrecioUnit_Label.Visible = false;
                PrecioUnit_textBox.Visible = false;
                PrecioTotal_Label.Visible = false;
                PrecioTotal_textBox.Visible = false;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Visibilidad_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Descrip_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Stock_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FechaFin_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Estado_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TipoPubli_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((string)TipoPubli_ComboBox.SelectedItem).Equals("Compra Inmediata"))
            {
                PrecioUnit_Label.Visible = true;
                PrecioUnit_textBox.Visible = true;
                PrecioTotal_Label.Visible = false;
                PrecioTotal_textBox.Visible = false;
            }

            else
            {
                PrecioUnit_Label.Visible = false;
                PrecioUnit_textBox.Visible = false;
                PrecioTotal_Label.Visible = true;
                PrecioTotal_textBox.Visible = true;
            }
        }

        private void PrecioUnit_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Limpiar_button_Click(object sender, EventArgs e)
        {
            Common.Interfaz.limpiarInterfaz(this);
            Visibilidad_ComboBox.Text = "";
            Estado_ComboBox.Text = "";
            TipoPubli_ComboBox.Text = "";
            OcultarAdicionales();
        }

        private void Guardar_button_Click(object sender, EventArgs e)
        {
            //Controlar que se completen todos los datos
            if (!Visibilidad_ComboBox.Text.Equals("") && !Descrip_TextBox.Text.Equals("") && !Stock_TextBox.Text.Equals("") && !FechaFin_DateTimePicker.Text.Equals("") && !Estado_ComboBox.Text.Equals("") && !TipoPubli_ComboBox.Text.Equals("") && !PrecioTotal_textBox.Text.Equals("") && !PrecioUnit_textBox.Text.Equals(""))
            {
                //Configurar publicación a ser creada
                int visibilidad = Convert.ToInt32(Visibilidad_ComboBox.Text);
                //Conseguir la ID_Vendedor
                
                string descripcion = Descrip_TextBox.Text;
                int stock;
                stock = Convert.ToInt32(Stock_TextBox.Text);
                stock = int.Parse(Stock_TextBox.Text);
                DateTime fechaFin = Convert.ToDateTime(FechaFin_DateTimePicker.Text);
                Estado_Publicacion estado = (Estado_Publicacion)Enum.Parse(typeof(Estado_Publicacion), Estado_ComboBox.Text);
                Tipo_Publicacion tipoPubli = (Tipo_Publicacion)Enum.Parse(typeof(Tipo_Publicacion), TipoPubli_ComboBox.Text);
                int precioTotal = Convert.ToInt32(PrecioTotal_textBox.Text);
                /* Alternativa?
                int precioTotal;
                precioTotal = int.Parse(PrecioTotal_textBox.Text);
                int precioUnit; */
                int precioUnit = Convert.ToInt32(PrecioUnit_textBox.Text);

                //Publicacion publiNueva = new Publicacion(visibilidad, vendedor, descripcion, stock, fechaFin, estado, tipoPubli, precioTotal, precioUnit);

                //Insertar publicacion en la tabla publicaciones
                //publiNueva.agregarPublicacion();
            }

            
        }

        private void permitirPreg_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerarPubliForm_Load(object sender, EventArgs e)
        {

        }






    }
}
