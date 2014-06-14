﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    public class Operacion
    {
        public int ID_Operacion { get; set; }
        public int ID_Vendedor { get; set; }
        public int ID_Comprador { get; set; }
        public int Cod_Publicacion { get; set; }
        public int Tipo_Operacion { get; set; } // 0: COMPRA, 1: SUBASTA GANADA, 2: OFERTA
        public int Cod_Calificacion { get; set; }
        public DateTime Fecha_Operacion { get; set; }
        public int Operacion_Facturada { get; set; }

        public Operacion(int idOperacion, int idVendedor, int idComprador, int codPublicacion, int tipoOperacion, int codCalificacion, DateTime fechaOperacion, int operacionFacturada)
        {
            this.ID_Comprador = idOperacion;
            this.ID_Vendedor = idVendedor;
            this.ID_Comprador = idComprador;
            this.Cod_Publicacion = codPublicacion;
            this.Tipo_Operacion = tipoOperacion;
            this.Fecha_Operacion = fechaOperacion;
            this.Operacion_Facturada = operacionFacturada;
            this.Cod_Calificacion = codCalificacion;
        }

        public static void facturarOperacion(int idOperacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            BDSQL.agregarParametro(parametros, "@idOperacion", idOperacion);

            string commandText = "UPDATE MERCADONEGRO.Operaciones SET Operacion_Facturada = 1 WHERE ID_Operacion = @idOperacion";

            BDSQL.ejecutarQuery(commandText, parametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();

        }

    }
}
