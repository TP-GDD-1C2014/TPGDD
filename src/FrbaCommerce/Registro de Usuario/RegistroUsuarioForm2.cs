using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Common;
using System.Security.Cryptography;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class RegistroUsuarioForm3 : Form
    {
        public string username { get; set; }
        public string password { get; set; }
        public int rol { get; set; }

        public RegistroUsuarioForm3(string user, string pass, int rol)
        {
            this.username = user;
            this.password = pass;
            this.rol = rol;
            InitializeComponent();
            this.CenterToScreen();

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
            for (i = 1; i <= 31; i++)
            {
                this.cbDia.Items.Add(i.ToString());
            }
        }

        public void llenarCbMes()
        {
            int i;
            for (i = 1; i <= 12; i++)
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

        public Boolean registrarCliente(string username, string passwordNoHash, string tipoDocumento, string numeroDocumento, string nombre, string apellido, string email, string telefono, string direccion, string codigoPostal, DateTime fechaNacimiento)
        {
            try
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(passwordNoHash));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros, "@Username", username);
                BDSQL.agregarParametro(listaParametros, "@Password", password);
                BDSQL.agregarParametro(listaParametros, "@Intentos_Login", 0);
                //BDSQL.agregarParametro(listaParametros, "@Habilitado", 1);
                BDSQL.agregarParametro(listaParametros, "@Primera_Vez", 0);
                BDSQL.agregarParametro(listaParametros, "@Cant_Publi_Gratuitas", 0);
                BDSQL.agregarParametro(listaParametros, "@Reputacion", 0);
                BDSQL.agregarParametro(listaParametros, "@Ventas_Sin_Rendir", 0);
                //BDSQL.agregarParametro(listaParametros, "@Habilitado_Compra", 1);
                BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Usuarios (Username, Password, Intentos_Login, Primera_Vez, Cant_Publi_Gratuitas, Reputacion, Ventas_Sin_Rendir) VALUES (@Username, @Password, @Intentos_Login, @Primera_Vez, @Cant_Publi_Gratuitas, @Reputacion, @Ventas_Sin_Rendir)", listaParametros, BDSQL.iniciarConexion());
                BDSQL.cerrarConexion();

                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros2, "@Username", username);
                SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User FROM MERCADONEGRO.Usuarios WHERE Username = @Username", listaParametros2, BDSQL.iniciarConexion());
                lector.Read();
                int idUser = Convert.ToInt32(lector["ID_User"]);
                BDSQL.cerrarConexion();

                List<SqlParameter> listaParametros3 = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros3, "@ID_User", idUser);
                BDSQL.agregarParametro(listaParametros3, "@Tipo_Doc", tipoDocumento);
                BDSQL.agregarParametro(listaParametros3, "@Num_Doc", numeroDocumento);
                BDSQL.agregarParametro(listaParametros3, "@Nombre", nombre);
                BDSQL.agregarParametro(listaParametros3, "@Apellido", apellido);
                BDSQL.agregarParametro(listaParametros3, "@Mail", email);
                BDSQL.agregarParametro(listaParametros3, "@Direccion", direccion);
                BDSQL.agregarParametro(listaParametros3, "@Codigo_Postal", codigoPostal);
                BDSQL.agregarParametro(listaParametros3, "@Fecha_Nacimiento", fechaNacimiento);

                if (telefono.Equals(""))
                {
                    BDSQL.agregarParametro(listaParametros3, "@Telefono", DBNull.Value);
                }
                else
                {
                    BDSQL.agregarParametro(listaParametros3, "@Telefono", Convert.ToInt64(telefono));
                }

                BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Clientes VALUES(@ID_User, @Tipo_Doc, @Num_Doc, @Nombre, @Apellido, @Mail, @Telefono, @Direccion, @Codigo_Postal, @Fecha_Nacimiento)", listaParametros3, BDSQL.iniciarConexion());
                BDSQL.cerrarConexion();

                List<SqlParameter> listaParametros4 = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros4, "@Nombre", "Cliente");
                SqlDataReader lector1 = BDSQL.ejecutarReader("SELECT ID_Rol FROM MERCADONEGRO.Roles WHERE Nombre = @Nombre", listaParametros4, BDSQL.iniciarConexion());
                lector1.Read();
                int idRol = Convert.ToInt32(lector1["ID_Rol"]);
                BDSQL.cerrarConexion();

                List<SqlParameter> listaParametros5 = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros5, "@ID_Rol", idRol);
                BDSQL.agregarParametro(listaParametros5, "@ID_User", idUser);
                BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Roles_Usuarios VALUES(@ID_User, @ID_Rol)", listaParametros5, BDSQL.iniciarConexion());
                BDSQL.cerrarConexion();

                return true;
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message.ToString());
                return false;
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

        public DateTime fechaNacimiento(string dia, string mes, string ano)
        {
            if (Convert.ToInt32(dia) <= 9)
            {
                dia = "0" + dia;
            }
            if (Convert.ToInt32(mes) <= 9)
            {
                mes = "0" + mes;
            }
            return DateTime.ParseExact(dia+"/"+mes+"/"+ano, "dd/MM/yyyy", null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbTipoDocumento.SelectedIndex != -1 && !numeroDocumento.Text.Equals("") && !nombre.Text.Equals("") && !apellido.Text.Equals("") && !email.Text.Equals("") && !direccion.Text.Equals("") && !codigoPostal.Text.Equals("") && cbDia.SelectedIndex != -1 && cbMes.SelectedIndex != -1 && cbAno.SelectedIndex != -1)
            {
                if (Interfaz.esNumerico(numeroDocumento.Text, System.Globalization.NumberStyles.Integer))
                {
                    if (!BDSQL.existenSimultaneamente(numeroDocumento.Text, cbTipoDocumento.SelectedItem.ToString(), "MERCADONEGRO.Clientes", "Num_Doc", "Tipo_Doc"))
                    {
                        if (Interfaz.esNumerico(telefono.Text, System.Globalization.NumberStyles.Integer) || telefono.Text.Equals(""))
                        {
                            if (!BDSQL.existeTelefono(Convert.ToInt32(telefono.Text)))
                            {
                                registrarCliente(username, password, cbTipoDocumento.SelectedItem.ToString(), numeroDocumento.Text, nombre.Text, apellido.Text, email.Text, telefono.Text, direccion.Text, codigoPostal.Text, fechaNacimiento(cbDia.SelectedItem.ToString(), cbMes.SelectedItem.ToString(), cbAno.SelectedItem.ToString()));
                                MessageBox.Show("Alta finalizada. Puede ingresar al sistema.", "Registro exitoso");
                                Login.LoginForm form = new Login.LoginForm();
                                this.Hide();
                                form.Show();
                            }
                            else
                            {
                                MessageBox.Show("Teléfono existente.", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Teléfono inválido.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Datos identificatorios (Tipo de documento, Número de documento) ya existentes.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Número de documento inválido.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos solicitados.", "Error");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Login.LoginForm form = new Login.LoginForm();
            this.Hide();
            form.Show();
        }

        private void RegistroUsuarioForm3_Load(object sender, EventArgs e)
        {

        }

        private void textboxNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textboxNoNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 65 || e.KeyChar > 122)
            {
                e.Handled = true;
            }
        }
    }
}
