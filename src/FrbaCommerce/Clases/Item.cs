using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    class Item
    {
        public int Cod_Publicacion { get; set; }
        public int ID_Facturacion { get; set; }
        public int Cantidad_Vendida { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio_Unitario { get; set; }

    public void InsertarItem(int idFactura)
    {
        List<SqlParameter> parametros = new List<SqlParameter>();

        BDSQL.agregarParametro(parametros, "@codPublicacion", this.Cod_Publicacion);
        BDSQL.agregarParametro(parametros, "@idFactura", idFactura);
        BDSQL.agregarParametro(parametros, "@cantidadVendida", this.Cantidad_Vendida);
        BDSQL.agregarParametro(parametros, "@descripcion", this.Descripcion);
        BDSQL.agregarParametro(parametros, "@precioItem", this.Precio_Unitario);

        BDSQL.ExecStoredProcedureSinRet("MERCADONEGRO.InsertarItem", parametros);
        BDSQL.cerrarConexion();

    }



    }

   
}
