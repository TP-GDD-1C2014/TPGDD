using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using System.Security.Cryptography;

namespace FrbaCommerce.Login
{
    public partial class CambiarPassword : Form
    {
        public Boolean primeraVez { get; set; }
        public CambiarPassword(Boolean pVez)
        {
            this.primeraVez = pVez;
            InitializeComponent();

            if (primeraVez)
            {
                passViejoNH.Enabled = false;
                MessageBox.Show("Con el fin de mejorar la protección de sus datos personales, hemos implementado\njunto al nuevo sistema de gestión una nueva política de seguridad.\n\nPara ello, le solicitamos que ingrese nuevamente su contraseña, o escoja una nueva. \n\nAtte,\nEl personal de MercadoNegro", "Bienvenido al nuevo sistema");
            }
        }

        private void pass2_TextChanged(object sender, EventArgs e)
        {
            pass2.PasswordChar = '*';
        }

        private void pass1_TextChanged(object sender, EventArgs e)
        {
            pass1.PasswordChar = '*';
        }

        private void passViejo_TextChanged(object sender, EventArgs e)
        {
            passViejoNH.PasswordChar = '*';
        }

        public Boolean chequearPassword(string password)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", Interfaz.usuario.ID_User);
            BDSQL.agregarParametro(listaParametros, "@Password", password);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Password FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User AND Password = @Password", listaParametros, BDSQL.iniciarConexion());
            Boolean res = lector.HasRows;
            BDSQL.cerrarConexion();
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((!passViejoNH.Text.Equals("") || primeraVez == true) && !pass1.Text.Equals("") && !pass2.Text.Equals(""))
            {
                if (primeraVez == false)
                {
                    UTF8Encoding encoderHash = new UTF8Encoding();
                    SHA256Managed hasher = new SHA256Managed();
                    byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(passViejoNH.Text));
                    string passViejo = bytesDeHasheoToString(bytesDeHasheo);

                    if (chequearPassword(passViejo))
                    {
                        if (pass1.Text == pass2.Text)
                        {
                            Interfaz.usuario.cambiarPassword(pass1.Text);
                            MessageBox.Show("Contraseña modificada.");
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El password viejo no es correcto.", "Error");
                    }
                }
                else
                {
                    if (pass1.Text == pass2.Text)
                    {
                        Interfaz.usuario.cambiarPassword(pass1.Text);
                        MessageBox.Show("Contraseña modificada.");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden.", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos solicitados.", "Error");
            }
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
    }
}
