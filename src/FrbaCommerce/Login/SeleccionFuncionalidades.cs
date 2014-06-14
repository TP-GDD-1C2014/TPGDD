using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using FrbaCommerce.Clases;

namespace FrbaCommerce.Login
{
    public partial class SeleccionFuncionalidades : Form
    {
        public Clases.Usuario usuario { get; set; }
        public Clases.Rol rolActual { get; set; }

        public class itemComboBox
        {
            public string Nombre_Funcionalidad { get; set; }
            public int ID_Funcionalidad { get; set; }

            public itemComboBox(string nombre, int id)
            {
                Nombre_Funcionalidad = nombre;
                ID_Funcionalidad = id;
            }
            public override string ToString()
            {
                return Nombre_Funcionalidad;
            }
        }

        public SeleccionFuncionalidades(Clases.Usuario usuario, int idRol, Boolean bypass)
        {
            //Genera el diccionario de tipoPublicacion, estadoPublicacion, tipoOperacion y Visibilidades
            Interfaz.generarDiccionarios();
            this.usuario = usuario;
            var rolQuery = from rol in this.usuario.Roles where rol.ID_Rol == idRol select rol;
            foreach (var item in rolQuery)
            {
                this.rolActual = item;
            }

            InitializeComponent();
            this.CenterToScreen();
            this.AcceptButton = continuar;

            cbFuncionalidades.DisplayMember = "Nombre_Funcionalidad";
            cbFuncionalidades.ValueMember = "ID_Funcionalidad";
            cbFuncionalidades.DropDownStyle = ComboBoxStyle.DropDownList;

            listarFuncionalidades();

            if (!bypass)
            {
                volver.Visible = true;
            }
            else
            {
                volver.Visible = false;
            }
        }

        public void listarFuncionalidades()
        {
            if (rolActual.funcionalidades.Count != 0)
            {
                cbFuncionalidades.Items.Add(new itemComboBox("Cambiar Contraseña", -2));
                for (int i = 0; i < rolActual.funcionalidades.Count; i++)
                {
                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 1)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Clientes", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 2)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Empresas", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 3)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Roles", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 4)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Rubros", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 5)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Visibilidades", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 6)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Generar Publicación", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 7)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Editar Publicación", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 8)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Gestionar Preguntas", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 9)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Comprar/Ofertar", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 10)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Calificar", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 11)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Historial de operaciones", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 12)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Facturar", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 13)
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Listado Estadístico", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }
                }
            }
        }

        private void continuar_Click(object sender, EventArgs e)
        {
            if (cbFuncionalidades.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una funcionalidad.", "Error");
            }
            else
            {
                itemComboBox seleccion = cbFuncionalidades.SelectedItem as itemComboBox;
                switch (seleccion.ID_Funcionalidad)
                {
                    case -2:
                        CambiarPassword formPass = new CambiarPassword(false);
                        formPass.Show();
                        break;
                    case 1:
                        Abm_Cliente.ABMClientes form1 = new Abm_Cliente.ABMClientes(this);
                        this.Hide();
                        form1.Show();
                        break;
                    case 2:
                        Abm_Empresa.ABMEmpresas form2 = new Abm_Empresa.ABMEmpresas(this);
                        this.Hide();
                        form2.Show();
                        break;
                    case 3:
                        ABM_Rol.AbmRolForm form3 = new ABM_Rol.AbmRolForm();
                        this.Hide();
                        form3.ShowDialog();
                        this.Show();
                        break;
                    case 4:
                        Abm_Rubro.ABMRubro form4 = new Abm_Rubro.ABMRubro(this);
                        this.Hide();
                        form4.Show();
                        break;
                    case 5:
                        Abm_Visibilidad.ABMVisibilidad form5 = new Abm_Visibilidad.ABMVisibilidad();
                        this.Hide();
                        form5.ShowDialog();
                        this.Show();
                        break;
                    case 6:
                        //Generar_Publicacion.GenerarPubliForm form6 = new Generar_Publicacion.GenerarPubliForm(this.usuario);
                        string modo = "Nuevo";
                        Generar_Publicacion.GenerarPubliForm form6 = new Generar_Publicacion.GenerarPubliForm(modo);
                        this.Hide();
                        form6.ShowDialog();
                        this.Show();
                        break;
                    case 7:
                        Editar_Publicacion.BuscarPubliForm form7 = new Editar_Publicacion.BuscarPubliForm(this);
                        this.Hide();
                        form7.ShowDialog();
                        this.Show();
                        break;
                    case 8:
                        Gestion_de_Preguntas.GestionPreguntas form8 = new Gestion_de_Preguntas.GestionPreguntas();
                        this.Hide();
                        form8.ShowDialog();
                        this.Show();
                        break;
                    case 9:
                        Comprar_Ofertar.ComprarOfertar form9 = new Comprar_Ofertar.ComprarOfertar();
                        this.Hide();
                        form9.ShowDialog();
                        this.Show();
                        break;
                    case 10:
                        Calificar_Vendedor.CalificarVendedor form10 = new Calificar_Vendedor.CalificarVendedor();
                        this.Hide();
                        form10.ShowDialog();
                        this.Show();
                        break;
                    case 11:
                        Historial_Cliente.SeleccionHistorial form11 = new Historial_Cliente.SeleccionHistorial(this);
                        this.Hide();
                        form11.Show();
                        break;
                    case 12:
                        Facturar_Publicaciones.FacturarForm form12 = new Facturar_Publicaciones.FacturarForm();
                        this.Hide();
                        form12.ShowDialog();
                        this.Show();
                        break;
                    case 13:
                        Listado_Estadistico.ListadoEstadisticoForm form13 = new Listado_Estadistico.ListadoEstadisticoForm();
                        this.Hide();
                        form13.ShowDialog();
                        this.Show();
                        break;
                }
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            SeleccionRoles formRoles = new SeleccionRoles(Interfaz.usuario);
            this.Hide();
            formRoles.Show();
        }

        private void SeleccionFuncionalidades_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                
                    Environment.Exit(0);
                
            }
            
        }  

    }
}
