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
    public partial class RegistroUsuarioForm1 : Form
    {
        public string username { get; set; }
        public string password { get; set; }
        public int rol { get; set; }

        public RegistroUsuarioForm1(string user, string pass, int rol)
        {
            this.username = user;
            this.password = pass;
            this.rol = rol;
            InitializeComponent();
            this.CenterToScreen();
        }

        public Boolean registrarEmpresa(string username, string passwordNoHash, string razonSocial, string cuit, string telefono, string direccion, string codigoPostal, string ciudad, string email, string nombreContacto, DateTime fechaCreacion)
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
                BDSQL.agregarParametro(listaParametros3, "@Razon_Social", razonSocial);
                BDSQL.agregarParametro(listaParametros3, "@CUIT", cuit);
                BDSQL.agregarParametro(listaParametros3, "@Direccion", direccion);
                BDSQL.agregarParametro(listaParametros3, "@Codigo_Postal", codigoPostal);
                BDSQL.agregarParametro(listaParametros3, "@Mail", email);
                BDSQL.agregarParametro(listaParametros3, "@Fecha_Creacion", fechaCreacion);

                if (telefono.Equals(""))
                {
                    BDSQL.agregarParametro(listaParametros3, "@Telefono", DBNull.Value);
                }
                else
                {
                    BDSQL.agregarParametro(listaParametros3, "@Telefono", Convert.ToInt64(telefono));
                }

                if (ciudad.Equals(""))
                {
                    BDSQL.agregarParametro(listaParametros3, "@Ciudad", DBNull.Value);
                }
                else
                {
                    BDSQL.agregarParametro(listaParametros3, "@Ciudad", ciudad);
                }

                if (nombreContacto.Equals(""))
                {
                    BDSQL.agregarParametro(listaParametros3, "@Nombre_Contacto", DBNull.Value);
                }
                else
                {
                    BDSQL.agregarParametro(listaParametros3, "@Nombre_Contacto", nombreContacto);
                }

                BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Empresas VALUES(@ID_User, @Razon_Social, @CUIT, @Telefono, @Direccion, @Codigo_Postal, @Ciudad, @Mail, @Nombre_Contacto, @Fecha_Creacion)", listaParametros3, BDSQL.iniciarConexion());
                BDSQL.cerrarConexion();

                List<SqlParameter> listaParametros4 = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros4, "@Nombre", "Empresa");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!razonSocial.Text.Equals("") && !cuit.Text.Equals("") && !direccion.Text.Equals("") && !codigoPostal.Text.Equals("") && !email.Text.Equals(""))
            {
                if (!BDSQL.existeString(razonSocial.Text, "MERCADONEGRO.Empresas", "Razon_Social"))
                {
                    if (!BDSQL.existeString(cuit.Text, "MERCADONEGRO.Empresas", "CUIT"))
                    {
                        if (Interfaz.esNumerico(telefono.Text, System.Globalization.NumberStyles.Integer) || telefono.Text.Equals(""))
                        {
                            if (!BDSQL.existeTelefono(Convert.ToInt32(telefono.Text)))
                            {
                                registrarEmpresa(username, password, razonSocial.Text, cuit.Text, telefono.Text, direccion.Text, codigoPostal.Text, ciudad.Text, email.Text, nombreContacto.Text, Interfaz.obtenerFecha());
                                MessageBox.Show("Alta finalizada. Puede ingresar al sistema.", "Registro exitoso");
                                Login.LoginForm form = new Login.LoginForm();
                                this.Hide();
                                form.Show();
                            }
                            else
                            {
                                MessageBox.Show("Teléfono existente.", "Error");
                            }
                        } else {
                            MessageBox.Show("Teléfono inválido existente.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("CUIT ya existente.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Razón Social ya existente.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos solicitados.", "Error");
            }
        }

       

        private void cancel_Click(object sender, EventArgs e)
        {
            Login.LoginForm form = new Login.LoginForm();
            this.Hide();
            form.Show();
        }

        private void textboxNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                   && !char.IsDigit(e.KeyChar)
                   )
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
