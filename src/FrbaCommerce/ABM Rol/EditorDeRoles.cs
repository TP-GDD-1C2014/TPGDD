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
        Rol RolActual;
        string nombreAux;
        bool guardarNuevo;
        
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
                guardarNuevo = true;
            }

        }

        public EditorDeRoles(string modo, Rol unRol)
        {
            InitializeComponent();
            CenterToScreen();
            RolActual = unRol;
            if (modo == "modificar")
            {
                List<Funcionalidad> listaFuncQueTiene = Funcionalidades.obtenerFuncionalidades(BDSQL.iniciarConexion(), unRol.ID_Rol);
                List<Funcionalidad> listaTodasLasFunc = Funcionalidades.obtenerFuncionalidades(BDSQL.iniciarConexion(), 0);

                Nombre_Textbox.Text = unRol.Nombre;
                Nombre_Textbox.Focus();
                Nombre_Textbox.SelectAll();
                nombreAux = unRol.Nombre;
                Funcionalidades_Checkboxlist.DisplayMember = "Nombre";
                Funcionalidades_Checkboxlist.ValueMember = "ID_Funcionalidad";
                cargarCheckboxList(listaTodasLasFunc);
                actualizarCheckboxList(listaFuncQueTiene);
                //si esta habilitado, NO permitir cambiar check, caso contrario permitir.
                if (unRol.Habilitado)
                {
                    Habilitado_Checkbox.Enabled = false;
                }
                else Habilitado_Checkbox.Enabled = true;

                guardarNuevo = false;
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
                        if (guardarNuevo)
                        //inserto nuevo rol
                        {
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
                        else if (!guardarNuevo)
                        //modifico el rol actual
                        {
                            if (Habilitado_Checkbox.Checked)
                                Habilitado_Checkbox.Enabled = false;

                            List<Funcionalidad> listaFuncActuales = Funcionalidades.obtenerFuncionalidades(BDSQL.iniciarConexion(), RolActual.ID_Rol);

                            if (sonIguales(listaNuevasFunc,listaFuncActuales) && (Nombre_Textbox.Text == nombreAux) && (RolActual.Habilitado || !RolActual.Habilitado && !Habilitado_Checkbox.Checked))
                            {
                                MessageBox.Show("Por favor realice al menos un cambio", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                if (Habilitado_Checkbox.Checked)
                                    RolActual.Habilitado = true;

                                if (RolActual.Habilitado)
                                    Roles.updatearRol(Nombre_Textbox.Text, listaNuevasFunc, true, RolActual.ID_Rol);
                                else
                                    Roles.updatearRol(Nombre_Textbox.Text, listaNuevasFunc, false, RolActual.ID_Rol);

                                nombreAux = Nombre_Textbox.Text;

                                actualizarFuncionalidadPorRol(listaNuevasFunc, listaFuncActuales);

                                MessageBox.Show("Rol modificado con éxito! Puede seguir modificandolo o volver a ABM Rol", "Succes!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              
                            }

                            
                        }
                    }
                }
            
           
        }

        private bool sonIguales(List<Funcionalidad> listaNuevasFunc, List<Funcionalidad> listaFuncActuales)
        {
            

            if (listaFuncActuales.Count != listaNuevasFunc.Count)
                return false;
            for (int i = 0; i < listaFuncActuales.Count; i++)
            {

                bool encontro = false;
                for (int j = 0; j < listaNuevasFunc.Count; j++)
                {
                    if (listaNuevasFunc[j].ID_Funcionalidad == listaFuncActuales[i].ID_Funcionalidad)
                    {
                        //if (!listaNuevasFunc.Contains(listaFuncActuales[i]) | !listaFuncActuales.Contains(listaNuevasFunc[i]))
                        encontro = true;
                        break;
                    }
                }
                if (!encontro)
                    //delete
                    return false;
            }
            return true;
            
        }


        private void actualizarFuncionalidadPorRol(List<Funcionalidad> listaNuevasFunc, List<Funcionalidad> listaFuncActuales)
        {
            for (int i = 0; i < listaFuncActuales.Count; i++)
            {

                bool encontro = false;
                for (int j = 0; j < listaNuevasFunc.Count; j++)
                {
                    if (listaNuevasFunc[j].ID_Funcionalidad == listaFuncActuales[i].ID_Funcionalidad)
                    {
                        //if (!listaNuevasFunc.Contains(listaFuncActuales[i]) | !listaFuncActuales.Contains(listaNuevasFunc[i]))
                        encontro = true;
                        break;
                    }
                }
                if (!encontro)
                    //delete
                    Funcionalidades.BorrarFuncionalidadEnRol(nombreAux, listaFuncActuales[i].Nombre);
                    
            }
           

            for (int i = 0; i < listaNuevasFunc.Count; i++)
            {

                bool encontro = false;
                for (int j = 0; j < listaFuncActuales.Count; j++)
                {
                    if (listaFuncActuales[j].ID_Funcionalidad == listaNuevasFunc[i].ID_Funcionalidad)
                    {
                        //if (!listaNuevasFunc.Contains(listaFuncActuales[i]) | !listaFuncActuales.Contains(listaNuevasFunc[i]))
                        encontro = true;
                        break;
                    }
                }
                if (!encontro)
                    //agregar
                    Funcionalidades.AgregarFuncionalidadEnRol(nombreAux, listaNuevasFunc[i]);
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
