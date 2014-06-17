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
    public partial class HistorialSubastas : Form
    {
        public SeleccionHistorial formAnterior { get; set; }
        public List<Clases.Compra> ofertasGanadas = new List<Clases.Compra>();
        public SqlConnection conexion { get; set; }
        public int paginaActual { get; set; }

        public int obtenerOfertasGanadas(int pagina)
        {
            int cont = 0;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", Interfaz.usuario.ID_User);
            BDSQL.agregarParametro(listaParametros, "@Pagina", pagina);
            this.conexion = BDSQL.iniciarConexion();
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.pObtenerOfertasGanadas @Pagina, @ID_User", listaParametros, this.conexion);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cont++;
                    int idVendedor = Convert.ToInt32(lector["ID_Vendedor"]);
                    int codPublicacion = Convert.ToInt32(lector["Cod_Publicacion"]);
                    Clases.Calificacion calificacion;

                    if (lector["Cod_Calificacion"] != DBNull.Value)
                    {
                        calificacion = obtenerCalificacion(Convert.ToInt32(lector["Cod_Calificacion"]));
                    }
                    else
                    {
                        calificacion = null;
                    }

                    DateTime fechaOperacion = Convert.ToDateTime(lector["Fecha_Operacion"].ToString());
                    Clases.Compra ofertaGanada = new Clases.Compra(idVendedor, codPublicacion, calificacion, fechaOperacion, this.conexion);
                    ofertasGanadas.Add(ofertaGanada);
                }
            }
            BDSQL.cerrarConexion();
            return cont;
        }

        public HistorialSubastas(SeleccionHistorial _formAnterior)
        {
            this.formAnterior = _formAnterior;
            this.paginaActual = 1;

            InitializeComponent();
            this.CenterToScreen();

            pAnterior.Enabled = false;

            if (obtenerOfertasGanadas(paginaActual) <= 9)
            {
                pSiguiente.Enabled = false;
            }
            else
            {
                pSiguiente.Enabled = true;
            }

            dgSubastasGanadas.DataSource = ofertasGanadas;
            formateo();
        }

        public Clases.Calificacion obtenerCalificacion(int codCalificacion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Cod_Calificacion", codCalificacion);
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerCalificacion @Cod_Calificacion", listaParametros, this.conexion);
            lector.Read();
            Clases.Calificacion calificacion = new Clases.Calificacion(Convert.ToInt32(lector["Puntaje"]), Convert.ToString(lector["Descripcion"]));
            return calificacion;
        }

        private void HistorialSubastas_Load(object sender, EventArgs e)
        {

        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            formAnterior.Show();
        }

        private void dgSubastasGanadas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                VerPublicacion formP1 = new VerPublicacion(Convert.ToInt32(dgSubastasGanadas.Rows[e.RowIndex].Cells[2].Value));
                formP1.Show();
            }
        }

        public void reformateo()
        {
            dgSubastasGanadas.Columns[2].Visible = false;
            dgSubastasGanadas.Columns[5].Visible = false;
            dgSubastasGanadas.Columns[6].Visible = false;
            dgSubastasGanadas.Columns[7].Visible = false;
            dgSubastasGanadas.Columns[8].Visible = false;
            dgSubastasGanadas.Columns[9].Visible = false;
            dgSubastasGanadas.Columns[10].Visible = false;
            dgSubastasGanadas.Columns[11].Visible = false;

            DataGridViewColumn compras_cBoton = dgSubastasGanadas.Columns[0];
            DataGridViewColumn compras_cFecha = dgSubastasGanadas.Columns[1];
            DataGridViewColumn compras_cCalificacion = dgSubastasGanadas.Columns[3];
            DataGridViewColumn compras_cComentarios = dgSubastasGanadas.Columns[4];

            compras_cBoton.DisplayIndex = 4;
            compras_cFecha.DisplayIndex = 0;
            compras_cCalificacion.DisplayIndex = 1;
            compras_cComentarios.DisplayIndex = 3;

            compras_cFecha.Resizable = DataGridViewTriState.False;
            compras_cCalificacion.Resizable = DataGridViewTriState.False;
            compras_cComentarios.Resizable = DataGridViewTriState.False;

            compras_cFecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            compras_cCalificacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            compras_cComentarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            compras_cFecha.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            compras_cCalificacion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            compras_cComentarios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            compras_cFecha.Width = 70;
            compras_cCalificacion.Width = 70;
            compras_cComentarios.Width = 311;
        }

        public void formateo()
        {
            dgSubastasGanadas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgSubastasGanadas.RowHeadersVisible = false;

            DataGridViewColumn ofertasGanadas_cPublicacion = dgSubastasGanadas.Columns[1];
            DataGridViewColumn ofertasGanadas_cFecha = dgSubastasGanadas.Columns[0];
            DataGridViewColumn ofertasGanadas_cCalificacion = dgSubastasGanadas.Columns[2];
            DataGridViewColumn ofertasGanadas_cComentarios = dgSubastasGanadas.Columns[3];

            DataGridViewColumn ofertasGanadas_cExtra1 = dgSubastasGanadas.Columns[5];
            DataGridViewColumn ofertasGanadas_cExtra2 = dgSubastasGanadas.Columns[6];
            DataGridViewColumn ofertasGanadas_cExtra3 = dgSubastasGanadas.Columns[7];
            DataGridViewColumn ofertasGanadas_cExtra4 = dgSubastasGanadas.Columns[8];
            DataGridViewColumn ofertasGanadas_cExtra5 = dgSubastasGanadas.Columns[9];
            DataGridViewColumn ofertasGanadas_cExtra6 = dgSubastasGanadas.Columns[10];

            ofertasGanadas_cExtra1.Visible = false;
            ofertasGanadas_cExtra2.Visible = false;
            ofertasGanadas_cExtra3.Visible = false;
            ofertasGanadas_cExtra4.Visible = false;
            ofertasGanadas_cExtra5.Visible = false;
            ofertasGanadas_cExtra6.Visible = false;

            DataGridViewButtonColumn ofertasGanadas_cVerPublicacion = new DataGridViewButtonColumn();

            dgSubastasGanadas.Columns.Add(ofertasGanadas_cVerPublicacion);
            ofertasGanadas_cVerPublicacion.HeaderText = "Publicación";
            ofertasGanadas_cVerPublicacion.Text = "Mostrar";
            ofertasGanadas_cVerPublicacion.Name = "btn1";
            ofertasGanadas_cVerPublicacion.Width = 115;
            ofertasGanadas_cVerPublicacion.UseColumnTextForButtonValue = true;
            ofertasGanadas_cVerPublicacion.Resizable = DataGridViewTriState.False;

            ofertasGanadas_cPublicacion.Visible = false;

            DataGridViewColumn ofertasGanadas_cConexion = dgSubastasGanadas.Columns[4];
            ofertasGanadas_cConexion.Visible = false;

            ofertasGanadas_cPublicacion.Resizable = DataGridViewTriState.False;
            ofertasGanadas_cFecha.Resizable = DataGridViewTriState.False;
            ofertasGanadas_cCalificacion.Resizable = DataGridViewTriState.False;
            ofertasGanadas_cComentarios.Resizable = DataGridViewTriState.False;

            ofertasGanadas_cFecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ofertasGanadas_cCalificacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ofertasGanadas_cPublicacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ofertasGanadas_cComentarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ofertasGanadas_cPublicacion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ofertasGanadas_cFecha.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ofertasGanadas_cCalificacion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ofertasGanadas_cComentarios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            ofertasGanadas_cPublicacion.Width = 70;
            ofertasGanadas_cFecha.Width = 70;
            ofertasGanadas_cCalificacion.Width = 70;
            ofertasGanadas_cComentarios.Width = 311;
        }

        private void pSiguiente_Click_1(object sender, EventArgs e)
        {
            this.paginaActual++;

            dgSubastasGanadas.DataSource = null;
            ofertasGanadas.Clear();

            pAnterior.Enabled = true;

            if (obtenerOfertasGanadas(paginaActual) <= 9)
            {
                pSiguiente.Enabled = false;
            }
            else
            {
                pSiguiente.Enabled = true;
            }

            dgSubastasGanadas.DataSource = ofertasGanadas;
            reformateo();
        }

        private void pAnterior_Click_1(object sender, EventArgs e)
        {
            this.paginaActual--;

            dgSubastasGanadas.DataSource = null;
            ofertasGanadas.Clear();

            pSiguiente.Enabled = true;
            obtenerOfertasGanadas(paginaActual);

            if (this.paginaActual == 1)
            {
                pAnterior.Enabled = false;
            }

            dgSubastasGanadas.DataSource = ofertasGanadas;
            reformateo();
        }
    }
}
