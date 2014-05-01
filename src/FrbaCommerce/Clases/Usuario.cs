using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    public class Usuario
    {
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
            //verificar contraseña con la base de datos

            //dummy
            return true;
        }

        public void ResetearIntentosFallidos()
        {
            //ir a la base de datos y resetear en 0 el campo Intentos_Login
        }

        public void sumarIntentoFallido()
        {
            // sumar + 1 Intentos_Login
        }

    }
}
