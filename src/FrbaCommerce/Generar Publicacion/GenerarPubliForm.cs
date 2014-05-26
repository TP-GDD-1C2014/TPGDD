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

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class GenerarPubliForm : Form
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

        public GenerarPubliForm()
        //Clases.Usuario userActual
        //Clases.Publicacion publicacion
        {
            //Obtiene el usuario loggeado
            Interfaz.loguearUsuario(usuario);

            InitializeComponent();

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
   
            List<preguntasComboBox> listaRespuestas = new List<preguntasComboBox>();
            listaRespuestas.Add(new preguntasComboBox("No",0));
            listaRespuestas.Add(new preguntasComboBox("Si",1));
            this.permitirPreg_combobox.DataSource = listaRespuestas;
            this.permitirPreg_combobox.DisplayMember = "Permiso_Pregunta";
            this.permitirPreg_combobox.ValueMember = "Cod_Pregunta";
            this.permitirPreg_combobox.SelectedIndexChanged += new System.EventHandler(this.permitirPreg_combobox_SelectedIndexChanged);

            Ocultar();
        }

        private void Ocultar()
        {
            PrecioUnit_Label.Visible = true;
            PrecioUnit_textBox.Visible = true;
            PrecioTotal_Label.Visible = false;
            PrecioTotal_textBox.Visible = false;
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
            //Dependiendo el tipo de publicacion, mostrar si es precio unitario o total
            if (TipoPubli_ComboBox.SelectedValue.Equals(0))
            {
                PrecioUnit_Label.Visible = true;
                PrecioUnit_textBox.Visible = true;
                PrecioTotal_Label.Visible = false;
                PrecioTotal_textBox.Visible = false;
            }
            else
            {
                PrecioUnit_Label.Visible = false;
                PrecioUnit_textBox.Visible = false;
                PrecioTotal_Label.Visible = true;
                PrecioTotal_textBox.Visible = true;
            }
        }

        private void PrecioUnit_textBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Limpiar_button_Click(object sender, EventArgs e)
        {
            Common.Interfaz.limpiarInterfaz(this);
            Ocultar();
        }

        private void Guardar_button_Click(object sender, EventArgs e)
        {
            //Controlar que se completen todos los datos y asignar
            if (!Visibilidad_ComboBox.Text.Equals("") && !Descrip_TextBox.Text.Equals("") && !Stock_TextBox.Text.Equals("") && !FechaFin_DateTimePicker.Text.Equals("") && !Estado_ComboBox.Text.Equals("") && !TipoPubli_ComboBox.Text.Equals("") && !PrecioTotal_textBox.Text.Equals("") && !PrecioUnit_textBox.Text.Equals(""))
            {
                int codPubli = 0;
                int visibilidad = Visibilidad_ComboBox.SelectedIndex;
                int idVendedor = usuario.ID_User;
                string descripcion = Descrip_TextBox.Text;
                int stock = Convert.ToInt32(Stock_TextBox.Text);
                        //stock = int.Parse(Stock_TextBox.Text);
                //TODO Revisar la cuestión de las fechas (archivo config)
                DateTime fechaFin = Convert.ToDateTime(FechaFin_DateTimePicker.Text);
                DateTime fechaInicio = DateTime.Today;
                var estado = (Estado_Publicacion)Estado_ComboBox.SelectedValue;
                        //int estado = Estado_ComboBox.SelectedIndex;
                        //Estado_Publicacion estado = (Estado_Publicacion)Enum.Parse(typeof(Estado_Publicacion), Estado_ComboBox.Text);
                var tipoPubli = (Tipo_Publicacion)TipoPubli_ComboBox.SelectedValue;
                
                int precio;
                //Dependiendo el tipo de publicacion, define el precio a elegir
                if (TipoPubli_ComboBox.SelectedValue.Equals(0))
                {
                    precio = Convert.ToInt32(PrecioUnit_textBox.Text);
                }
                else
                {
                    precio = Convert.ToInt32(PrecioTotal_textBox.Text);
                }
                var permisoPreg = (int)permitirPreg_combobox.SelectedValue;

                //Crear la publicacion con los parametros asignados
                //TODO Revisar tipos
                Publicacion publiNueva = new Publicacion(codPubli, visibilidad, idVendedor, descripcion, stock, fechaFin, fechaInicio, precio, estado, tipoPubli, permisoPreg, stock);

                //Invocar funcion que inserta publicacion en la tabla publicaciones
                publiNueva.agregarPublicacion(visibilidad,idVendedor,descripcion,stock,fechaFin,fechaInicio,estado,tipoPubli,precio,permisoPreg);
            }
            else
            {
                MessageBox.Show("Para continuar, ingrese todos los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void permitirPreg_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void GenerarPubliForm_Load(object sender, EventArgs e)
        {
        }
    }
}
