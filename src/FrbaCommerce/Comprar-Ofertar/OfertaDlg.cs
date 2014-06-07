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
using FrbaCommerce.Clases;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class OfertaDlg : Form
    {
        Publicacion publicacion;
        
        public OfertaDlg(Publicacion publi)
        {
            InitializeComponent();
            publicacion = publi;
            string ofertaMasGrande = Oferta.cargarOfertaMasAlta(publicacion.Cod_Publicacion);

            if (ofertaMasGrande == "")
            {
                txtOfertaActual.Text = "No hay ofertas realizadas!";
            }
            else txtOfertaActual.Text = ofertaMasGrande;
            

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtOferta.Text = "";
        }

        private void txtAceptar_Click(object sender, EventArgs e)
        {
            int valor;
            if (int.TryParse(txtOferta.Text, out valor))
            {
                Oferta oferta = new Oferta(publicacion.ID_Vendedor, Interfaz.usuario.ID_User, publicacion.Cod_Publicacion, 1, valor);
                if (Oferta.insertarOferta(oferta))
                {
                    MessageBox.Show("Oferta realizada con éxito! Actualmente usted tiene la oferta mas alta.", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txtOfertaActual.Text = Oferta.cargarOfertaMasAlta(publicacion.Cod_Publicacion);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor numerico entero, mayor que la oferta actual.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
