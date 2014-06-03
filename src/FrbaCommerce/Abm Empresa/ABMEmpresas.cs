using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class ABMEmpresas : Form
    {
        public string razonSocial { get; set; }
        public string cuit { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string codigoPostal { get; set; }
        public string ciudad { get; set; }
        public string mail { get; set; }
        public string nombreContacto { get; set; }
        public DateTime fechaCreacion { get; set; }

        public Login.SeleccionFuncionalidades formAnterior { get; set; }

        public ABMEmpresas(Login.SeleccionFuncionalidades _formAnterior)
        {
            this.formAnterior = _formAnterior;
            InitializeComponent();
        }

        private void ABMEmpresas_Load(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            formAnterior.Show();
        }

        public Boolean campoVacio(TextBox textbox)
        {
            return textbox.Text.Equals("");
        }

        public Boolean cboxVacio(ComboBox combobox)
        {
            if (combobox.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean campoNumerico(TextBox textbox)
        {
            return Interfaz.esNumerico(textbox.Text, System.Globalization.NumberStyles.Integer);
        }

        public Boolean chequearCampos()
        {
            if (!campoVacio(tRazonSocial) && !campoVacio(tEmail) && !campoVacio(tDireccion) && !campoVacio(tCodigoPostal) && !campoVacio(tCuit))
            {
                if (campoVacio(tTelefono) || (!campoVacio(tTelefono) && campoNumerico(tTelefono)))
                {
                    if (!campoVacio(tTelefono))
                    {
                        this.telefono = tTelefono.Text;
                    }
                    else
                    {
                        this.telefono = "";
                    }

                    if (!campoVacio(tCiudad))
                    {
                        this.ciudad = tCiudad.Text;
                    }
                    else
                    {
                        this.ciudad = "";
                    }

                    this.razonSocial = tRazonSocial.Text;
                    this.cuit = tCuit.Text;
                    this.direccion = tDireccion.Text;
                    this.codigoPostal = tCodigoPostal.Text;
                    this.mail = tEmail.Text;
                    this.nombreContacto = tNombreDeContacto.Text;
                    this.fechaCreacion = Interfaz.obtenerFecha();

                    return true;
                }
                else
                {
                    MessageBox.Show("Teléfono inválido", "Error");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                return false;
            }
        }

        public string randomString(int caracteres)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return (new string(
                Enumerable.Repeat(chars, caracteres)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray()));
        }

        public string randomUser()
        {
            string random = "merca" + randomString(10);
            if (!BDSQL.existeString(random, "MERCADONEGRO.Usuarios", "Username"))
            {
                return random;
            }
            else
            {
                return randomUser();
            }
        }

        public string randomPassword()
        {
            return randomString(20);
        }

        private void registrar_Click(object sender, EventArgs e)
        {
            string username = randomUser();
            string password = randomPassword();
            int intentosLogin = 0;
            int habilitado = 1;
            int primeraVez = 1;
            DBNull cantPubliGratuitas = DBNull.Value;
            DBNull reputacion = DBNull.Value;
            DBNull ventasSinRendir = DBNull.Value;

            if (chequearCampos())
            {
                MessageBox.Show("Usuario:\n\nusername: " + username + "\npassword: " + password + "\nintentosLogin: " + intentosLogin.ToString() + "\nhabilitado: " + habilitado.ToString() + "\nprimeraVez: " + primeraVez.ToString());
                MessageBox.Show("Empresa:\n\nrazonSocial: " + this.razonSocial + "\ncuit: " + this.cuit + "\ntelefono: " + this.telefono + "\ndireccion: " + this.direccion + "\ncodigoPostal: " + this.codigoPostal + "\nciudad: " + this.ciudad + "\nmail: " + this.mail + "\nnombreContacto :" + this.nombreContacto + "\nfechaCreacion :" + this.fechaCreacion.ToString());
            }
        }
    }
}
