using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    class Rubro
    {
        private List<string> rubros = new List<string>();

        public void agregarRubro(string rubro)
        {
            this.rubros.Add(rubro);

        }

    }
}
