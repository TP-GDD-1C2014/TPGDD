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
        public int ID_User { get; set; } // Lo agregamos para consultar con las tablas donde es FK
        public List<Rol> Roles { get; set; } // Lo agregamos para ejecutar el método obtenerRoles() y chequear las tablas Roles_Usuario y Roles

        public string Username { get; set; }
        public string Password { get; set; }
        public int Intentos_Login { get; set; }
        public int Habilitado { get; set; }
        public int Primera_Vez { get; set; }
        public int Cant_Publi_Gratuitas { get; set; }
        public float Reputacion { get; set; }
        public int Ventas_Sin_Rendir { get; set; }

        public Usuario(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public Boolean verificarContrasenia()
        {
            try
            {
                // Conectamos
                SqlConnection conexion = BDSQL.iniciarConexion();

                // Armamos el query con los parámetros
                SqlCommand queryLogin = new SqlCommand("SELECT Username, Password FROM MERCADONEGRO.Usuarios WHERE Username = @Username AND PASSWORD = @Password", conexion);
                queryLogin.Parameters.AddWithValue("@Username", this.Username);
                queryLogin.Parameters.AddWithValue("@Password", this.Password);

                // Ejecutamos el query
                queryLogin.ExecuteNonQuery();

                // Recibimos el resultado
                SqlDataReader lector = queryLogin.ExecuteReader();

                // Chequeamos si hubo coincidencias
                if (lector.HasRows)
                {
                    BDSQL.cerrarConexion();
                    return true;
                }
                else
                {
                    BDSQL.cerrarConexion();
                    return false;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error en verificar contraseña");
                return false;
            }
        }

        public void ResetearIntentosFallidos()
        {
            // Conectamos
            SqlConnection conexion = BDSQL.iniciarConexion();

            // Armamos el query
            SqlCommand queryResetearIntentos = new SqlCommand("UPDATE MERCADONEGRO.Usuarios SET Intentos_Login = 0 WHERE Username = @Username", conexion);
            queryResetearIntentos.Parameters.AddWithValue("@Username", Username);

            // Ejecutamos el query
            queryResetearIntentos.ExecuteNonQuery();

            // Cerramos
            BDSQL.cerrarConexion();
        }

        public void sumarIntentoFallido()
        {
            // Conectamos
            SqlConnection conexion = BDSQL.iniciarConexion();

            // Armamos el query
            SqlCommand querySumarIntento = new SqlCommand("UPDATE MERCADONEGRO.Usuarios SET Intentos_Login = (Intentos_Login+1) WHERE Username = @Username", conexion);
            querySumarIntento.Parameters.AddWithValue("@Username", Username);

            // Ejecutamos el query
            querySumarIntento.ExecuteNonQuery();

            // Cerramos
            BDSQL.cerrarConexion();
        }

        public int cantidadIntentosFallidos()
        {
            // Conectamos
            SqlConnection conexion = BDSQL.iniciarConexion();

            // Armamos el query
            SqlCommand queryCantidadIntentos = new SqlCommand("SELECT Intentos_Login FROM MERCADONEGRO.Usuario WHERE Username = @Username", conexion);
            queryCantidadIntentos.Parameters.AddWithValue("@Username", Username);

            // Ejecutamos el query
            queryCantidadIntentos.ExecuteNonQuery();

            // Recibimos el resultado
            SqlDataReader lector = queryCantidadIntentos.ExecuteReader();

            // Cerramos
            BDSQL.cerrarConexion();

            return lector.GetInt32(0); // No sabíamos si poner Int16, Int32 o Int64
        }

        public void inhabilitarUsuario()
        {
            // Conectar a la base de datos y cambiar el campo Habilitado a 0
            // NO contempla la inhabilitación de Rol

            // Conectamos
            SqlConnection conexion = BDSQL.iniciarConexion();

            // Armamos el query
            SqlCommand queryInhabilitar = new SqlCommand("UPDATE MERCADONEGRO.Usuarios SET Habilitado = 0 WHERE Username = @Username", conexion);
            queryInhabilitar.Parameters.AddWithValue("@Username", Username);

            // Ejecutamos el query
            queryInhabilitar.ExecuteNonQuery();

            // Cerramos
            BDSQL.cerrarConexion();
        }

        public void agregarRol(Rol rol)
        {
            this.Roles.Add(rol);
        }


        public Boolean obtenerRoles()
        {
            // Conectamos
            SqlConnection conexion = BDSQL.iniciarConexion();

            // Chequeamos la tabla Roles_Usuarios
            SqlCommand queryRolesUsuario = new SqlCommand("SELECT (ID_Rol) FROM MERCADONEGRO.Roles_Usuarios WHERE ID_User = @ID_User", conexion);
            queryRolesUsuario.Parameters.AddWithValue("@ID_User", ID_User);
            SqlDataReader lectorRolesUsuario = queryRolesUsuario.ExecuteReader();

            if (lectorRolesUsuario.HasRows)
            {
                // El usuario tiene roles
                while (lectorRolesUsuario.Read())
                {
                    // Para cada ID_Rol asociado a ID_User, busca en la tabla Roles los campos Nombre y Habilitado...
                    SqlCommand queryRoles = new SqlCommand("SELECT (Nombre, Habilitado) FROM MERCADONEGRO.Roles WHERE ID_Rol = @ID_Rol", conexion);
                    queryRoles.Parameters.AddWithValue("@ID_Rol", lectorRolesUsuario.GetInt32(0));

                    SqlDataReader lectorRoles = queryRoles.ExecuteReader();

                    // Con el ID_Rol, el Nombre y el Habilitado obtenidos creamos un nuevo objeto y lo agregamos a la colección de la clase
                    Rol nuevoRol = new Rol(lectorRolesUsuario.GetInt32(0), lectorRoles.GetString(0), lectorRoles.GetInt32(1)); // Otro Int32 que no sabemos si esta bien
                    this.agregarRol(nuevoRol);
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
