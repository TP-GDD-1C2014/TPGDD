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

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class BuscarPubliForm : Form
    {


        public BuscarPubliForm()
        {
            InitializeComponent();
            CenterToScreen();
            llenarCombos();
            Interfaz.limpiarInterfaz(this);

            esAdmin = Usuario.controlarRol(usuario.ID_User);

            //Cargar DataGridView con las publicaciones dependiendo si es Admin o no
            if (esAdmin == true)
            {
                dataGridView1.DataSource = Publicaciones.obtenerTodaPublicacion();
            }
            else
            {
                dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);
            }


        }

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

        bool esAdmin;
        /*public List<Publicacion> listaPublicaciones = new List<Publicacion>();
        public List<Publicacion> listaEnBlanco  = new List<Publicacion>();
        public Publicacion unaPublicacion { get; set; }     // = new Publicacion (); ? */

        /*private void BuscarPubliForm_Load(object sender, EventArgs e) 
        {
            Publicacion unaPubli = dataGridView1.CurrentRow.DataBoundItem as Publicacion;

        }*/

        private void filtrar_button_Click(object sender, EventArgs e)
        {
            //Obtener todos los filtros
            int cod_publi;
            if (CodPubli_textBox.Text == "")
            {
                cod_publi = -1;
            }
            else
            {
                cod_publi = Convert.ToInt32(CodPubli_textBox.Text);
            }
            //TODO Recordar de pasar como parámetro a filtrarPublicaciones el index de visibilidad!
            string visibilidad = Convert.ToString(Visibilidad_ComboBox.SelectedItem);
            int visibilidadIndex = Visibilidad_ComboBox.SelectedIndex;
            int idVendedor = usuario.ID_User;
            string descripcion = Descrip_TextBox.Text;

            int stock;
            if (StockInicial_TextBox.Text == "")
            {
                stock = -1;
            }
            else 
            {
                stock = Convert.ToInt32(StockInicial_TextBox.Text);     
            }

            //TODO Averiguar como filtrar por fecha (cuestion NULL)
            string dateString = null;
            DateTime fechaFin;
            if (dateTimePicker1.Text == " ")
            {
                fechaFin = Convert.ToDateTime(dateString);
            }else
            {
                fechaFin = Convert.ToDateTime(dateTimePicker1.Text);
            }

            DateTime fechaInic;
            if (dateTimePicker2.Text == " ")
            {
                fechaInic = Convert.ToDateTime(dateString);
            }
            else
            {
                fechaInic = Convert.ToDateTime(dateTimePicker2.Text);
            }

            string estado = Convert.ToString(Estado_ComboBox.SelectedItem);
            int estadoIndex = Estado_ComboBox.SelectedIndex;
            string tipoPubli = Convert.ToString(TipoPubli_ComboBox.SelectedItem);
            int tipoPubliIndex = TipoPubli_ComboBox.SelectedIndex;
            decimal precio;
            if (precio_textBox.Text == "")
            {
                precio = -1;
            }
            else
            {
                precio = Convert.ToDecimal(precio_textBox.Text);
            }
            bool permisoPreg = permisos_checkbox.Checked;

            Publicacion publi = new Publicacion(cod_publi, visibilidad, idVendedor, descripcion, stock, fechaFin, fechaInic, precio, estado, tipoPubli, permisoPreg, stock);
            

            //Filtrar Publicaciones y mostrar en dataGridView1
            if ((cod_publi == -1) && (visibilidadIndex == -1) && (descripcion == ""))
            {
                MessageBox.Show("Debe completar algún filtro para poder llevar a cabo este proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.DataSource = Publicaciones.filtrarPublicaciones(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);
            }
            //Recordar que los campos del datagridview NO pueden ser editables
        }

        private void limpiar_button_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
            if (esAdmin == true)
            {
                dataGridView1.DataSource = Publicaciones.obtenerTodaPublicacion();
            }
            else
            {
                dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);
            }

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
            //Al elegir una fila, dirigir a la form EditarPubliForm
            Publicacion unaPubli = dataGridView1.CurrentRow.DataBoundItem as Publicacion;

            //EditarPubliForm editForm = new EditarPubliForm(unaPubli);
            if ((unaPubli.Estado_Publicacion == "Borrador") || (unaPubli.Estado_Publicacion == "Publicada"))
            {
                Generar_Publicacion.GenerarPubliForm editForm = new Generar_Publicacion.GenerarPubliForm("Modificar", unaPubli);
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("El estado de la publicación no permite modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool esAdmin = Usuario.controlarRol(usuario.ID_User);
            //Cargar DataGridView con las publicaciones dependiendo si es Admin o no
            if (esAdmin == true)
            {
                dataGridView1.DataSource = Publicaciones.obtenerTodaPublicacion();
            }
            else
            {
                dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);
            }

            /*Generar_Publicacion.GenerarPubliForm editForm = new Generar_Publicacion.GenerarPubliForm("Modificar", unaPubli);
            editForm.ShowDialog();
            dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);*/
        }

        public void llenarCombos()
        {
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
            listaEstados.Add(new estadoComboBox("Publicada", 1));
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

        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BuscarPubliForm_Load(object sender, EventArgs e)
        {

        }

    }
}
