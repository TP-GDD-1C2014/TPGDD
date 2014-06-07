using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.Common;


namespace FrbaCommerce.Clases
{
    public class Publicaciones
    {
    
        public static List<Publicacion> obtenerPublicaciones(int idUser)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@idUser",idUser));
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Publicaciones WHERE ID_Vendedor=@idUser",listaParametros , BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //Se obtienen las descripciones a partir de los codigos de la BD
                    int cod_visibilidad = Convert.ToInt32(lector["Cod_Visibilidad"]);
                    string desc_visibilidad = Interfaz.getDescripcion(cod_visibilidad, "visibilidad");
                    int cod_estado = Convert.ToInt32(lector["Cod_EstadoPublicacion"]);
                    string desc_estado = Interfaz.getDescripcion(cod_estado, "estado");
                    int cod_tipo = Convert.ToInt32(lector["Cod_TipoPublicacion"]);
                    string desc_tipo = Interfaz.getDescripcion(cod_estado, "tipoPublicacion");

                    Publicacion unaPublicacion = new Publicacion((int)(decimal)lector["Cod_Publicacion"], desc_visibilidad, (int)(decimal)lector["ID_Vendedor"], (string)lector["Descripcion"], (int)(decimal)lector["Stock"], (DateTime)lector["Fecha_Vencimiento"], (DateTime)lector["Fecha_Inicial"], (decimal)lector["Precio"], desc_estado, desc_tipo, (bool)lector["Permisos_Preguntas"], (int)(decimal)lector["Stock_Inicial"]);
                    /*unaPublicacion.Cod_Publicacion = (int)(decimal)lector["Cod_Publicacion"];
                    unaPublicacion.Cod_Visibilidad = (int)(decimal)lector["Cod_Visibilidad"];
                    unaPublicacion.ID_Vendedor = (int)(decimal)lector["ID_Vendedor"];
                    unaPublicacion.Descripcion = (String)lector["Descripcion"];
                    unaPublicacion.Stock = (int)(decimal)lector["Stock"];
                    unaPublicacion.Fecha_Vto = (DateTime)lector["Fecha_Vto"];
                    unaPublicacion.Fecha_Inicio = (DateTime)lector["Fecha_Inic"];
                    unaPublicacion.Precio = (int)(decimal)lector["Precio"];
                    unaPublicacion.Estado_Publicacion = (String)lector["Estado_Public"];
                    unaPublicacion.Tipo_Publicacion = (String)lector["Tipo_Public"];
                    unaPublicacion.Permiso_Preguntas = (int)(decimal)lector["Permisos_Preguntas"];
                    unaPublicacion.Stock_Inicial = (int)(decimal)lector["Stock_Inicial"];*/
                    publicaciones.Add(unaPublicacion);
                }
            }

            BDSQL.cerrarConexion();
            return publicaciones;
        }


        public static List<Publicacion> obtenerTodaPublicacion()
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Publicaciones", BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //Se obtienen las descripciones a partir de los codigos de la BD
                    int cod_visibilidad = Convert.ToInt32(lector["Cod_Visibilidad"]);
                    string desc_visibilidad = Interfaz.getDescripcion(cod_visibilidad, "visibilidad");
                    int cod_estado = Convert.ToInt32(lector["Cod_EstadoPublicacion"]);
                    string desc_estado = Interfaz.getDescripcion(cod_estado, "estado");
                    int cod_tipo = Convert.ToInt32(lector["Cod_TipoPublicacion"]);
                    string desc_tipo = Interfaz.getDescripcion(cod_estado, "tipoPublicacion");

                    //Publicacion unaPublicacion = new Publicacion((int)(decimal)lector["Cod_Publicacion"], (string)lector["Cod_Visibilidad"], (int)(decimal)lector["ID_Vendedor"], (string)lector["Descripcion"], (int)(decimal)lector["Stock"], (DateTime)lector["Fecha_Vencimiento"], (DateTime)lector["Fecha_Inicial"], (decimal)lector["Precio"], (String)lector["Estado_Publicacion"], (String)lector["Tipo_Publicacion"], (bool)lector["Permisos_Preguntas"], (int)(decimal)lector["Stock_Inicial"]);
                    Publicacion unaPublicacion = new Publicacion((int)(decimal)lector["Cod_Publicacion"], desc_visibilidad, (int)(decimal)lector["ID_Vendedor"], (string)lector["Descripcion"], (int)(decimal)lector["Stock"], (DateTime)lector["Fecha_Vencimiento"], (DateTime)lector["Fecha_Inicial"], (decimal)lector["Precio"], desc_estado, desc_tipo, (bool)lector["Permisos_Preguntas"], (int)(decimal)lector["Stock_Inicial"]);
                    publicaciones.Add(unaPublicacion);
                }
            }

            BDSQL.cerrarConexion();
            return publicaciones;
        }

        public static void eliminarPublicacion(Publicacion unaPubli)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@idUser", unaPubli.ID_Vendedor));
            listaParametros.Add(new SqlParameter("@Cod_Publi", unaPubli.Cod_Publicacion));
            int resultado = BDSQL.ejecutarQuery("DELETE FROM MERCADONEGRO.Publicaciones WHERE ID_Vendedor=@idUser AND Cod_Publicacion=@Cod_Publi", listaParametros, BDSQL.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al eliminar Publicacion", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            BDSQL.cerrarConexion();
        }

        public static List<Publicacion> obtenerPublicacionesPaginadas(int desde, int hasta)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@desde", desde);
            BDSQL.agregarParametro(listaParametros, "@hasta", hasta);

            String commandtext = "WITH tablaNumerada AS " +
            "(SELECT Cod_Publicacion, Cod_Visibilidad, ID_Vendedor,Descripcion," +
            "Stock,Fecha_Vencimiento,Fecha_Inicial,Precio,Estado_Publicacion,Tipo_Publicacion,Permisos_Preguntas,Stock_Inicial, ROW_NUMBER() OVER (ORDER BY Cod_Visibilidad) AS RowNumber " +
            "FROM MERCADONEGRO.Publicaciones " +
            "WHERE Estado_Publicacion = 'Publicada' AND Stock > 0 AND Fecha_Vencimiento < GETUTCDATE() ) " +
            "SELECT Cod_Publicacion, Cod_Visibilidad ,ID_Vendedor, Descripcion, " +
            "Stock, Fecha_Vencimiento, Fecha_Inicial, Precio, Estado_Publicacion, Tipo_Publicacion, Permisos_Preguntas, Stock_Inicial " +
            "FROM tablaNumerada " +
            "WHERE RowNumber BETWEEN @desde AND @hasta";

            SqlDataReader lector = BDSQL.ejecutarReader(commandtext, listaParametros, BDSQL.iniciarConexion());

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Publicacion publi = new Publicacion();

                    publi.Cod_Publicacion = Convert.ToInt32(lector["Cod_Publicacion"]);
                    publi.Cod_Visibilidad = Interfaz.getDescripcion(Convert.ToInt32(lector["Cod_Visibilidad"]), "visibilidad");
                    //publi.Cod_Visibilidad = Convert.ToInt32(lector["Cod_Visibilidad"]);
                    publi.ID_Vendedor = Convert.ToInt32(lector["ID_Vendedor"]);
                    publi.Descripcion = Convert.ToString(lector["Descripcion"]);
                    publi.Stock = Convert.ToInt32(lector["Stock"]);
                    publi.Fecha_Vto =  Convert.ToDateTime(lector["Fecha_Vencimiento"]);
                    publi.Fecha_Inicio = Convert.ToDateTime(lector["Fecha_Inicial"]);
                    publi.Precio = Convert.ToDecimal(lector["Precio"]);
                    publi.Estado_Publicacion = Convert.ToString(lector["Estado_Publicacion"]);
                    publi.Tipo_Publicacion = Convert.ToString(lector["Tipo_Publicacion"]) ;
                    publi.Permiso_Preguntas = Convert.ToBoolean(lector["Permisos_Preguntas"]);
                    publi.Stock_Inicial = Convert.ToInt32(lector["Stock_Inicial"]);
            
                    publicaciones.Add(publi);
                }
            }

            BDSQL.cerrarConexion();
            return publicaciones;
        }

        public static void actualizarPublicacion(Publicacion unaPublicacion, int visibilidad)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@codPubli",unaPublicacion.Cod_Publicacion));
            listaParametros.Add(new SqlParameter("@codVisib", visibilidad));
            listaParametros.Add(new SqlParameter("@idUser", unaPublicacion.ID_Vendedor));
            listaParametros.Add(new SqlParameter("@descrip", unaPublicacion.Descripcion));
            listaParametros.Add(new SqlParameter("@stock", unaPublicacion.Stock));
            listaParametros.Add(new SqlParameter("@fechaVto", unaPublicacion.Fecha_Vto));
            listaParametros.Add(new SqlParameter("@fechaInic", unaPublicacion.Fecha_Inicio));
            listaParametros.Add(new SqlParameter("@precio", unaPublicacion.Precio));
            listaParametros.Add(new SqlParameter("@estado", unaPublicacion.Estado_Publicacion));
            listaParametros.Add(new SqlParameter("@tipo", unaPublicacion.Tipo_Publicacion));
            listaParametros.Add(new SqlParameter("@permiso", unaPublicacion.Permiso_Preguntas));
            listaParametros.Add(new SqlParameter("@stockInic", unaPublicacion.Stock_Inicial));

            int resultado = BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Publicaciones SET Cod_Visibilidad=@codVisib, ID_Vendedor=@idUser, Descripcion=@descrip, Stock=@stock, Fecha_Vencimiento=@fechaVto, Fecha_Inicial=@fechaInic, Precio=@precio, Estado_Publicacion=@estado, Tipo_Publicacion=@tipo, Permisos_Preguntas=@permiso, Stock_Inicial=@stockInic WHERE Cod_Publicacion=@codPubli", listaParametros, BDSQL.iniciarConexion());
            if (resultado == -1)
                MessageBox.Show("Falló al actualizar Publicación", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Éxtio al actualizar Publicación", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            BDSQL.cerrarConexion();
        }

        public static void agregarPublicacion(Publicacion unaPubli, int visibilidad, int estado, int tipoPubli)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            BDSQL.agregarParametro(listaParametros, "@Cod_Visibilidad", visibilidad);
            BDSQL.agregarParametro(listaParametros, "@ID_Vendedor", unaPubli.ID_Vendedor);
            BDSQL.agregarParametro(listaParametros, "@Descripcion", unaPubli.Descripcion);
            BDSQL.agregarParametro(listaParametros, "@Stock", unaPubli.Stock);
            BDSQL.agregarParametro(listaParametros, "@Fecha_Vto", unaPubli.Fecha_Vto);
            BDSQL.agregarParametro(listaParametros, "@Fecha_Inic", unaPubli.Fecha_Inicio);
            BDSQL.agregarParametro(listaParametros, "@Precio", unaPubli.Precio);
            BDSQL.agregarParametro(listaParametros, "@Estado_Publicacion", estado);
            BDSQL.agregarParametro(listaParametros, "@Tipo_Publicacion", tipoPubli);
            BDSQL.agregarParametro(listaParametros, "@Permiso_Preguntas", unaPubli.Permiso_Preguntas);
            BDSQL.agregarParametro(listaParametros, "@Stock_Inicial", unaPubli.Stock_Inicial);

            int resultado = BDSQL.ejecutarQuery("INSERT INTO MERCADONEGRO.Publicaciones(Cod_visibilidad,ID_Vendedor,Descripcion,Stock,Fecha_Vencimiento,Fecha_Inicial,Precio,Cod_EstadoPublicacion,Cod_TipoPublicacion,Permisos_Preguntas,Stock_Inicial) VALUES(@Cod_visibilidad,@ID_Vendedor,@Descripcion,@Stock,@Fecha_Vto,@Fecha_Inic,@Precio,@Estado_Publicacion,@Tipo_Publicacion,@Permiso_Preguntas,@Stock_Inicial)", listaParametros, BDSQL.iniciarConexion());

            if (resultado == -1)
            {
                MessageBox.Show("Falló al generar Publicacion", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Éxito al generar Publicacion", "Nice!", MessageBoxButtons.OK);
            }



            BDSQL.cerrarConexion();
        }

    }
}