using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    class Empresa
    {
        public string Razon_Social { get; set; }
        public int CUIT { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public int Codigo_Postal { get; set; }
        public string Ciudad { get; set; }
        public string Mail { get; set; }
        public string Nombre_Contacto { get; set; }
        public DateTime Fecha_Creacion { get; set; }

    }
}
