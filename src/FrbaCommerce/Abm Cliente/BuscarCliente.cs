using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Common;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class BuscarCliente : Form
    {
        public char filtro { get; set; }
        public string valor { get; set; }
        public int cantResultados { get; set; }

        public class ResultadoClientes {
            public int ID_User { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }

            public ResultadoClientes(int _ID_User, string _Nombre, string _Apellido)
            {
                ID_User = _ID_User;
                Nombre = _Nombre;
                Apellido = _Apellido;
            }
        }

        public List<ResultadoClientes> resultados = new List<ResultadoClientes>();

        public BuscarCliente(char _filtro, string _valor)
        {
            this.filtro = _filtro;
            this.valor = _valor;

            InitializeComponent();

            this.cantResultados = cargarLista();
            formatearDataGrid();
        }

        public int cargarLista()
        {
            int resultado = 0;

            switch (filtro)
            {
                case 'N': // Nombre
                    resultado = buscarNombre();
                    break;
                case 'A': // Apellido
                    resultado = buscarApellido();
                    break;
                case 'T': // Tipo de documento
                    resultado = buscarTipoDeDocumento();
                    break;
                case 'D': // Número de documento
                    resultado = buscarNumeroDeDocumento();
                    break;
                case 'E': // E-mail
                    resultado = buscarEmail();
                    break;
            }

            return resultado;
        }

        public int buscarNombre()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Nombre", this.valor);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User, Nombre, Apellido FROM MERCADONEGRO.Clientes WHERE Nombre = @Nombre", listaParametros, BDSQL.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int ID_User = Convert.ToInt32(lector["ID_User"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(ID_User, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            BDSQL.cerrarConexion();
            return cantRes;
        }

        public int buscarApellido()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Apellido", this.valor);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User, Nombre, Apellido FROM MERCADONEGRO.Clientes WHERE Apellido = @Apellido", listaParametros, BDSQL.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int ID_User = Convert.ToInt32(lector["ID_User"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(ID_User, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            BDSQL.cerrarConexion();
            return cantRes;
        }

        public int buscarTipoDeDocumento()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Tipo_Doc", this.valor);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User, Nombre, Apellido FROM MERCADONEGRO.Clientes WHERE Tipo_Doc = @Tipo_Doc", listaParametros, BDSQL.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int ID_User = Convert.ToInt32(lector["ID_User"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(ID_User, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            BDSQL.cerrarConexion();
            return cantRes;
        }

        public int buscarNumeroDeDocumento()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Num_Doc", this.valor);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User, Nombre, Apellido FROM MERCADONEGRO.Clientes WHERE Num_Doc = @Num_Doc", listaParametros, BDSQL.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int ID_User = Convert.ToInt32(lector["ID_User"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(ID_User, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            BDSQL.cerrarConexion();
            return cantRes;
        }

        public int buscarEmail()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Mail", this.valor);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User, Nombre, Apellido FROM MERCADONEGRO.Clientes WHERE Mail = @Mail", listaParametros, BDSQL.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int ID_User = Convert.ToInt32(lector["ID_User"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(ID_User, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            BDSQL.cerrarConexion();
            return cantRes;
        }

        public void formatearDataGrid()
        {
            int widthNombre = 100;
            int widthApellido = 120;
            int widthBotones = 80;

            dgResultados.DataSource = resultados;
            dgResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResultados.RowHeadersVisible = false;

            DataGridViewColumn col_idUser = dgResultados.Columns[0];
            col_idUser.Visible = false;

            DataGridViewColumn col_nombre = dgResultados.Columns[1];
            col_nombre.Resizable = DataGridViewTriState.False;
            col_nombre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_nombre.Width = widthNombre;

            DataGridViewColumn col_apellido = dgResultados.Columns[2];
            col_apellido.Resizable = DataGridViewTriState.False;
            col_apellido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_apellido.Width = widthApellido;

            DataGridViewButtonColumn botonesModificar = new DataGridViewButtonColumn();
            botonesModificar.HeaderText = "";
            botonesModificar.Text = "Modificar";
            botonesModificar.Name = "bMod";
            botonesModificar.Width = widthBotones;
            botonesModificar.UseColumnTextForButtonValue = true;
            botonesModificar.Resizable = DataGridViewTriState.False;

            DataGridViewButtonColumn botonesEliminar = new DataGridViewButtonColumn();
            botonesEliminar.HeaderText = "";
            botonesEliminar.Text = "Eliminar";
            botonesEliminar.Name = "bElim";
            botonesEliminar.Width = widthBotones;
            botonesEliminar.UseColumnTextForButtonValue = true;
            botonesEliminar.Resizable = DataGridViewTriState.False;

            dgResultados.Columns.Add(botonesModificar);
            dgResultados.Columns.Add(botonesEliminar);
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public void eliminarCliente(int id)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", id);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET Habilitado = 0 WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
            MessageBox.Show("Usuario inhabilitado.");
        }

        private void dgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    ModificarCliente form1 = new ModificarCliente(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value), this);
                    this.Hide();
                    form1.Show();
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("Se inhabilitará al cliente " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[3].Value) + ", " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[4].Value) + ".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        eliminarCliente(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value));
                    }
                    break;
            }
        }
    }
}
