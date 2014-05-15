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


        public SeleccionFuncionalidades(Clases.Usuario usuario, int idRol)
        {
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
        }

        public void listarFuncionalidades()
        {
            if (rolActual.funcionalidades.Count != 0)
            {
                for (int i = 0; i < rolActual.funcionalidades.Count; i++)
                {
                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 1) // Administrar Clientes
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Clientes", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 2) // Administrar Empresas
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Empresas", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 3) // Administrar Roles
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Roles", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 4) // Administrar Rubros
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Rubros", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 5) // Administrar Visibilidades
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Administrar Visibilidades", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 6) // Generar Publicación
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Generar Publicación", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 7) // Editar Publicación
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Editar Publicación", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 8) // Gestionar Preguntas
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Gestionar Preguntas", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 9) // Comprar / Ofertar
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Comprar/Ofertar", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 10) // Calificar
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Calificar", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 11) // Historial de operaciones
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Historial de operaciones", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 12) // Facturar
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Facturar", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }

                    if (rolActual.funcionalidades[i].ID_Funcionalidad == 13) // Listado Estadístico
                    {
                        cbFuncionalidades.Items.Add(new itemComboBox("Listado Estadístico", rolActual.funcionalidades[i].ID_Funcionalidad));
                    }
                }
            }
        }

        private void SeleccionFuncionalidades_Load(object sender, EventArgs e)
        {

        }
    }
}
