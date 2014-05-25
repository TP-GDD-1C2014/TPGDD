using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace FrbaCommerce.Common
{
    class BDSQL
    {
        static SqlConnection conexion = new SqlConnection();
        static string stringConexion;

        public static Boolean existeString(string valor, string nombreTabla, string nombreColumna)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            agregarParametro(listaParametros, "@valor", valor);
            SqlDataReader lector = ejecutarReader("SELECT * FROM " + nombreTabla + " WHERE " + nombreColumna + " = @valor", listaParametros, iniciarConexion());
            Boolean res = lector.HasRows;
            cerrarConexion();
            return res;
        }

//---------------------------------------------------------------------------------------------------------------------------------------------- 

        public static Boolean existenSimultaneamente(string valor1, string valor2, string nombreTabla, string nombreColumna1, string nombreColumna2)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            agregarParametro(listaParametros, "@valor1", valor1);
            agregarParametro(listaParametros, "@valor2", valor2);
            SqlDataReader lector = ejecutarReader("SELECT * FROM " + nombreTabla + " WHERE " + nombreColumna1 + " = @valor1 AND "+nombreColumna2 + " = @valor2", listaParametros, iniciarConexion());
            Boolean res = lector.HasRows;
            cerrarConexion();
            return res;
        }

//---------------------------------------------------------------------------------------------------------------------------------------------- 

        public static SqlConnection iniciarConexion()
        {
            try
            {
                stringConexion = ConfigurationManager.AppSettings["ConnectionString"];
                conexion.ConnectionString = stringConexion;
                conexion.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Error en la conexión a la base de datos");
            }
            return conexion;
        }

//---------------------------------------------------------------------------------------------------------------------------------------------- 

        public static void cerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Error al desconectar la base de datos");
            }   
        }
//----------------------------------------------------------------------------------------------------------------------------------------------    
    
        public static void agregarParametro(List<SqlParameter> lista, string parametro, object valor) {
            lista.Add(new SqlParameter(parametro, valor));
        }

//----------------------------------------------------------------------------------------------------------------------------------------------   

        public static SqlDataReader ejecutarReader(string stringQuery, List<SqlParameter> parametros, SqlConnection conexion) // PARA SELECT
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = stringQuery;
            foreach (SqlParameter parametro in parametros)
            {
                comando.Parameters.Add(parametro);
            }
            return comando.ExecuteReader();
        }

        public static SqlDataReader ejecutarReader(string stringQuery, SqlConnection conexion) // PARA SELECT
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = stringQuery;

            return comando.ExecuteReader();
        }

//----------------------------------------------------------------------------------------------------------------------------------------------  
 
        public static int ejecutarQuery(string stringQuery, List<SqlParameter> parametros, SqlConnection conexion) // PARA UPDATE, INSERT, DELETE
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = stringQuery;
            foreach (SqlParameter parametro in parametros)
            {
                comando.Parameters.Add(parametro);
            }
            return comando.ExecuteNonQuery();
        }

//----------------------------------------------------------------------------------------------------------------------------------------------  
 
        public static SqlDataReader ObtenerDataReader(string commandtext, string commandtype, List<SqlParameter> ListaParametro)
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = iniciarConexion();
            comando.CommandText = commandtext;
            foreach (SqlParameter elemento in ListaParametro)
            {
                comando.Parameters.Add(elemento);
            }
            switch (commandtype)
            {
                case "T":
                    comando.CommandType = CommandType.Text;
                    break;
                case "TD":
                    comando.CommandType = CommandType.TableDirect;
                    break;
                case "SP":
                    comando.CommandType = CommandType.StoredProcedure;
                    break;
            }
            return comando.ExecuteReader();
        }

//----------------------------------------------------------------------------------------------------------------------------------------------  

        public static decimal ExecStoredProcedure(string commandtext, List<SqlParameter> ListaParametro)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = iniciarConexion();
                comando.CommandText = commandtext;
                comando.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter elemento in ListaParametro)
                {
                    comando.Parameters.Add(elemento);
                }

                comando.ExecuteNonQuery();
                return (decimal)comando.Parameters["@ret"].Value;
            }
            catch
            {
                return 0;
            }
        }
//---------------------------------------------------------------------------------------------------------------------------------------------- 
// Iniciar transaccion

        public static SqlTransaction iniciarTransaccion(SqlTransaction objTransaccion)
        {
            try
            {
                objTransaccion = conexion.BeginTransaction();
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudo inicializar la transacción");
            }
            return objTransaccion;
        }
        

    }
}
