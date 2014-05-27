using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//Hace referencia a la carpeta "Login", en donde se ubica la form LoginForm
using FrbaCommerce.Login;

namespace FrbaCommerce
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

        }
    }
}
