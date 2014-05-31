using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    class Facturacion
    {
        public int Cod_Publicacion { get; set; }
        public enum Forma_Pago { Efectivo, Tarjeta }
        public float Total_Facturacion { get; set; }


        public DataTable obtenerOperaciones(Usuario usuario)
        {
            return BDSQL.obtenerDataTable("MERCADONEGRO.ObtenerOperacionesSinFacturar", "SP");

        }


    }
}
