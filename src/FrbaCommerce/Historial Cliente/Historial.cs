using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
            obtenerCompras();
            obtenerOfertas();
        }

        private class Compra
        {
            public int ID_Operacion { get; set; }
            public int ID_Vendedor { get; set; }
            public int ID_Comprador { get; set; }
            public int Cod_Publicacion { get; set; }
            public Clases.Calificacion Calificacion { get; set; }
            public DateTime Fecha_Operacion { get; set; }

            public Compra(int id, int idVendedor, int idComprador, int codPublicacion, Clases.Calificacion calif, DateTime fecha)
            {
                ID_Operacion = id;
                ID_Vendedor = idVendedor;
                ID_Comprador = idComprador;
                Cod_Publicacion = codPublicacion;
                Calificacion = calif;
                Fecha_Operacion = fecha;
            }
        }

        private class Oferta
        {
            public int ID_Operacion { get; set; }
            public int ID_Vendedor { get; set; }
            public int ID_Comprador { get; set; }
            public int Cod_Publicacion { get; set; }
            public Clases.Calificacion Calificacion { get; set; }
            public DateTime Fecha_Operacion { get; set; }
            public Boolean Subasta_Ganada { get; set; }

            public Oferta(int id, int idVendedor, int idComprador, int codPublicacion, Clases.Calificacion calif, DateTime fecha, Boolean subastaGanada)
            {
                ID_Operacion = id;
                ID_Vendedor = idVendedor;
                ID_Comprador = idComprador;
                Cod_Publicacion = codPublicacion;
                Calificacion = calif;
                Fecha_Operacion = fecha;
                Subasta_Ganada = subastaGanada;
            }
        }



        public List<Compra> compras = new List<Compra>();
        public List<Oferta> ofertas = new List<Oferta>();

        public Boolean ganoSubasta(int codPublicacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", Interfaz.usuario.ID_User);
            BDSQL.agregarParametro(listaParametros, "@Cod_Publicacion", codPublicacion);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Tipo_Operacion FROM MERCADONEGRO.Operaciones WHERE Tipo_Operacion = 2 AND Cod_Publicacion = @Cod_Publicacion AND ID_Comprador = @ID_User", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                BDSQL.cerrarConexion();
                return true;
            }
            else
            {
                BDSQL.cerrarConexion();
                return false;
            }
        }

        public Clases.Calificacion obtenerCalificacion(int codCalificacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Calificacion", codCalificacion);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT * FROM MERCADONEGRO.Calificaciones WHERE Cod_Calificacion = @Cod_Calificacion", listaParametros, BDSQL.iniciarConexion());
            lector.Read();
            return new Clases.Calificacion(Convert.ToInt32(lector["Puntaje"]), Convert.ToString(lector["Descripcion"]));
        }

        public int obtenerCompras()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", Interfaz.usuario.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_Operacion, ID_Vendedor, ID_Comprador, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion FROM MERCADONEGRO.Operaciones WHERE ID_Comprador = @ID_User AND Tipo_Operacion = 0", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                int cant = 0;
                while (lector.Read())
                {
                    if (lector["Cod_Calificacion"] != DBNull.Value)
                    {
                        compras.Add(new Compra(Convert.ToInt32(lector["ID_Operacion"]), Convert.ToInt32(lector["ID_Vendedor"]), Convert.ToInt32(lector["ID_Comprador"]), Convert.ToInt32(lector["Cod_Publicacion"]), obtenerCalificacion(Convert.ToInt32(lector["Cod_Calificacion"])), Convert.ToDateTime(lector["Fecha_Operacion"].ToString())));
                    }
                    else
                    {
                        compras.Add(new Compra(Convert.ToInt32(lector["ID_Operacion"]), Convert.ToInt32(lector["ID_Vendedor"]), Convert.ToInt32(lector["ID_Comprador"]), Convert.ToInt32(lector["Cod_Publicacion"]), null, Convert.ToDateTime(lector["Fecha_Operacion"].ToString())));
                    }
                    cant++;
                }
                BDSQL.cerrarConexion();
                return cant;
            }
            else
            {
                BDSQL.cerrarConexion();
                return 0;
            }
        }

        public int obtenerOfertas()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", Interfaz.usuario.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_Operacion, ID_Vendedor, ID_Comprador, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion FROM MERCADONEGRO.Operaciones WHERE ID_Comprador = @ID_User AND Tipo_Operacion = 1", listaParametros, BDSQL.iniciarConexion());
            if (lector.HasRows)
            {
                int cant = 0;
                while (lector.Read())
                {
                    Boolean r_ganoSubasta;
                    if ((r_ganoSubasta = ganoSubasta(Convert.ToInt32(lector["Cod_Publicacion"]))) && (lector["Cod_Calificacion"] != DBNull.Value))
                    {
                        ofertas.Add(new Oferta(Convert.ToInt32(lector["ID_Operacion"]), Convert.ToInt32(lector["ID_Vendedor"]), Convert.ToInt32(lector["ID_Comprador"]), Convert.ToInt32(lector["Cod_Publicacion"]), obtenerCalificacion(Convert.ToInt32(lector["Cod_Calificacion"])), Convert.ToDateTime(lector["Fecha_Operacion"].ToString()), r_ganoSubasta));
                    }
                    else
                    {
                        ofertas.Add(new Oferta(Convert.ToInt32(lector["ID_Operacion"]), Convert.ToInt32(lector["ID_Vendedor"]), Convert.ToInt32(lector["ID_Comprador"]), Convert.ToInt32(lector["Cod_Publicacion"]), null, Convert.ToDateTime(lector["Fecha_Operacion"].ToString()), r_ganoSubasta));
                    }
                    cant++;
                }
                BDSQL.cerrarConexion();
                return cant;
            }
            else
            {
                BDSQL.cerrarConexion();
                return 0;
            }
        }
    }
}
