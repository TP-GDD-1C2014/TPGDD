using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    public class Compra
    {
        public string Vendedor { get; set; }
        public string Publicacion { get; set; }
        public DateTime Fecha { get; set; }

        public int Calificacion { get; set; }
        public string Comentarios { get; set; }

        public Compra(int idVendedor, int codPublicacion, Clases.Calificacion calificacion, DateTime fechaOperacion)
        {
            Vendedor = obtenerVendedor(idVendedor);
            Publicacion = obtenerPublicacion(codPublicacion);
            Fecha = fechaOperacion;
            if (calificacion != null)
            {
                Calificacion = calificacion.Puntaje;
                Comentarios = calificacion.Descripcion;
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
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Username FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_Vendedor", listaParametros, BDSQL.iniciarConexion());
            lector.Read();
            string res = Convert.ToString(lector["Username"]);
            BDSQL.cerrarConexion();
            return res;
        }

        public string obtenerPublicacion(int codPublicacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", codPublicacion);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Descripcion FROM MERCADONEGRO.Publicaciones WHERE Cod_Publicacion = @Cod_Publicacion", listaParametros, BDSQL.iniciarConexion());
            lector.Read();
            string res = Convert.ToString(lector["Descripcion"]);
            BDSQL.cerrarConexion();
            return res;
        }
    }
}
