using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class ModificarCliente : Form
    {
        public BuscarCliente formAnterior { get; set; }

        public int ID_User { get; set; }

        public string vUsername { get; set; }
        public string vPassword { get; set; }
        public int vHabilitado { get; set; }
        public string vPublicacionesGratuitas { get; set; }

        public int vTipoDeDocumento { get; set; }
        public string vNumeroDeDocumento { get; set; }
        public string vNombre { get; set; }
        public string vApellido { get; set; }
        public string vEmail { get; set; }
        public string vTelefono { get; set; }
        public string vDireccion { get; set; }
        public string vCodigoPostal { get; set; }
        public int vDia { get; set; }
        public int vMes { get; set; }
        public int vAno { get; set; }

        public ModificarCliente(int _ID_User, BuscarCliente _formAnterior)
        {
            this.ID_User = _ID_User;
            this.formAnterior = _formAnterior;

            InitializeComponent();

            setearComboBoxes();
            cargarDatosUsuario();
            cargarDatosCliente();

            cargarDatosViejos();
        }

        public void cargarDatosViejos()
        {
            this.vUsername = tUsername.Text;
            this.vPassword = tPassword.Text;
            this.vHabilitado = cbHabilitado.SelectedIndex;
            this.vPublicacionesGratuitas = tPublicacionesGratuitas.Text;

            this.vTipoDeDocumento = cbTipoDeDocumento.SelectedIndex;
            this.vNumeroDeDocumento = tNumeroDeDocumento.Text;
            this.vNombre = tNombre.Text;
            this.vApellido = tApellido.Text;
            this.vEmail = tEmail.Text;
            this.vTelefono = tTelefono.Text;
            this.vDireccion = tDireccion.Text;
            this.vCodigoPostal = tCodigoPostal.Text;
            this.vDia = cbDia.SelectedIndex;
            this.vMes = cbMes.SelectedIndex;
            this.vAno = cbAno.SelectedIndex;
        }

        public void setearComboBoxes()
        {
            cbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoDeDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHabilitado.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarCbDia();
            llenarCbMes();
            llenarCbAno();
            llenarCbTipoDoc();
            llenarCbHabilitado();
        }

        public void llenarCbTipoDoc()
        {
            this.cbTipoDeDocumento.Items.Add("DU");
            this.cbTipoDeDocumento.Items.Add("CI");
            this.cbTipoDeDocumento.Items.Add("LC");
        }

        public void llenarCbHabilitado()
        {
            this.cbHabilitado.Items.Add("No");
            this.cbHabilitado.Items.Add("Sí");
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
            for (i = 1000; i <= 2014; i++)
            {
                this.cbAno.Items.Add(i.ToString());
            }
        }

        public void cargarDatosCliente()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Tipo_Doc, Num_Doc, Nombre, Apellido, Mail, Telefono, Direccion, Codigo_Postal, DAY(Fecha_Nacimiento) AS Fecha_Nacimiento_Dia, MONTH(Fecha_Nacimiento) AS Fecha_Nacimiento_Mes, YEAR(Fecha_Nacimiento) AS Fecha_Nacimiento_Ano FROM MERCADONEGRO.Clientes WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            lector.Read();

            if (Convert.ToString(lector["Tipo_Doc"]) == "DU")
            {
                cbTipoDeDocumento.SelectedIndex = 0;
            }

            if (Convert.ToString(lector["Tipo_Doc"]) == "CI")
            {
                cbTipoDeDocumento.SelectedIndex = 1;
            }

            if (Convert.ToString(lector["Tipo_Doc"]) == "LC")
            {
                cbTipoDeDocumento.SelectedIndex = 2;
            }

            tNumeroDeDocumento.Text = Convert.ToInt32(lector["Num_Doc"]).ToString();
            tNombre.Text = Convert.ToString(lector["Nombre"]);
            tApellido.Text = Convert.ToString(lector["Apellido"]);
            tEmail.Text = Convert.ToString(lector["Mail"]);

            if (lector["Telefono"] != DBNull.Value)
            {
                tTelefono.Text = Convert.ToInt32(lector["Telefono"]).ToString();
            }
            else
            {
                tTelefono.Text = "";
            }

            tDireccion.Text = Convert.ToString(lector["Direccion"]);
            tCodigoPostal.Text = Convert.ToString(lector["Codigo_Postal"]);

            cbDia.SelectedIndex = Convert.ToInt32(lector["Fecha_Nacimiento_Dia"]);
            cbMes.SelectedIndex = Convert.ToInt32(lector["Fecha_Nacimiento_Mes"]);
            cbAno.SelectedIndex = Convert.ToInt32(lector["Fecha_Nacimiento_Ano"]) - 1000;

            BDSQL.cerrarConexion();
        }

        public void cargarDatosUsuario()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Username, Habilitado, Cant_Publi_Gratuitas FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            lector.Read();

            tUsername.Text = Convert.ToString(lector["Username"]);

            if (Convert.ToInt32(lector["Habilitado"]) == 0)
            {
                cbHabilitado.SelectedIndex = 0;
            }
            else
            {
                cbHabilitado.SelectedIndex = 1;
            }

            if (lector["Cant_Publi_Gratuitas"] != DBNull.Value)
            {
                tPublicacionesGratuitas.Text = Convert.ToString(lector["Cant_Publi_Gratuitas"]);
            }
            else
            {
                tPublicacionesGratuitas.Text = "";
            }

            BDSQL.cerrarConexion();
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {

        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formAnterior.Show();
        }

        public Boolean cambioString(string string1, string string2)
        {
            return !string1.Equals(string2);
        }

        public Boolean cambioInt(int int1, int int2)
        {
            if (int1 == int2)
            {
                return false;
            }
            else
            {
                return true;
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

        public void cambiarStringUsuarios(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Valor", valor);
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void cambiarStringClientes(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Valor", valor);
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Clientes SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void cambiarIntUsuarios(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Valor", valor);
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void cambiarIntClientes(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Valor", valor);
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Clientes SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void cambiarLongIntClientes(string columna, long valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Valor", valor);
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Clientes SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void cambiarFecha(string columna, DateTime fecha)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Valor", fecha);
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Clientes SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public string hashear(string valor)
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(valor));
            return bytesDeHasheoToString(bytesDeHasheo);
        }

        public Boolean usernameValido()
        {
            if (!tUsername.Text.Equals("") && !BDSQL.existeString(tUsername.Text, "MERCADONEGRO.Usuarios", "Username"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean numeroDeDocumentoValido()
        {
            if ((Interfaz.esNumerico(tNumeroDeDocumento.Text, System.Globalization.NumberStyles.Integer)) && (tNumeroDeDocumento.Text.Length <= 18))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean tipoDeDocumentoValido()
        {
            string Tipo_Doc = "";
            Boolean res = false;

            switch (cbTipoDeDocumento.SelectedIndex)
            {
                case 0: // DU
                    Tipo_Doc = "DU";
                    break;
                case 1: // CI
                    Tipo_Doc = "CI";
                    break;
                case 2: // LC
                    Tipo_Doc = "LC";
                    break;
            }

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Tipo_Doc", Tipo_Doc);
            BDSQL.agregarParametro(listaParametros, "@Num_Doc", tNumeroDeDocumento.Text);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Clientes WHERE Tipo_Doc = @Tipo_Doc AND Num_Doc = @Num_Doc", listaParametros, BDSQL.iniciarConexion());

            lector.Read();

            if (lector.HasRows)
            {
                res = false;
            }
            else
            {
                res = true;
            }

            BDSQL.cerrarConexion();
            return res;
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

        private void bModificar_Click(object sender, EventArgs e)
        {
            string resumenModificaciones = "Se han modificado los campos:";
            string resumenErrores = "No se han podido modificar los campos:";

            Boolean modificacion = false;
            Boolean error = false;

            if (cambioString(this.vUsername, tUsername.Text))
            {
                if (usernameValido())
                {
                    cambiarStringUsuarios("Username", tUsername.Text);
                    resumenModificaciones = resumenModificaciones + "\nNombre de usuario";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("Nombre de usuario inválido.", "Error");
                    resumenErrores = resumenErrores + "\nNombre de usuario (ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.vPassword, tPassword.Text))
            {
                cambiarStringUsuarios("Password", hashear(tPassword.Text));
                resumenModificaciones = resumenModificaciones + "\nContraseña";
                modificacion = true;
            }

            if (cambioInt(this.vHabilitado, cbHabilitado.SelectedIndex))
            {
                cambiarIntUsuarios("Habilitado", cbHabilitado.SelectedIndex);
                resumenModificaciones = resumenModificaciones + "\nHabilitado";
                modificacion = true;
            }

            if (cambioString(this.vPublicacionesGratuitas, tPublicacionesGratuitas.Text))
            {
                if ((Convert.ToInt32(tPublicacionesGratuitas.Text) <= 255) && (Convert.ToInt32(tPublicacionesGratuitas.Text) >= 0))
                {
                    cambiarIntUsuarios("Cant_Publi_Gratuitas", (Convert.ToInt32(tPublicacionesGratuitas.Text)));
                    resumenModificaciones = resumenModificaciones + "\nPublicaciones gratuitas";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("Cantidad de publicaciones gratuitas inválida.", "Error");
                    resumenErrores = resumenErrores + "\nPublicaciones gratuitas (valor muy grande o negativo)";
                    error = true;
                }
            }

            if (cambioInt(this.vTipoDeDocumento, cbTipoDeDocumento.SelectedIndex))
            {
                if (numeroDeDocumentoValido() && tipoDeDocumentoValido())
                {
                    switch (cbTipoDeDocumento.SelectedIndex)
                    {
                        case 0:
                            cambiarStringClientes("Tipo_Doc", "DU");
                            break;
                        case 1:
                            cambiarStringClientes("Tipo_Doc", "CI");
                            break;
                        case 2:
                            cambiarStringClientes("Tipo_Doc", "LC");
                            break;
                    }
                    resumenModificaciones = resumenModificaciones + "\nTipo de documento";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("Tipo y/o número de documento inválido/s.", "Error");
                    resumenErrores = resumenErrores + "\nTipo de documento (ya existente o valor inválido)";
                    error = true;
                }
            }

            if (cambioString(this.vNumeroDeDocumento, tNumeroDeDocumento.Text))
            {
                if (numeroDeDocumentoValido() && tipoDeDocumentoValido())
                {
                    cambiarLongIntClientes("Num_Doc", Convert.ToInt64(tNumeroDeDocumento.Text));
                    resumenModificaciones = resumenModificaciones + "\nNúmero de documento";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("Número de documento inválido.", "Error");
                    resumenErrores = resumenErrores + "\nNúmero de documento (ya existente o valor inválido)";
                    error = true;
                }
            }

            if (cambioString(this.vNombre, tNombre.Text))
            {
                cambiarStringClientes("Nombre", tNombre.Text);
                resumenModificaciones = resumenModificaciones + "\nNombre";
                modificacion = true;
            }

            if (cambioString(this.vApellido, tApellido.Text))
            {
                cambiarStringClientes("Apellido", tApellido.Text);
                resumenModificaciones = resumenModificaciones + "\nApellido";
                modificacion = true;
            }

            if (cambioString(this.vEmail, tEmail.Text))
            {
                cambiarStringClientes("Mail", tEmail.Text);
                resumenModificaciones = resumenModificaciones + "\nE-mail";
                modificacion = true;
            }

            if (cambioString(this.vTelefono, tTelefono.Text))
            {
                if ((Interfaz.esNumerico(tTelefono.Text, System.Globalization.NumberStyles.Integer)) && (tTelefono.Text.Length <= 18))
                {
                    cambiarIntClientes("Telefono", Convert.ToInt32(tTelefono.Text));
                    resumenModificaciones = resumenModificaciones + "\nTeléfono";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("Teléfono inválido.", "Error");
                    resumenErrores = resumenErrores + "\nTeléfono (no numérico o muy grande)";
                    error = true;
                }
            }

            if (cambioString(this.vDireccion, tDireccion.Text))
            {
                cambiarStringClientes("Direccion", tDireccion.Text);
                resumenModificaciones = resumenModificaciones + "\nDirección";
                modificacion = true;
            }

            if (cambioString(this.vCodigoPostal, tCodigoPostal.Text))
            {
                if (tCodigoPostal.Text.Length <= 50)
                {
                    cambiarStringClientes("Codigo_Postal", tCodigoPostal.Text);
                    resumenModificaciones = resumenModificaciones + "\nCódigo Postal";
                    modificacion = true;
                }
                else
                {
                    MessageBox.Show("Código postal inválido.", "Error");
                    resumenErrores = resumenErrores + "\nCódigo postal (valor muy grande)";
                    error = true;
                }
            }

            if (cambioInt(vDia, cbDia.SelectedIndex) || cambioInt(vMes, cbMes.SelectedIndex) || cambioInt(vAno, cbAno.SelectedIndex))
            {
                cambiarFecha("Fecha_Nacimiento", fecha(cbDia.SelectedItem.ToString(), cbMes.SelectedItem.ToString(), cbAno.SelectedItem.ToString()));
                resumenModificaciones = resumenModificaciones + "\nFecha de nacimiento";
                modificacion = true;
            }

            if (modificacion)
            {
                MessageBox.Show(resumenModificaciones);
                
            }

            if (error)
            {
                MessageBox.Show(resumenErrores);
            }

            if (modificacion || error)
            {
                this.Close();
                formAnterior.Show();
            }
        }
    }
}
