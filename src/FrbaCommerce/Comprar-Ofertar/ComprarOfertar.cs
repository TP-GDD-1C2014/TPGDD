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
        int paginaActual;
        int cantPublicacionesPorPagina = 18; //because of reasons
        int cantPublicacionesTotal;
        int ultimaPagina;
        string filtro;
        bool filtroRubros;
        static List<Rubro> rubros = new List<Rubro>();
        
        
        public ComprarOfertar()
        {
            InitializeComponent();
            this.CenterToScreen();
            paginaActual = 0;
            filtro = "";
            filtroRubros = false;
            contarPublicaciones();
            cargarPublicaciones();
        }
        
        public void cargarPublicaciones()
        {         
           
            int desde;
            int hasta;

            if (paginaActual == 0)
            {
                desde = 0;
                hasta = cantPublicacionesPorPagina;

                if (ultimaPagina != 0)
                {
                    btnAnteriorPag.Enabled = false;
                    btnPrimerPag.Enabled = false;
                    btnSiguientePag.Enabled = true;
                    btnUltimaPag.Enabled = true;
                }
                else
                {
                    btnAnteriorPag.Enabled = false;
                    btnPrimerPag.Enabled = false;
                    btnSiguientePag.Enabled = false;
                    btnUltimaPag.Enabled = false;
                }
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

            List<Publicacion> listaPublicaciones = Publicaciones.obtenerPublicacionesPaginadas(desde, hasta, filtro, filtroRubros);

            Publicaciones_Datagrid.DataSource = listaPublicaciones;
            Publicaciones_Datagrid.Columns["ID_Vendedor"].Visible = false;
            Publicaciones_Datagrid.Columns["Cod_Publicacion"].Visible = false;
            Publicaciones_Datagrid.Columns["Estado_Publicacion"].Visible = false;
            Publicaciones_Datagrid.Columns["Permiso_Preguntas"].Visible = false;
            Publicaciones_Datagrid.Columns["Stock_Inicial"].Visible = false;
          
        }

        private void btnSiguientePag_Click(object sender, EventArgs e)
        {
            paginaActual = paginaActual + 1;
            cargarPublicaciones();

        }

        private void btnAnteriorPag_Click(object sender, EventArgs e)
        {
            
            paginaActual = paginaActual - 1;
            cargarPublicaciones();
        }

        private void btnPrimerPag_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            cargarPublicaciones();
        }

        private void btnUltimaPag_Click(object sender, EventArgs e)
        {
            paginaActual = ultimaPagina;
            cargarPublicaciones();
        }


        private void contarPublicaciones ()
        {
            string commandtext = "SELECT COUNT (*) AS cant from MERCADONEGRO.Publicaciones AS p " +
                                 "JOIN MERCADONEGRO.Estados_Publicacion ep ON ep.Cod_EstadoPublicacion = p.Cod_EstadoPublicacion ";
            if (filtroRubros)
                commandtext += "JOIN MERCADONEGRO.Rubro_Publicacion rp ON p.Cod_Publicacion = rp.Cod_Publicacion ";

            commandtext += "WHERE ep.Descripcion != 'Finalizada' ";
            
            if (filtro != "")
                commandtext += " AND " + filtro;
                    
            SqlDataReader reader = BDSQL.ejecutarReader(commandtext, BDSQL.iniciarConexion());

            if (reader.HasRows)
            {
                reader.Read();
                cantPublicacionesTotal = Convert.ToInt32(reader["cant"]);
                ultimaPagina = cantPublicacionesTotal / cantPublicacionesPorPagina;

                if (ultimaPagina < 1)
                    ultimaPagina = 0;
            }

            BDSQL.cerrarConexion();
        }

        private void btnAbrirPublicacion_Click(object sender, EventArgs e)
        {
            if (Publicaciones_Datagrid.SelectedRows.Count == 0)
                return;
            else
            {
                Publicacion unaPublicacion = Publicaciones_Datagrid.CurrentRow.DataBoundItem as Publicacion;
                DetallePublicacion detalleForm = new DetallePublicacion(unaPublicacion);
                detalleForm.ShowDialog();
                cargarPublicaciones();
            }
            
        }

        private void btnAgregarRubros_Click(object sender, EventArgs e)
        {
            AgregarRubros agregarRubros = new AgregarRubros(rubros);
            agregarRubros.ShowDialog();

            cargarTxtRubros();
            
        }

        private void cargarTxtRubros()
        {
            string str = "";

            for (int i = 0; i < rubros.Count; i++)
            {
                if (i == 0)
                    str += rubros[i].Descripcion;
                else
                    str += ", " + rubros[i].Descripcion;
            }

            txtRubros.Text = str;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            armarFiltro();
            contarPublicaciones();
            cargarPublicaciones();
        }


        private void armarFiltro()
        {
            filtro = "";
            filtroRubros = false;

            if (rubros != null)
            {
                for (int i = 0; i < rubros.Count; i++)
                {
                    filtroRubros = true;
                    
                    if (i == 0)
                        filtro += " (";
                    else filtro += " or ";

                    filtro = filtro + "rp.ID_Rubro = " + rubros[i].ID_Rubro;

                    if (i == rubros.Count - 1)
                        filtro += " ) ";
                }
            }

            if (txtDescripcion.Text != "")
            {
                if (filtro != "")
                    filtro += "AND ";
                filtro += " p.Descripcion LIKE  '%" + txtDescripcion.Text + "%' ";
            }
        }

        private void btnBorrarDescripcion_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtRubros.Text = "";
            rubros.Clear();

            paginaActual = 0;
            filtro = "";
            contarPublicaciones();
            cargarPublicaciones();

        }

    

    }
    
}
