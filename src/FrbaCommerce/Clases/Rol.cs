using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    public class Rol
    {
        public int ID_Rol { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }

        public Rol(int id_rol, string nombre, bool habilitado)
        {
            this.ID_Rol = id_rol;
            this.Nombre = nombre;
            this.Habilitado = habilitado;
        }

        public List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        public void obtenerFuncionalidades(SqlConnection conexion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_Rol", this.ID_Rol);
            SqlDataReader lectorFuncionalidades = BDSQL.ejecutarReader("SELECT ID_Funcionalidad FROM MERCADONEGRO.Funcionalidad_Rol WHERE ID_Rol = @ID_Rol", listaParametros, conexion);
            if (lectorFuncionalidades.HasRows)
            {
                while (lectorFuncionalidades.Read())
                {
                    Funcionalidad funcionalidad = new Funcionalidad(Convert.ToInt32(lectorFuncionalidades["ID_Funcionalidad"]));
                    this.funcionalidades.Add(funcionalidad);
                }
            }
        }

        public static int obtenerID(string nombreRol)
        {
            int idRol;
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            listaParametros.Clear();

            BDSQL.agregarParametro(listaParametros, "@nombre", "Cliente");

            string commandText = "SELECT ID_Rol FROM MERCADONEGRO.Roles WHERE Nombre = @nombre";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", listaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                idRol = Convert.ToInt32(lector["ID_Rol"]);

            }
            else
                idRol = -1;

            BDSQL.cerrarConexion();
            return idRol;
        }

       
        
    }
}
