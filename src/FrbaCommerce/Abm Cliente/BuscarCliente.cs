using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class BuscarCliente : Form
    {
        public char filtro { get; set; }
        public string valor { get; set; }

        public BuscarCliente(char _filtro, string _valor)
        {
            this.filtro = _filtro;
            this.valor = _valor;

            InitializeComponent();
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
