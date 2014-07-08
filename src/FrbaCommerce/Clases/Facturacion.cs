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
        
        public string forma_Pago { get; set; }
        public float Total_Facturacion { get; set; }

        public Facturacion(string formaPago)
        {
            this.forma_Pago = formaPago;

        }

        public Facturacion()
        {
        }


        public DataTable obtenerCompras(Usuario usuario)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            if (usuario.esAdmin())
            {
                //buscar todas las ventas sin rendir, tal que los users esten inhabilitados y las ventas_sin_Rendir > 10
                string commandText = "SELECT * FROM MERCADONEGRO.ComprasSinFacturar";

                return BDSQL.obtenerDataTable(commandText, "T");

            }
            else
            {

                BDSQL.agregarParametro(listaParametros, "@username", usuario.Username);

                return BDSQL.obtenerDataTable("MERCADONEGRO.ObtenerComprasSinFacturar", "SP", listaParametros);
            }

        }

        public int crearFactura()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();


            BDSQL.agregarParametro(listaParametros, "@formaDePago", this.forma_Pago);
            BDSQL.agregarParametro(listaParametros, "@fechaFactura", Interfaz.obtenerFecha());
            SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
            paramRet.Direction = System.Data.ParameterDirection.Output;
            listaParametros.Add(paramRet);



            int idInsertada = (int)BDSQL.ExecStoredProcedure("MERCADONEGRO.crearFactura", listaParametros);
            BDSQL.cerrarConexion();

            return idInsertada;
        }

        public bool noExiste(int idFactura, int codigoPublicacion)
        {
            bool existe = false;

            existe = BDSQL.existeFactura(idFactura, codigoPublicacion);

            return existe;
        }

        public void insertarAsociativa(int idFactura, int codigoPublicacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@idFactura", idFactura);
            BDSQL.agregarParametro(listaParametros, "@codPublicacion", codigoPublicacion);

            string commandText = "INSERT INTO MERCADONEGRO.Factura_Publicacion(Nro_Factura, Cod_Publicacion) " +
                                    "VALUES(@idFactura, @codPublicacion)";

            BDSQL.ejecutarQuery(commandText, listaParametros, BDSQL.iniciarConexion());

            BDSQL.cerrarConexion();
                

        }



    }
}
