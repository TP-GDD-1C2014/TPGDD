using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class RegistroUsuarioForm3 : Form
    {
        public string username { get; set; }
        public string password { get; set; }
        public int rol { get; set; }

        public RegistroUsuarioForm3(string user, string pass, int rol)
        {
            this.username = user;
            this.password = pass;
            this.rol = rol;
            InitializeComponent();
        }

        private void RegistroUsuarioForm2_Load(object sender, EventArgs e)
        {

        }
    }
}
