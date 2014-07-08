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

        public static string obtenerTipoPublicacion(int codPublicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            BDSQL.agregarParametro(parametros, "@codPublicacion", codPublicacion);
            
            string commandText = "SELECT Cod_TipoPublicacion FROM MERCADONEGRO.Publicaciones WHERE Cod_Publicacion = @codPublicacion";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", parametros);
            int tipoPublicacion = -1;
            string tipoPublicacionDescripcion;

            if (lector.HasRows)
            {
                lector.Read();


                tipoPublicacion = Convert.ToInt32(lector["Cod_TipoPublicacion"]);




                tipoPublicacionDescripcion = Interfaz.getDescripcion(tipoPublicacion, "tipoPublicacion");

                BDSQL.cerrarConexion();
                return tipoPublicacionDescripcion;
            }
            else
            {
                BDSQL.cerrarConexion();
                return "";
            }
            
        }

        public static int obtenerStock(int codPublicacion)
        {
            int stock;
            List<SqlParameter> parametros = new List<SqlParameter>();

            BDSQL.agregarParametro(parametros, "@codPublicacion", codPublicacion);

            string commandText = "SELECT Stock_Inicial FROM MERCADONEGRO.Publicaciones WHERE Publicaciones.Cod_Publicacion = @codPublicacion";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", parametros);

            if (lector.HasRows)
            {
                lector.Read();

                stock = Convert.ToInt32(lector["Stock_Inicial"]);

                BDSQL.cerrarConexion();
                return stock;
            }
            else
            {
                BDSQL.cerrarConexion();
                return -1;
            }
        }

        public static decimal sumarObtenerPrecio(int codPublicacion, string tipoPublicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            decimal precio;
            decimal comisionPorVisibilidad;
            int visibilidad;
            int idVendedor;
            string commandText = "";

            BDSQL.agregarParametro(parametros, "@codPublicacion", codPublicacion);

            //obtengo el precio x unidad y la comision por la visibiliad

            if (tipoPublicacion == "Compra Inmediata")
            {
                commandText = "SELECT p.ID_Vendedor, p.Precio, v.Porcentaje_Venta, v.Cod_Visibilidad  FROM MERCADONEGRO.Publicaciones p " +
                                   "JOIN MERCADONEGRO.Visibilidades v ON p.Cod_Visibilidad = v.Cod_Visibilidad " +
                                   "WHERE p.Cod_Publicacion = @codPublicacion";
            }
            else if (tipoPublicacion == "Subasta")
            {
                commandText = "SELECT p.ID_Vendedor, c.Monto_Compra AS Precio, v.Porcentaje_Venta, v.Cod_Visibilidad  FROM MERCADONEGRO.Publicaciones p " +
                                   "JOIN MERCADONEGRO.Visibilidades v ON p.Cod_Visibilidad = v.Cod_Visibilidad " +
                                   "JOIN MERCADONEGRO.Compras c ON p.ID_Vendedor = c.ID_Vendedor " +
                                   "WHERE p.Cod_Publicacion = @codPublicacion";
            }

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", parametros);

            if (lector.HasRows)
            {
                lector.Read();

                idVendedor = Convert.ToInt32(lector["ID_Vendedor"]);
                precio = Convert.ToDecimal(lector["Precio"]);
                comisionPorVisibilidad = Convert.ToDecimal(lector["Porcentaje_Venta"]);
                visibilidad = Convert.ToInt32(lector["Cod_Visibilidad"]);
                BDSQL.cerrarConexion();

                //inserto registro en Bonificaciones (si no existia) y suma uno a la cant de esa visibilidad para ese vendedor
                insertar_SumarUno(idVendedor, visibilidad);
                
                //chequea si es la novena y obtiene el precio
                if (Visibilidad.esLaNovenaVenta(idVendedor, visibilidad))
                {
                    BDSQL.cerrarConexion();
                    return 0;
                }
                else
                {
                 
                BDSQL.cerrarConexion();
                return precio * comisionPorVisibilidad;
                }


            }
            else
            {
                BDSQL.cerrarConexion();
                return -1;
            }
        }

        public static void pausarPublicaciones(int idUser)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            int idPublicacionPausada = Publicacion.getCodigoEstadoPublicacionDe("Pausada");

            int idPublicacionActiva = Publicacion.getCodigoEstadoPublicacionDe("Publicada");


            BDSQL.agregarParametro(listaParametros, "@idUser", idUser);
            BDSQL.agregarParametro(listaParametros, "@idPublicacionPausada", idPublicacionPausada);
            BDSQL.agregarParametro(listaParametros, "@idPublicacionActiva", idPublicacionActiva);

            string commandText = "UPDATE MERCADONEGRO.Publicaciones SET Cod_EstadoPublicacion = @idPublicacionPausada WHERE ID_User = @idUser "+
                                    " AND Cod_EstadoPublicacion = @idPublicacionActiva";

            BDSQL.ejecutarQuery(commandText, listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();

        }

        public static int getCodigoEstadoPublicacionDe(string descripcionEstado)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@descripcion", descripcionEstado);

            string commanText = "SELECT Descripcion FROM MERCADONEGRO.Estados_Publicacion WHERE DESCRIPCION = @descripcion";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commanText, "T", listaParametros);

            lector.Read();

            int codigoEstado = Convert.ToInt32(lector["Descripcion"]);

            return codigoEstado;

        }

        public static void insertar_SumarUno (int idVendedor, int visibilidad)
        {
            int idBonificacion;
            
            //Me fijo si existe ya la visibilidad para el idVendedor
            List<SqlParameter> parametros = new List<SqlParameter>();

            BDSQL.agregarParametro(parametros, "@idVendedor", idVendedor);
            BDSQL.agregarParametro(parametros, "@visibilidad", visibilidad);
            



            string commandText = "SELECT b.ID_Bonificacion FROM MERCADONEGRO.Bonificaciones b " +
                                 "WHERE b.ID_User = @idVendedor AND b.Visibilidad = @visibilidad";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", parametros);

            //si existe me quedo con el idBonificacion
            if (lector.HasRows)
            {
                lector.Read();
                idBonificacion = Convert.ToInt32(lector["ID_Bonificacion"]);
                BDSQL.cerrarConexion();
            }
            else
            {
                BDSQL.cerrarConexion();
                //sino existe inserto un nuevo registro y me traigo el idBonificacion
                List<SqlParameter> parametros2 = new List<SqlParameter>();

                BDSQL.agregarParametro(parametros2, "@idVendedor", idVendedor);
                BDSQL.agregarParametro(parametros2, "@visibilidad", visibilidad);
                SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
                paramRet.Direction = System.Data.ParameterDirection.Output;
                parametros2.Add(paramRet);

                idBonificacion = (int)BDSQL.ExecStoredProcedure("MERCADONEGRO.InsertarBonificacionUsuarioVisibilidad", parametros2);
                BDSQL.cerrarConexion();
            }
            
            //cualquiera sea el caso, sumo uno a la cantidad, de esa visibilidad, para ese vendedor (por el idBonificacion obtenido)
            List<SqlParameter> parametros3 = new List<SqlParameter>();

            BDSQL.agregarParametro(parametros3, "@idBonificacion", idBonificacion);

            BDSQL.ExecStoredProcedureSinRet("MERCADONEGRO.SumarCantidadBonificacion", parametros3);
            BDSQL.cerrarConexion();
        }

    }
}