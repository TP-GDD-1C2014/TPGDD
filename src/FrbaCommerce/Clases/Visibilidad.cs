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

        public static int obtenerIDVisibilidad(string descripcion)
        {
            int idVisibilidad = -1;

            List<SqlParameter> listaParametros = new List<SqlParameter>();

            BDSQL.agregarParametro(listaParametros, "@descripcion", descripcion);

            string commandText = "SELECT Cod_Visibilidad FROM MERCADONEGRO.Visibilidades WHERE Descripcion = @descripcion";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", listaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    idVisibilidad = Convert.ToInt32(lector["Cod_Visibilidad"]);

                }
            }
            BDSQL.cerrarConexion();

            return idVisibilidad;

        }
            

        public static List<Visibilidad> ObtenerVisibilidades()
        {
            List<Visibilidad> visibilidades = new List<Visibilidad>();

            string commandText = "SELECT * FROM MERCADONEGRO.VISIBILIDADES WHERE HABILITADA = 1 ORDER BY JERARQUIA";

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

        public static List<Visibilidad> ObtenerTodasLasVisibilidades()
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
                                                                   (decimal)lector["Costo_Publicacion"],
                                                                   Convert.ToInt32(((decimal)lector["Porcentaje_Venta"]) * 100),
                                                                   (bool)lector["Habilitada"]);
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

        public static bool esLaNovenaVenta(int idVendedor, int visibilidad)
        {         
                  
            List<SqlParameter> parametros2 = new List<SqlParameter>();

            BDSQL.agregarParametro(parametros2, "@idVendedor", idVendedor);
            BDSQL.agregarParametro(parametros2, "@visibilidad", visibilidad);
            
            string commandText = "SELECT b.Cantidad FROM MERCADONEGRO.Bonificaciones b " +
                                 "WHERE b.ID_User = @idVendedor AND b.Visibilidad = @visibilidad";

            SqlDataReader lector = BDSQL.ejecutarReader(commandText, parametros2, BDSQL.iniciarConexion());

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

        public static string obtenerDescripcionVisibilidad(int codVisibilidad)
        {
            string descripcion = "";

            List<SqlParameter> listaParametros = new List<SqlParameter>();

            BDSQL.agregarParametro(listaParametros, "@codVisibilidad", codVisibilidad);

            string commandText = "SELECT Descripcion FROM MERCADONEGRO.Visibilidades WHERE Cod_Visibilidad = @codVisibilidad";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", listaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    descripcion = Convert.ToString(lector["Descripcion"]);

                }
            }
            BDSQL.cerrarConexion();

            return descripcion;

        }

     }
}
