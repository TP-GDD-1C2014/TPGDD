using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Common;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrbaCommerce.Clases;

namespace FrbaCommerce.Clases
{

    //public enum Estado_Publicacion { Borrador = 0, Publicada, Pausada, Finalizada }; es que.. a ver pera
    //public enum Tipo_Publicacion { Inmediata = 0, Subasta } sino la hago rústica y veo si puedo pasarle cada parametro de la publi

    public class Publicacion
    {
        public int Cod_Publicacion { get; set; }
        public string Cod_Visibilidad { get; set; }
        //public int Cod_Visibilidad { get; set; }
        public int ID_Vendedor { get; set; } //ID_User
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public DateTime Fecha_Vto { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public decimal Precio { get; set; }
        public string Estado_Publicacion { get; set; }
        public string Tipo_Publicacion { get; set; }
        public bool Permiso_Preguntas { get; set; }
        public int Stock_Inicial { get; set; }

        //private List<Rubro> Rubros = new List<Rubro>();
        public Publicacion()
        {
        }
        
        public Publicacion(int cod_Publicacion, string visibilidad, int id_Vendedor, string descripcion, int stock, DateTime fecha_Fin, DateTime fecha_Inicio, decimal precio, string estado, string tipoPubli, bool permisoPreg, int stock_Inicial)
        {
            this.Cod_Publicacion = cod_Publicacion;
            this.Cod_Visibilidad = visibilidad;
            this.ID_Vendedor = id_Vendedor;
            this.Descripcion = descripcion;
            this.Stock = stock;
            this.Fecha_Vto = fecha_Fin;
            this.Fecha_Inicio = fecha_Inicio;
            this.Precio = precio;
            this.Estado_Publicacion = estado;
            this.Tipo_Publicacion = tipoPubli;
            this.Permiso_Preguntas = permisoPreg;
            this.Stock_Inicial = stock_Inicial;
        }
        /*
        public void agregarRubro(Rubro rubro)
        {
            this.Rubros.Add(rubro);
            //
        }
        */
        
    }
}