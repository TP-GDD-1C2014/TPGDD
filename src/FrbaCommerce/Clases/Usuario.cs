using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Common;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

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
        //public bool Habilitado_Compra { get; set; }

        public List<Rol> Roles = new List<Rol>(); 

        public Usuario(int id, string username, string password)
        {
            this.ID_User = id;
            this.Username = username;
            this.Password = password;
            Interfaz.loguearUsuario(this);
        }

        public Usuario()
        {
        }

        public Boolean esAdmin()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@idUser", this.ID_User);

            string commandText = "SELECT ID_Rol FROM MERCADONEGRO.Roles_Usuarios WHERE ID_User = @idUser";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", listaParametros);
            if (lector.HasRows)
            {
                lector.Read();

                int idRol = Convert.ToInt32(lector["ID_Rol"]);
                BDSQL.cerrarConexion();


                listaParametros.Clear();
                BDSQL.agregarParametro(listaParametros, "@idRol", idRol);

                commandText = "SELECT Nombre FROM MERCADONEGRO.Roles WHERE ID_ROL = @idRol";

                lector = BDSQL.ObtenerDataReader(commandText, "T", listaParametros);

                if (lector.HasRows)
                {
                    lector.Read();

                    string nombre = Convert.ToString(lector["Nombre"]);
                    BDSQL.cerrarConexion();

                    if (nombre == "Administrador General")
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }




        public Boolean obtenerPK()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Username", this.Username);
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

        public Boolean habilitado()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Habilitado FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            lector.Read();
            if (Convert.ToInt32(lector["Habilitado"]) == 1)
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

        public int cantidadVentasSinRendir()
        {
            int idUser = this.ID_User;
            int cantidadVentasSinRendir;

            List<SqlParameter> parametros = new List<SqlParameter>();

            BDSQL.agregarParametro(parametros, "@idUser", idUser);

            string commandtext = "SELECT Ventas_Sin_Rendir FROM MERCADONEGRO.Usuarios WHERE ID_USER = @idUser";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandtext, "T", parametros);

            if (lector.HasRows)
            {
                lector.Read();
                cantidadVentasSinRendir = Convert.ToInt32(lector["Ventas_Sin_Rendir"]);

                BDSQL.cerrarConexion();
                return cantidadVentasSinRendir;
            }
            else
            {
                    BDSQL.cerrarConexion();
                    return -1;
            }
        }

        public int primeraVez()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Primera_Vez FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            lector.Read();
            int pVez = Convert.ToInt32(lector["Primera_Vez"]);
            if (pVez == 0)
            {
                BDSQL.cerrarConexion();
                return pVez;
            }
            else
            {
                BDSQL.cerrarConexion();
                return pVez;
            }
        }

        public Boolean verificarContraseniaSinHash(string password)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Password FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            lector.Read();
            if (password == Convert.ToString(lector["Password"]))
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

        public Boolean verificarContrasenia()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Username", this.Username);
            BDSQL.agregarParametro(listaParametros, "@Password", this.Password);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Username, Password FROM MERCADONEGRO.Usuarios WHERE Username = @Username AND PASSWORD = @Password", listaParametros, BDSQL.iniciarConexion());
            Boolean res = lector.HasRows;
            BDSQL.cerrarConexion();
            return res;
        }

        public void ResetearIntentosFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Intentos_Login = 0 WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void sumarIntentoFallido()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Intentos_Login = (Intentos_Login+1) WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public int intentosFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Intentos_Login FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            lector.Read();
            int res = Convert.ToInt32(lector["Intentos_Login"]);
            BDSQL.cerrarConexion();
            return res;
        }

        public int cantidadIntentosFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Intentos_Login FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read();
                int resultado = Convert.ToInt32(lector["Intentos_Login"]);
                BDSQL.cerrarConexion();
                return resultado;
            }
            else
            {
                BDSQL.cerrarConexion();
                return -1;
            }
        }

        public void inhabilitarUsuario()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Habilitado = 0 WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void cambiarPassword(string nuevoPass)
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(nuevoPass));
            string password = bytesDeHasheoToString(bytesDeHasheo);

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.agregarParametro(listaParametros, "@Password", password);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Password = @Password, Primera_Vez = 0 WHERE ID_User = @ID_user", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[i].ToString("X2"));
            }
            return salida.ToString();
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
                    Rol nuevoRol = new Rol(Convert.ToInt32(lectorRolesUsuario["ID_Rol"]), lectorRoles["Nombre"].ToString(), (bool)lectorRoles["Habilitado"]);
                    nuevoRol.obtenerFuncionalidades(conexion);
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

        public void sumarPubliGratuita()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Cant_Publi_Gratuitas = (Cant_Publi_Gratuitas+1) WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void restarPubliGratuita()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Cant_Publi_Gratuitas = (Cant_Publi_Gratuitas-1) WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public static int obtenerPublisGratuitas(int ID_User)
        {
            int cantPublis = -1;

            List<SqlParameter> listaParametros1 = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros1, "@ID_User", ID_User);
            SqlConnection conexion = BDSQL.iniciarConexion();
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Cant_Publi_Gratuitas FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros1, conexion);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cantPublis = Convert.ToInt32(lector["Cant_Publi_Gratuitas"]);
                }
                BDSQL.cerrarConexion();
            }

            return cantPublis;
        }

        public static bool controlarRol(int idUser)
        {
            bool resultado = false;

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@idUser", idUser));
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_Rol FROM MERCADONEGRO.Roles_Usuarios WHERE ID_User = @idUser", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read();
                int rol = Convert.ToInt32(lector["ID_Rol"]);
                if (rol == 0)
                {
                    resultado = true;
                }
            }

            BDSQL.cerrarConexion();
            return resultado;
        }
        /*        public static List<Publicacion> obtenerPublicaciones(int idUser)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@idUser",idUser));
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Publicaciones WHERE ID_Vendedor=@idUser",listaParametros , BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {*/

        public static DataTable obtenerUsuarios()
        {
            string str = "SELECT ID_User, Username from MERCADONEGRO.Usuarios";

            DataTable dataTable = BDSQL.obtenerDataTable(str, "T");

            return dataTable;
        }

        public static string obtenerUsername(int idUser)
        {
            string username = "";

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", idUser);
            SqlConnection conexion = BDSQL.iniciarConexion();

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Username FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, conexion);
            lector.Read();

            username = Convert.ToString(lector["Username"]);

            BDSQL.cerrarConexion();
            return username;
        }

        public static bool habilitadoCompra(int idUser)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", idUser);
            SqlConnection conexion = BDSQL.iniciarConexion();

            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Habilitado_Compra FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, conexion);
            lector.Read();

            bool puedeComprar = Convert.ToBoolean(lector["Habilitado_Compra"]);

            BDSQL.cerrarConexion();
            return puedeComprar;
        }

        public static void updateHabilitadoCompra(int idUser, bool habilitadoCompra)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@idUser", idUser);
            BDSQL.agregarParametro(listaParametros, "@habilitadoCompra", habilitadoCompra);
            SqlConnection conexion = BDSQL.iniciarConexion();

            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Habilitado_Compra = @habilitadoCompra WHERE ID_User = @idUser", listaParametros, conexion);

            BDSQL.cerrarConexion();        
        }

        public static void restarVentaSinRendir(int idOperacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "idOperacion", idOperacion);

            string commandText = "SELECT ID_Vendedor FROM MERCADONEGRO.Compras WHERE ID_Compra = @idOperacion";
            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", listaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                int idVendedor = Convert.ToInt32(lector["ID_Vendedor"]);
                BDSQL.cerrarConexion();

                listaParametros.Clear();


                BDSQL.agregarParametro(listaParametros, "@idUser", idVendedor);

                commandText = "UPDATE MERCADONEGRO.Usuarios SET Ventas_Sin_Rendir = Ventas_Sin_Rendir - 1 WHERE ID_USER = @idUser";

                BDSQL.ejecutarQuery(commandText, listaParametros, BDSQL.iniciarConexion());
                BDSQL.cerrarConexion();
            }
        }

        public static void updateVentasSinRendir(Compra compra)
        {
            int idUser = compra.Vendedor;

            List<SqlParameter> listaParametros = new List<SqlParameter>();

            BDSQL.agregarParametro(listaParametros, "@idUser", idUser);

            string commandText = "UPDATE MERCADONEGRO.Usuarios SET Ventas_Sin_Rendir = Ventas_Sin_Rendir + 1 WHERE ID_USER = @idUser";

            BDSQL.ejecutarQuery(commandText, listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();

            //verifico que haya llegado a las 10
            bool puedeComprarLaProxPorVentas = Usuario.verificarCantidadVentasSinRendir(compra.Vendedor);

            if (!puedeComprarLaProxPorVentas)
            {
                //inhabilita al usuario
                Usuario usuario = new Usuario();
                usuario.ID_User = compra.Vendedor;

                usuario.inhabilitarUsuario();

                //updatea todas sus publicaciones a Pausadas
                Publicacion.pausarPublicaciones(compra.Vendedor);
            }

        }

        public static bool verificarCantidadVentasSinRendir(int idUser)
        {
            bool puedeComprar;

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@idUser", idUser);

            string commandText = "SELECT Ventas_Sin_Rendir FROM MERCADONEGRO.Usuarios WHERE ID_User = @idUser";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", listaParametros);

            lector.Read();

            int cant = Convert.ToInt32(lector["Ventas_Sin_Rendir"]);

            BDSQL.cerrarConexion();

            if (cant >= 10)
                puedeComprar = false;
            else puedeComprar = true;

            return puedeComprar;

        }

        public static int obtenerIDUser(string username)
        {
            int idUser;

            List<SqlParameter> listaParametros = new List<SqlParameter>();

            BDSQL.agregarParametro(listaParametros, "@username", username);

            string commandText = "SELECT ID_User FROM MERCADONEGRO.Usuarios WHERE Username = @username";

            SqlDataReader lector = BDSQL.ObtenerDataReader(commandText, "T", listaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                idUser = Convert.ToInt32(lector["ID_User"]);
                BDSQL.cerrarConexion();
                return idUser;
            }
            else
                return -1;
        }
    }
}