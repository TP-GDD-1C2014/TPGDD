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

            //dummy (borrar dps!)
            Rol_Combo.Items.Add("Cliente");
            Rol_Combo.Items.Add("Empresa");
            Rol_Combo.Sorted = true;
            Rol_Combo.DropDownStyle = ComboBoxStyle.DropDown;
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
            Rol_Combo.SelectedItem = "";
        }

        private void Rol_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mostrar los Strings de cada rol que se encuentren en la base de datos

           
      
           


        }
    }
}
