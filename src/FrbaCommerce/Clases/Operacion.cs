using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    class Operacion
    {
        public int ID_Comprador { get; set; }
        public int ID_Vendedor { get; set; }
        public int Cod_Publicacion { get; set; }
        public enum Tipo_Operacion { Compra, Subasta_Ganada, Oferta } 
        public DateTime Fecha_Operacion { get; set; }
        public int Operacion_Facturada { get; set; }

    }
}
