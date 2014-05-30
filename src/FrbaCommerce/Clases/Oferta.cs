using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    public class Oferta
    {
        public int ID_Subasta { get; set; }
        public int ID_Vendedor { get; set; }
        public string Publicacion { get; set; }
        public DateTime Fecha_Oferta { get; set; }
        public string Subasta_Ganada { get; set; }

        public Oferta(int idSubasta, int idVendedor, int codPublicacion, DateTime fechaOferta, Boolean subastaGanada)
        {
            ID_Subasta = idSubasta;
            ID_Vendedor = idVendedor;
            Publicacion = obtenerPublicacion(codPublicacion);
            Fecha_Oferta = fechaOferta;
            if (subastaGanada)
            {
                Subasta_Ganada = "Sí";
            }
            else
            {
                Subasta_Ganada = "No";
            }
        }

        public string obtenerPublicacion(int codPublicacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", codPublicacion);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Descripcion FROM MERCADONEGRO.Publicaciones WHERE Cod_Publicacion = @Cod_Publicacion", listaParametros, BDSQL.iniciarConexion());
            lector.Read();
            string res = Convert.ToString(lector["Descripcion"]);
            BDSQL.cerrarConexion();
            return res;
        }
    }
}
