using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    public class Rol
    {
        public int ID_Rol { get; set; }
        public string Nombre { get; set; }
        public int Habilitado { get; set; }

        public Rol(int id_rol, string nombre, int habilitado)
        {
            this.ID_Rol = id_rol;
            this.Nombre = nombre;
            this.Habilitado = habilitado;
        }

        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        public void agregarFuncionalidades(Funcionalidad funcionalidad)
        {
            this.funcionalidades.Add(funcionalidad);

        }

    }
}
