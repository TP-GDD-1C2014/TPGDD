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
using FrbaCommerce.Generar_Publicacion;
using System.Data.SqlClient;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class BuscarPubliForm : Form
    {
        //Combobox Visibilidad (numeric(18,0) )
        public class visibilidadComboBox
        {
            public string Nombre_Visibilidad { get; set; }
            public int Cod_Visibilidad { get; set; }
            public visibilidadComboBox(string nombre, int cod)
            {
                Nombre_Visibilidad = nombre;
                Cod_Visibilidad = cod;
            }
            public override string ToString()
            {
                return Nombre_Visibilidad;
            }
        }
        //Combobox Estado (tinyint)
        public class estadoComboBox
        {
            public string Nombre_Estado { get; set; }
            public int Cod_Estado { get; set; }
            public estadoComboBox(string nombre, int cod)
            {
                Nombre_Estado = nombre;
                Cod_Estado = cod;
            }
            public override string ToString()
            {
                return Nombre_Estado;
            }
        }
        //Combobox Tipo (tinyint)
        public class tipoComboBox
        {
            public string Nombre_Tipo { get; set; }
            public int Cod_Tipo { get; set; }
            public tipoComboBox(string nombre, int cod)
            {
                Nombre_Tipo = nombre;
                Cod_Tipo = cod;
            }
            public override string ToString()
            {
                return Nombre_Tipo;
            }
        }
        //Combobox Preguntas (bit)
        public class permitirPreg_combobox
        {
            public string Permiso_Pregunta { get; set; }
            public int Cod_Pregunta { get; set; }
            public permitirPreg_combobox(string nombre, int cod)
            {
                Permiso_Pregunta = nombre;
                Cod_Pregunta = cod;
            }
            public override string ToString()
            {
                return Permiso_Pregunta;
            }
        }

        //Obtiene el usuario loggeado
        Clases.Usuario usuario = FrbaCommerce.Common.Interfaz.usuario;
        /*public List<Publicacion> listaPublicaciones = new List<Publicacion>();
        public List<Publicacion> listaEnBlanco  = new List<Publicacion>();
        public Publicacion unaPublicacion { get; set; }     // = new Publicacion (); ? */

        public BuscarPubliForm()
        {
            InitializeComponent();

            //Cargar DataGridView con las publicaciones
            dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);

            //Crear listas para los combobox
            List<visibilidadComboBox> listaVisibilidades = new List<visibilidadComboBox>();
            listaVisibilidades.Add(new visibilidadComboBox("Platino", 0));
            listaVisibilidades.Add(new visibilidadComboBox("Oro", 1));
            listaVisibilidades.Add(new visibilidadComboBox("Plata", 2));
            listaVisibilidades.Add(new visibilidadComboBox("Bronce", 3));
            listaVisibilidades.Add(new visibilidadComboBox("Gratis", 4));
            this.Visibilidad_ComboBox.DataSource = listaVisibilidades;
            this.Visibilidad_ComboBox.DisplayMember = "Nombre_Visibilidad";
            this.Visibilidad_ComboBox.ValueMember = "Cod_Visibilidad";
            this.Visibilidad_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_ComboBox_SelectedIndexChanged);

            List<estadoComboBox> listaEstados = new List<estadoComboBox>();
            listaEstados.Add(new estadoComboBox("Borrador", 0));
            listaEstados.Add(new estadoComboBox("Activa", 1));
            listaEstados.Add(new estadoComboBox("Pausada", 2));
            listaEstados.Add(new estadoComboBox("Finalizada", 3));
            this.Estado_ComboBox.DataSource = listaEstados;
            this.Estado_ComboBox.DisplayMember = "Nombre_Estado";
            this.Estado_ComboBox.ValueMember = "Cod_Estado";
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);
 
            List<tipoComboBox> listaTipos = new List<tipoComboBox>();
            listaTipos.Add(new tipoComboBox("Inmediata", 0));
            listaTipos.Add(new tipoComboBox("Subasta", 1));
            this.TipoPubli_ComboBox.DataSource = listaTipos;
            this.TipoPubli_ComboBox.DisplayMember = "Nombre_Tipo";
            this.TipoPubli_ComboBox.ValueMember = "Cod_Tipo";
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);

        }

        private void BuscarPubliForm_Load(object sender, EventArgs e)
        {
            Publicacion unaPublicacion = dataGridView1.CurrentRow.DataBoundItem as Publicacion;
            EditarPubliForm editarPubliForm = new EditarPubliForm();
            editarPubliForm.ShowDialog();

            /*dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSourceChanged += new EventHandler(dataGridView1_DataSourceChanged);
            dataGridView1.DataSource = Conseguir la publicacion (_publiManager?)*/

        }

        void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            /*var dataSource = dataGridView1.DataSource as IList;
            Resultados_label.Text = dataSource.Count.ToString();*/

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void CodPubli_TextChanged(object sender, EventArgs e)
        {
        }

        private void Visibilidad_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Descrip_TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void StockInicial_TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Estado_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void TipoPubli_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //Fecha Vencimiento
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //Fecha Inicial
        }

        private void precio_textBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void buscar_button_Click(object sender, EventArgs e)
        {
            //Obtener todos los filtros
            //TODO Verificar que campos está completos (recordar que son filtros ACUMULATIVOS)
            int cod_publi = Convert.ToInt32(CodPubli_textBox.Text);
            var visibilidad = (Visibilidad)Visibilidad_ComboBox.SelectedValue;
            int idVendedor = usuario.ID_User;
            string descripcion = Descrip_TextBox.Text;
            int stock = Convert.ToInt32(StockInicial_TextBox.Text);
            //Obtener fechaFin y fechaInic
            DateTime fechaFin = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime fechaInic = Convert.ToDateTime(dateTimePicker2.Text);
            var estado = (int)Estado_ComboBox.SelectedValue;
            var tipoPubli = (int)TipoPubli_ComboBox.SelectedValue;
            int precio = Convert.ToInt32(precio_textBox.Text);
            //Falta permisoPreg (problema con combobox)

            //TODO Revisar parámetros
            //Publicacion publi = new Publicacion(cod_publi, visibilidad, idVendedor, descripcion, stock, fechaFin, fechaInic, estado, precio, tipoPubli, permisoPreg, stock);

            //Buscar Publicaciones y mostrar en dataGridView1
            //nuevaPubli.buscarPublicacion(cod_publi,idVendedor,visibilidad,descripcion,stock,estado,tipoPubli);

            //Recordar que los campos del datagridview NO pueden ser editables
        }

        private void limpiar_button_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
            //Visibilidad_ComboBox.Text = "";
            //Estado_ComboBox.Text = "";
            //TipoPubli_ComboBox.Text = "";
            //dataGridView1.DataSource = listaEnBlanco;

        }

        private void modificar_button_Click(object sender, EventArgs e)
        {
            //Al elegir una fila, dirigir a la form EditarPubliForm


        }

        private void borrar_button_Click(object sender, EventArgs e)
        {
            Publicacion unaPubli = dataGridView1.CurrentRow.DataBoundItem as Publicacion;

            string mensaje = string.Format("¿Desea confirmar la eliminacion de la publicación?");
            DialogResult resultado = MessageBox.Show(mensaje, "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                Publicaciones.eliminarPublicacion(unaPubli);
                dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);
            }


            }

        private void modificar_button_Click_1(object sender, EventArgs e)
        {
            Publicacion unaPubli = dataGridView1.CurrentRow.DataBoundItem as Publicacion;
            //string modo = "Modificar";
            //GenerarPubliForm generarForm = new GenerarPubliForm(modo, unaPubli);
            //generarForm.ShowDialog();

            dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
}
