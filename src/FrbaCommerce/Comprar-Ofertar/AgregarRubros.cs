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

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class AgregarRubros : Form
    {
        private List<Rubro> rubros;
        public static List<Rubro> rubrosSeleccionados;


        public AgregarRubros(List<Rubro> rubrosFiltro)
        {
            InitializeComponent();
            this.CenterToScreen();
            rubrosSeleccionados = rubrosFiltro;
            rubros = Rubro.obtenerRubros();

            cblRubros.DisplayMember = "Descripcion";
            cblRubros.ValueMember = "ID_Rubro";
            cargarCheckboxlist();
            actualizarCheckboxList();
        }

        private void actualizarCheckboxList()
        {
            foreach (Rubro rubro in rubrosSeleccionados)
            {
                for (int i = 0; i < cblRubros.Items.Count; i++)
                {
                    Rubro otroRubro = cblRubros.Items[i] as Rubro;

                    if (rubro.ID_Rubro == otroRubro.ID_Rubro)
                    {
                        cblRubros.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        private void cargarCheckboxlist()
        {
            for (int i = 0; i < rubros.Count(); i++)
            {
                cblRubros.Items.Add(new Rubro(rubros[i].ID_Rubro, rubros[i].Descripcion));
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            guardarSeleccionados();
        }

        private void guardarSeleccionados()
        {
            rubrosSeleccionados.Clear();

            for (int i = 0; i < cblRubros.Items.Count; i++)
            {
                if (cblRubros.GetItemChecked(i))
                {
                    Rubro rubro = cblRubros.Items[i] as Rubro;
                    rubrosSeleccionados.Add(rubro);
                }
            }

        }

        private void btnNinguno_Click(object sender, EventArgs e)
        {
            foreach (int i in cblRubros.CheckedIndices)
            {
                cblRubros.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}
