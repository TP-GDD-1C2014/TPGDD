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
        public class itemComboBox
        {
            public string Nombre_Rol { get; set; }
            public int ID_Rol { get; set; }

            public itemComboBox(string nombre, int id)
            {
                Nombre_Rol = nombre;
                ID_Rol = id;
            }
            public override string ToString()
            {
                return Nombre_Rol;
            }
        }

        public SeleccionRoles(Clases.Usuario usuario)
        {
            InitializeComponent();
            comboBox_Roles.DisplayMember = "Nombre_Rol";
            comboBox_Roles.ValueMember = "ID_Rol";
            comboBox_Roles.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            comboBox_Roles.DropDownStyle = ComboBoxStyle.DropDownList;
            llenarComboBox(usuario);
        }

        public void llenarComboBox(Clases.Usuario usuario)
        {
            for (int i = 0; i < usuario.Roles.Count; i++)
            {
                if (usuario.Roles[i].Habilitado != 0) // TOMANDO EN CUENTA QUE 1 ES HABILITADO
                {
                    comboBox_Roles.Items.Add(new itemComboBox(usuario.Roles[i].Nombre, usuario.Roles[i].ID_Rol));
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            itemComboBox seleccion = comboBox_Roles.SelectedItem as itemComboBox;
            MessageBox.Show("Has seleccionado el rol " + seleccion.ID_Rol.ToString());
        }
    }
}
