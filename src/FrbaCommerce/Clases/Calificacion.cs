using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using FrbaCommerce.Clases;
using System.Data.SqlClient;

namespace FrbaCommerce.Clases
{
    public class Calificacion
    {
        public int Cod_Calificacion { get; set; }
        public int? Puntaje { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha_Calificacion { get; set; }

        public Calificacion(int punt, string desc)
        {
            
            Puntaje = punt;
            Descripcion = desc;
        }
        
        public Calificacion(int cod, int? punt, string desc, DateTime? fecha)
        {
            Cod_Calificacion = cod;
            Puntaje = punt;
            Descripcion = desc;
            Fecha_Calificacion = fecha;
        }


        public static List<Calificacion> obtenerCalificaciones(int idUser)
        {
            List<Calificacion> calificaciones = new List<Calificacion>();
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idUser", idUser));

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT c.Cod_Calificacion, c.Puntaje, c.Descripcion, c.Fecha_Calificacion " +
                                                        "FROM MERCADONEGRO.Calificaciones c " +
                                                        "JOIN MERCADONEGRO.Compras o ON o.Cod_Calificacion = c.Cod_Calificacion "+
                                                        "WHERE o.ID_Comprador = @idUser AND c.Puntaje IS NULL", ListaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int? puntaje;
                    string desc;
                    DateTime? fecha;

                    if (Convert.IsDBNull(lector["Puntaje"]))
                    {
                        puntaje = null;
                    }
                    else puntaje = (int)(decimal)lector["Puntaje"];

                    if (Convert.IsDBNull(lector["Descripcion"]))
                    {
                        desc = "";
                    }
                    else desc = (string)lector["Descripcion"];

                    if (Convert.IsDBNull(lector["Fecha_Calificacion"]))
                    {
                        fecha = null;
                    }
                    else fecha = (DateTime)lector["Fecha_Calificacion"];
                    
                    

                    Calificacion unaCalificacion = new Calificacion((int)(decimal)lector["Cod_Calificacion"],
                                                                    puntaje,
                                                                    desc, 
                                                                    fecha);
                    calificaciones.Add(unaCalificacion);
                }
            }
            BDSQL.cerrarConexion();
            return calificaciones;
        }


        public static void updateCalificacion(Calificacion calific)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codCalificacion", calific.Cod_Calificacion));
            ListaParametros.Add(new SqlParameter("@puntaje", calific.Puntaje));
            ListaParametros.Add(new SqlParameter("@descripcion", calific.Descripcion));
            ListaParametros.Add(new SqlParameter("@fecha", calific.Fecha_Calificacion));

            BDSQL.ExecStoredProcedureSinRet("MERCADONEGRO.UpdateCalificacion", ListaParametros);
		   // "SET Puntaje = @puntaje, Descripcion = @descripcion, Fecha_Calificacion = @fecha "
		    //+ "WHERE Cod_Calificacion = @codCalificacion", ListaParametros, BDSQL.iniciarConexion());

            BDSQL.cerrarConexion();
        }

        public static int getCodPublicacion(int codCalific)
        {
            int codPublicacion;

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codCalificacion", codCalific));

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Cod_Publicacion FROM MERCADONEGRO.Compras WHERE Cod_Calificacion = @codCalificacion",ListaParametros,BDSQL.iniciarConexion());

            lector.Read();

            codPublicacion = Convert.ToInt32(lector["Cod_Publicacion"]);

            BDSQL.cerrarConexion();

            return codPublicacion;
        }

        public static bool verificarCantidadCalificaciones(int idUser)
        {
            bool puedeComprar;

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idUser", idUser));

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT COUNT(ID_Compra) AS cant FROM MERCADONEGRO.Compras o " +
                                                        "JOIN MERCADONEGRO.Calificaciones c ON o.Cod_Calificacion = c.Cod_Calificacion " +
                                                        "WHERE o.ID_Comprador = @idUser AND c.Puntaje is NULL", 
                                                        ListaParametros, BDSQL.iniciarConexion());

            lector.Read();

            int cant = Convert.ToInt32(lector["cant"]);

            BDSQL.cerrarConexion();

            if (cant >= 5)
                puedeComprar = false;
            else puedeComprar = true;

            return puedeComprar;
        }
    }
}
