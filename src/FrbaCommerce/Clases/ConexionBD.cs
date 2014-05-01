using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.Common
{
    public class ConexionBD
    {
        public static string String_Conexion = "Server=localhost\\SQLSERVER2008;Database=GD1C2014;User Id=gd;Password=gd2014;";
    
         
        SqlConnection _con = new SqlConnection(String_Conexion);
        
  

       try{
            _con.Open();
            
        


        _con.Close();

   }
}
      
