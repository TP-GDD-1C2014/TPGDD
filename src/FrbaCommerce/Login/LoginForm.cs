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
            this.CenterToScreen();
            this.AcceptButton = Login_Button;
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
                Usuario usuarioLogin = new Usuario(0, username, password);
                if (usuarioLogin.obtenerPK())
                {
                    if (usuarioLogin.habilitado())
                    {
                        if (!usuarioLogin.primeraVez())
                        {
                            if (usuarioLogin.verificarContrasenia())
                            {
                                usuarioLogin.ResetearIntentosFallidos();
                                if (usuarioLogin.obtenerRoles())
                                {
                                    if (usuarioLogin.Roles.Count() == 1)
                                    {
                                        this.Hide();
                                        SeleccionFuncionalidades formSeleccionFuncionalidades = new SeleccionFuncionalidades(usuarioLogin, usuarioLogin.Roles[0].ID_Rol);
                                        formSeleccionFuncionalidades.Show();
                                    }
                                    else
                                    {
                                        this.Hide();
                                        SeleccionRoles formSeleccionRoles = new SeleccionRoles(usuarioLogin);
                                        formSeleccionRoles.Show();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El usuario no tiene roles asignados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                CambiarPassword formPass = new CambiarPassword();
                                formPass.Show();
                            }
                        }
                        else
                        {
                            usuarioLogin.sumarIntentoFallido();
                            if (usuarioLogin.cantidadIntentosFallidos() == CANTIDAD_MAXIMA_INTENTOS)
                            {
                                usuarioLogin.inhabilitarUsuario();
                                MessageBox.Show("Usuario inhabilitado.", "Error");
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrecta, le quedan " + (CANTIDAD_MAXIMA_INTENTOS - usuarioLogin.intentosFallidos()).ToString() + " intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario se encuentra inhabilitado.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no existe.", "Error");
                }

            }
            else
            {
                MessageBox.Show("Por favor, ingrese los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[i].ToString("X2"));
            }
            return salida.ToString();
        }

        private void Password_TextBox_TextChanged(object sender, EventArgs e)
        {
            Password_TextBox.PasswordChar = '*';
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
