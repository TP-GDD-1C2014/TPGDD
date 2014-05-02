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
        
        // Iniciar transaccion, no probado
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
