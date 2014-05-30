using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class Historial : Form
    {
        public List<Clases.Compra> compras = new List<Clases.Compra>();
        public List<Clases.Oferta> ofertas = new List<Clases.Oferta>();

        public Historial()
        {
            InitializeComponent();

            dgCompras.DataSource = compras;
            dgOfertas.DataSource = ofertas;

            obtenerCompras();
            obtenerOfertas();

        }

        public Clases.Calificacion obtenerCalificacion(int codCalificacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Calificacion", codCalificacion);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Calificaciones WHERE Cod_Calificacion = @Cod_Calificacion", listaParametros, BDSQL.iniciarConexion());
            lector.Read();
            Clases.Calificacion calificacion = new Clases.Calificacion(Convert.ToInt32(lector["Puntaje"]), Convert.ToString(lector["Descripcion"]));
            BDSQL.cerrarConexion();
            return calificacion;
        }

        public int obtenerCompras()
        {
            int cont = 0;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", Interfaz.usuario.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerCompras @ID_User", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cont++;
                    int idOperacion = Convert.ToInt32(lector["ID_Operacion"]);
                    int idVendedor = Convert.ToInt32(lector["ID_Vendedor"]);
                    int codPublicacion = Convert.ToInt32(lector["Cod_Publicacion"]);
                    Clases.Calificacion calificacion;

                    if (lector["Cod_Calificacion"] != DBNull.Value)
                    {
                        calificacion = obtenerCalificacion(Convert.ToInt32(lector["Cod_Calificacion"]));
                    }
                    else
                    {
                        calificacion = null;
                    }
                    
                    DateTime fechaOperacion = Convert.ToDateTime(lector["Fecha_Operacion"].ToString());
                    Clases.Compra compra = new Clases.Compra(idOperacion, idVendedor, codPublicacion, calificacion, fechaOperacion);
                    compras.Add(compra);
                }
            }
            BDSQL.cerrarConexion();
            return cont;
        }

        public int obtenerOfertas()
        {
            int cont = 0;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", Interfaz.usuario.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerOfertas @ID_User", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cont++;
                    int idSubasta = Convert.ToInt32(lector["ID_Subasta"]);
                    int idVendedor = Convert.ToInt32(lector["ID_Vendedor"]);
                    int codPublicacion = Convert.ToInt32(lector["Cod_Publicacion"]);
                    DateTime fechaOferta = Convert.ToDateTime(lector["Fecha_Oferta"].ToString());
                    Boolean subastaGanada;

                    if (Convert.ToInt32(lector["Tipo_Operacion"]) == 1)
                    {
                        subastaGanada = true;
                    }
                    else
                    {
                        subastaGanada = false;
                    }

                    Clases.Oferta oferta = new Clases.Oferta(idSubasta, idVendedor, codPublicacion, fechaOferta, subastaGanada);
                    ofertas.Add(oferta);
                }
            }
            BDSQL.cerrarConexion();
            return cont;
        }

        private void Historial_Load(object sender, EventArgs e)
        {

        }

        private void dgCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {

        }
    }
}
