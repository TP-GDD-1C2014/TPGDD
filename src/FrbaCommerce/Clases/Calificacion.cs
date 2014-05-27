using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    public class Calificacion
    {
        public int Puntaje { get; set; }
        public string Descripcion { get; set; }

        public Calificacion(int punt, string desc)
        {
            this.Puntaje = punt;
            this.Descripcion = desc;
        }
    }
}
