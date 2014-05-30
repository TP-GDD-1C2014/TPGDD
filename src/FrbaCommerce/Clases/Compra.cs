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
        public int ID_Operacion { get; set; }
        public int ID_Vendedor { get; set; }
        public string Publicacion { get; set; }
        public DateTime Fecha_Operacion { get; set; }

        public int Calificacion_Puntaje { get; set; }
        public string Calificacion_Descripcion { get; set; }

        public Compra(int idOperacion, int idVendedor, int codPublicacion, Clases.Calificacion calificacion, DateTime fechaOperacion)
        {
            ID_Operacion = idOperacion;
            ID_Vendedor = idVendedor;
            Publicacion = obtenerPublicacion(codPublicacion);
            Fecha_Operacion = fechaOperacion;
            if (calificacion != null)
            {
                Calificacion_Puntaje = calificacion.Puntaje;
                Calificacion_Descripcion = calificacion.Descripcion;
            }
            else
            {
                Calificacion_Puntaje = 0;
                Calificacion_Descripcion = "Sin calificar";
            }
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
