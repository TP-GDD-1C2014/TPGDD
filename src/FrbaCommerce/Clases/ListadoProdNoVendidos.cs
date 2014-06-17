using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    class ListadoProdNoVendidos
    {
        public int anio { get; set; }
        public int mesMinimo { get; set; }
        public int mesMaximo { get; set; }
        public string tipoVisibilidad { get; set; }
        public string mes { get; set; }

        public ListadoProdNoVendidos(int trimestreMinimo, int anio, string tipoVisibilidad, string mes)
        {
            this.anio = anio;
            this.mesMinimo = trimestreMinimo;
            this.mesMaximo = trimestreMinimo + 2;
            this.tipoVisibilidad = tipoVisibilidad;
            this.mes = mes;
        }

        public DataTable obtenerListado()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Año", this.anio);
            BDSQL.agregarParametro(listaParametros, "@mesMinimo", this.mesMinimo);
            BDSQL.agregarParametro(listaParametros, "@mesMaximo", this.mesMaximo);

            String commandtext = "SELECT TOP(5) Username, [Codigo Publicacion], Descripcion, Stock, Mes, Año " +
                                                                "FROM MERCADONEGRO.MayorCantProductosNoVendidos " +
                                                                "WHERE Mes BETWEEN @mesMinimo AND @mesMaximo AND Año = @año";

            if (tipoVisibilidad != null)
            {
                BDSQL.agregarParametro(listaParametros, "@descripcionVisibilidad", this.tipoVisibilidad);
                commandtext = commandtext + " AND Descripcion = @descripcionVisibilidad";
            }

            if (mes != null && mes != "")
            {
                
                BDSQL.agregarParametro(listaParametros, "@mes", this.mes);
                commandtext = commandtext + " AND Mes = @mes";
            }

            commandtext = commandtext + " ORDER BY Stock DESC, Jerarquia, Mes, Año";

            

            return BDSQL.obtenerDataTable(commandtext, "T", listaParametros);

        }

    }
}
