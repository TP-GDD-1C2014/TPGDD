﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    class Funcionalidades
    {
        public static List<Funcionalidad> obtenerFuncionalidades(SqlConnection conexion, int ID_Rol)
        {
            List<Funcionalidad> listaFuncionalidades = new List<Funcionalidad>();
            
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_Rol", ID_Rol);
            SqlDataReader lectorFuncionalidades = BDSQL.ejecutarReader("SELECT f.ID_Funcionalidad, f.Nombre FROM MERCADONEGRO.Funcionalidades f, MERCADONEGRO.Funcionalidad_Rol fr WHERE fr.ID_Rol = @ID_Rol AND fr.ID_Funcionalidad = f.ID_Funcionalidad", listaParametros, conexion);
            
            if (lectorFuncionalidades.HasRows)
            {
                while (lectorFuncionalidades.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad((int)(decimal)lectorFuncionalidades["ID_Funcionalidad"], (string)lectorFuncionalidades["Nombre"]);
                    listaFuncionalidades.Add(unaFuncionalidad);
                }
            }
            BDSQL.cerrarConexion();
            return listaFuncionalidades;
        }

        public static void AgregarFuncionalidadEnRol(string nombre, Funcionalidad unaFunc)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@rol", nombre));
            ListaParametros.Add(new SqlParameter("@func", unaFunc.Nombre));

            BDSQL.ExecStoredProcedure("MERCADONEGRO.AgregarFuncionalidad", ListaParametros);
            BDSQL.cerrarConexion();
           
        }
    }
}
