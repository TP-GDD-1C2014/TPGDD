using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class RegistroUsuarioForm : Form
    {
        public Login.LoginForm formAnterior { get; set; }

        public RegistroUsuarioForm(Login.LoginForm formAnt)
        {
            this.formAnterior = formAnt;
            InitializeComponent();
            this.CenterToScreen();
            Rol_Combo.Items.Add("Cliente");
            Rol_Combo.Items.Add("Empresa");
            Rol_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void RegistroUsuarioForm_Load(object sender, EventArgs e)
        {

        }

        private void Contrasenia_Label_Click(object sender, EventArgs e)
        {

        }

        private void Password_TextBox_TextChanged(object sender, EventArgs e)
        {
            Password_TextBox.PasswordChar = '*';
        }

        private void Limpiar_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            formAnterior.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Tipo_Doc_Label_Click(object sender, EventArgs e)
        {

        }

        private void Registrar_Button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username_TextBox.Text) && !string.IsNullOrEmpty(Password_TextBox.Text) && Rol_Combo.SelectedIndex != -1)
            {
                if(!BDSQL.existeString(Username_TextBox.Text, "MERCADONEGRO.Usuarios", "Username")){
                    if (Rol_Combo.SelectedIndex == 0)
                    {
                        RegistroUsuarioForm3 form2 = new RegistroUsuarioForm3(Username_TextBox.Text, Password_TextBox.Text, Rol_Combo.SelectedIndex);
                        this.Hide();
                        form2.Show();
                    }
                    else
                    {
                        RegistroUsuarioForm1 form3 = new RegistroUsuarioForm1(Username_TextBox.Text, Password_TextBox.Text, Rol_Combo.SelectedIndex);
                        this.Hide();
                        form3.Show();
                    }
                } else {
                    MessageBox.Show("Usuario ya existente.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar el formulario.", "Error");
            }
        }

        private void Rol_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Username_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Username_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

    }
}
