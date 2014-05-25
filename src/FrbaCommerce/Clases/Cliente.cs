using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    class Cliente
    {
        public string Tipo_Doc { get; set; }
        public int Num_Doc { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public int Codigo_Postal { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }

        //Por ahora lo dejamos en comentario
        //public int CUIL { get; set; }

        //Consulta: Tipo_Doc no debiera ser Enum?



    }
}
