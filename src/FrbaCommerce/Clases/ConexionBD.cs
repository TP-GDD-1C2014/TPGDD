using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaCommerce.Clases
{
    class ConexionBD
    {

        private static string stringConexion = ConfigurationManager.AppSettings["ConnectionString"];

        SqlConnection con = new SqlConnection(stringConexion);
    }
}
