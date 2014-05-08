using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Common;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace FrbaCommerce.Clases
{
    public enum Estado_Publicacion { Borrador = 0, Activa, Pausada, Finalizada };
    public enum Tipo_Publicacion { Inmediata = 0, Subasta }

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
        public Estado_Publicacion Estado_Publicacion;
        public Tipo_Publicacion Tipo_Publicacion;
        public int Permiso_Preguntas { get; set; }
        public int Stock_Inicial { get; set; }

        private List<Rubro> Rubros = new List<Rubro>();

        public Publicacion(int visibilidad, string descripcion, int stock, System.DateTime fechaFin, Estado_Publicacion estado, Tipo_Publicacion tipoPubli, int precioTotal, int precioUnit)
        {
            this.Cod_Visibilidad = visibilidad;
            this.Descripcion = descripcion;
            this.Stock_Inicial = stock;
            this.Fecha_Vto = fechaFin;
            this.Estado_Publicacion = estado;
            this.Tipo_Publicacion = tipoPubli;
            this.Precio = precioTotal;
            this.Precio = precioUnit;

        }

        public void agregarRubro(Rubro rubro)
        {
            this.Rubros.Add(rubro);

        }
    }
}
