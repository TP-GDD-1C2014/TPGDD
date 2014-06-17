using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Clases;
using FrbaCommerce.Common;
using System.Data.SqlClient;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FacturarForm : Form
    {
        public FacturarForm()
        {
            InitializeComponent();

            this.generarDataGrid(Interfaz.usuarioActual());

            if (!Interfaz.usuarioActual().esAdmin())
            {
                this.formaDePagoComboBox.Items.Add("Efectivo");
                this.nombreUserLabel.Hide();
                this.usernameTextBox.Hide();
                this.buscarButton.Hide();
            }

            this.formaDePagoComboBox.Items.Add("Tarjeta de Crédito");

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvOperaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void generarDataGrid(Usuario usuario)
        {
            Facturacion factura = new Facturacion();

            this.dgvOperaciones.DataSource = factura.obtenerOperaciones(usuario);
            this.dgvOperaciones.Refresh();
            
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rendirButton_Click(object sender, EventArgs e)
        {
            bool chequeado = this.chequearCampos(this.dgvOperaciones, this.formaDePagoComboBox);

            if (chequeado)
            {
                //se empiezan a facturar todas las ventas en orden
              
                //obtengo la lista de los diferentes codigos de las publicaciones
                List<int> listaCodigos = this.obtenerFacturas(this.dgvOperaciones.SelectedRows);

                int codigoIndex = 0;
                int cantidadFacturas = listaCodigos.Count;

                while (codigoIndex < cantidadFacturas)
                {
                    //crear la factura
                    Facturacion factura = new Facturacion(listaCodigos[codigoIndex],this.formaDePagoComboBox.Text);

                    int idFactura = factura.crearFactura();

                    //recorro los selectedRows del datagridview para insertar los items a la factura creada
                    int i = 0;
                    int cantidadFilas = this.dgvOperaciones.SelectedRows.Count;

                    while (i < cantidadFilas)
                    {
                        //si el item corresponde a esa factura...
                        if (factura.Cod_Publicacion == Convert.ToInt32(this.dgvOperaciones.SelectedRows[i].Cells[2].Value))
                        {
                            //insertar item
                            Item item = new Item();
                            
                            //1. Nro factura
                            item.ID_Facturacion = idFactura;

                            //primero obtengo el tipo de publicacion para saber cuánto stock se ha vendido

                            string tipoPublicacion = Publicacion.obtenerTipoPublicacion(factura.Cod_Publicacion);

                            //2. Cantidad Vendida
                            if (tipoPublicacion == "Compra Inmediata")
                            {
                                item.Cantidad_Vendida = 1;

                            }
                            else if (tipoPublicacion == "Subasta")
                            {
                                item.Cantidad_Vendida = Publicacion.obtenerStock(factura.Cod_Publicacion);
                            }

                            //3. Precio unitario
                            item.Precio_Unitario = Publicacion.obtenerPrecio(factura.Cod_Publicacion);

                            //4. Descripcion
                            item.Descripcion = Convert.ToString(this.dgvOperaciones.SelectedRows[i].Cells[3].Value);

                            //Inserto el item y ACTUALIZO EL TOTAL_FACTURACION (de la tabla facturas)
                            item.InsertarItem(idFactura);

                            //Actualizo la operacion a facturada
                            int idOperacion = Convert.ToInt32(this.dgvOperaciones.SelectedRows[i].Cells[1].Value);

                            Operacion.facturarOperacion(idOperacion);

                            Usuario.restarVentaSinRendir(idOperacion);
                    
                        }

                        i++;
                    }

                    codigoIndex++;

                }


                MessageBox.Show("¡Factura generada!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.generarDataGrid(Interfaz.usuarioActual());
                this.dgvOperaciones.Refresh();

            }
            

        }

        private bool chequearCampos(DataGridView dgv, ComboBox formaDePago)
        {
            if (dgv.RowCount > 0)
            {

                if (!this.chequearFilasConsecutivas(dgv))
                {
                    MessageBox.Show("Deben facturarse sólo las ventas más antiguas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (formaDePago.Text == "")
                {
                    MessageBox.Show("Por favor, complete los datos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                    return true;
            }
            else
            {
                MessageBox.Show("Usted no debe ninguna venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
	    }
            

        private bool chequearFilasConsecutivas(DataGridView dgv)
        {
            int filasSeleccionadas = this.dgvOperaciones.SelectedRows.Count;
            int i = 0;
            bool sonConsecutivas = true;

            while (i < filasSeleccionadas)
            {
                if (!this.dgvOperaciones.Rows[i].Selected)
                    sonConsecutivas = false;

                i++;
            }

            return sonConsecutivas;

        }

        private List<int> obtenerFacturas(DataGridViewSelectedRowCollection dgv)
        {
            int i = 0;
            int cantidadFilas = dgv.Count;

            List<int> codigosPublicaciones = new List<int>();

            foreach(DataGridViewRow fila in dgv)
            {
                
                int codPublicacion = Convert.ToInt32(fila.Cells[2].Value);

                if(!codigosPublicaciones.Contains(codPublicacion))
                    codigosPublicaciones.Add(codPublicacion);

                i++;
            }

            return codigosPublicaciones;

        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            if (this.usernameTextBox.Text != "" && this.usernameTextBox != null)
            {
                string username = this.usernameTextBox.Text;

                List<SqlParameter> listaParametros = new List<SqlParameter>();

                BDSQL.agregarParametro(listaParametros, "@username", username);

                this.dgvOperaciones.DataSource = BDSQL.obtenerDataTable("MERCADONEGRO.ObtenerOperacionesSinFacturar", "SP", listaParametros);
            }
        }

             

    }
}
