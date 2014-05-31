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

    //public enum Estado_Publicacion { Borrador = 0, Activa, Pausada, Finalizada };
    //public enum Tipo_Publicacion { Inmediata = 0, Subasta }

    class Publicacion
    {
        public int Cod_Publicacion { get; set; }
        public int Cod_Visibilidad { get; set; }
        public int ID_Vendedor { get; set; } //ID_User
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public DateTime Fecha_Vto { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public decimal Precio { get; set; }
        public int Estado_Publicacion { get; set; }
        public int Tipo_Publicacion { get; set; }
        public bool Permiso_Preguntas { get; set; }
        public int Stock_Inicial { get; set; }

        //private List<Rubro> Rubros = new List<Rubro>();

        public Publicacion(int cod_Publicacion, int visibilidad, int id_Vendedor, string descripcion, int stock, DateTime fecha_Fin, DateTime fecha_Inicio, decimal precio, int estado, int tipoPubli, bool permisoPreg, int stock_Inicial)
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
        
        public void agregarRubro(Rubro rubro)
        {
            //this.Rubros.Add(rubro);

        }

        public void agregarPublicacion(int visibilidad, int idVendedor, string descripcion, int stock, System.DateTime fechaVto, System.DateTime fechaInicio, int estado, int tipoPubli, int precio, bool permisoPreg)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            
            //Se agrega automaticamente Cod_Publicacion?
            //BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", this.Cod_Publicacion);

            BDSQL.agregarParametro(listaParametros, "@Cod_Visibilidad", visibilidad);
            BDSQL.agregarParametro(listaParametros, "@ID_Vendedor", idVendedor);
            BDSQL.agregarParametro(listaParametros, "@Descripcion", descripcion);
            BDSQL.agregarParametro(listaParametros, "@Stock", stock);
            BDSQL.agregarParametro(listaParametros, "@Fecha_Vto", fechaVto);
            BDSQL.agregarParametro(listaParametros, "@Fecha_Inicio", fechaInicio);
            BDSQL.agregarParametro(listaParametros, "@Precio", precio);
            BDSQL.agregarParametro(listaParametros, "@Estado_Publicacion", estado);
            BDSQL.agregarParametro(listaParametros, "@Tipo_Publicacion", tipoPubli);
            BDSQL.agregarParametro(listaParametros, "@Permiso_Preguntas", permisoPreg);
            BDSQL.agregarParametro(listaParametros, "@Stock_Inicial", stock);

            BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Publicaciones(Cod_visibilidad,ID_Vendedor,Descripcion,Stock,Vecha_Vto,Fecha_Inic,Precio,Estado_Public,Tipo_Public,Permisos_Preguntas,Stock_Inicial) VALUES(@Cod_visibilidad,@ID_Vendedor,@Descripcion,@Stock,@Vecha_Vto,@Fecha_Inic,@Precio,@Estado_Public,@Tipo_Public,@Permisos_Preguntas,@Stock_Inicial)", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        /*public void buscarPublicacion(int codPubli, int visibilidad, int idVendedor, string descripcion, int stock, int estado, int tipoPubli)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", codPubli);
            BDSQL.agregarParametro(listaParametros, "@Cod_Visibilidad", visibilidad);
            BDSQL.agregarParametro(listaParametros, "@ID_Vendedor", idVendedor);
            BDSQL.agregarParametro(listaParametros, "@Descripcion", descripcion);
            BDSQL.agregarParametro(listaParametros, "@Stock", stock);
            BDSQL.agregarParametro(listaParametros, "@Estado_Publicacion", estado);
            BDSQL.agregarParametro(listaParametros, "@Tipo_Publicacion", tipoPubli);
            BDSQL.agregarParametro(listaParametros, "@Stock_Inicial", stock);

            //Recordar que no todos los parámetros son obligatorios
            //BDSQL.ejecutarQuery("SELECT Cod_Publicacion,Cod_Visibilidad,Descripcion,Stock,Estado_Public,Tipo_Public FROM MERCADONEGRO.Publicaciones WHERE Cod_Publicacion=@Cod_Publicacion AND Cod_Visibilidad=Cod_Visibilidad AND ID_Vendedor=@ID_Vendedor AND Descripcion=@Descripcion AND Stock=@Stock AND Estado_Public=@Estado_Public AND Tipo_Public=@Tipo_Public", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }*/

        public void actualizarPublicacion(int visibilidad, int idVendedor, string descripcion, int stock, System.DateTime fechaVto, System.DateTime fechaInicio, int estado, int tipoPubli, int precio, bool permisoPreg)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            BDSQL.agregarParametro(listaParametros, "@Cod_Visibilidad", visibilidad);
            BDSQL.agregarParametro(listaParametros, "@ID_Vendedor", idVendedor);
            BDSQL.agregarParametro(listaParametros, "@Descripcion", descripcion);
            BDSQL.agregarParametro(listaParametros, "@Stock", stock);
            BDSQL.agregarParametro(listaParametros, "@Fecha_Vto", fechaVto);
            BDSQL.agregarParametro(listaParametros, "@Fecha_Inicio", fechaInicio);
            BDSQL.agregarParametro(listaParametros, "@Precio", precio);
            BDSQL.agregarParametro(listaParametros, "@Estado_Publicacion", estado);
            BDSQL.agregarParametro(listaParametros, "@Tipo_Publicacion", tipoPubli);
            BDSQL.agregarParametro(listaParametros, "@Permiso_Preguntas", permisoPreg);
            BDSQL.agregarParametro(listaParametros, "@Stock_Inicial", stock);


            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Publicaciones SET Cod_visibilidad=@Cod_visibilidad, ID_Vendedor=@ID_Vendedor, Descripcion=@Descripcion, Stock=@Stock, Vecha_Vto=@Vecha_Vto, Fecha_Inic=@Fecha_Inic, Precio=@Precio, Estado_Public=@Estado_Public, Tipo_Public=@Tipo_Public, Permisos_Preguntas=@Permisos_Preguntas", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }
    }
}