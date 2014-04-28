using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Common
{
    class Publicacion
    {
        public int Cod_Publicacion { get; set; }
        public int Cod_Visibilidad { get; set; }
        public int ID_Vendedor { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Vto { get; set; }
        public float Precio { get; set; }
        public int Estado_Publicacion { get; set; }
        public int Tipo_Publicacion { get; set; }
        public int Permiso_Preguntas { get; set; }
        public int Stock_Inicial { get; set; }
    }
}
