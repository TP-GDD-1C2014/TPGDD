using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    public class Oferta
    {
        // Atributos Historial

        public DateTime Fecha { get; set; }
        public int Cod_Publicacion { get; set; }
        public int Monto { get; set; }

        public SqlConnection conexion { get; set; }

        // Atributos Comprar/Ofertar

        public int Vendedor { get; set; }
        public int Tipo_Operacion { get; set; }
        public int Comprador { get; set; }

        public Oferta(int idVendedor, int idComprador, int codPublicacion, int tipoOperacion, int monto)
        {
            Vendedor = idVendedor;
            Comprador = idComprador;
            Cod_Publicacion = codPublicacion;
            Tipo_Operacion = tipoOperacion;
            Monto = monto;
        }
        
        public Oferta(int idVendedor, int codPublicacion, DateTime fechaOferta, int monto, SqlConnection _conexion)
        {
            this.conexion = _conexion;
            //Vendedor = obtenerVendedor(idVendedor);
            Cod_Publicacion = codPublicacion;
            Fecha = fechaOferta;
            Monto = monto;
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

        public static void insertarOferta(Oferta oferta)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idVendedor", oferta.Vendedor));
            ListaParametros.Add(new SqlParameter("@idComprador", oferta.Comprador));
            ListaParametros.Add(new SqlParameter("@codPublicacion", oferta.Cod_Publicacion));
            ListaParametros.Add(new SqlParameter("@tipoOperacion", oferta.Tipo_Operacion));
            ListaParametros.Add(new SqlParameter("@fechaOferta", Interfaz.obtenerFecha()));
            ListaParametros.Add(new SqlParameter("@montoOferta", oferta.Monto));
            
            BDSQL.ExecStoredProcedureSinRet("MERCADONEGRO.InsertarOFerta",ListaParametros);
            BDSQL.cerrarConexion();
        }

        public static decimal cargarOfertaMasAlta(int codPublicacion)
        {
            decimal ofertaMasGrande = 0;

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codPublicacion", codPublicacion));

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ISNULL (MAX(Monto_Oferta), 0) as Maxima FROM MERCADONEGRO.Subastas WHERE Cod_Publicacion = @codPublicacion", ListaParametros, BDSQL.iniciarConexion());

            if (lector.HasRows)
            {
                lector.Read();

                ofertaMasGrande = Convert.ToDecimal(lector["Maxima"]);               
            }
                          
            BDSQL.cerrarConexion();
            return ofertaMasGrande;

        }

        public static int getIdGanador(int codPubli, decimal montoOferta)
        {
            int ganador = -1;

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codPublicacion", codPubli));
            ListaParametros.Add(new SqlParameter("@montoOferta", montoOferta));

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_Comprador FROM MERCADONEGRO.Subastas WHERE Cod_Publicacion = @codPublicacion AND Monto_Oferta = @montoOferta", ListaParametros, BDSQL.iniciarConexion());

            if (lector.HasRows)
            {
                lector.Read();

                ganador = Convert.ToInt32(lector["ID_Comprador"]);               
            }
                          
            BDSQL.cerrarConexion();
            return ganador;
        }
    }
}
