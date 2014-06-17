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
    public partial class Confirmacion : Form
    {
        public string username { get; set; }
        public string password { get; set; }

        public Confirmacion(string _username, string _password)
        {
            this.username = _username;
            this.password = _password;

            InitializeComponent();
            this.CenterToScreen();

            tUsername.Text = this.username;
            tPassword.Text = this.password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
