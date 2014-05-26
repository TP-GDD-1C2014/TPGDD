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
        public Clases.Usuario usuario { get; set; }

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

        public SeleccionRoles(Clases.Usuario usuarioLogin)
        {
            this.usuario = usuarioLogin;
            InitializeComponent();
            this.CenterToScreen();
            this.AcceptButton = continuar_Boton;
            comboBox_Roles.DisplayMember = "Nombre_Rol";
            comboBox_Roles.ValueMember = "ID_Rol";
            comboBox_Roles.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            comboBox_Roles.DropDownStyle = ComboBoxStyle.DropDownList;
            llenarComboBox();
        }

        public void llenarComboBox()
        {
            for (int i = 0; i < usuario.Roles.Count(); i++)
            {
                if (usuario.Roles[i].Habilitado != false) // TOMANDO EN CUENTA QUE 1 ES HABILITADO
                {
                    comboBox_Roles.Items.Add(new itemComboBox(usuario.Roles[i].Nombre, usuario.Roles[i].ID_Rol));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox_Roles.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Error");
            }
            else
            {
                if (this.usuario.Roles[comboBox_Roles.SelectedIndex].funcionalidades.Count != 0)
                {
                    itemComboBox seleccion = comboBox_Roles.SelectedItem as itemComboBox;
                    SeleccionFuncionalidades formFuncionalidades = new SeleccionFuncionalidades(usuario, seleccion.ID_Rol, false);
                    this.Hide();
                    formFuncionalidades.Show();
                }
                else
                {
                    MessageBox.Show("El rol seleccionado no posee funcionalidades.", "Error");
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

        private void SeleccionRoles_Load(object sender, EventArgs e)
        {

        }
    }
}
