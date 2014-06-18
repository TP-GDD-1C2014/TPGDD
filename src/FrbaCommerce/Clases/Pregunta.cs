using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Common;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.Clases
{
    public class Pregunta
    {
        public int ID_Pregunta { get; set; }
        public int ID_User { get; set; }
        public string _Pregunta { get; set; }
        public string Respuesta { get; set; }
        public DateTime? Fecha_Respuesta { get; set; }

        public Pregunta(int idPregunta, int idUser, string pregunta, string respuesta, DateTime? fechaRespuesta)
        {
            this.ID_Pregunta = idPregunta;
            this.ID_User = idUser;
            this._Pregunta = pregunta;
            this.Respuesta = respuesta;
            this.Fecha_Respuesta = fechaRespuesta;
        } 
        
        public static int insertarPregunta(string pregunta, int idUser)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@pregunta", pregunta));
            ListaParametros.Add(new SqlParameter("@idUser", idUser));
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

            BDSQL.ExecStoredProcedureSinRet("MERCADONEGRO.InsertarPreguntaPorPublicacion", ListaParametros);

            BDSQL.cerrarConexion();
        }

        public static List<Pregunta> obtenerPreguntas(int idUser )
        {
            List<Pregunta> preguntas = new List<Pregunta>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idUser", idUser));

            string str = "SELECT p.ID_Pregunta, p.ID_User, p.Pregunta, p.Respuesta, p.Fecha_Respuesta FROM MERCADONEGRO.Preguntas p " +
                         "JOIN MERCADONEGRO.Pregunta_Publicacion pp ON p.ID_Pregunta = pp.ID_Pregunta " +
                         "JOIN MERCADONEGRO.Publicaciones pub ON pub.Cod_Publicacion = pp.Cod_Publicacion ";
      
            str += "WHERE pub.ID_Vendedor = @idUser AND p.Respuesta IS NULL"; //aca seria @idUser, pero uso 88 por ej para test.
            

            
            SqlDataReader lector = BDSQL.ejecutarReader( str, ListaParametros,  BDSQL.iniciarConexion());
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

                    Pregunta unaPregunta = new Pregunta(Convert.ToInt32(lector["ID_Pregunta"]), 
                                                        Convert.ToInt32(lector["ID_User"]),
                                                        pregunta,
                                                        respuesta,
                                                        fechaRespuesta);
                                                       
                    preguntas.Add(unaPregunta);
                }
            }

            BDSQL.cerrarConexion();

            return preguntas;



        }

        public static DataTable obtenerRespuestas(int idUser)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idUser", idUser));
            
            string str = "select * from MERCADONEGRO.VerRespuestasView WHERE ID_User = @idUser";

            DataTable dataTable = BDSQL.obtenerDataTable(str, "T", ListaParametros);

            return dataTable;
        }

        public static bool actualizarRespuesta(Pregunta pregunta)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idPregunta", pregunta.ID_Pregunta));
            ListaParametros.Add(new SqlParameter("@respuesta", pregunta.Respuesta));
            ListaParametros.Add(new SqlParameter("@fecha", Interfaz.obtenerFecha()));

            int ret = BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Preguntas " +
                                          "SET Respuesta = @respuesta, Fecha_Respuesta = @fecha " + 
                                          "WHERE ID_Pregunta = @idPregunta", 
                                          ListaParametros, BDSQL.iniciarConexion());

            BDSQL.cerrarConexion();

            if (ret == -1)
                return false;

            return true;
            
        }

       

    }
}
