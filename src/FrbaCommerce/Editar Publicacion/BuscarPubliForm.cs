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
using FrbaCommerce.Login;
using System.Data.SqlClient;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class BuscarPubliForm : Form
    {
        public SeleccionFuncionalidades formAnterior { get; set; }
        
        public BuscarPubliForm(SeleccionFuncionalidades _formAnterior)
        {
            this.formAnterior = _formAnterior;
            InitializeComponent();
            CenterToScreen();
            llenarCombos();
            Interfaz.limpiarInterfaz(this);

            //Comprueba si el usuario es administrador o no
            esAdmin = Usuario.controlarRol(usuario.ID_User);

            //Cargar DataGridView con las publicaciones dependiendo si es Admin o no
            if (esAdmin == true){
                dataGridView1.DataSource = Publicaciones.obtenerTodaPublicacion();
            }
            else{
                dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);
            }

            //No permitir cambios en el DataGridView
            dataGridView1.ReadOnly = true;

            //Setea los text de las fechas en nulo, gracias al checkbox
            if (!fechaVenc_checkBox.Checked){
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }
            else{
                dateTimePicker1.CustomFormat = null;
                dateTimePicker1.Format = DateTimePickerFormat.Long;
            }
            if (!fechaInic_checkBox.Checked){
                dateTimePicker2.CustomFormat = " ";
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
            }
            else{
                dateTimePicker2.CustomFormat = null;
                dateTimePicker2.Format = DateTimePickerFormat.Long;
            }
        }



        //Combobox Visibilidad (numeric(18,0) )
        public class visibilidadComboBox
        {
            public string Descripcion_Visibilidad { get; set; }
            public int Cod_Visibilidad { get; set; }
            public visibilidadComboBox(string descripcion, int cod)
            {
                Descripcion_Visibilidad = descripcion;
                Cod_Visibilidad = cod;
            }
            public override string ToString()
            {
                return Descripcion_Visibilidad;
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



        //Obtiene el usuario loggeado
        Clases.Usuario usuario = FrbaCommerce.Common.Interfaz.usuario; 
        bool esAdmin;



        //BOTON FILTRAR
        private void filtrar_button_Click(object sender, EventArgs e)
        {
            //Obtener todos los filtros
            int cod_publi;
            if (CodPubli_textBox.Text == ""){
                cod_publi = -1;
            }
            else{
                cod_publi = Convert.ToInt32(CodPubli_textBox.Text);
            }

            string visibilidad = Convert.ToString(Visibilidad_ComboBox.SelectedItem);
            int visibilidadIndex = Visibilidad_ComboBox.SelectedIndex;
            int idVendedor = usuario.ID_User;
            string descripcion = Descrip_TextBox.Text;

            int stock;
            if (StockInicial_TextBox.Text == ""){
                stock = -1;
            }
            else {
                stock = Convert.ToInt32(StockInicial_TextBox.Text);     
            }

            DateTime fechaFin;
            bool fechaFinNula;
            if (dateTimePicker1.Text == " "){
                fechaFinNula = true;
                fechaFin = Convert.ToDateTime(null);
            }
            else{
                fechaFinNula = false;
                fechaFin = Convert.ToDateTime(dateTimePicker1.Text);
            }

            DateTime fechaInic;
            bool fechaInicNula;
            if (dateTimePicker2.Text == " "){
                fechaInicNula = true;
                fechaInic = Convert.ToDateTime(null);
            }
            else{
                fechaInicNula = false;
                fechaInic = Convert.ToDateTime(dateTimePicker2.Text);
            }
            
            string estado = Convert.ToString(Estado_ComboBox.SelectedItem);
            int estadoIndex = Estado_ComboBox.SelectedIndex;
            string tipoPubli = Convert.ToString(TipoPubli_ComboBox.SelectedItem);
            int tipoPubliIndex = TipoPubli_ComboBox.SelectedIndex;
            decimal precio;
            if (precio_textBox.Text == ""){
                precio = -1;
            }
            else{
                precio = Convert.ToDecimal(precio_textBox.Text);
            }

            //Recordar que el filtro de permiso de preguntas fue removido
            //bool permisoPreg = permisos_checkbox.Checked;
            bool permisoPreg = false;

            //Crea una publicacion a partir de los datos seleccionados
            Publicacion publi = new Publicacion(cod_publi, visibilidad, idVendedor, descripcion, stock, fechaFin, fechaInic, precio, estado, tipoPubli, permisoPreg, stock);
            
            //Comprueba que haya por lo menos 1 campo completo
            if ((cod_publi == -1) && (visibilidadIndex == -1) && (descripcion == "") && (stock == -1) && (precio == -1) && (estadoIndex == -1) && (tipoPubliIndex == -1) && fechaFinNula == true && fechaInicNula == true)
            {
                MessageBox.Show("Debe completar algún filtro para poder llevar a cabo esta acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Filtrar Publicaciones y mostrar en dataGridView1
                dataGridView1.DataSource = Publicaciones.filtrarPublicaciones(publi, visibilidad, estadoIndex, tipoPubliIndex, fechaFinNula, fechaInicNula, esAdmin);
            }
        }



        //BOTON LIMPIAR
        private void limpiar_button_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
            //Re-checkea si el usuario es admin o no, para saber cómo completar el datagridview
            if (esAdmin == true)
            {
                dataGridView1.DataSource = Publicaciones.obtenerTodaPublicacion();
            }
            else
            {
                dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);
            }

        }



        //BOTON BORRAR
        private void borrar_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {

                //Obtiene la publicacion seleccionada
                Publicacion unaPubli = dataGridView1.CurrentRow.DataBoundItem as Publicacion;

                string mensaje = string.Format("¿Desea confirmar la eliminacion de la publicación?");
                DialogResult resultado = MessageBox.Show(mensaje, "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    //Elimina publicacion de la BD y vuelve a cargar el datagrid
                    List<int> listaRubrosDePublicacion = Rubro.obtenerRubrosDePublicacion(unaPubli.Cod_Publicacion);
                    Rubro.eliminarRubroPublicacion(listaRubrosDePublicacion, unaPubli.Cod_Publicacion);
                    Publicaciones.eliminarPublicacion(unaPubli);

                    string codVis = unaPubli.Cod_Visibilidad;
                    string estado = unaPubli.Estado_Publicacion;
                    if ((codVis == "Gratis") && (estado == "Publicada"))
                    {
                        usuario.restarPubliGratuita();
                    }

                    //Re-checkea si el usuario es admin o no, para saber cómo completar el datagridview
                    if (esAdmin == true)
                    {
                        dataGridView1.DataSource = Publicaciones.obtenerTodaPublicacion();
                    }
                    else
                    {
                        dataGridView1.DataSource = Publicaciones.obtenerPublicaciones(usuario.ID_User);
                    }
                }
            }else
            {
                MessageBox.Show("Por favor, seleccione alguna publicación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



        //BOTON VOLVER
        private void volver_button_Click(object sender, EventArgs e)
        {
            this.Close();
            this.formAnterior.Show();
        }



        //BOTON MODIFICAR
        private void modificar_button_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                //Al elegir una fila, dirigir a la form EditarPubliForm
                Publicacion unaPubli = dataGridView1.CurrentRow.DataBoundItem as Publicacion;

                //Dependiendo el estado seleccionado, permite o no su modificación
                if ((unaPubli.Estado_Publicacion == "Borrador") || (unaPubli.Estado_Publicacion == "Publicada"))
                {
                    //Invoca la form de Generar Publicación
                    Generar_Publicacion.GenerarPubliForm editForm = new Generar_Publicacion.GenerarPubliForm("Modificar", unaPubli);

                    this.Hide();
                    editForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("El estado o tipo de la publicación no permite modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Averigua si el usuario es o no Admin
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
            }
            else
            {
                MessageBox.Show("Por favor, seleccione alguna publicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        public void llenarCombos()
        {
            //Llena Combobox de visibilidad
            List<Visibilidad> listaVisibilidades = Visibilidad.ObtenerVisibilidades();
            for (int i = 0; i < listaVisibilidades.Count(); i++)
            {
                this.Visibilidad_ComboBox.Items.Add(new visibilidadComboBox((listaVisibilidades[i].Descripcion), i));
            }
            this.Visibilidad_ComboBox.DisplayMember = "Descripcion_Visibilidad";
            this.Visibilidad_ComboBox.ValueMember = "Cod_Visibilidad";
            this.Visibilidad_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_ComboBox_SelectedIndexChanged);

            //Llena Combobox de estado
            List<estadoComboBox> listaEstados = new List<estadoComboBox>();
            listaEstados.Add(new estadoComboBox("Borrador", 0));
            listaEstados.Add(new estadoComboBox("Publicada", 1));
            listaEstados.Add(new estadoComboBox("Pausada", 2));
            listaEstados.Add(new estadoComboBox("Finalizada", 3));
            this.Estado_ComboBox.DataSource = listaEstados;
            this.Estado_ComboBox.DisplayMember = "Nombre_Estado";
            this.Estado_ComboBox.ValueMember = "Cod_Estado";
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);

            //Llena Combobox de tipo
            List<tipoComboBox> listaTipos = new List<tipoComboBox>();
            listaTipos.Add(new tipoComboBox("Subasta", 0));
            listaTipos.Add(new tipoComboBox("Compra Inmediata", 1));
            this.TipoPubli_ComboBox.DataSource = listaTipos;
            this.TipoPubli_ComboBox.DisplayMember = "Nombre_Tipo";
            this.TipoPubli_ComboBox.ValueMember = "Cod_Tipo";
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);

            //Llena Combobox de rubro
            /*List<Rubro> listaRubros = Rubro.obtenerRubros();
            for (int i = 0; i < listaRubros.Count(); i++)
            {
                this.Rubro_comboBox.Items.Add(new rubroComboBox((listaRubros[i].Descripcion), listaRubros[i].ID_Rubro));
            }

            this.Rubro_comboBox.DisplayMember = "Nombre_Rubro";
            this.Rubro_comboBox.ValueMember = "Cod_Rubro";
            this.Rubro_comboBox.SelectedIndex = 0;
            this.Rubro_comboBox.SelectedIndexChanged += new System.EventHandler(this.Rubro_comboBox_SelectedIndexChanged);*/


            //Inicializa fechas según la config
            dateTimePicker1.Text = Convert.ToString(Interfaz.obtenerFecha());
            dateTimePicker2.Text = Convert.ToString(Interfaz.obtenerFecha());
        }


        void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
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

        private void Rubro_comboBox_SelectedIndexChanged(object sender, EventArgs e)
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


        private void fechaVenc_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //Dependiendo el checkbox, habilita o no el filtro por fecha de vencimiento
            if (!fechaVenc_checkBox.Checked)
            {
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dateTimePicker1.CustomFormat = null;
                dateTimePicker1.Format = DateTimePickerFormat.Long;
            }
        }


        private void fechaInic_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //Dependiendo el checkbox, habilita o no el filtro por fecha inicial
            if (!fechaInic_checkBox.Checked)
            {
                dateTimePicker2.CustomFormat = " ";
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dateTimePicker2.CustomFormat = null;
                dateTimePicker2.Format = DateTimePickerFormat.Long;
            }
        }



        //Permitir unicamente el ingreso de datos numéricos enteros al textbox requerido
        private void Enteros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Denegar el ingreso de datos no numéricos al textbox de Peso
        private void precio_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (precio_textBox.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == ',' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }



    }
}
