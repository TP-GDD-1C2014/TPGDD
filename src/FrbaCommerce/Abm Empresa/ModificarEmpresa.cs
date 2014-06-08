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

namespace FrbaCommerce.Abm_Empresa
{
    public partial class ModificarEmpresa : Form
    {
        public BuscarEmpresa formAnterior { get; set; }

        public int ID_User { get; set; }

        public ModificarEmpresa(int _ID_User, BuscarEmpresa _formAnterior)
        {
            this.ID_User = _ID_User;
            this.formAnterior = _formAnterior;

            InitializeComponent();

            setearComboBoxes();
            cargarDatosUsuario();
            cargarDatosEmpresa();
        }

        public void setearComboBoxes()
        {
            cbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHabilitado.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarCbDia();
            llenarCbMes();
            llenarCbAno();
            llenarCbHabilitado();
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

        public void cargarDatosEmpresa()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Razon_Social, CUIT, Telefono, Direccion, Codigo_Postal, Ciudad, Mail, Nombre_Contacto, DAY(Fecha_Creacion) AS Fecha_Creacion_Dia, MONTH(Fecha_Creacion) AS Fecha_Creacion_Mes, YEAR(Fecha_Creacion) AS Fecha_Creacion_Ano  FROM MERCADONEGRO.Empresas WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            lector.Read();

            tRazonSocial.Text = Convert.ToString(lector["Razon_Social"]);
            tCUIT.Text = Convert.ToString(lector["CUIT"]);

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

            if (lector["Ciudad"] != DBNull.Value)
            {
                tCiudad.Text = Convert.ToString(lector["Ciudad"]);
            }
            else
            {
                tCiudad.Text = "";
            }

            tEmail.Text = Convert.ToString(lector["Mail"]);

            if (lector["Nombre_Contacto"] != DBNull.Value)
            {
                tNombreDeContacto.Text = Convert.ToString(lector["Nombre_Contacto"]);
            }
            else
            {
                tNombreDeContacto.Text = "";
            }

            cbDia.SelectedIndex = Convert.ToInt32(lector["Fecha_Creacion_Dia"]);
            cbMes.SelectedIndex = Convert.ToInt32(lector["Fecha_Creacion_Mes"]);
            cbAno.SelectedIndex = Convert.ToInt32(lector["Fecha_Creacion_Ano"]) - 1000;

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

            tPublicacionesGratuitas.Text = Convert.ToString(lector["Cant_Publi_Gratuitas"]);

            BDSQL.cerrarConexion();
        }

        private void ModificarEmpresa_Load(object sender, EventArgs e)
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
