using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using FrbaCommerce.Clases;

namespace FrbaCommerce.ABM_Rol
{
    public partial class AsignarRolesUsuario : Form
    {
        public AsignarRolesUsuario()
        {
            InitializeComponent();
            this.CenterToScreen();
            cargarUsuarios();
        }

        private void cargarUsuarios()
        {
            usuariosDataGrid.DataSource = Usuario.obtenerUsuarios();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (usuariosDataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow row = usuariosDataGrid.CurrentRow;

                int idUser = Convert.ToInt32(row.Cells[0].Value);
                string username = Convert.ToString(row.Cells[1].Value);

                RolesUsuarioDlg rolesUsuarioDlg = new RolesUsuarioDlg(idUser, username );

                rolesUsuarioDlg.ShowDialog();
            }
        }
    }
}
