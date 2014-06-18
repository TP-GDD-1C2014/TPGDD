using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using FrbaCommerce.Common;
using FrbaCommerce.Clases;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class ABMClientes : Form
    {
        public string username { get; set; }
        public string password { get; set; }
        public int intentosLogin { get; set; }
        public int habilitado { get; set; }
        public int primeraVez { get; set; }
        public DBNull cantPubliGratuitas { get; set; }
        public DBNull reputacion { get; set; }
        public DBNull ventasSinRendir { get; set; }

        public string tipoDoc { get; set; }
        public string numDoc { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public string codPostal { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public string passwordNoHash { get; set; }

        public Login.SeleccionFuncionalidades formAnterior { get; set; }

        public ABMClientes(Login.SeleccionFuncionalidades _formAnterior)
        {
            this.formAnterior = _formAnterior;
            InitializeComponent();
            this.CenterToScreen();

            cbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFiltroTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarCbDia();
            llenarCbMes();
            llenarCbAno();
            llenarCbTipoDoc();
            llenarCbFiltro();
            llenarCbFiltroTipoDoc();
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

        public void llenarCbFiltro()
        {
            this.cbFiltro.Items.Add("Nombre");
            this.cbFiltro.Items.Add("Apellido");
            this.cbFiltro.Items.Add("Tipo de documento");
            this.cbFiltro.Items.Add("Número de documento");
            this.cbFiltro.Items.Add("E-mail");
        }

        public void llenarCbFiltroTipoDoc()
        {
            this.cbFiltroTipoDocumento.Items.Add("DU");
            this.cbFiltroTipoDocumento.Items.Add("CI");
            this.cbFiltroTipoDocumento.Items.Add("LC");
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox CB = (ComboBox)sender;
            if (CB.SelectedIndex == 2)
            {
                cbFiltroTipoDocumento.Visible = true;
                tBusqueda.Visible = false;
            }
            else
            {
                cbFiltroTipoDocumento.Visible = false;
                tBusqueda.Visible = true;
            }
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
                    if (!BDSQL.existenSimultaneamente(cbTipoDocumento.SelectedItem.ToString(), tNumeroDocumento.Text, "MERCADONEGRO.Clientes", "Tipo_Doc", "Num_Doc"))
                    {
                        if (!campoVacio(tTelefono))
                        {
                            this.telefono = Convert.ToInt32(tTelefono.Text);
                        }
                        else
                        {
                            this.telefono = -1;
                        }
                        this.tipoDoc = cboxString(cbTipoDocumento);
                        this.numDoc = tNumeroDocumento.Text;
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
                        MessageBox.Show("El tipo y número de documento ingresados ya fueron registrados.", "Error");
                        return false;
                    }
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

        public void cargarCliente()
        {
            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros2, "@Username", this.username);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User FROM MERCADONEGRO.Usuarios WHERE Username = @Username", listaParametros2, BDSQL.iniciarConexion());
            lector.Read();
            int idUser = Convert.ToInt32(lector["ID_User"]);
            BDSQL.cerrarConexion();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", idUser);
            BDSQL.agregarParametro(listaParametros, "@Tipo_Doc", this.tipoDoc);
            BDSQL.agregarParametro(listaParametros, "@Num_Doc", this.numDoc);
            BDSQL.agregarParametro(listaParametros, "@Nombre", this.nombre);
            BDSQL.agregarParametro(listaParametros, "@Apellido", this.apellido);
            BDSQL.agregarParametro(listaParametros, "@Mail", this.email);

            if (this.telefono == -1)
            {
                BDSQL.agregarParametro(listaParametros, "@Telefono", DBNull.Value);
            }
            else
            {
                BDSQL.agregarParametro(listaParametros, "@Telefono", this.telefono);
            }
            
            BDSQL.agregarParametro(listaParametros, "@Direccion", this.direccion);
            BDSQL.agregarParametro(listaParametros, "@Codigo_Postal", this.codPostal);
            BDSQL.agregarParametro(listaParametros, "@Fecha_Nacimiento", this.fechaNacimiento);
            BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Clientes VALUES (@ID_User, @Tipo_Doc, @Num_Doc, @Nombre, @Apellido, @Mail, @Telefono, @Direccion, @Codigo_Postal, @Fecha_Nacimiento)", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();


            //Obteniendo la ID_Rol del cliente
            int idRol = Rol.obtenerID("Cliente");

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
                //MessageBox.Show("Cliente:\n\ntipoDoc: " + this.tipoDoc + "\nnumDoc: " + this.numDoc.ToString() + "\nnombre: " + this.nombre + "\napellido: " + this.apellido + "\nemail: " + this.email + "\ntelefono: " + this.telefono + "\ndireccion: " + this.direccion + "\ncodPostal: " + this.codPostal + "\nfechaNacimiento: " + this.fechaNacimiento.ToString());
                cargarUsuario();
                cargarCliente();
                //MessageBox.Show("Alta de usuario realizada exitosamente.\n\nPuede ingresar al sistema mediante con los siguientes datos:\nUsername: " + this.username + "\nPassword: " + this.passwordNoHash);
                new Confirmacion(this.username, this.passwordNoHash).Show();
            }
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            formAnterior.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (cbFiltro.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Debe seleccionar un criterio de búsqueda.", "Error");
                    break;
                case 0: // Nombre
                    if (!tBusqueda.Text.Equals(""))
                    {
                        BuscarCliente form0 = new BuscarCliente('N', tBusqueda.Text);
                        form0.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
                    }
                    break;
                case 1: // Apellido
                    if (!tBusqueda.Text.Equals(""))
                    {
                        BuscarCliente form1 = new BuscarCliente('A', tBusqueda.Text);
                        form1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
                    }
                    break;
                case 2: // Tipo de documento
                    if (cbFiltroTipoDocumento.SelectedIndex != -1)
                    {
                        BuscarCliente form2 = new BuscarCliente('T', cbFiltroTipoDocumento.SelectedItem.ToString());
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
                    }
                    break;
                case 3: // Número de documento
                    if (!tBusqueda.Text.Equals(""))
                    {
                        if (Interfaz.esNumerico(tBusqueda.Text, System.Globalization.NumberStyles.Integer))
                        {
                            BuscarCliente form3 = new BuscarCliente('D', tBusqueda.Text);
                            form3.Show();
                        }
                        else
                        {
                            MessageBox.Show("Número de documento inválido.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
                    }
                    break;
                case 4: // Email
                    if (!tBusqueda.Text.Equals(""))
                    {
                        BuscarCliente form4 = new BuscarCliente('E', tBusqueda.Text);
                        form4.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
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
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
        }
    }
}
