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

namespace FrbaCommerce.Abm_Cliente
{
    public partial class ModificarCliente : Form
    {
        public BuscarCliente formAnterior { get; set; }

        public int ID_User { get; set; }

        public ModificarCliente(int _ID_User, BuscarCliente _formAnterior)
        {
            this.ID_User = _ID_User;
            this.formAnterior = _formAnterior;

            InitializeComponent();

            setearComboBoxes();
            cargarDatosUsuario();
            cargarDatosCliente();
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

        private void bModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
