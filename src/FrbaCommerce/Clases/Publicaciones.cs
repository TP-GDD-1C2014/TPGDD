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
                    Publicacion unaPublicacion = new Publicacion((int)(decimal)lector["Cod_Publicacion"], (int)(decimal)lector["Cod_Visibilidad"], (int)(decimal)lector["ID_Vendedor"], (String)lector["Descripcion"], (int)(decimal)lector["Stock"], (DateTime)lector["Fecha_Vto"], (DateTime)lector["Fecha_Inic"], (int)(decimal)lector["Precio"], (Estado_Publicacion)lector["Estado_Public"], (Tipo_Publicacion)lector["Tipo_Public"], (int)(decimal)lector["Permisos_Preguntas"], (int)(decimal)lector["Stock_Inicial"]);
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

        public static void eliminarPublicacion(Publicacion unaPubli)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@idUser", unaPubli.Cod_Publicacion));
            int resultado = BDSQL.ejecutarQuery("DELETE FROM MERCADONEGRO.Publicaciones WHERE ID_Vendedor=@idUser", listaParametros, BDSQL.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al eliminar Publicacion", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            BDSQL.cerrarConexion();

        }

    }
}