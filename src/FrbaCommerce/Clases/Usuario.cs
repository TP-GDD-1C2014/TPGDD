using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Common;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce.Clases
{
    public class Usuario
    {
        public int ID_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Intentos_Login { get; set; }
        public int Habilitado { get; set; }
        public int Primera_Vez { get; set; }
        public int Cant_Publi_Gratuitas { get; set; }
        public float Reputacion { get; set; }
        public int Ventas_Sin_Rendir { get; set; }

        public List<Rol> Roles = new List<Rol>(); 

        public Usuario(int id, string username, string password)
        {
            this.ID_User = id;
            this.Username = username;
            this.Password = password;
        }

        public Boolean obtenerPK(string username)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Username", username);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User FROM MERCADONEGRO.Usuarios WHERE Username = @Username", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read();
                this.ID_User = Convert.ToInt32(lector["ID_User"]);
                BDSQL.cerrarConexion();
                return true;
            }
            else
            {
                BDSQL.cerrarConexion();
                return false;
            }
        }

        public Boolean verificarContrasenia()
        {
            try
            {
                if (obtenerPK(this.Username))
                {
                    List<SqlParameter> listaParametros = new List<SqlParameter>();
                    BDSQL.agregarParametro(listaParametros, "@Username", this.Username);
                    BDSQL.agregarParametro(listaParametros, "@Password", this.Password);
                    SqlDataReader lector = BDSQL.ejecutarReader("SELECT Username, Password FROM MERCADONEGRO.Usuarios WHERE Username = @Username AND PASSWORD = @Password", listaParametros, BDSQL.iniciarConexion());
                    Boolean res = lector.HasRows;
                    BDSQL.cerrarConexion();
                    return res;
                }
                else
                {
                    return false;
                }
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Error en verificarContrasenia()");
                BDSQL.cerrarConexion();
                return false;
            }
        }

        public void ResetearIntentosFallidos()
        {
            try
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
                BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Intentos_Login = 0 WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
                BDSQL.cerrarConexion();
            }
            catch (SqlException)
            {
                MessageBox.Show("Error en ResetearIntentosFallidos()");
                BDSQL.cerrarConexion();
            }
        }

        public void sumarIntentoFallido()
        {
            try
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
                BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Intentos_Login = (Intentos_Login+1) WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
                BDSQL.cerrarConexion();
            }
            catch (SqlException)
            {
                MessageBox.Show("Error en sumarIntentoFallido()");
                BDSQL.cerrarConexion();
            }
        }

        public int intentosFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Intentos_Login FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            return lector.GetInt32(0);
        }

        public int cantidadIntentosFallidos() // Retorna -1 si falla el SELECT o por CATCH
        {
            try
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
                SqlDataReader lector = BDSQL.ejecutarReader("SELECT Intentos_Login FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());

                if (lector.HasRows)
                {
                    int resultado = lector.GetInt32(0);
                    BDSQL.cerrarConexion();
                    return resultado;
                }
                else
                {
                    BDSQL.cerrarConexion();
                    return -1;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error en cantidadIntentosFallidos()");
                BDSQL.cerrarConexion();
                return -1;
            }
        }

        public void inhabilitarUsuario()
        {
            try
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
                BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Habilitado = 0 WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
                BDSQL.cerrarConexion();
            }
            catch (SqlException)
            {
                MessageBox.Show("Error en inhabilitarUsuario()");
                BDSQL.cerrarConexion();
            }
        }

        public Boolean obtenerRoles()
        {
            List<SqlParameter> listaParametros1 = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros1, "@ID_User", this.ID_User);
            SqlConnection conexion = BDSQL.iniciarConexion();
            SqlDataReader lectorRolesUsuario = BDSQL.ejecutarReader("SELECT ID_Rol FROM MERCADONEGRO.Roles_Usuarios WHERE ID_User = @ID_User", listaParametros1, conexion);
            if (lectorRolesUsuario.HasRows)
            {
                while (lectorRolesUsuario.Read())
                {
                    List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                    BDSQL.agregarParametro(listaParametros2, "@ID_Rol", Convert.ToInt32(lectorRolesUsuario["ID_Rol"]));
                    SqlDataReader lectorRoles = BDSQL.ejecutarReader("SELECT Nombre, Habilitado FROM MERCADONEGRO.Roles WHERE ID_Rol = @ID_Rol", listaParametros2, conexion);
                    lectorRoles.Read();
                    Rol nuevoRol = new Rol(Convert.ToInt32(lectorRolesUsuario["ID_Rol"]), lectorRoles["Nombre"].ToString(), Convert.ToInt32(lectorRoles["Habilitado"]));
                    this.Roles.Add(nuevoRol);
                }
                BDSQL.cerrarConexion();
                return true;
            }
            else
            {
                BDSQL.cerrarConexion();
                return false;
            }
        }
    }
}