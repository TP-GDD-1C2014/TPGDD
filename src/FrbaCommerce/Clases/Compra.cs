using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FrbaCommerce.Common;
using FrbaCommerce.Comprar_Ofertar;

namespace FrbaCommerce.Clases
{
    public class Compra
    {
        // Atributos Historial

        public DateTime Fecha { get; set; }
        public int Cod_Publicacion { get; set; }
        public int Calificacion { get; set; }
        public string Comentarios { get; set; }

        public SqlConnection conexion { get; set; }

        // Atributos Comprar/Ofertar

        public int Vendedor { get; set; }
        public int Tipo_Operacion { get; set; }
        public int Cod_Calificacion { get; set; }
        public decimal Monto_Compra { get; set; }
        public bool Operacion_Facturada { get; set; }
        public int Comprador { get; set; }

        public Compra(int idVendedor, int idComprador, int codPublicacion, int tipoOperacion, decimal montoCompra, bool operacionFacutrada)
        {
            Vendedor = idVendedor;
            Comprador = idComprador;
            Cod_Publicacion = codPublicacion;
            Tipo_Operacion = tipoOperacion;
            //Cod_Calificacion = codCalificacion;
            //Fecha = fecha;
            Monto_Compra = montoCompra;
            Operacion_Facturada = operacionFacutrada;
        }
        
        
        public Compra(int idVendedor, int codPublicacion, Clases.Calificacion calificacion, DateTime fechaOperacion, SqlConnection _conexion)
        {
            this.conexion = _conexion;

            //Vendedor = obtenerVendedor(idVendedor);
            Cod_Publicacion = codPublicacion;
            Fecha = fechaOperacion;
            if (calificacion != null)
            {
                Calificacion = (int)calificacion.Puntaje;
                if (calificacion.Descripcion.Equals(""))
                {
                    Comentarios = "Sin comentarios";
                }
                else
                {
                    Comentarios = calificacion.Descripcion;
                }
            }
            else
            {
                Calificacion = 0;
                Comentarios = "Sin calificar";
            }
        }

        /*public string obtenerVendedor(int idVendedor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_Vendedor", idVendedor);
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerVendedor @ID_Vendedor", listaParametros, this.conexion);
            lector.Read();
            string res = Convert.ToString(lector["Username"]);
            return res;
        }*/

        /*public string obtenerPublicacion(int codPublicacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", codPublicacion);
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerPublicacion @Cod_Publicacion", listaParametros, this.conexion);
            lector.Read();
            string res = Convert.ToString(lector["Descripcion"]);
            return res;
        }*/

        public static SqlDataReader clienteEmpresa(int idVendedor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@idVendedor", idVendedor);

            SqlDataReader lector1 = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Clientes WHERE ID_User = @idVendedor", listaParametros, BDSQL.iniciarConexion());
            lector1.Read();
            
            if (!lector1.HasRows)
            {
                BDSQL.cerrarConexion();

                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros2, "@idVendedor", idVendedor);

                SqlDataReader lector2 = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Empresas WHERE ID_User = @idVendedor", listaParametros2, BDSQL.iniciarConexion());
                lector2.Read();
                DatosVendedor.vendedor = "Empresa";
                return lector2;
            }
            else 
            {
                DatosVendedor.vendedor = "Cliente";
                return lector1;
            }
    
        }

        public static void insertarCompra(Compra compra)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idVendedor", compra.Vendedor));
            ListaParametros.Add(new SqlParameter("@idComprador", compra.Comprador));
            ListaParametros.Add(new SqlParameter("@codPublicacion", compra.Cod_Publicacion));
            ListaParametros.Add(new SqlParameter("@tipoOperacion", compra.Tipo_Operacion));
            ListaParametros.Add(new SqlParameter("@montoCompra", compra.Monto_Compra));
            ListaParametros.Add(new SqlParameter("@operacionFacturada", compra.Operacion_Facturada));
            ListaParametros.Add(new SqlParameter("@fechaCompra", Interfaz.obtenerFecha()));

            BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Compras (ID_Vendedor, ID_Comprador, Cod_Publicacion, Cod_TipoOperacion, " +
                                "Fecha_Operacion, Monto_Compra, Operacion_Facturada) " +
	                            "VALUES ( @idVendedor , @idComprador , @codPublicacion , @tipoOperacion , " +
                                "@fechaCompra, @montoCompra , @operacionFacturada )", ListaParametros, BDSQL.iniciarConexion());
            
            BDSQL.cerrarConexion();
        }
    }
}
