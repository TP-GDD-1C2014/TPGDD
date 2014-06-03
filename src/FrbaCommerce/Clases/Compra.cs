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
        public string Vendedor { get; set; }
        public string Publicacion { get; set; }
        public DateTime Fecha { get; set; }

        public int Calificacion { get; set; }
        public string Comentarios { get; set; }

        public SqlConnection conexion { get; set; }

        public Compra(int idVendedor, int codPublicacion, Clases.Calificacion calificacion, DateTime fechaOperacion, SqlConnection _conexion)
        {
            this.conexion = _conexion;

            Vendedor = obtenerVendedor(idVendedor);
            Publicacion = obtenerPublicacion(codPublicacion);
            Fecha = fechaOperacion;
            if (calificacion != null)
            {
                Calificacion = calificacion.Puntaje;
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

        public string obtenerVendedor(int idVendedor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_Vendedor", idVendedor);
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerVendedor @ID_Vendedor", listaParametros, this.conexion);
            lector.Read();
            string res = Convert.ToString(lector["Username"]);
            return res;
        }

        public string obtenerPublicacion(int codPublicacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", codPublicacion);
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerPublicacion @Cod_Publicacion", listaParametros, this.conexion);
            lector.Read();
            string res = Convert.ToString(lector["Descripcion"]);
            return res;
        }

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
    }
}
