using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Clases
{
    class Facturacion
    {
        public int Cod_Publicacion { get; set; }
        public string forma_Pago { get; set; }
        public float Total_Facturacion { get; set; }

        public Facturacion(int codPublicacion, string formaPago)
        {
            this.Cod_Publicacion = codPublicacion;
            this.forma_Pago = formaPago;

        }

        public Facturacion()
        {
        }


        public DataTable obtenerOperaciones(Usuario usuario)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            if (usuario.esAdmin())
            {
                //buscar todas las ventas sin rendir, tal que los users esten inhabilitados y las ventas_sin_Rendir > 10
                string commandText = "SELECT * FROM MERCADONEGRO.OperacionesSinFacturar";

                return BDSQL.obtenerDataTable(commandText, "T");

            }
            else
            {

                BDSQL.agregarParametro(listaParametros, "@username", usuario.Username);

                return BDSQL.obtenerDataTable("MERCADONEGRO.ObtenerOperacionesSinFacturar", "SP", listaParametros);
            }

        }

        public int crearFactura()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            BDSQL.agregarParametro(listaParametros, "@codPublicacion", this.Cod_Publicacion);
            BDSQL.agregarParametro(listaParametros, "@formaDePago", this.forma_Pago);
            BDSQL.agregarParametro(listaParametros, "@fechaFactura", Interfaz.obtenerFecha());
            SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
            paramRet.Direction = System.Data.ParameterDirection.Output;
            listaParametros.Add(paramRet);



            int idInsertada = (int)BDSQL.ExecStoredProcedure("MERCADONEGRO.crearFactura", listaParametros);
            BDSQL.cerrarConexion();

            return idInsertada;
        }

    }
}
