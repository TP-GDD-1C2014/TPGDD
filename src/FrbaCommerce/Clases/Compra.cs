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
        public DateTime Fecha_Operacion { get; set; }

        public int Calificacion_Puntaje { get; set; }
        public string Calificacion_Descripcion { get; set; }

        public Compra(int idOperacion, int idVendedor, int codPublicacion, Clases.Calificacion calificacion, DateTime fechaOperacion)
        {
            ID_Operacion = idOperacion;
            ID_Vendedor = idVendedor;
            Cod_Publicacion = codPublicacion;
            Fecha_Operacion = fechaOperacion;
            if (calificacion != null)
            {
                Calificacion_Puntaje = calificacion.Puntaje;
                Calificacion_Descripcion = calificacion.Descripcion;
            }
            else
            {
                Calificacion_Puntaje = -1;
                Calificacion_Descripcion = "Sin calificar";
            }
        }
    }
}
