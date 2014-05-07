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
    public partial class SeleccionRoles : Form
    {
        public class Item
        {
            public int idRol { get; set; }
            public string nombreRol { get; set; }
            public int habilitado { get; set; }

            public Item(int idRol, string nombreRol, int habilitado)
            {
                idRol = this.idRol;
                nombreRol = this.nombreRol;
                habilitado = this.habilitado;
            }
        }

        public SeleccionRoles(Clases.Usuario usuario)
        {
            InitializeComponent();
            llenarComboBox(usuario);
        }

        public void llenarComboBox(Clases.Usuario usuario)
        {
            for (int i = 0; i < usuario.Roles.Count; i++)
            {
                comboBox1.Items.Add(new Item(usuario.Roles[i].ID_Rol, usuario.Roles[i].Nombre, usuario.Roles[i].Habilitado));
                MessageBox.Show((comboBox1.SelectedItem as Item).nombreRol.ToString()); // <-- SEGUIR ACA (ALAN)
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
