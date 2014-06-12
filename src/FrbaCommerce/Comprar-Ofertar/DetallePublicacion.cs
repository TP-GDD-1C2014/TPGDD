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



namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class DetallePublicacion : Form
    {
       Publicacion publi;

        public  DetallePublicacion(Publicacion unaPublicacion)
        {
            InitializeComponent();

            publi = unaPublicacion;

            txtCodPublicacion.Text = Convert.ToString(unaPublicacion.Cod_Publicacion);
            txtCodVisibilidad.Text = Convert.ToString(unaPublicacion.Cod_Visibilidad);
            txtDescripcion.Text = unaPublicacion.Descripcion;
            txtEstadoPublicacion.Text = unaPublicacion.Estado_Publicacion;
            txtFechaFinalizacion.Text = Convert.ToString(unaPublicacion.Fecha_Vto);
            txtFechaInicio.Text = Convert.ToString(unaPublicacion.Fecha_Inicio);
            txtIdVendedor.Text = Convert.ToString(unaPublicacion.ID_Vendedor);
            txtPrecio.Text = Convert.ToString(unaPublicacion.Precio);
            txtStockDisponible.Text = Convert.ToString(unaPublicacion.Stock);
            txtStockInicial.Text = Convert.ToString(unaPublicacion.Stock_Inicial);
            txtTipoPublicacion.Text = unaPublicacion.Tipo_Publicacion;

            if (!unaPublicacion.Permiso_Preguntas)
            {
                lblPregunta.Text = "Esta publicación no admite preguntas.";
                txtPregunta.Enabled = false;
                btnEnviar.Enabled = false;
                btnLimpiar.Enabled = false;
            }

            if (publi.Tipo_Publicacion != "Compra Inmediata")
                btnComprar.Text = "Ofertar";

        }

   
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPregunta.Text = "";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int idPregunta = Pregunta.insertarPregunta(txtPregunta.Text);

            if (idPregunta != -1)
            {
                MessageBox.Show("Pregunta enviada con éxito!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPregunta.Text = "";
                Pregunta.insertarPreguntaPorPublicacion(publi.Cod_Publicacion, idPregunta);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            //chequeo que no tenga mas de 5 compras sin calificar o si esta habilitado
            bool puedeComprar = Calificacion.verificarCantidadCalificaciones(Interfaz.usuario.ID_User);

            if (!puedeComprar)
            {
                //TODO: deshabilitar funcioanlidad compra
                MessageBox.Show("Usted tiene 5 compras (inmediata o subasta ganada) sin calificar, " +
                "no podrá seguir comprando hasta que no califique a los vendedores.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            int stock = int.Parse(txtStockDisponible.Text);
            
            if (stock == 0)
            {
                MessageBox.Show("No hay mas stock disponibles!", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (publi.Tipo_Publicacion == "Compra Inmediata")
            {
                DialogResult res = MessageBox.Show("Esta seguro que desea realizar la compra?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (res == DialogResult.Yes)
                {
                    stock = stock - 1;
                    txtStockDisponible.Text = Convert.ToString(stock);

                    Compra compra = new Compra(publi.ID_Vendedor, Interfaz.usuario.ID_User, publi.Cod_Publicacion, 0 , publi.Precio, false);
                    Compra.insertarCompra(compra);

                    bool puedeComprarLaProx = Calificacion.verificarCantidadCalificaciones(Interfaz.usuario.ID_User);

                    if (!puedeComprarLaProx)
                    {
                        //TODO: deshabilitar funcioanlidad compra
                        MessageBox.Show("Usted tiene 5 compras (inmediata o subasta ganada) sin calificar, " +
                        "no podrá seguir comprando hasta que no califique a los vendedores.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                    DatosVendedor datosVendedorForm = new DatosVendedor(publi.ID_Vendedor);
                    datosVendedorForm.ShowDialog();
                }
            }
            else if (publi.Tipo_Publicacion == "Subasta")
            {
                OfertaDlg ofertaDlg = new OfertaDlg(publi);
                ofertaDlg.ShowDialog();
            }
        }

      
    }
}
