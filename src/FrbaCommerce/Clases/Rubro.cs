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

    }

   
}
