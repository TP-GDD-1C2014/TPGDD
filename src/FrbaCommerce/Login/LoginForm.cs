using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Clases;
using FrbaCommerce.Registro_de_Usuario;




namespace FrbaCommerce.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            // Consultar en la base de datos y verificar la password, y con esto ver si loguea o no (en este caso sumar +1 cantidad_intentos)
            string username = Username_TextBox.Text;
            string password = Password_TextBox.Text;

            if (!username.Equals("") || !password.Equals(""))
            {
                Usuario usuarioLogin = new Usuario(username, password);

                if (usuarioLogin.verificarContrasenia())
                {
                    //se logueo correctamente

                    //reseteando intentos fallidos
                    usuarioLogin.ResetearIntentosFallidos();

                    //Segun el rol (Ó LOS ROLES!!) que tenga, abrir la AMB correspondiente

                }
                else
                {
                    // login incorrecto, se suma + 1 lo intentos fallidos
                    usuarioLogin.sumarIntentoFallido();

                    // la idea aca es meter la cantidad restante de intentos
                    MessageBox.Show("ERRROR: Usuario o contraseña incorrecta, le quedan X intentos");

                }

            }
            else
            {
                MessageBox.Show("Por favor, complete los campos correspondientes");
            }
        }

        private void RegistrarUsuario_Button_Click(object sender, EventArgs e)
        {
            this.Hide();

            RegistroUsuarioForm formRegistro = new RegistroUsuarioForm();
            formRegistro.Show();
        }
    }
}
