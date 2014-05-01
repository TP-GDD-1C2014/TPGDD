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




    }
}
