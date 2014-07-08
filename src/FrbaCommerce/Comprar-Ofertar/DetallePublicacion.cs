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
            this.CenterToScreen();

            publi = unaPublicacion;

            txtUsername.Text = Usuario.obtenerUsername(publi.ID_Vendedor);

            txtCodPublicacion.Text = Convert.ToString(publi.Cod_Publicacion);
            txtCodVisibilidad.Text = Convert.ToString(publi.Cod_Visibilidad);
            txtDescripcion.Text = publi.Descripcion;
            txtEstadoPublicacion.Text = publi.Estado_Publicacion;
            txtFechaFinalizacion.Text = Convert.ToString(publi.Fecha_Vto);
            txtFechaInicio.Text = Convert.ToString(publi.Fecha_Inicio);

            if (publi.Tipo_Publicacion == "Subasta")
            {
                actualizarOfertaDetallePublicacion();
                lblPrecio.Text = "Oferta actual";
            }
            else
             txtPrecio.Text = Convert.ToString(publi.Precio);

            txtStockDisponible.Text = Convert.ToString(publi.Stock);
            txtStockInicial.Text = Convert.ToString(publi.Stock_Inicial);
            txtTipoPublicacion.Text = publi.Tipo_Publicacion;

            cargarTxtRubros();

            if (!unaPublicacion.Permiso_Preguntas)
            {
                lblPregunta.Text = "Esta publicación no admite preguntas.";
                txtPregunta.Enabled = false;
                btnEnviar.Enabled = false;
                btnLimpiar.Enabled = false;
            }

            if (publi.Tipo_Publicacion != "Compra Inmediata")
                btnComprar.Text = "Ofertar";

            if (publi.ID_Vendedor == Interfaz.usuario.ID_User)
            {
                btnComprar.Enabled = false;
                btnEnviar.Enabled = false;
                btnLimpiar.Enabled = false;
                txtPregunta.Text = "No puede realizar preguntas o comprarse a si mismo.";
                txtPregunta.Enabled = false;
            }


        }

   
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPregunta.Text = "";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int idPregunta = Pregunta.insertarPregunta(txtPregunta.Text, Interfaz.usuarioActual().ID_User);

            if (idPregunta != -1)
            {
                MessageBox.Show("Pregunta enviada con éxito!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPregunta.Text = "";
                Pregunta.insertarPreguntaPorPublicacion(publi.Cod_Publicacion, idPregunta);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (!Usuario.habilitadoCompra(Interfaz.usuario.ID_User))
            {
                MessageBox.Show("Usted se encuentra actualmente inhabilitado para comprar.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                DialogResult res = MessageBox.Show("¿Esta seguro que desea realizar la compra?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (res == DialogResult.Yes)
                {
                    stock = stock - 1;
                    txtStockDisponible.Text = Convert.ToString(stock);

                    Compra compra = new Compra(publi.ID_Vendedor, Interfaz.usuario.ID_User, publi.Cod_Publicacion, 0 , publi.Precio, false);
                    //inserto la compra a operaciones y updateo el campo ventas_sin_rendir al id_vendedor
                    Compra.insertarCompra(compra);
                    Usuario.updateVentasSinRendir(compra);
                    //Visibilidad.insertBonificacion(publi.ID_Vendedor, publi.Cod_Visibilidad);

                    bool puedeComprarLaProxPorCalific = Calificacion.verificarCantidadCalificaciones(Interfaz.usuarioActual().ID_User);             

                    if (!puedeComprarLaProxPorCalific)
                    {
                        //TODO: deshabilitar funcioanlidad compra
                        MessageBox.Show("Usted ha llegado a 5 compras (inmediata o subasta ganada) sin calificar, " +
                        "no podrá seguir comprando hasta que no se ponga al día.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Usuario.updateHabilitadoCompra(Interfaz.usuarioActual().ID_User, false);
                    }

           
                    if (publi.ID_Vendedor == 0)
                    {
                        MessageBox.Show("Publicacion creada por el Administrador General, no puede ver sus datos.", "Atención", MessageBoxButtons.OK);
                        return;
                    }
                    
                    DatosVendedor datosVendedorForm = new DatosVendedor(publi.ID_Vendedor);
                    datosVendedorForm.ShowDialog();
                }
            }
            else if (publi.Tipo_Publicacion == "Subasta")
            {
                OfertaDlg ofertaDlg = new OfertaDlg(publi);
                ofertaDlg.ShowDialog();

                actualizarOfertaDetallePublicacion();
            }
        }

        private void cargarTxtRubros()
        {
            string rubros = Rubro.obtenerStringRubros(publi.Cod_Publicacion);
            txtRubros.Text = rubros;
        }

        private void actualizarOfertaDetallePublicacion()
        {
            txtPrecio.Text = Convert.ToString(Oferta.cargarOfertaMasAlta(publi.Cod_Publicacion));       
        }

        


      
    }
}
