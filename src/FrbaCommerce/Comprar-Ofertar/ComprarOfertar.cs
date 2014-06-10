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
        int cantPublicacionesPorPagina = 18;
        int cantPublicacionesTotal;
        int ultimaPagina;
        string filtro;
        bool filtroRubros;
        static List<Rubro> rubros = new List<Rubro>();
        
        
        public ComprarOfertar()
        {
            InitializeComponent();
            paginaActual = 0;
            filtro = "";
            filtroRubros = false;
            contarPublicaciones();
            cargarPublicaciones();

            //cmbRubros.DisplayMember = "Descripcion";
            //cmbRubros.ValueMember = "ID_Rubro";
        }

        public class itemComboBox
        {
            public string Nombre_Rubro { get; set; }
            public int ID_Rubro { get; set; }

            public itemComboBox(string nombre, int id)
            {
                Nombre_Rubro = nombre;
                ID_Rubro = id;
            }
            public override string ToString()
            {
                return Nombre_Rubro;
            }
        }
        
        public void cargarPublicaciones()
        {
            
            //Common.Interfaz.limpiarInterfaz(this);
            actualizarDisplay();

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

            List<Publicacion> listaPublicaciones = Publicaciones.obtenerPublicacionesPaginadas(desde, hasta, filtro, filtroRubros);

            Publicaciones_Datagrid.DataSource = listaPublicaciones;
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
            string commandtext = "select COUNT (*) AS cant from MERCADONEGRO.Publicaciones as p JOIN MERCADONEGRO.Rubro_Publicacion rp ON p.Cod_Publicacion=rp.Cod_Publicacion ";

            if (filtro != "")
                commandtext += " WHERE " + filtro;
            
            SqlDataReader reader = BDSQL.ejecutarReader(commandtext, BDSQL.iniciarConexion());

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
            if (Publicaciones_Datagrid.SelectedRows.Count == 0)
                return;
            else
            {
                Publicacion unaPublicacion = Publicaciones_Datagrid.CurrentRow.DataBoundItem as Publicacion;
                DetallePublicacion detalleForm = new DetallePublicacion(unaPublicacion);
                detalleForm.ShowDialog();
                cargarPublicaciones();
            }
            

            //cargarTodosLosRoles(); actualizar
        }

        private void btnAgregarRubros_Click(object sender, EventArgs e)
        {
            AgregarRubros agregarRubros = new AgregarRubros(rubros);
            agregarRubros.ShowDialog();


            //borrarComboRubros();
            cmbRubros.Items.Clear();
            cargarComboRubros();
            
        }

        private void cargarComboRubros()
        {
            for (int i = 0; i < rubros.Count; i++)
            {
                cmbRubros.Items.Add(new itemComboBox(rubros[i].Descripcion.ToString(), rubros[i].ID_Rubro));
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
            cmbRubros.Items.Clear();
            rubros.Clear();
            cargarPublicaciones();

        }

        private void actualizarDisplay()
        {
            txtCantPublicaciones.Text = Convert.ToString(cantPublicacionesTotal );
            txtPaginaActual.Text = Convert.ToString(paginaActual + 1);
        }



        /*
        private void borrarComboRubros()
        {
            for (int i = 0; i < cmbRubros.Items.Count; i++)
            {
                cmbRubros.Items.RemoveAt(i);
            }
        }
         * */

      


            


    }
    
}
