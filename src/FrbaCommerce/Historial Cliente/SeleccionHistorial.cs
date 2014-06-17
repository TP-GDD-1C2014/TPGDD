using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class SeleccionHistorial : Form
    {
        public Login.SeleccionFuncionalidades formAnterior { get; set; }

        public SeleccionHistorial(Login.SeleccionFuncionalidades _formAnterior)
        {
            this.formAnterior = _formAnterior;
            InitializeComponent();
            this.CenterToScreen();
        }

        private void bCompras_Click(object sender, EventArgs e)
        {
            HistorialCompras form = new HistorialCompras(this);
            this.Hide();
            form.Show();
        }

        private void bSubastas_Click(object sender, EventArgs e)
        {
            HistorialSubastas form = new HistorialSubastas(this);
            this.Hide();
            form.Show();
        }

        private void bOfertas_Click(object sender, EventArgs e)
        {
            HistorialOfertas form = new HistorialOfertas(this);
            this.Hide();
            form.Show();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formAnterior.Show();
        }
    }
}
