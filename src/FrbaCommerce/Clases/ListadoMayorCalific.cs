﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    class ListadoMayorCalific{
    
        public string username { get; set; }
        public float reputacion { get; set; }
        public int anio { get; set; }
        public int mesMinimo { get; set; }
        public int mesMaximo { get; set; }


        public ListadoMayorCalific(int trimestreMinimo, int anio)
        {
            this.anio = anio;
            this.mesMinimo = trimestreMinimo;
            this.mesMaximo = trimestreMinimo + 2;
        }


         public DataTable obtenerListado()
         {
             List<SqlParameter> listaParametros = new List<SqlParameter>();
             BDSQL.agregarParametro(listaParametros, "@Año", this.anio);
             BDSQL.agregarParametro(listaParametros, "@mesMinimo", this.mesMinimo);
             BDSQL.agregarParametro(listaParametros, "@mesMaximo", this.mesMaximo);


             String commandtext = "SELECT TOP(5) Vendedor, AVG(Puntaje) AS Reputacion " +
                                                                 "FROM MERCADONEGRO.MayorReputacionView " +
                                                                 "WHERE Mes BETWEEN @mesMinimo AND @mesMaximo AND Año = @año " +
                                                                 "GROUP BY Vendedor " +
                                                                 "ORDER BY Reputacion DESC";

             return BDSQL.obtenerDataTable(commandtext, "T", listaParametros);

         }



    }
}
