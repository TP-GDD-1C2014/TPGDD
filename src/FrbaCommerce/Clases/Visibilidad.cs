using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Common;
using System.Data;
using System.Data.SqlClient;


namespace FrbaCommerce.Clases
{
    class Visibilidad
    {
        public int Cod_Visibilidad { get; set; }
        public string Descripcion { get; set; }
        public float Costo_Publicacion { get; set; }
        public float Porcentaje_Venta  { get; set; }
        public bool habilitada { get; set; }

        public Visibilidad(int codVisibilidad, string descripcion, float costoPublicacion, float porcentajeVenta, bool habilitada)
        {
            this.Cod_Visibilidad = codVisibilidad;
            this.Descripcion = descripcion;
            this.Costo_Publicacion = costoPublicacion;
            this.Porcentaje_Venta = porcentajeVenta;
            this.habilitada = habilitada;
        }

   

        public static List<Visibilidad> ObtenerVisibilidades()
        {
            List<Visibilidad> visibilidades = new List<Visibilidad>();

            string commandText = "SELECT * FROM MERCADONEGRO.VISIBILIDADES";

            SqlDataReader lector = BDSQL.ejecutarReader(commandText, BDSQL.iniciarConexion());


            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Visibilidad unaVisibilidad = new Visibilidad((int)(decimal)lector["Cod_Visibilidad"],
                                                                   (string)lector["Descripcion"],
                                                                   (float) (decimal) lector["Costo_Publicacion"],
                                                                   (float) (decimal) lector["Porcentaje_Venta"],
                                                                   (bool) lector["Habilitada"]);
                    visibilidades.Add(unaVisibilidad);
                }
            }
            BDSQL.cerrarConexion();
            return visibilidades;

            
        }

     }
}
