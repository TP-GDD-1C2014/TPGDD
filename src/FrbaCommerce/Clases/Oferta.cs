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
        public string Vendedor { get; set; }
        public string Publicacion { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }


        public SqlConnection conexion { get; set; }

        public Oferta(int idVendedor, int codPublicacion, DateTime fechaOferta, int monto, SqlConnection _conexion)
        {
            this.conexion = _conexion;
            Vendedor = obtenerVendedor(idVendedor);
            Publicacion = obtenerPublicacion(codPublicacion);
            Fecha = fechaOferta;
            Monto = monto;
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
    }
}
