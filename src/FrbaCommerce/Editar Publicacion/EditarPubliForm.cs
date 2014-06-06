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
    public partial class EditarPubliForm : Form
    {
        
        public EditarPubliForm(Publicacion unaPubli) 
        {

            
            InitializeComponent();
            CenterToScreen();
            llenarCombos();

            //TODO revisar Visibilidad_ComboBox
            Visibilidad_ComboBox.SelectedValue = unaPubli.Cod_Visibilidad;
            Descrip_TextBox.Text = unaPubli.Descripcion;
            Stock_TextBox.Text = Convert.ToString(unaPubli.Stock);
            FechaFin_DateTimePicker.Text = Convert.ToString(unaPubli.Fecha_Vto);
            //TODO revisar TipoPubli_ComboBox y Estado_ComboBox
            TipoPubli_ComboBox.SelectedValue = unaPubli.Tipo_Publicacion;
            Estado_ComboBox.SelectedValue = unaPubli.Estado_Publicacion;
            Precio_textBox.Text = Convert.ToString(unaPubli.Precio);
            PermitirPreguntas_Checkbox.Checked = unaPubli.Permiso_Preguntas;
            PermitirPreguntas_Checkbox.Checked = false;

            //TODO Mostrar todos los campos que se encuentren completos en la tabla de Publicaciones
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

        Clases.Usuario usuario = FrbaCommerce.Common.Interfaz.usuario;


        private void Guardar_Button_Click(object sender, EventArgs e)
        {
            
            //Controlar que se completen todos los datos y asignar
            if (!Visibilidad_ComboBox.Text.Equals("") && !Descrip_TextBox.Text.Equals("") && !Stock_TextBox.Text.Equals("") && !FechaFin_DateTimePicker.Text.Equals("") && !Estado_ComboBox.Text.Equals("") && !TipoPubli_ComboBox.Text.Equals("") && !Precio_textBox.Text.Equals(""))
            {
                int codPubli = 0;
                string visibilidad = Visibilidad_ComboBox.SelectedItem.ToString();
                //TODO Conseguir la ID_Vendedor
                int idVendedor = usuario.ID_User;
                string descripcion = Descrip_TextBox.Text;
                int stock = Convert.ToInt32(Stock_TextBox.Text);
                DateTime fechaFin = Convert.ToDateTime(FechaFin_DateTimePicker.Text);
                DateTime fechaInicio = DateTime.Today;
                string estado = Estado_ComboBox.SelectedText;
                string tipoPubli = TipoPubli_ComboBox.SelectedText;

                int precio = Convert.ToInt32(Precio_textBox.Text);
                bool permisoPreg = PermitirPreguntas_Checkbox.Checked;
                //var permisoPreg = (int)PermisoPreg_Combobox.SelectedValue;

                //Actualiza la publicacion con los parametros asignados
                Publicacion publi = new Publicacion(codPubli,visibilidad, idVendedor, descripcion, stock, fechaFin, fechaInicio, precio, estado, tipoPubli,permisoPreg, stock);

                //Invocar funcion que actualiza publicacion en la tabla publicaciones
                //publi.actualizarPublicacion(visibilidad,idVendedor,descripcion,stock,fechaFin,fechaInicio,estado,tipoPubli,precio,permisoPreg);
            }
            else
            {
                MessageBox.Show("Para continuar, ingrese todos los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
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
            //this.Visibilidad_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<estadoComboBox> listaEstados = new List<estadoComboBox>();
            listaEstados.Add(new estadoComboBox("Borrador", 0));
            listaEstados.Add(new estadoComboBox("Activa", 1));
            listaEstados.Add(new estadoComboBox("Pausada", 2));
            listaEstados.Add(new estadoComboBox("Finalizada", 3));
            this.Estado_ComboBox.DataSource = listaEstados;
            this.Estado_ComboBox.DisplayMember = "Nombre_Estado";
            this.Estado_ComboBox.ValueMember = "Cod_Estado";
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);
            //Estado_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<tipoComboBox> listaTipos = new List<tipoComboBox>();
            listaTipos.Add(new tipoComboBox("Inmediata", 0));
            listaTipos.Add(new tipoComboBox("Subasta", 1));
            this.TipoPubli_ComboBox.DataSource = listaTipos;
            this.TipoPubli_ComboBox.DisplayMember = "Nombre_Tipo";
            this.TipoPubli_ComboBox.ValueMember = "Cod_Tipo";
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);
            //TipoPubli_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            
            /*List<preguntasComboBox> listaRespuestas = new List<preguntasComboBox>();
            listaRespuestas.Add(new preguntasComboBox("No",0));
            listaRespuestas.Add(new preguntasComboBox("Si",1));
            this.permitirPreg_combobox.DataSource = listaRespuestas;
            this.permitirPreg_combobox.DisplayMember = "Permiso_Pregunta";
            this.permitirPreg_combobox.ValueMember = "Cod_Pregunta";
            this.permitirPreg_combobox.SelectedIndexChanged += new System.EventHandler(this.permitirPreg_combobox_SelectedIndexChanged);
            */
            
        }

        private void Visibilidad_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Descrip_TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Stock_TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void FechaFin_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Estado_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void TipoPubli_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Precio_textBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void PermitirPreguntas_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
        }

    }
}
