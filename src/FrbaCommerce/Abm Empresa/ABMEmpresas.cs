using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using FrbaCommerce.Common;
using FrbaCommerce.Clases;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class ABMEmpresas : Form
    {
        public string username { get; set; }
        public string password { get; set; }
        public int intentosLogin { get; set; }
        public int habilitado { get; set; }
        public int primeraVez { get; set; }
        public DBNull cantPubliGratuitas { get; set; }
        public DBNull reputacion { get; set; }
        public DBNull ventasSinRendir { get; set; }

        public string razonSocial { get; set; }
        public string cuit { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public string codigoPostal { get; set; }
        public string ciudad { get; set; }
        public string mail { get; set; }
        public string nombreContacto { get; set; }
        public DateTime fechaCreacion { get; set; }
        
        public string passwordNoHash { get; set; }

        public Login.SeleccionFuncionalidades formAnterior { get; set; }

        public ABMEmpresas(Login.SeleccionFuncionalidades _formAnterior)
        {
            this.formAnterior = _formAnterior;
            InitializeComponent();

            cbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarCbFiltro();
        }

        public void llenarCbFiltro()
        {
            this.cbFiltro.Items.Add("Razón social");
            this.cbFiltro.Items.Add("CUIT");
            this.cbFiltro.Items.Add("E-mail");
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
                    if (!BDSQL.existeString(tRazonSocial.Text, "MERCADONEGRO.Empresas", "Razon_Social") && !BDSQL.existeString(tCuit.Text, "MERCADONEGRO.Empresas", "CUIT"))
                    {

                        if (!campoVacio(tTelefono))
                        {
                            this.telefono = Convert.ToInt32(tTelefono.Text);
                        }
                        else
                        {
                            this.telefono = -1;
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
                        MessageBox.Show("Razón social y/o CUIT ya existente/s.", "Error");
                        return false;
                    }
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
            string random = "MERCA" + randomString(10);
            if (!BDSQL.existeString(random, "MERCADONEGRO.Usuarios", "Username"))
            {
                return random;
            }
            else
            {
                return randomUser();
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

        public string randomPassword()
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            this.passwordNoHash = randomString(20);
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(this.passwordNoHash));
            return bytesDeHasheoToString(bytesDeHasheo);
        }

        public void cargarUsuario()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Username", this.username);
            BDSQL.agregarParametro(listaParametros, "@Password", this.password);
            BDSQL.agregarParametro(listaParametros, "@Intentos_Login", this.intentosLogin);
            BDSQL.agregarParametro(listaParametros, "@Habilitado", this.habilitado);
            BDSQL.agregarParametro(listaParametros, "@Primera_Vez", this.primeraVez);
            BDSQL.agregarParametro(listaParametros, "@Cant_Publi_Gratuitas", this.cantPubliGratuitas);
            BDSQL.agregarParametro(listaParametros, "@Reputacion", this.reputacion);
            BDSQL.agregarParametro(listaParametros, "@Ventas_Sin_Rendir", this.ventasSinRendir);
            BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Usuarios VALUES (@Username, @Password, @Intentos_Login, @Habilitado, @Primera_Vez, @Cant_Publi_Gratuitas, @Reputacion, @Ventas_Sin_Rendir, 0)", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void cargarEmpresa()
        {
            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros2, "@Username", this.username);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User FROM MERCADONEGRO.Usuarios WHERE Username = @Username", listaParametros2, BDSQL.iniciarConexion());
            lector.Read();
            int idUser = Convert.ToInt32(lector["ID_User"]);
            BDSQL.cerrarConexion();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", idUser);
            BDSQL.agregarParametro(listaParametros, "@Razon_Social", this.razonSocial);
            BDSQL.agregarParametro(listaParametros, "@CUIT", this.cuit);

            if (this.telefono == -1)
            {
                BDSQL.agregarParametro(listaParametros, "@Telefono", DBNull.Value);
            }
            else
            {
                BDSQL.agregarParametro(listaParametros, "@Telefono", this.telefono);
            }

            BDSQL.agregarParametro(listaParametros, "@Direccion", this.direccion);
            BDSQL.agregarParametro(listaParametros, "@Codigo_Postal", this.codigoPostal);

            if (this.ciudad.Equals(""))
            {
                BDSQL.agregarParametro(listaParametros, "@Ciudad", DBNull.Value);
            }
            else
            {
                BDSQL.agregarParametro(listaParametros, "@Ciudad", this.ciudad);
            }


            BDSQL.agregarParametro(listaParametros, "@Mail", this.mail);

            if (this.nombreContacto.Equals(""))
            {
                BDSQL.agregarParametro(listaParametros, "@Nombre_Contacto", DBNull.Value);
            }
            else
            {
                BDSQL.agregarParametro(listaParametros, "@Nombre_Contacto", this.nombreContacto);
            }

            BDSQL.agregarParametro(listaParametros, "@Fecha_Creacion", this.fechaCreacion);
            BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Empresas VALUES (@ID_User, @Razon_Social, @CUIT, @Telefono, @Direccion, @Codigo_Postal, @Ciudad, @Mail, @Nombre_Contacto, @Fecha_Creacion)", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();

            //Obteniendo la ID_Rol del cliente
            int idRol = Rol.obtenerID("Empresa");

            Roles.AgregarRolEnUsuario(idUser, idRol);
        }

        private void registrar_Click(object sender, EventArgs e)
        {
            this.username = randomUser();
            this.password = randomPassword();
            this.intentosLogin = 0;
            this.habilitado = 1;
            this.primeraVez = 1;
            this.cantPubliGratuitas = DBNull.Value;
            this.reputacion = DBNull.Value;
            this.ventasSinRendir = DBNull.Value;

            if (chequearCampos())
            {
                //MessageBox.Show("Usuario:\n\nusername: " + username + "\npassword: " + password + "\nintentosLogin: " + intentosLogin.ToString() + "\nhabilitado: " + habilitado.ToString() + "\nprimeraVez: " + primeraVez.ToString());
                //MessageBox.Show("Empresa:\n\nrazonSocial: " + this.razonSocial + "\ncuit: " + this.cuit + "\ntelefono: " + this.telefono + "\ndireccion: " + this.direccion + "\ncodigoPostal: " + this.codigoPostal + "\nciudad: " + this.ciudad + "\nmail: " + this.mail + "\nnombreContacto: " + this.nombreContacto + "\nfechaCreacion: " + this.fechaCreacion.ToString());
                cargarUsuario();
                cargarEmpresa();
                //MessageBox.Show("Alta de usuario realizada exitosamente.\n\nPuede ingresar al sistema mediante con los siguientes datos:\nUsername: " + this.username + "\nPassword: " + this.passwordNoHash);
                new Abm_Cliente.Confirmacion(this.username, this.passwordNoHash).Show();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            switch (cbFiltro.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Debe seleccionar un criterio de búsqueda.", "Error");
                    break;
                case 0: // Razón Social
                    if (!tBusqueda.Text.Equals(""))
                    {
                        BuscarEmpresa form0 = new BuscarEmpresa('R', tBusqueda.Text);
                        form0.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                    }
                    break;
                case 1: // CUIT
                    if (!tBusqueda.Text.Equals(""))
                    {
                        if (tBusqueda.Text.Length <= 50)
                        {
                            BuscarEmpresa form1 = new BuscarEmpresa('C', tBusqueda.Text);
                            form1.Show();
                        }
                        else
                        {
                            MessageBox.Show("CUIT inválido.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                    }
                    break;
                case 2: // EMAIL
                    if (!tBusqueda.Text.Equals(""))
                    {
                        BuscarEmpresa form2 = new BuscarEmpresa('E', tBusqueda.Text);
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                    }
                    break;
            }
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
            if (Char.IsControl(e.KeyChar) || e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else if (e.KeyChar < 65 || e.KeyChar > 122)
            {
                e.Handled = true;
            }

            /*if (e.KeyChar < 65 || e.KeyChar > 122)
            {
                e.Handled = true;
            }*/
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
        }
    }
}
