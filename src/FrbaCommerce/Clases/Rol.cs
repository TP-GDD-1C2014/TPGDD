using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    class Rol
    {
        public string Nombre { get; set; }
        public int Habilitado { get; set; }

        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        public void agregarFuncionalidades(Funcionalidad funcionalidad)
        {
            this.funcionalidades.Add(funcionalidad);

        }

    }
}
