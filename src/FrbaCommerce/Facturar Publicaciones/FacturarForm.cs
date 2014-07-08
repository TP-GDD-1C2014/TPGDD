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

            this.dgvOperaciones.DataSource = factura.obtenerCompras(usuario);
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
              
                //obtengo la lista de los codigos de las publicaciones
                List<int> listaCodigos = this.obtenerFacturas(this.dgvOperaciones.SelectedRows);
                
                int cantidadFacturas = listaCodigos.Count;

                    //crear la factura
                    Facturacion factura = new Facturacion(this.formaDePagoComboBox.Text);

                    int idFactura = factura.crearFactura();

                    //recorro los selectedRows del datagridview para insertar los items a la factura creada
                    int i = 0;
                    int cantidadFilas = this.dgvOperaciones.SelectedRows.Count;

                    while (i < cantidadFilas)
                    {
                        
                            //insertar item
                            Item item = new Item();
                            
                            //1. Nro factura
                            item.ID_Facturacion = idFactura;

                            //2. Codigo de la Publicacion
                            item.Cod_Publicacion = listaCodigos[i];

                            //primero obtengo el tipo de publicacion para saber cuánto stock se ha vendido

                            string tipoPublicacion = Publicacion.obtenerTipoPublicacion(item.Cod_Publicacion);

                            //3. Cantidad Vendida
                            if (tipoPublicacion == "Compra Inmediata")
                            {
                                item.Cantidad_Vendida = 1;

                            }
                            else if (tipoPublicacion == "Subasta")
                            {
                                item.Cantidad_Vendida = Publicacion.obtenerStock(item.Cod_Publicacion);
                            }

                            //4. Sumar 1 en bonificaciones, y obtener el Precio unitario (si esta bonificada devuelve 0)
                            item.Precio_Unitario = Publicacion.sumarObtenerPrecio(item.Cod_Publicacion, tipoPublicacion);

                            //5. Descripcion
                            item.Descripcion = Convert.ToString(this.dgvOperaciones.SelectedRows[i].Cells[3].Value);

                            //Inserto el item y ACTUALIZO EL TOTAL_FACTURACION (de la tabla facturas)
                            item.InsertarItem(idFactura);

                            //Actualizo la operacion a facturada
                            int idOperacion = Convert.ToInt32(this.dgvOperaciones.SelectedRows[i].Cells[1].Value);

                            Operacion.facturarCompra(idOperacion);

                            Usuario.restarVentaSinRendir(idOperacion);
                    
                        //inserto en la tabla asociativa el idFactura y el codPublicacion
                        if(!factura.noExiste(idFactura, listaCodigos[i]))
                        {
                            //insert
                            factura.insertarAsociativa(idFactura, listaCodigos[i]);
                        }



                        i++;
                    

                }


                MessageBox.Show("¡Ventas facturadas!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                else if (Interfaz.usuarioActual().esAdmin() && this.usernameTextBox.Text == "")
                {
                    MessageBox.Show("Por favor, filtre por algun usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
           
            List<int> codigosPublicaciones = new List<int>();

            foreach(DataGridViewRow fila in dgv)
            {
                
                int codPublicacion = Convert.ToInt32(fila.Cells[2].Value);

                    codigosPublicaciones.Add(codPublicacion);

                
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

                this.dgvOperaciones.DataSource = BDSQL.obtenerDataTable("MERCADONEGRO.ObtenerComprasSinFacturar", "SP", listaParametros);
            }
        }

             

    }
}
