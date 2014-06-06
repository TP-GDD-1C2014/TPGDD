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
        int codPublicacion;
        int idVendedor;

        public  DetallePublicacion(Publicacion unaPublicacion)
        {
            InitializeComponent();

            //guardo el codPublicacion
            txtCodPublicacion.Text = Convert.ToString(unaPublicacion.Cod_Publicacion);
            codPublicacion = unaPublicacion.Cod_Publicacion;

            txtCodVisibilidad.Text = Convert.ToString(unaPublicacion.Cod_Visibilidad);
            txtDescripcion.Text = unaPublicacion.Descripcion;
            txtEstadoPublicacion.Text = unaPublicacion.Estado_Publicacion;
            txtFechaFinalizacion.Text = Convert.ToString(unaPublicacion.Fecha_Vto);
            txtFechaInicio.Text = Convert.ToString(unaPublicacion.Fecha_Inicio);

            //guardo el idVendedor
            txtIdVendedor.Text = Convert.ToString(unaPublicacion.ID_Vendedor);
            idVendedor = unaPublicacion.ID_Vendedor;

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
                Pregunta.insertarPreguntaPorPublicacion(codPublicacion, idPregunta);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Esta seguro que desea realizar la compra?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes)
            {
                
                DatosVendedor datosVendedorForm = new DatosVendedor(idVendedor);
                datosVendedorForm.ShowDialog();
            }
        }
    }
}
