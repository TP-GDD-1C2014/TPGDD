using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Clases;
using FrbaCommerce.Common;
using System.Data.SqlClient;

namespace FrbaCommerce.ABM_Rol
{
    public partial class EditorDeRoles : Form
    {
        /*public class itemCheckboxlistFuncionalidades
        {
            public string Nombre{ get; set; }
            public int ID { get; set; }

            public itemCheckboxlistFuncionalidades(string nombre, int id)
            {
                Nombre = nombre;
                ID = id;
            }
            public override string ToString()
            {
                return Nombre_Rol;
            }
        } */
   
        public EditorDeRoles(string modo)
        {
            InitializeComponent();
            CenterToScreen();
            if (modo == "nuevo")
            {
                List<Funcionalidad> lista = Funcionalidades.obtenerFuncionalidades(BDSQL.iniciarConexion() , 0);
                
                Funcionalidades_Checkboxlist.DisplayMember = "Nombre";//TODO checkear
                Funcionalidades_Checkboxlist.ValueMember = "ID_Funcionalidad";
                cargarCheckboxList(lista);

                Habilitado_Checkbox.Enabled = false;
            }

        }

        public EditorDeRoles(string modo, Rol unRol)
        {
            InitializeComponent();
            CenterToScreen();
            if (modo == "modificar")
            {
                List<Funcionalidad> listaFuncQueTiene = Funcionalidades.obtenerFuncionalidades(BDSQL.iniciarConexion(), unRol.ID_Rol);
                List<Funcionalidad> listaTodasLasFunc = Funcionalidades.obtenerFuncionalidades(BDSQL.iniciarConexion(), 0);

                Nombre_Textbox.Text = unRol.Nombre;
                Nombre_Textbox.Focus();
                Nombre_Textbox.SelectAll();
                Funcionalidades_Checkboxlist.DisplayMember = "Nombre";
                Funcionalidades_Checkboxlist.ValueMember = "ID_Funcionalidad";
                cargarCheckboxList(listaTodasLasFunc);
                actualizarCheckboxList(listaFuncQueTiene);
                //TODO que Guardar haga update del rol seleccionado y no uno nuevo en adelante, con un flag probablemente
                
            
            }
        }

        private void cargarCheckboxList(List<Funcionalidad> lista)
        {
            for (int i = 0; i < lista.Count(); i++)
            {
                Funcionalidades_Checkboxlist.Items.Add(new Funcionalidad(lista[i].ID_Funcionalidad, lista[i].Nombre));
            }
        }

        private void actualizarCheckboxList(List<Funcionalidad> listaFuncQueTiene)
        {
            foreach (Funcionalidad func in listaFuncQueTiene)
            {
                for (int i = 0; i < Funcionalidades_Checkboxlist.Items.Count; i++)
                {
                    Funcionalidad otraFunc = Funcionalidades_Checkboxlist.Items[i] as Funcionalidad;

                    if (func.ID_Funcionalidad == otraFunc.ID_Funcionalidad)
                    {
                        Funcionalidades_Checkboxlist.SetItemCheckState(i, CheckState.Checked);
                    }
                }
             }
         }

        private void Guardar_Button_Click(object sender, EventArgs e)
        {
            if (Nombre_Textbox.Text == "")
            {
                MessageBox.Show("Complete el nombre del nuevo Rol", "Error - Falta llenar algun campo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Nombre_Textbox.Focus();
            }
            else
            {
                int cant = Funcionalidades_Checkboxlist.CheckedItems.Count;
                if (cant < 1)
                {
                    MessageBox.Show("Selecciones al menos una funcionalidad", "Error - Falta llenar algun campo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<Funcionalidad> listaNuevasFunc = filtrarSeleccionadas();
                    //inserto nuevo rol
                    bool respuesta = Roles.insertarNuevoRol(Nombre_Textbox.Text, listaNuevasFunc);

                    if (respuesta == false)
                    {
                        MessageBox.Show("Ya existe un rol con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Nombre_Textbox.Focus();
                        Nombre_Textbox.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("Rol creado con éxito!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Interfaz.limpiarCheckboxList(Funcionalidades_Checkboxlist);
                        Interfaz.limpiarInterfaz(this);
                        Nombre_Textbox.Focus();
                    }

                }
            }
        }

        private List<Funcionalidad> filtrarSeleccionadas()
        {
            List<Funcionalidad> funcionalidadesNuevoRol = new List<Funcionalidad>();

            for (int i = 0; i < Funcionalidades_Checkboxlist.Items.Count; i++)
            {
                if (Funcionalidades_Checkboxlist.GetItemChecked(i))
                {
                    Funcionalidad func = Funcionalidades_Checkboxlist.Items[i] as Funcionalidad;
                    funcionalidadesNuevoRol.Add(func);
                }
            }
            return funcionalidadesNuevoRol;
        }
    }
}
