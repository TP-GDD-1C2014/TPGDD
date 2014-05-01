using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace FrbaCommerce.Clases
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

    }
}
