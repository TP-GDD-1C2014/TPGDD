using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;

namespace FrbaCommerce.Login
{
    public partial class CambiarPassword : Form
    {
        public CambiarPassword()
        {
            InitializeComponent();
        }

        private void pass2_TextChanged(object sender, EventArgs e)
        {
            pass2.PasswordChar = '*';
        }

        private void pass1_TextChanged(object sender, EventArgs e)
        {
            pass1.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pass1.Text == pass2.Text)
            {
                Interfaz.usuario.cambiarPassword(pass1.Text);
                MessageBox.Show("Contraseña modificada.");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error");
            }
        }
    }
}
