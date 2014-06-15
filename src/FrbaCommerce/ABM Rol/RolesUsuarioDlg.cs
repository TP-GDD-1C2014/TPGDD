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
    public partial class RolesUsuarioDlg : Form
    {
        int idUser;
        string username;
        List<Rol> todosLosRoles;
        List<Rol> rolesUsuario; 

        public RolesUsuarioDlg(int _idUser, string _username)
        {
            InitializeComponent();
            idUser = _idUser;
            username = _username;

            cblRoles.DisplayMember = "Nombre"; 
            cblRoles.ValueMember = "ID_Rol";

            todosLosRoles = Roles.obtenerRoles();
            rolesUsuario  = Roles.obtenerRolesUsuario(idUser);

            cargarCheckboxList();
            cargarRolesUsuario();

            txtIdUser.Text = Convert.ToString(idUser);
            txtUsername.Text = username;
        }

        private void cargarCheckboxList()
        {
            for (int i = 0; i < todosLosRoles.Count(); i++)
            {
                cblRoles.Items.Add(new Rol(todosLosRoles[i].ID_Rol, todosLosRoles[i].Nombre, todosLosRoles[i].Habilitado));
            }
        }
        
        private void cargarRolesUsuario()
        {
           

            foreach (Rol rol in rolesUsuario)
            {
                for (int i = 0; i < cblRoles.Items.Count; i++)
                {
                    Rol unRol = cblRoles.Items[i] as Rol;

                    if (rol.ID_Rol == unRol.ID_Rol)
                    {
                        cblRoles.SetItemCheckState(i, CheckState.Checked);
                    }
                }
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Rol> rolesSeleccionados = filtrarSeleccionadas();

            if (sonIguales(rolesSeleccionados))
            {
                MessageBox.Show("Por favor realice al menos un cambio", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private List<Rol> filtrarSeleccionadas()
        {
            List<Rol> rolesSeleccionados = new List<Rol>();

            for (int i = 0; i < cblRoles.Items.Count; i++)
            {
                if (cblRoles.GetItemChecked(i))
                {
                    Rol rol = cblRoles.Items[i] as Rol;
                    rolesSeleccionados.Add(rol);
                }
            }
            return rolesSeleccionados;
        }

        private bool sonIguales(List<Rol> rolesSeleccionados)
        {
            if (rolesUsuario.Count != rolesSeleccionados.Count)
                return false;

            for (int i = 0; i < rolesUsuario.Count; i++)
            {
                bool encontro = false;

                for (int j = 0; j < rolesSeleccionados.Count; j++)
                {
                    if (rolesSeleccionados[j].ID_Rol == rolesUsuario[i].ID_Rol)
                    {
                        encontro = true;
                        break;
                    }
                }

                if (!encontro)
                    return false;
            }
            return true;
        }
    }
}
