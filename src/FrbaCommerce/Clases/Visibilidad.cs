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
    
        public Visibilidad()
        {
           
        }
     }
}
