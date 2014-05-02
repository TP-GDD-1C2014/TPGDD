using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class RegistroUsuarioForm : Form
    {

        public RegistroUsuarioForm()
        {
            InitializeComponent();

            // Empezamos transacción
            

            //dummy (borrar dps!)
            Rol_Combo.Items.Add("Cliente");
            Rol_Combo.Items.Add("Empresa");
            Rol_Combo.Sorted = true;
            Rol_Combo.DropDownStyle = ComboBoxStyle.DropDown;

            //dummy adicionales x rol
            OcultarAdicionales();
        }

        //funcion para ocultar controles adiocionales (especificos x rol)
        private void OcultarAdicionales()
        {
            Tipo_Doc_Label.Visible = false;
            Tipo_Doc_TextBox.Visible = false;
            Razon_Social_Label.Visible = false;
            Razon_Social_TextBox.Visible = false;
        }

        private void RegistroUsuarioForm_Load(object sender, EventArgs e)
        {

        }

        private void Contrasenia_Label_Click(object sender, EventArgs e)
        {

        }

        private void Password_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Limpiar_Button_Click(object sender, EventArgs e)
        {
            Common.Interfaz.limpiarInterfaz(this);
            Rol_Combo.Text = "";
            OcultarAdicionales();
        }

        private void Rol_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mostrar los Strings de cada rol que se encuentren en la base de datos
            //anexo del dummy, debera ser SWTICH para mas de 2(dos) roles

           

              if (((string) Rol_Combo.SelectedItem).Equals("Cliente"))
                {
                    Tipo_Doc_Label.Visible       = true;
                    Tipo_Doc_TextBox.Visible     = true;
                    Razon_Social_Label.Visible   = false;
                    Razon_Social_TextBox.Visible = false;
                }

              else
                 {
                    Tipo_Doc_Label.Visible       = false;
                    Tipo_Doc_TextBox.Visible     = false;
                    Razon_Social_Label.Visible   = true;
                    Razon_Social_TextBox.Visible = true;
                  }
               
      
           


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Tipo_Doc_Label_Click(object sender, EventArgs e)
        {

        }
    }
}
