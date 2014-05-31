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
    public partial class EditarPubliForm : Form
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
        public class preguntasComboBox
        {
            public string Permiso_Pregunta { get; set; }
            public int Cod_Pregunta { get; set; }
            public preguntasComboBox(string nombre, int cod)
            {
                Permiso_Pregunta = nombre;
                Cod_Pregunta = cod;
            }
            public override string ToString()
            {
                return Permiso_Pregunta;
            }
        }

        public Clases.Usuario usuario { get; set; }

        public EditarPubliForm()
        {
            //Obtiene el usuario loggeado
            Interfaz.loguearUsuario(usuario);

            InitializeComponent();

            //Todos los campos deben ser completados con la selección realizada en BuscarPubliForm

            //Si el estado es borrador => permitir modificar todos los campos
            //si esl estado es activa (publicada) y el tipo es compra inmediata => permitir modificar estado a pausada o finalizada e incrementar stock

            //Crear listas para los combobox
            List<visibilidadComboBox> listaVisibilidades = new List<visibilidadComboBox>();
            listaVisibilidades.Add(new visibilidadComboBox("Platino", 0));
            listaVisibilidades.Add(new visibilidadComboBox("Oro", 1));
            listaVisibilidades.Add(new visibilidadComboBox("Plata", 2));
            listaVisibilidades.Add(new visibilidadComboBox("Bronce", 3));
            listaVisibilidades.Add(new visibilidadComboBox("Gratis", 4));
            this.Visibilidad_Combobox.DataSource = listaVisibilidades;
            this.Visibilidad_Combobox.DisplayMember = "Nombre_Visibilidad";
            this.Visibilidad_Combobox.ValueMember = "Cod_Visibilidad";
            this.Visibilidad_Combobox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_Combobox_SelectedIndexChanged);
            //this.Visibilidad_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<estadoComboBox> listaEstados = new List<estadoComboBox>();
            listaEstados.Add(new estadoComboBox("Borrador", 0));
            listaEstados.Add(new estadoComboBox("Activa", 1));
            listaEstados.Add(new estadoComboBox("Pausada", 2));
            listaEstados.Add(new estadoComboBox("Finalizada", 3));
            this.Estado_Combobox.DataSource = listaEstados;
            this.Estado_Combobox.DisplayMember = "Nombre_Estado";
            this.Estado_Combobox.ValueMember = "Cod_Estado";
            this.Estado_Combobox.SelectedIndexChanged += new System.EventHandler(this.Estado_Combobox_SelectedIndexChanged);
            //Estado_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<tipoComboBox> listaTipos = new List<tipoComboBox>();
            listaTipos.Add(new tipoComboBox("Inmediata", 0));
            listaTipos.Add(new tipoComboBox("Subasta", 1));
            this.Tipo_Combobox.DataSource = listaTipos;
            this.Tipo_Combobox.DisplayMember = "Nombre_Tipo";
            this.Tipo_Combobox.ValueMember = "Cod_Tipo";
            this.Tipo_Combobox.SelectedIndexChanged += new System.EventHandler(this.Tipo_Combobox_SelectedIndexChanged);
            //TipoPubli_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            /*
            List<preguntasComboBox> listaRespuestas = new List<preguntasComboBox>();
            listaRespuestas.Add(new preguntasComboBox("No", 0));
            listaRespuestas.Add(new preguntasComboBox("Si", 1));
            this.PermisoPreg_Combobox.DataSource = listaRespuestas;
            this.PermisoPreg_Combobox.DisplayMember = "Permiso_Pregunta";
            this.PermisoPreg_Combobox.ValueMember = "Cod_Pregunta";
            this.PermisoPreg_Combobox.SelectedIndexChanged += new System.EventHandler(this.PermisoPreg_Combobox_SelectedIndexChanged);
            */
            PermitirPreguntas_Checkbox.Checked = false;

            //TODO Mostrar todos los campos que se encuentren completos en la tabla de Publicaciones
        }

        private void EditarPubliForm_Load(object sender, EventArgs e)
        {

        }

        private void Guardar_Button_Click(object sender, EventArgs e)
        {
            //Controlar que se completen todos los datos y asignar
            if (!Visibilidad_Combobox.Text.Equals("") && !Descripcion_Textbox.Text.Equals("") && !Stock_Textbox.Text.Equals("") && !dateTimePicker1.Text.Equals("") && !Estado_Combobox.Text.Equals("") && !Tipo_Combobox.Text.Equals("") && !Precio_Textbox.Text.Equals(""))
            {
                int codPubli = 0;
                int visibilidad = Visibilidad_Combobox.SelectedIndex;
                //TODO Conseguir la ID_Vendedor
                int idVendedor = usuario.ID_User;
                string descripcion = Descripcion_Textbox.Text;
                int stock = Convert.ToInt32(Stock_Textbox.Text);
                DateTime fechaFin = Convert.ToDateTime(dateTimePicker1.Text);
                DateTime fechaInicio = DateTime.Today;
                int estado = Estado_Combobox.SelectedIndex;
                int tipoPubli = Tipo_Combobox.SelectedIndex;

                int precio = Convert.ToInt32(Precio_Textbox.Text);
                bool permisoPreg = PermitirPreguntas_Checkbox.Checked;
                //var permisoPreg = (int)PermisoPreg_Combobox.SelectedValue;

                //Actualiza la publicacion con los parametros asignados
                Publicacion publi = new Publicacion(codPubli,visibilidad, idVendedor, descripcion, stock, fechaFin, fechaInicio, precio, estado, tipoPubli,permisoPreg, stock);

                //Invocar funcion que actualiza publicacion en la tabla publicaciones
                publi.actualizarPublicacion(visibilidad,idVendedor,descripcion,stock,fechaFin,fechaInicio,estado,tipoPubli,precio,permisoPreg);
            }
            else
            {
                MessageBox.Show("Para continuar, ingrese todos los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Limpiar_Button_Click(object sender, EventArgs e)
        {

        }

        private void Visibilidad_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Estado_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tipo_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PermisoPreg_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
