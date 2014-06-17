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
        public int jerarquia { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo_Publicacion { get; set; }
        public decimal Porcentaje_Venta  { get; set; }
        public bool habilitada { get; set; }

        public Visibilidad(int jerarquia, string descripcion, decimal costoPublicacion, decimal porcentajeVenta, bool habilitada)
        {
            this.jerarquia = jerarquia;
            this.Descripcion = descripcion;
            this.Costo_Publicacion = costoPublicacion;
            this.Porcentaje_Venta = porcentajeVenta;
            this.habilitada = habilitada;

        }

    
            

        public static List<Visibilidad> ObtenerVisibilidades()
        {
            List<Visibilidad> visibilidades = new List<Visibilidad>();

            string commandText = "SELECT * FROM MERCADONEGRO.VISIBILIDADES ORDER BY JERARQUIA";

            SqlDataReader lector = BDSQL.ejecutarReader(commandText, BDSQL.iniciarConexion());


            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Visibilidad unaVisibilidad = new Visibilidad((int)(decimal)lector["Jerarquia"],
                                                                   (string)lector["Descripcion"],
                                                                   (decimal) lector["Costo_Publicacion"],
                                                                   Convert.ToInt32(((decimal) lector["Porcentaje_Venta"]) * 100),
                                                                   (bool) lector["Habilitada"]);
                    visibilidades.Add(unaVisibilidad);
                }
            }
            BDSQL.cerrarConexion();
            return visibilidades;

            
        }

        public bool hayQueCambiarLaJerarquia(Visibilidad visibilidadVieja)
        {
            if (this.jerarquia == visibilidadVieja.jerarquia)
                return false;
            else
                return true;
            
        }

        public static bool esLaNovenaVenta(int codPublicacion, int visibilidad)
        {         
            List<SqlParameter> parametros = new List<SqlParameter>();

            BDSQL.agregarParametro(parametros, "@codPublicacion", codPublicacion);
            BDSQL.agregarParametro(parametros, "@visibilidad", visibilidad);
            
            string commandText = "SELECT b.Cantidad FROM MERCADONEGRO.Bonificaciones b, MERCADONEGRO.Publicaciones p, MERCADONEGRO.Usuarios u " +
                                 "WHERE p.Cod_Publicacion = @Cod_Publicacion AND u.ID_User = p.ID_Vendedor AND b.Visibilidad = @visibilidad";

            SqlDataReader lector = BDSQL.ejecutarReader(commandText, BDSQL.iniciarConexion());

            lector.Read();
          
            int cant = Convert.ToInt32(lector["Cantidad"]);

            if (cant >= 9)
            {
                BDSQL.cerrarConexion();
                return true;
            }
            else
            {
                BDSQL.cerrarConexion();
                return false;
            }
            
            
        }

        /*
        public static void insertBonificacion(int idVendedor, int codVisibilidad)
        {

        }

        public static void updateBonificacion()
        {

        }
        */



     }
}
