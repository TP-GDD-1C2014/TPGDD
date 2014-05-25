using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Common;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.Clases
{
    class Roles
    {
        public static List<Rol> obtenerRoles()
        {
            List<Rol> roles = new List<Rol>();
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Roles", BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol((int)(decimal)lector["ID_Rol"], (string)lector["Nombre"], (bool)lector["Habilitado"]);
                    roles.Add(unRol);
                }
            }
            BDSQL.cerrarConexion();
            return roles;
        }
        public static bool insertarNuevoRol(string nombre , List<Funcionalidad> lista)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@nombreRol", nombre));
                SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
                paramRet.Direction = System.Data.ParameterDirection.Output;
                ListaParametros.Add(paramRet);

                //insert, devuelve ret = id rol insertado
                //TODO : Mega fino.. hacer que agregarRolNuevo haga primero select para ver si ya existe luego
                // el insert, como esta ahora NO inserta si ya existe, pero el identity suma +1 y queda "feo"
                // no afecta en nada, pero bueno, belleza. 
                // ej: inserta: id 4, nombre Rol1 SUCCES, inserta Rol1 de nuevo FAIL, no inserta, pero identity+1
                // inserta Rol22 SUCCES, pero queda id 6. 
                int ret = (int)BDSQL.ExecStoredProcedure("MERCADONEGRO.agregarRolNuevo", ListaParametros);
                BDSQL.cerrarConexion();

                if (ret != 0)
                {
                    foreach (Funcionalidad unaFunc in lista)
                    {
                        //insert FUNCIONALIDAD_ROL 
                        Funcionalidades.AgregarFuncionalidadEnRol(nombre, unaFunc);
                    }
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

    }
}
