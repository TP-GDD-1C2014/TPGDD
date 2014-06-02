using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using FrbaCommerce.Clases;
using System.Data.SqlClient;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class DatosVendedor : Form
    {
        public static string vendedor;
        
        public DatosVendedor(int idVendedor)
        {
            InitializeComponent();

            SqlDataReader lector = Compra.clienteEmpresa(idVendedor);

            if (vendedor == "Cliente")
            {
                textBox9.Text = "Cliente";
            }
            else textBox9.Text = "Empresa";

            //test, aca se debera usar el lector antes de cerrar
            BDSQL.cerrarConexion();


        }
    }
}
