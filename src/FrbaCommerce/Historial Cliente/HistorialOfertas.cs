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
    public partial class HistorialOfertas : Form
    {
        public SeleccionHistorial formAnterior { get; set; }
        public List<Clases.Oferta> ofertas = new List<Clases.Oferta>();
        public SqlConnection conexion { get; set; }

        public int obtenerOfertas()
        {
            int cont = 0;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", Interfaz.usuario.ID_User);
            this.conexion = BDSQL.iniciarConexion();
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerOfertas @ID_User", listaParametros, this.conexion);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cont++;
                    int idVendedor = Convert.ToInt32(lector["ID_Vendedor"]);
                    int codPublicacion = Convert.ToInt32(lector["Cod_Publicacion"]);
                    DateTime fechaOferta = Convert.ToDateTime(lector["Fecha_Oferta"].ToString());
                    int monto = Convert.ToInt32(lector["Monto_Oferta"]);
                    Clases.Oferta oferta = new Clases.Oferta(idVendedor, codPublicacion, fechaOferta, monto, this.conexion);
                    ofertas.Add(oferta);
                }
            }
            BDSQL.cerrarConexion();
            return cont;
        }

        public HistorialOfertas(SeleccionHistorial _formAnterior)
        {
            this.formAnterior = _formAnterior;
            InitializeComponent();
            obtenerOfertas();

            dgOfertas.DataSource = ofertas;
            dgOfertas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgOfertas.RowHeadersVisible = false;

            DataGridViewColumn ofertas_cPublicacion = dgOfertas.Columns[1];
            DataGridViewColumn ofertas_cFecha = dgOfertas.Columns[0];
            DataGridViewColumn ofertas_cMonto = dgOfertas.Columns[2];

            DataGridViewColumn ofertas_cExtra1 = dgOfertas.Columns[4];
            DataGridViewColumn ofertas_cExtra2 = dgOfertas.Columns[5];
            DataGridViewColumn ofertas_cExtra3 = dgOfertas.Columns[6];

            ofertas_cExtra1.Visible = false;
            ofertas_cExtra2.Visible = false;
            ofertas_cExtra3.Visible = false;

            DataGridViewButtonColumn ofertas_cVerPublicacion = new DataGridViewButtonColumn();

            dgOfertas.Columns.Add(ofertas_cVerPublicacion);
            ofertas_cVerPublicacion.HeaderText = "Publicación";
            ofertas_cVerPublicacion.Text = "Mostrar";
            ofertas_cVerPublicacion.Name = "btn1";
            ofertas_cVerPublicacion.Width = 115;
            ofertas_cVerPublicacion.UseColumnTextForButtonValue = true;
            ofertas_cVerPublicacion.Resizable = DataGridViewTriState.False;

            ofertas_cPublicacion.Visible = false;

            DataGridViewColumn ofertas_cConexion = dgOfertas.Columns[3];
            ofertas_cConexion.Visible = false;

            ofertas_cPublicacion.Resizable = DataGridViewTriState.False;
            ofertas_cFecha.Resizable = DataGridViewTriState.False;
            ofertas_cMonto.Resizable = DataGridViewTriState.False;

            ofertas_cFecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ofertas_cMonto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ofertas_cPublicacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ofertas_cPublicacion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ofertas_cFecha.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ofertas_cMonto.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            ofertas_cPublicacion.Width = 245;
            ofertas_cFecha.Width = 70;
            ofertas_cMonto.Width = 365;
        }

        private void HistorialOfertas_Load(object sender, EventArgs e)
        {

        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            formAnterior.Show();
        }

        private void dgOfertas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                VerPublicacion formP1 = new VerPublicacion(Convert.ToInt32(dgOfertas.Rows[e.RowIndex].Cells[2].Value));
                formP1.Show();
            }
        }
    }
}
