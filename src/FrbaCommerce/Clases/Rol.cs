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
        public int Habilitado { get; set; }

        public Rol(int id_rol, string nombre, int habilitado)
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


        
    }
}
