using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Login
{
    public partial class SeleccionFuncionalidades : Form
    {
        public Clases.Usuario usuario { get; set; }
        public int idRol { get; set; }

        public SeleccionFuncionalidades(Clases.Usuario usuario, int idRol)
        {
            this.usuario = usuario;
            this.idRol = idRol;
            InitializeComponent();
            this.CenterToScreen();
        }

        private void SeleccionFuncionalidades_Load(object sender, EventArgs e)
        {

        }
    }
}
