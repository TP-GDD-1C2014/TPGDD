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
        Rol RolActual; //Rol seleccionado en el datagridview, como objeto Rol
        string nombreAux; //aux para permitir varias actualizaciones en Modificar, sin tener que salir y entrar, y que no permita poner el mismo nombre.
        bool guardarNuevo; //Flag para saber al momento de apretar el boton Guardar, si es nuevo o modificar (ya que comparten el mismo form)
        
        //Constructor modo "nuevo"
        public EditorDeRoles(string modo)
        {
            InitializeComponent();
            CenterToScreen();
            if (modo == "nuevo")
            {
                List<Funcionalidad> lista = Funcionalidades.obtenerFuncionalidades(BDSQL.iniciarConexion() , 0); //0 son todas

                Funcionalidades_Checkboxlist.DisplayMember = "Nombre"; 
                Funcionalidades_Checkboxlist.ValueMember = "ID_Funcionalidad";
                cargarCheckboxList(lista);

                Habilitado_Checkbox.Enabled = false;
                guardarNuevo = true;
            }

        }

        //Constructor modo "modificar", necesito los datos del Rol seleccionado
        public EditorDeRoles(string modo, Rol unRol)
        {
            InitializeComponent();
            CenterToScreen();
            RolActual = unRol;

            if (modo == "modificar")
            {
                List<Funcionalidad> listaFuncQueTiene = Funcionalidades.obtenerFuncionalidades(BDSQL.iniciarConexion(), unRol.ID_Rol);
                List<Funcionalidad> listaTodasLasFunc = Funcionalidades.obtenerTodasLasFuncionalidades(BDSQL.iniciarConexion());

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
           }
        }

        //Carga el checkbox con todas las funcionalidades
        private void cargarCheckboxList(List<Funcionalidad> lista)
        {
            for (int i = 0; i < lista.Count(); i++)
            {
                Funcionalidades_Checkboxlist.Items.Add(new Funcionalidad(lista[i].ID_Funcionalidad, lista[i].Nombre));
            }
        }

        //Actualiza el checkbox con todas las funcionalidades que tiene en la BD, checkeadas.
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
                    //TODO No estoy seguro si esto esta prohibido! por las dudas obligo a que ingrese una.
                    int cant = Funcionalidades_Checkboxlist.CheckedItems.Count;
                    if (cant < 1)
                    {
                        MessageBox.Show("Selecciones al menos una funcionalidad", "Error - Falta llenar algun campo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Me quedo con las funcionalidades que estan checkeadas
                        List<Funcionalidad> listaNuevasFunc = filtrarSeleccionadas();

                        if (guardarNuevo)
                        //Inserto un nuevo rol
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
                                MessageBox.Show("Rol creado con éxito! Puede seguir creando roles.", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Interfaz.limpiarCheckboxList(Funcionalidades_Checkboxlist);
                                Interfaz.limpiarInterfaz(this);
                                Nombre_Textbox.Focus();
                            }
                        }
                        else if (!guardarNuevo)
                        //Modifico el rol actualmente seleccionado
                        {
                            //Esto es para que si modifico el rol una vez, y lo paso de inhabilitado-->habilitado y SIGUE modificando, ya no le deje cambiar el checkbox habilitado
                            if (Habilitado_Checkbox.Checked)
                                Habilitado_Checkbox.Enabled = false;

                            List<Funcionalidad> listaFuncActuales = Funcionalidades.obtenerFuncionalidades(BDSQL.iniciarConexion(), RolActual.ID_Rol);

                            //Me fijo que haya hecho al menos un cambio.. el OR (||) es por si entro como habilitado o deshabilitado.
                            if (sonIguales(listaNuevasFunc, listaFuncActuales) && (Nombre_Textbox.Text == nombreAux) && (RolActual.Habilitado || !RolActual.Habilitado && !Habilitado_Checkbox.Checked))
                            {
                                MessageBox.Show("Por favor realice al menos un cambio", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                //actualizo al RolActual que fue habilitado (en caso de checkear el box), para que si sigue modificando ya se lo considere habilitado
                                if (Habilitado_Checkbox.Checked)
                                    RolActual.Habilitado = true;

                                
                                //UPDATE de los cambios realizados, con cuidado especial en Habilitado. Con que haya un cambio, actualizo todo, por mas que sean redundantes
                                //dos de los 3 campos (por ejemplo), es un solo acceso a la BD.
                                if (RolActual.Habilitado)
                                    Roles.updatearRol(Nombre_Textbox.Text, listaNuevasFunc, true, RolActual.ID_Rol);
                                else
                                    Roles.updatearRol(Nombre_Textbox.Text, listaNuevasFunc, false, RolActual.ID_Rol);
                                

                                //TODO creo que es al pedo el aux
                                nombreAux = Nombre_Textbox.Text;

                                //UPDATE de FUNCIONALIDADES_X_ROL - Aca si pongo un if, ya que son muchos accesos a la BD y si son iguales no son es necesario.
                                if (!sonIguales(listaNuevasFunc, listaFuncActuales))
                                actualizarFuncionalidadPorRol(listaNuevasFunc, listaFuncActuales);

                                MessageBox.Show("Rol modificado con éxito! Puede seguir modificandolo o volver a ABM Rol", "Succes!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              
                            }

                            
                        }
                    }
                }
            
           
        }

        //Se fija si las dos listas de funcionalidades dadas son iguales (respecto a ID_Funcionalidad)
        public static bool sonIguales(List<Funcionalidad> listaNuevasFunc, List<Funcionalidad> listaFuncActuales)
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
                        encontro = true;
                        break;
                    }
                }

                if (!encontro)
                    return false;
            }
            return true;
        }

        //Dadas las funcionalidades que estan actualmente en la BD y las que selecciono nuevas (o saco algunas que ya estaban), Delete o Insert
        private void actualizarFuncionalidadPorRol(List<Funcionalidad> listaNuevasFunc, List<Funcionalidad> listaFuncActuales)
        {
            for (int i = 0; i < listaFuncActuales.Count; i++)
            {
                bool encontro = false;

                for (int j = 0; j < listaNuevasFunc.Count; j++)
                {
                    if (listaNuevasFunc[j].ID_Funcionalidad == listaFuncActuales[i].ID_Funcionalidad)
                    {
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
                        encontro = true;
                        break;
                    }
                }
                if (!encontro)
                    //agregar
                    Funcionalidades.AgregarFuncionalidadEnRol(nombreAux, listaNuevasFunc[i]);
            }
        }

        //Devuelve Lista de funcionalidades que estan seleccionadas en el checkboxlist
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
