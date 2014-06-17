using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Clases;
using FrbaCommerce.Common;
using System.Data.SqlClient;
namespace FrbaCommerce.Clases
{
    public class Rubro
    {
        public int ID_Rubro { get; set; } //chequear mismo caso que funcionalidad
        public string Descripcion { get; set; }

        public Rubro(int idRubro, string descripcion)
        {
            this.ID_Rubro = idRubro;
            this.Descripcion = descripcion;
        }


        public static List<Rubro> obtenerRubros()
        {
            List<Rubro> rubros = new List<Rubro>();
            
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Rubros", BDSQL.iniciarConexion());
            if (lector.HasRows)
            {       
                while (lector.Read())
                {
                    rubros.Add(new Rubro( Convert.ToInt32(lector["ID_Rubro"]),lector["Descripcion"].ToString()));
                }
            }
            BDSQL.cerrarConexion();

            return rubros;
        }

        public static List<int> obtenerRubrosDePublicacion(int codPubli)
        {
            List<int> listaRubros = new List<int>();
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@Cod_Publicacion", codPubli));

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Rubro_Publicacion WHERE Cod_Publicacion=@Cod_Publicacion", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    listaRubros.Add(Convert.ToInt32(lector["ID_Rubro"]));
                }
            }

            BDSQL.cerrarConexion();
            return listaRubros;

        }


        //Agrega los rubros seleccionados al crear una publicacion
        public static void agregarRubroPublicacion(List<Rubro> listaRubrosSeleccionados, int nuevoCodPubli)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            foreach (Rubro rub in listaRubrosSeleccionados)
            {
                listaParametros.Add(new SqlParameter("@Cod_Publicacion", nuevoCodPubli));
                listaParametros.Add(new SqlParameter("@ID_Rubro", rub.ID_Rubro));
                int resultado = BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Rubro_Publicacion(Cod_Publicacion,ID_Rubro) VALUES(@Cod_Publicacion,@ID_Rubro)", listaParametros, BDSQL.iniciarConexion());
                listaParametros.Clear();
                BDSQL.cerrarConexion();
            }
        }

        public static void actualizarRubroPublicacion(List<Rubro> listaRubrosSeleccionados, int nuevoCodPubli)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@Cod_Publicacion", nuevoCodPubli));
            BDSQL.ejecutarQuery("DELETE FROM MERCADONEGRO.Rubro_Publicacion WHERE Cod_Publicacion=@Cod_Publicacion", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();

            foreach (Rubro rub in listaRubrosSeleccionados)
            {
                listaParametros.Clear();
                listaParametros.Add(new SqlParameter("@Cod_Publicacion", nuevoCodPubli));
                listaParametros.Add(new SqlParameter("@ID_Rubro", rub.ID_Rubro));
                int resultado = BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Rubro_Publicacion(Cod_Publicacion,ID_Rubro) VALUES(@Cod_Publicacion,@ID_Rubro)", listaParametros, BDSQL.iniciarConexion());
                BDSQL.cerrarConexion();
            }
        }

        public static void eliminarRubroPublicacion(List<int> listaRubrosSeleccionados, int nuevoCodPubli)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            foreach (int rub in listaRubrosSeleccionados)
            {
                listaParametros.Add(new SqlParameter("@Cod_Publicacion", nuevoCodPubli));
                listaParametros.Add(new SqlParameter("@ID_Rubro", rub));
                int resultado = BDSQL.ejecutarQuery("DELETE FROM MERCADONEGRO.Rubro_Publicacion WHERE ID_Rubro=@ID_Rubro AND Cod_Publicacion=@Cod_Publicacion", listaParametros, BDSQL.iniciarConexion());
                listaParametros.Clear();
                BDSQL.cerrarConexion();
            }
        }

        public static string obtenerStringRubros(int codPubli)
        {
            string rubros = "";
            
            List<Rubro> listaRubros = new List<Rubro>();
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@Cod_Publicacion", codPubli));

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT r.Descripcion FROM MERCADONEGRO.Rubros r " +
                                                        "JOIN MERCADONEGRO.Rubro_Publicacion rp ON rp.ID_Rubro = r.ID_Rubro " +                                            
                                                        "WHERE rp.Cod_Publicacion = @Cod_Publicacion", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                bool primero = true;

                while (lector.Read())
                {
                    if (primero)
                    {
                        rubros += Convert.ToString(lector["Descripcion"]);
                        primero = false;
                    }
                    else
                        rubros += ", " + Convert.ToString(lector["Descripcion"]);
                }
            }

            BDSQL.cerrarConexion();
            return rubros;

        }


        public static int encontrarRubroPublicacion(int codPubli, int idRubro)
        {
            int resultado;
            List<int> listaRubros = new List<int>();
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@Cod_Publicacion", codPubli));
            listaParametros.Add(new SqlParameter("@ID_Rubro", idRubro));

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Rubro_Publicacion WHERE Cod_Publicacion=@Cod_Publicacion AND ID_Rubro=@ID_Rubro", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                resultado = 1;
            }
            else
            {
                resultado = -1;
            }

            BDSQL.cerrarConexion();
            return resultado;
        }


    }
}
