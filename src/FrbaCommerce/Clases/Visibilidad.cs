using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Common
{
    class Visibilidad
    {
        public enum Cod_Visibilidad { Platino = 10002, Oro, Plata, Bronce, Gratis };
        public string Descripcion { get; set; }
        public float Costo_Publicacion { get; set; }
        public float Porcentaje_Venta  { get; set; }

    }
}
