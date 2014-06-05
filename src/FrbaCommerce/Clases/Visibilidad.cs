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
        public static Dictionary<int, string> diccionarioVisibilidades = new Dictionary<int, string>();
    
        public Visibilidad()
        {
            this.generarDiccionario();
        }


    
        private void generarDiccionario()
        {
            SqlDataReader lector = BDSQL.ObtenerDataReader("SELECT COD_VISIBILIDAD, DESCRIPCION FROM MERCADONEGRO.VISIBILIDADES ORDER BY COD_VISIBILIDAD",
                                                            "T");
                                              
             if (lector.HasRows)
            {
                while (lector.Read())
                {
                    diccionarioVisibilidades.Add( (int)(decimal) lector["COD_VISIBILIDAD"], (string) lector["DESCRIPCION"] );
                }
            }
            BDSQL.cerrarConexion();
            
        }

        //Metodo para obtener el "String" de la publicacion
        public string getDescripcion(int codVisibilidad)
        {
            string descripcion;

            diccionarioVisibilidades.TryGetValue(codVisibilidad, out descripcion);

            return descripcion;
        }

    }
}
