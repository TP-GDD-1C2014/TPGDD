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
    public partial class HistorialCompras : Form
    {
        public SeleccionHistorial formAnterior { get; set; }
        public List<Clases.Compra> compras = new List<Clases.Compra>();
        public SqlConnection conexion { get; set; }

        public int obtenerCompras()
        {
            int cont = 0;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", Interfaz.usuario.ID_User);
            this.conexion = BDSQL.iniciarConexion();
            SqlDataReader lector = BDSQL.ejecutarReader("EXEC MERCADONEGRO.obtenerCompras @ID_User", listaParametros, conexion);
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
                    Clases.Compra compra = new Clases.Compra(idVendedor, codPublicacion, calificacion, fechaOperacion, this.conexion);
                    compras.Add(compra);
                }
            }
            BDSQL.cerrarConexion();
            return cont;
        }

        public HistorialCompras(SeleccionHistorial _formAnterior)
        {
            this.formAnterior = _formAnterior;
            InitializeComponent();
            obtenerCompras();

            dgCompras.DataSource = compras;
            dgCompras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgCompras.RowHeadersVisible = false;

            DataGridViewColumn compras_cPublicacion = dgCompras.Columns[1];
            DataGridViewColumn compras_cFecha = dgCompras.Columns[0];
            DataGridViewColumn compras_cCalificacion = dgCompras.Columns[2];
            DataGridViewColumn compras_cComentarios = dgCompras.Columns[3];

            DataGridViewColumn compras_cExtra1 = dgCompras.Columns[5];
            DataGridViewColumn compras_cExtra2 = dgCompras.Columns[6];
            DataGridViewColumn compras_cExtra3 = dgCompras.Columns[7];
            DataGridViewColumn compras_cExtra4 = dgCompras.Columns[8];
            DataGridViewColumn compras_cExtra5 = dgCompras.Columns[9];
            DataGridViewColumn compras_cExtra6 = dgCompras.Columns[10];

            compras_cExtra1.Visible = false;
            compras_cExtra2.Visible = false;
            compras_cExtra3.Visible = false;
            compras_cExtra4.Visible = false;
            compras_cExtra5.Visible = false;
            compras_cExtra6.Visible = false;

            DataGridViewButtonColumn compras_cVerPublicacion = new DataGridViewButtonColumn();

            dgCompras.Columns.Add(compras_cVerPublicacion);
            compras_cVerPublicacion.HeaderText = "Publicación";
            compras_cVerPublicacion.Text = "Mostrar";
            compras_cVerPublicacion.Name = "btn";
            compras_cVerPublicacion.Width = 115;
            compras_cVerPublicacion.UseColumnTextForButtonValue = true;
            compras_cVerPublicacion.Resizable = DataGridViewTriState.False;

            compras_cPublicacion.Visible = false;

            DataGridViewColumn compras_cConexion = dgCompras.Columns[4];
            compras_cConexion.Visible = false;

            compras_cPublicacion.Resizable = DataGridViewTriState.False;
            compras_cFecha.Resizable = DataGridViewTriState.False;
            compras_cCalificacion.Resizable = DataGridViewTriState.False;
            compras_cComentarios.Resizable = DataGridViewTriState.False;

            compras_cFecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            compras_cCalificacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            compras_cPublicacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            compras_cComentarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            compras_cPublicacion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            compras_cFecha.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            compras_cCalificacion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            compras_cComentarios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            compras_cPublicacion.Width = 70;
            compras_cFecha.Width = 70;
            compras_cCalificacion.Width = 70;
            compras_cComentarios.Width = 295;
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

        private void HistorialCompras_Load(object sender, EventArgs e)
        {

        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            formAnterior.Show();
        }

        private void dgCompras_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                VerPublicacion formP1 = new VerPublicacion(Convert.ToInt32(dgCompras.Rows[e.RowIndex].Cells[2].Value));
                formP1.Show();
            }
        }
    }
}
