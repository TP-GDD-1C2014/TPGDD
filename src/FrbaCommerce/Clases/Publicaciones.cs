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
    class Publicaciones
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
                    Publicacion unaPublicacion = new Publicacion((int)(decimal)lector["Cod_Publicacion"], (int)(decimal)lector["Cod_Visibilidad"], (int)(decimal)lector["ID_Vendedor"], (String)lector["Descripcion"], (int)(decimal)lector["Stock"], (DateTime)lector["Fecha_Vto"], (DateTime)lector["Fecha_Inic"], (int)(decimal)lector["Precio"], (string)lector["Estado_Public"], (string)lector["Tipo_Public"], (bool)lector["Permisos_Preguntas"], (int)(decimal)lector["Stock_Inicial"]);
                    /*unaPublicacion.Cod_Publicacion = (int)(decimal)lector["Cod_Publicacion"];
                    unaPublicacion.Cod_Visibilidad = (int)(decimal)lector["Cod_Visibilidad"];
                    unaPublicacion.ID_Vendedor = (int)(decimal)lector["ID_Vendedor"];
                    unaPublicacion.Descripcion = (String)lector["Descripcion"];
                    unaPublicacion.Stock = (int)(decimal)lector["Stock"];
                    unaPublicacion.Fecha_Vto = (DateTime)lector["Fecha_Vto"];
                    unaPublicacion.Fecha_Inicio = (DateTime)lector["Fecha_Inic"];
                    unaPublicacion.Precio = (int)(decimal)lector["Precio"];
                    unaPublicacion.Estado_Publicacion = (Estado_Publicacion)lector["Estado_Public"];
                    unaPublicacion.Tipo_Publicacion = (Tipo_Publicacion)lector["Tipo_Public"];
                    unaPublicacion.Permiso_Preguntas = (int)(decimal)lector["Permisos_Preguntas"];
                    unaPublicacion.Stock_Inicial = (int)(decimal)lector["Stock_Inicial"];*/
                    publicaciones.Add(unaPublicacion);
                }
            }

            BDSQL.cerrarConexion();
            return publicaciones;
        }

<<<<<<< HEAD
        public static void eliminarPublicacion(Publicacion unaPubli)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@idUser", unaPubli.Cod_Publicacion));
            int resultado = BDSQL.ejecutarQuery("DELETE FROM MERCADONEGRO.Publicaciones WHERE ID_Vendedor=@idUser", listaParametros, BDSQL.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al eliminar Publicacion", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            BDSQL.cerrarConexion();

=======
        public static List<Publicacion> obtenerPublicacionesPaginadas(int desde, int hasta)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@desde", desde);
            BDSQL.agregarParametro(listaParametros, "@hasta", hasta);

            String commandtext = "WITH tablaNumerada AS " +
            "(SELECT Cod_Publicacion, Cod_Visibilidad,ID_Vendedor,Descripcion," + 
            "Stock,Fecha_Vencimiento,Fecha_Inicial,Precio,Estado_Publicacion,Tipo_Publicacion,Permisos_Preguntas,Stock_Inicial, ROW_NUMBER() OVER (ORDER BY Cod_Visibilidad) AS RowNumber " +
            "FROM MERCADONEGRO.Publicaciones WHERE Estado_Publicacion = 'Publicada' AND Stock > 0 AND Fecha_Vencimiento < GETUTCDATE() ) " +
            "SELECT Cod_Publicacion, Cod_Visibilidad,ID_Vendedor,Descripcion, " + 
            "Stock,Fecha_Vencimiento,Fecha_Inicial,Precio,Estado_Publicacion,Tipo_Publicacion,Permisos_Preguntas,Stock_Inicial " +
            "FROM tablaNumerada " +
            "WHERE RowNumber BETWEEN @desde AND @hasta";

            SqlDataReader lector = BDSQL.ejecutarReader(commandtext, listaParametros, BDSQL.iniciarConexion());

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Publicacion unaPublicacion = new Publicacion(
                            Convert.ToInt32(lector["Cod_Publicacion"]),
                            Convert.ToInt32(lector["Cod_Visibilidad"]),
                            Convert.ToInt32(lector["ID_Vendedor"]), 
                            Convert.ToString(lector["Descripcion"]),
                            Convert.ToInt32(lector["Stock"]),
                            Convert.ToDateTime(lector["Fecha_Vencimiento"]),
                            Convert.ToDateTime(lector["Fecha_Inicial"]), 
                            Convert.ToDecimal(lector["Precio"]),
                            Convert.ToString(lector["Estado_Publicacion"]),
                            Convert.ToString(lector["Tipo_Publicacion"]), 
                            Convert.ToBoolean(lector["Permisos_Preguntas"]),
                            Convert.ToInt32(lector["Stock_Inicial"]));
                    publicaciones.Add(unaPublicacion);
                }
            }

            BDSQL.cerrarConexion();
            return publicaciones;
>>>>>>> 7abd53983619ab401cb11f9d40a61e7b80f3fc7a
        }

    }
}