using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    class Publicacion
    {
        public int Cod_Publicacion { get; set; }
        public int Cod_Visibilidad { get; set; }
        public int ID_Vendedor { get; set; } //ID_User
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Vto { get; set; }
        public float Precio { get; set; }
        public enum Estado_Publicacion { Borrador = 0, Activa, Pausada, Finalizada }
        public enum Tipo_Publicacion { Inmediata = 0, Subasta }
        public int Permiso_Preguntas { get; set; }
        public int Stock_Inicial { get; set; }

        private List<Rubro> Rubros = new List<Rubro>();

        public void agregarRubro(Rubro rubro)
        {
            this.Rubros.Add(rubro);

        }
    }
}
