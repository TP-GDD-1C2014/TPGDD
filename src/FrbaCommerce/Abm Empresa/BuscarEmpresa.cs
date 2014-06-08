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

namespace FrbaCommerce.Abm_Empresa
{
    public partial class BuscarEmpresa : Form
    {
        public char filtro { get; set; }
        public string valor { get; set; }
        public int cantResultados { get; set; }

        public class ResultadoEmpresas
        {
            public int ID_User { get; set; }
            public string Razon_Social { get; set; }

            public ResultadoEmpresas(int _ID_User, string _Razon_Social)
            {
                ID_User = _ID_User;
                Razon_Social = _Razon_Social;
            }
        }

        public List<ResultadoEmpresas> resultados = new List<ResultadoEmpresas>();

        public BuscarEmpresa(char _filtro, string _valor)
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
                case 'R': // Razón Social
                    resultado = buscarRazonSocial();
                    break;
                case 'C': // CUIT
                    resultado = buscarCUIT();
                    break;
                case 'E': // E-mail
                    resultado = buscarEmail();
                    break;
            }

            return resultado;
        }

        public int buscarRazonSocial()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Razon_Social", this.valor);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User FROM MERCADONEGRO.Empresas WHERE Razon_Social = @Razon_Social", listaParametros, BDSQL.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int ID_User = Convert.ToInt32(lector["ID_User"]);
                    string Razon_Social = this.valor;

                    ResultadoEmpresas resultado = new ResultadoEmpresas(ID_User, Razon_Social);
                    resultados.Add(resultado);
                }
            }

            BDSQL.cerrarConexion();
            return cantRes;
        }

        public int buscarCUIT()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@CUIT", this.valor);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User, Razon_Social FROM MERCADONEGRO.Empresas WHERE CUIT = @CUIT", listaParametros, BDSQL.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int ID_User = Convert.ToInt32(lector["ID_User"]);
                    string Razon_Social = Convert.ToString(lector["Razon_Social"]);

                    ResultadoEmpresas resultado = new ResultadoEmpresas(ID_User, Razon_Social);
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
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT ID_User, Razon_Social FROM MERCADONEGRO.Empresas WHERE Mail = @Mail", listaParametros, BDSQL.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int ID_User = Convert.ToInt32(lector["ID_User"]);
                    string Razon_Social = Convert.ToString(lector["Razon_Social"]);

                    ResultadoEmpresas resultado = new ResultadoEmpresas(ID_User, Razon_Social);
                    resultados.Add(resultado);
                }
            }

            BDSQL.cerrarConexion();
            return cantRes;
        }

        public void formatearDataGrid()
        {
            int widthRazonSocial = 227;
            int widthBotones = 85;

            dgResultados.DataSource = resultados;
            dgResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResultados.RowHeadersVisible = false;

            DataGridViewColumn col_idUser = dgResultados.Columns[0];
            col_idUser.Visible = false;

            DataGridViewColumn col_razonSocial = dgResultados.Columns[1];
            col_razonSocial.Resizable = DataGridViewTriState.False;
            col_razonSocial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_razonSocial.Width = widthRazonSocial;

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

        private void BuscarEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public void eliminarEmpresa(int id)
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
                    ModificarEmpresa form1 = new ModificarEmpresa(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value), this);
                    this.Hide();
                    form1.Show();
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("Se inhabilitará a la empresa "+Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[3].Value)+".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        eliminarEmpresa(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value));
                    }
                    break;
            }
        }
    }
}
