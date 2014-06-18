using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using FrbaCommerce.Clases;
using System.Data.SqlClient;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class DatosVendedor : Form
    {
        public static string vendedor;
        
        public DatosVendedor(int idVendedor)
        {      
            InitializeComponent();
            this.CenterToScreen();
            SqlDataReader lector = Compra.clienteEmpresa(idVendedor);
            cargarDatos(lector);
            BDSQL.cerrarConexion();
     
        }

        private void cargarDatos(SqlDataReader lector)
        {
            if (vendedor != "Empresa")
            {
                lblCuit_NumDoc.Text = "Número documento";
                lblRazonSocial_TipoDoc.Text = "Tipo documento";
                lblCiudad_Apellido.Text = "Apellido";
                lblNombreContacto_Nombre.Text = "Nombre";
                lblFechaCreacion_FechaNacimiento.Text = "Fecha nacimiento";

                txtCuit_NumDoc.Text = Convert.ToString(lector["Num_Doc"]);
                txtRazonSocial_TipoDoc.Text = Convert.ToString(lector["Tipo_Doc"]);
                txtCiudad_Apellido.Text = Convert.ToString(lector["Apellido"]);
                txtNombreContacto_Nombre.Text = Convert.ToString(lector["Nombre"]);
                txtFechaCreacion_FechaNacimiento.Text = Convert.ToString(lector["Fecha_Nacimiento"]);
            }
            else 
            {
                txtCuit_NumDoc.Text = Convert.ToString(lector["CUIT"]);
                txtRazonSocial_TipoDoc.Text = Convert.ToString(lector["Razon_Social"]);
                txtCiudad_Apellido.Text = Convert.ToString(lector["Ciudad"]);
                txtNombreContacto_Nombre.Text = Convert.ToString(lector["Nombre_Contacto"]);
                txtFechaCreacion_FechaNacimiento.Text = Convert.ToString(lector["Fecha_Creacion"]);
            }

            txtCodPostal.Text = Convert.ToString(lector["Codigo_Postal"]);
            txtDireccion.Text = Convert.ToString(lector["Direccion"]);
            txtMail.Text = Convert.ToString(lector["Mail"]);
            txtTelefono.Text = Convert.ToString(lector["Telefono"]);
            
            
        }

    }
}
