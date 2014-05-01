using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    class Facturacion
    {
        public int Cod_Publicacion { get; set; }
        public enum Forma_Pago { Efectivo, Tarjeta }
        public float Total_Facturacion { get; set; }

    }
}
