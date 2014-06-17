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

namespace FrbaCommerce.Historial_Cliente
{
    public partial class VerPublicacion : Form
    {
        public int codPublicacion { get; set; }
        public SqlConnection conexion { get; set; }

        public string nombreVendedor(int idVendedor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_Vendedor", idVendedor);
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerVendedor @ID_Vendedor", listaParametros, this.conexion);
            lector.Read();
            return Convert.ToString(lector["Username"]);
        }

        public string reputacionVendedor(int idVendedor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_Vendedor", idVendedor);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Reputacion FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_Vendedor", listaParametros, this.conexion);
            lector.Read();
            return Convert.ToString(lector["Reputacion"]);
        }

        public string rubroPublicacion()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", this.codPublicacion);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_Rubro FROM MERCADONEGRO.Rubro_Publicacion WHERE Cod_Publicacion = @Cod_Publicacion", listaParametros, this.conexion);
            lector.Read();

            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros2, "@ID_Rubro", Convert.ToInt32(lector["ID_Rubro"]));
            SqlDataReader lector2 = BDSQL.ejecutarReader("SELECT Descripcion FROM MERCADONEGRO.Rubros WHERE ID_Rubro = @ID_Rubro", listaParametros2, this.conexion);
            lector2.Read();

            return Convert.ToString(lector2["Descripcion"]);
        }

        public string descripcionPublicacion()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", this.codPublicacion);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Descripcion FROM MERCADONEGRO.Publicaciones WHERE Cod_Publicacion = @Cod_Publicacion", listaParametros, this.conexion);
            lector.Read();
            return Convert.ToString(lector["Descripcion"]);
        }

        public string precioPublicacion()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", this.codPublicacion);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Precio FROM MERCADONEGRO.Publicaciones WHERE Cod_Publicacion = @Cod_Publicacion", listaParametros, this.conexion);
            lector.Read();
            return Convert.ToString(lector["Precio"]);
        }

        public int estadoPublicacion()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", this.codPublicacion);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Cod_EstadoPublicacion FROM MERCADONEGRO.Publicaciones WHERE Cod_Publicacion = @Cod_Publicacion", listaParametros, this.conexion);
            lector.Read();
            return Convert.ToInt32(lector["Cod_EstadoPublicacion"]);
        }

        public VerPublicacion(int _codPublicacion)
        {
            this.codPublicacion = _codPublicacion;
            InitializeComponent();

            this.CenterToScreen();

            this.conexion = BDSQL.iniciarConexion();

            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros2, "@Cod_Publicacion", codPublicacion);
            SqlDataReader lector2 = BDSQL.ejecutarReader("SELECT ID_Vendedor, Descripcion, Precio, Cod_EstadoPublicacion FROM MERCADONEGRO.Publicaciones WHERE Cod_Publicacion = @Cod_Publicacion", listaParametros2, this.conexion);
            lector2.Read();

            tNombre.Text = nombreVendedor(Convert.ToInt32(lector2["ID_Vendedor"]));
            tReputacion.Text = reputacionVendedor(Convert.ToInt32(lector2["ID_Vendedor"]));

            tRubro.Text = rubroPublicacion();
            tDescripcion.Text = descripcionPublicacion();
            tPrecio.Text = precioPublicacion();
            if (estadoPublicacion() == 1)
            {
                tEstado.Text = "Activa";
            }
            else
            {
                tEstado.Text = "Inactiva";
            }
            

            BDSQL.cerrarConexion();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
