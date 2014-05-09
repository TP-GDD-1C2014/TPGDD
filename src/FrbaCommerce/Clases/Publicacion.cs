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
        public DateTime Fecha_Vto { get; set; }
        public DateTime Fecha_Inicio { get; set; }
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

        public void agregarPublicacion()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", this.Cod_Publicacion);
            BDSQL.agregarParametro(listaParametros, "@Cod_Visibilidad", this.Cod_Visibilidad);
            BDSQL.agregarParametro(listaParametros, "@ID_Vendedor", this.ID_Vendedor);
            BDSQL.agregarParametro(listaParametros, "@Descripcion", this.Descripcion);
            BDSQL.agregarParametro(listaParametros, "@Stock", this.Stock);
            BDSQL.agregarParametro(listaParametros, "@Fecha_Vto", this.Fecha_Vto);
            BDSQL.agregarParametro(listaParametros, "@Fecha_Inicio", this.Fecha_Inicio);
            BDSQL.agregarParametro(listaParametros, "@Precio", this.Precio);
            BDSQL.agregarParametro(listaParametros, "@Estado_Publicacion", this.Estado_Publicacion);
            BDSQL.agregarParametro(listaParametros, "@Tipo_Publicacion", this.Tipo_Publicacion);
            BDSQL.agregarParametro(listaParametros, "@Permiso_Preguntas", this.Permiso_Preguntas);
            BDSQL.agregarParametro(listaParametros, "@Stock_Inicial", this.Stock_Inicial);

            //Configurar parámetros del INSERT
            BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Publicaciones SELECT *", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }
    }
}
