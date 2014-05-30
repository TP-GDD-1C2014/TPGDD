using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Clases
{
    public class Compra
    {
        public int ID_Operacion { get; set; }
        public int ID_Vendedor { get; set; }
        public int Cod_Publicacion { get; set; }
        public Clases.Calificacion Calificacion { get; set; }
        public DateTime Fecha_Operacion { get; set; }

        public Compra(int idOperacion, int idVendedor, int codPublicacion, Clases.Calificacion codCalificacion, DateTime fechaOperacion)
        {
            ID_Operacion = idOperacion;
            ID_Vendedor = idVendedor;
            Cod_Publicacion = codPublicacion;
            Calificacion = codCalificacion;
            Fecha_Operacion = fechaOperacion;
        }
    }
}
