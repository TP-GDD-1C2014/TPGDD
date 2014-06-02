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
        public DateTime Fecha_Respuesta { get; set; }

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

    }
}
