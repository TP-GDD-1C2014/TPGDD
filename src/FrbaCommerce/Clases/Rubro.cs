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

       

    }

   
}
