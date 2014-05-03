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
using System.Security.Cryptography;
using System.Data.SqlClient;


namespace FrbaCommerce.Login
{
    public partial class LoginForm : Form
    {
        public const int CANTIDAD_MAXIMA_INTENTOS = 3;


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
            if (!Username_TextBox.Text.Equals("") && !Password_TextBox.Text.Equals(""))
            {
                string username = Username_TextBox.Text;
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(Password_TextBox.Text));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                Usuario usuarioLogin = new Usuario(username, password);

                if (usuarioLogin.verificarContrasenia())
                {
                        usuarioLogin.ResetearIntentosFallidos();
                        if (usuarioLogin.obtenerRoles())
                        {
                            // SEGUIR A PARTIR DE ACA (ALAN) <----
                            // mostrar roles en combobox
                        }
                        else
                        {
                            MessageBox.Show("El usuario no tiene roles asignados");
                            // no tiene roles
                        };
                        //Segun el rol (Ó LOS ROLES!!) que tenga, abrir la ABM correspondiente
                }
                else
                {
                    // login incorrecto, se suma + 1 lo intentos fallidos
                    usuarioLogin.sumarIntentoFallido();

                    // la idea aca es meter la cantidad restante de intentos
                    MessageBox.Show("ERRROR: Usuario o contraseña incorrecta, le quedan X intentos");

                    if (usuarioLogin.cantidadIntentosFallidos() == CANTIDAD_MAXIMA_INTENTOS)
                    {
                        //superó la cantidad maxima de intentos
                        usuarioLogin.inhabilitarUsuario();
                    }

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

        private void Limpiar_Button_Click(object sender, EventArgs e)
        {
            Common.Interfaz.limpiarInterfaz(this);
        }

        //funcion para transformar lo hasheado a string
        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[i].ToString("X2"));
            }
            return salida.ToString();
        }
    }
}
