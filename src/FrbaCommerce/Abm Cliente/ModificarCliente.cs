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
    public partial class ModificarCliente : Form
    {
        public BuscarCliente formAnterior { get; set; }

        public ModificarCliente(int ID_User, BuscarCliente _formAnterior)
        {
            this.formAnterior = _formAnterior;

            InitializeComponent();
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
