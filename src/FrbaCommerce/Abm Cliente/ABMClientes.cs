using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class ABMClientes : Form
    {
        public string tipoDoc { get; set; }
        public int numDoc { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string codPostal { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public Login.SeleccionFuncionalidades formAnterior { get; set; }

        public ABMClientes(Login.SeleccionFuncionalidades _formAnterior)
        {
            this.formAnterior = _formAnterior;
            InitializeComponent();

            cbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarCbDia();
            llenarCbMes();
            llenarCbAno();
            llenarCbTipoDoc();
        }

        public void llenarCbDia()
        {
            int i;
            for (i = 0; i <= 31; i++)
            {
                this.cbDia.Items.Add(i.ToString());
            }
        }

        public void llenarCbMes()
        {
            int i;
            for (i = 0; i <= 12; i++)
            {
                this.cbMes.Items.Add(i.ToString());
            }
        }

        public void llenarCbAno()
        {
            int i;
            for (i = 1914; i <= 2014; i++)
            {
                this.cbAno.Items.Add(i.ToString());
            }
        }

        public void llenarCbTipoDoc()
        {
            this.cbTipoDocumento.Items.Add("DU");
            this.cbTipoDocumento.Items.Add("CI");
            this.cbTipoDocumento.Items.Add("LC");
        }

        private void ABMClientes_Load(object sender, EventArgs e)
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

        public string cboxString(ComboBox combobox)
        {
            return combobox.SelectedItem.ToString();
        }

        public DateTime fecha(string dia, string mes, string ano)
        {
            if (Convert.ToInt32(dia) <= 9)
            {
                dia = "0" + dia;
            }
            if (Convert.ToInt32(mes) <= 9)
            {
                mes = "0" + mes;
            }
            return DateTime.ParseExact(dia + "/" + mes + "/" + ano, "dd/MM/yyyy", null);
        }

        public Boolean chequearCampos()
        {
            if (!campoVacio(tNombre) && !campoVacio(tApellido) && !campoVacio(tNumeroDocumento) && !campoVacio(tEmail) && !campoVacio(tDireccion) && !campoVacio(tCodigoPostal) && !cboxVacio(cbTipoDocumento) && !cboxVacio(cbDia) && !cboxVacio(cbMes) && !cboxVacio(cbAno))
            {
                if (campoNumerico(tNumeroDocumento) && (campoVacio(tTelefono) || (!campoVacio(tTelefono) && campoNumerico(tTelefono))))
                {
                    if (!campoVacio(tTelefono))
                    {
                        this.telefono = tTelefono.Text;
                    }
                    else
                    {
                        this.telefono = "";
                    }
                    this.tipoDoc = cboxString(cbTipoDocumento);
                    this.numDoc = Convert.ToInt32(tNumeroDocumento.Text);
                    this.nombre = tNombre.Text;
                    this.apellido = tApellido.Text;
                    this.email = tEmail.Text;
                    this.direccion = tDireccion.Text;
                    this.codPostal = tCodigoPostal.Text;
                    this.fechaNacimiento = fecha(cboxString(cbDia), cboxString(cbMes), cboxString(cbAno));
                    return true;
                }
                else
                {
                    MessageBox.Show("Número de documento y/o teléfono inválido/s", "Error");
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
                MessageBox.Show("Usuario:\n\nusername: "+username+"\npassword: "+password+"\nintentosLogin: "+intentosLogin.ToString()+"\nhabilitado: "+habilitado.ToString()+"\nprimeraVez: "+primeraVez.ToString());
                MessageBox.Show("Cliente:\n\ntipoDoc: " + this.tipoDoc + "\nnumDoc: " + this.numDoc.ToString() + "\nnombre: " + this.nombre + "\napellido: " + this.apellido + "\nemail: " + this.email + "\ntelefono: " + this.telefono + "\ndireccion: " + this.direccion + "\ncodPostal: " + this.codPostal + "fechaNacimiento: " + this.fechaNacimiento.ToString());
            }
        }
    }
}
