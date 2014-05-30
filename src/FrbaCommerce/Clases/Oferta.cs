using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    public class Oferta
    {
        public int ID_Subasta { get; set; }
        public int ID_Vendedor { get; set; }
        public int Cod_Publicacion { get; set; }
        public DateTime Fecha_Oferta { get; set; }
        public string Subasta_Ganada { get; set; }

        public Oferta(int idSubasta, int idVendedor, int codPublicacion, DateTime fechaOferta, Boolean subastaGanada)
        {
            ID_Subasta = idSubasta;
            ID_Vendedor = idVendedor;
            Cod_Publicacion = codPublicacion;
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
    }
}
