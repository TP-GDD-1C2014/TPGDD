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

        public static Boolean existeTelefono(int numero)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            agregarParametro(listaParametros, "@valor", numero);

            //tabla clientes
            SqlDataReader lector = ejecutarReader("SELECT * FROM MERCADONEGRO.Clientes WHERE Telefono = @valor", listaParametros, iniciarConexion());
            Boolean res = lector.HasRows;
            if (res)
            {
                cerrarConexion();
                return res;
            }
            else
            {
                //me fijo en empresas
                cerrarConexion();
                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                agregarParametro(listaParametros2, "@valor", numero);
                SqlDataReader lector2 = ejecutarReader("SELECT * FROM MERCADONEGRO.Empresas WHERE Telefono = @valor", listaParametros2, iniciarConexion());
                res = lector2.HasRows;
                if (res)
                {
                    cerrarConexion();
                    return res;
                }
            }
            cerrarConexion();
            return res;
        }

        public static Boolean existeFactura(int idFactura, int codPublicacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            agregarParametro(listaParametros, "@idFactura", idFactura);
            agregarParametro(listaParametros, "@codPublicacion", codPublicacion);

            SqlDataReader lector = ejecutarReader("SELECT Nro_Factura FROM MERCADONEGRO.Factura_Publicacion "+
                                                "WHERE Nro_Factura = @idFactura AND Cod_Publicacion = @codPublicacion", 
                                                listaParametros, iniciarConexion());
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
            SqlDataReader lector = ejecutarReader("SELECT * FROM " + nombreTabla + " WHERE " + nombreColumna1 + " = @valor1 AND " + nombreColumna2 + " = @valor2", listaParametros, iniciarConexion());
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

        public static void agregarParametro(List<SqlParameter> lista, string parametro, object valor)
        {
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

        public static SqlDataReader ejecutarReader(string stringQuery, SqlConnection conexion) // PARA SELECT * (sin parametros)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = stringQuery;

            return comando.ExecuteReader();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------  

        public static int ejecutarQuery(string stringQuery, List<SqlParameter> parametros, SqlConnection conexion) // PARA UPDATE, INSERT, DELETE, SELECT (con parametros)
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

        public static SqlDataReader ObtenerDataReader(string commandtext, string commandtype, List<SqlParameter> ListaParametro) //(con parametros)
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

            
        public static SqlDataReader ObtenerDataReader(string commandtext, string commandtype) //sin parametros
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = iniciarConexion();
            comando.CommandText = commandtext;
           
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


        public static DataTable obtenerDataTable(string commandtext, string commandtype, List<SqlParameter> ListaParametro) //(con parametros)
        {
            DataTable result = null;

           int count = 0;

            try
            {
                SqlDataReader dr = ObtenerDataReader(commandtext, commandtype, ListaParametro);
                if (dr.HasRows)
                {

                    result = new DataTable();

                    while (dr.Read())
                    {
                        DataRow row = result.NewRow();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            if (count == 0)
                                result.Columns.Add(dr.GetName(i));

                            row[i] = dr[i];
                        }
                        result.Rows.Add(row);
                        count++;
                    }
                }
                dr.Close();
            }
            finally
            {
                try
                {
                    conexion.Close();
                    conexion.Dispose();
                }
                catch { }
            }


            return result;

        }


        public static DataTable obtenerDataTable(string commandtext, string commandtype) //(sin parametros)
        {
            DataTable result = null;

            int count = 0;

            try
            {
                SqlDataReader dr = ObtenerDataReader(commandtext, commandtype);
                if (dr.HasRows)
                {

                    result = new DataTable();

                    while (dr.Read())
                    {
                        DataRow row = result.NewRow();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            if (count == 0)
                                result.Columns.Add(dr.GetName(i));

                            row[i] = dr[i];
                        }
                        result.Rows.Add(row);
                        count++;
                    }
                }
                dr.Close();
            }
            finally
            {
                try
                {
                    conexion.Close();
                    conexion.Dispose();
                }
                catch { }
            }


            return result;

        }




        //----------------------------------------------------------------------------------------------------------------------------------------------  

        public static decimal ExecStoredProcedure(string commandtext, List<SqlParameter> ListaParametro) //con parametros
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
            catch(SqlException e)
            {
                MessageBox.Show("" + e.Message, "Error");
                return 0;
            }
        }


        public static decimal ExecStoredProcedure(string commandtext) //sin parametros
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = iniciarConexion();
                comando.CommandText = commandtext;
                comando.CommandType = CommandType.StoredProcedure;

           
                comando.ExecuteNonQuery();
                return (decimal)comando.Parameters["@ret"].Value;
            }
            catch
            {
                return 0;
            }
        }



        public static void ExecStoredProcedureSinRet(string commandtext, List<SqlParameter> ListaParametro) //con parametros
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

        }


        public static void ExecStoredProcedureSinRet(string commandtext) //sin parametros
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = iniciarConexion();
            comando.CommandText = commandtext;
            comando.CommandType = CommandType.StoredProcedure;


            comando.ExecuteNonQuery();

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



       



