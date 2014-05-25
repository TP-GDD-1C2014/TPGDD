using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    public class Funcionalidad
    {
        public int    ID_Funcionalidad { get; set; }
        public string Nombre { get; set; }

        public Funcionalidad(int id)
        {
            this.ID_Funcionalidad = id;
        }

        public Funcionalidad(int id, string nombre)
        {
            ID_Funcionalidad = id;
            Nombre = nombre;

        }
    }
}
