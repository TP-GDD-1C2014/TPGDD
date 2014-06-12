using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Common;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.Clases
{
    class Pregunta
    {
        public string _Pregunta { get; set; }
        public string Respuesta { get; set; }
        public DateTime? Fecha_Respuesta { get; set; }

        public Pregunta(string pregunta, string respuesta, DateTime? fechaRespuesta)
        {
            this._Pregunta = pregunta;
            this.Respuesta = respuesta;
            this.Fecha_Respuesta = fechaRespuesta;
        } 
        
        public static int insertarPregunta(string pregunta)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@pregunta", pregunta));
            SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
            paramRet.Direction = System.Data.ParameterDirection.Output;
            ListaParametros.Add(paramRet);

            int ret = (int)BDSQL.ExecStoredProcedure("MERCADONEGRO.InsertarPregunta", ListaParametros);

            BDSQL.cerrarConexion();

            return ret;

        }

        public static void insertarPreguntaPorPublicacion(int codPublicacion, int idPregunta)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codPublicacion", codPublicacion));
            ListaParametros.Add(new SqlParameter("@idPregunta", idPregunta));

            BDSQL.ExecStoredProcedure("MERCADONEGRO.InsertarPreguntaPorPublicacion", ListaParametros);

            BDSQL.cerrarConexion();
        }

        public static List<Pregunta> obtenerPreguntas(int idUser)
        {
            List<Pregunta> preguntas = new List<Pregunta>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codPublicacion", idUser));

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT p.Pregunta, p.Respuesta, p.Fecha_Respuesta FROM MERCADONEGRO.Preguntas p " +
                                                        "JOIN MERCADONEGRO.Pregunta_Publicacion pp ON p.ID_Pregunta = pp.ID_Pregunta " +
                                                        "JOIN MERCADONEGRO.Publicaciones pub ON pub.Cod_Publicacion = pp.Cod_Publicacion " +
                                                        "WHERE pub.ID_Vendedor = 88", ListaParametros,  BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string pregunta;
                    string respuesta;
                    DateTime? fechaRespuesta;

                    if (Convert.IsDBNull(lector["Pregunta"]))
                    {
                        pregunta = "";
                    }
                    else pregunta = Convert.ToString(lector["Pregunta"]);

                    if (Convert.IsDBNull(lector["Respuesta"]))
                    {
                        respuesta = "";
                    }
                    else respuesta = Convert.ToString(lector["Respuesta"]);

                    if (Convert.IsDBNull(lector["Fecha_Respuesta"]))
                    {
                        fechaRespuesta = null;
                    }
                    else fechaRespuesta = Convert.ToDateTime(lector["Fecha_Respuesta"]);

                    Pregunta unaPregunta = new Pregunta(pregunta,respuesta,fechaRespuesta);
                                                       
                    preguntas.Add(unaPregunta);
                }
            }

            BDSQL.cerrarConexion();

            return preguntas;



        }

    }
}
