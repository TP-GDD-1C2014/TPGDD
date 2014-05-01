using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Common
{
    class Item
    {
        public int ID_Facturacion { get; set; }
        public int Cantidad_Vendida { get; set; }
        public string Descripcion { get; set; }
        public float Precio_Unitario { get; set; }
    }
}
