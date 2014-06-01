using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using FrbaCommerce.Clases;
using System.Data.SqlClient;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class ComprarOfertar : Form
    {
        static int paginaActual;
        static int cantPublicacionesPorPagina = 30;
        static int cantPublicacionesTotal;
        static int ultimaPagina;
        
        public ComprarOfertar()
        {
            InitializeComponent();
            paginaActual = 0;
            contarPublicaciones();
            cargarPublicaciones(paginaActual);
        }

        public void cargarPublicaciones(int paginaActual)
        {
            Common.Interfaz.limpiarInterfaz(this);

            int desde;
            int hasta;

            if (paginaActual == 0)
            {
                desde = 0;
                hasta = cantPublicacionesPorPagina;

                btnAnteriorPag.Enabled = false;
                btnPrimerPag.Enabled = false;
                btnSiguientePag.Enabled = true;
                btnUltimaPag.Enabled = true;
            }
            else if (paginaActual == ultimaPagina)
            {
                desde = ((cantPublicacionesPorPagina * paginaActual) + 1);
                hasta = (desde + cantPublicacionesPorPagina - 1);

                btnSiguientePag.Enabled = false;
                btnUltimaPag.Enabled = false;
                btnAnteriorPag.Enabled = true;
                btnPrimerPag.Enabled = true;
            }
            else
            {
                desde = ((cantPublicacionesPorPagina * paginaActual) + 1);
                hasta = (desde + cantPublicacionesPorPagina - 1);

                btnSiguientePag.Enabled = true;
                btnUltimaPag.Enabled = true;
                btnAnteriorPag.Enabled = true;
                btnPrimerPag.Enabled = true;
            }

            List<Publicacion> listaPublicaciones = Publicaciones.obtenerPublicacionesPaginadas(desde, hasta);

            dataGridView1.DataSource = listaPublicaciones;
            dataGridView1.Columns["Cod_Publicacion"].Visible = false;
            dataGridView1.Columns["Estado_Publicacion"].Visible = false;
            dataGridView1.Columns["Permiso_Preguntas"].Visible = false;
            dataGridView1.Columns["Stock_Inicial"].Visible = false;
            
          
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                int filtro = Convert.ToInt32(textBox3.Text);
                cargarPublicaciones(paginaActual, filtro);
            }
            else cargarPublicaciones(paginaActual);
        }


        public void cargarPublicaciones(int paginaActual, int filtro)
        {
            Common.Interfaz.limpiarInterfaz(this);

            int desde;
            int hasta;

            if (paginaActual == 0)
            {
                desde = 0;
                hasta = cantPublicacionesPorPagina;

                btnAnteriorPag.Enabled = false;
                btnPrimerPag.Enabled = false;
                btnSiguientePag.Enabled = true;
                btnUltimaPag.Enabled = true;
            }
            else if (paginaActual == ultimaPagina)
            {
                desde = ((cantPublicacionesPorPagina * paginaActual) + 1);
                hasta = (desde + cantPublicacionesPorPagina);

                btnSiguientePag.Enabled = false;
                btnUltimaPag.Enabled = false;
                btnAnteriorPag.Enabled = true;
                btnPrimerPag.Enabled = true;
            }
            else
            {
                desde = ((cantPublicacionesPorPagina * paginaActual) + 1);
                hasta = (desde + cantPublicacionesPorPagina);

                btnSiguientePag.Enabled = true;
                btnUltimaPag.Enabled = true;
                btnAnteriorPag.Enabled = true;
                btnPrimerPag.Enabled = true;
            }
            

           

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@desde", desde);
            BDSQL.agregarParametro(listaParametros, "@hasta", hasta);
            BDSQL.agregarParametro(listaParametros, "@filtro", filtro);

        
            String commandtext = "WITH NumberedMyTable AS (SELECT Cod_Publicacion, Stock, ROW_NUMBER() OVER (ORDER BY Cod_Visibilidad) AS RowNumber " +
            "FROM MERCADONEGRO.Publicaciones WHERE Stock = @filtro AND Estado_Publicacion = 0 AND Stock > 0 AND Fecha_Vencimiento < GETUTCDATE() ) SELECT Cod_Publicacion,Stock FROM NumberedMyTable " +
            "WHERE RowNumber BETWEEN @cant AND @desde";
            DataTable ret = BDSQL.obtenerDataTable(commandtext, "T", listaParametros);

            dataGridView1.DataSource = ret;
            BDSQL.cerrarConexion();

        }

        private void btnSiguientePag_Click(object sender, EventArgs e)
        {
            paginaActual = paginaActual + 1;
            cargarPublicaciones(paginaActual);
        }

        private void btnAnteriorPag_Click(object sender, EventArgs e)
        {
            
            paginaActual = paginaActual - 1;
            cargarPublicaciones(paginaActual);
        }

        private void btnPrimerPag_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            cargarPublicaciones(paginaActual);
        }

        private void btnUltimaPag_Click(object sender, EventArgs e)
        {
            paginaActual = ultimaPagina;
            cargarPublicaciones(paginaActual);
        }


        private void contarPublicaciones ()
        {
            SqlDataReader reader = BDSQL.ejecutarReader("select COUNT (*) AS cant from MERCADONEGRO.Publicaciones", BDSQL.iniciarConexion());

            if (reader.HasRows)
            {
                reader.Read();
                cantPublicacionesTotal = Convert.ToInt32(reader["cant"]);
                ultimaPagina = cantPublicacionesTotal / cantPublicacionesPorPagina;
            }

            BDSQL.cerrarConexion();
        }

        private void btnAbrirPublicacion_Click(object sender, EventArgs e)
        {

        }
            


    }
    
}
