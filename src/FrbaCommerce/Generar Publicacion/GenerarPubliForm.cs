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

        //Obtiene el usuario loggeado
        Clases.Usuario usuario = FrbaCommerce.Common.Interfaz.usuario;
        //public Clases.Usuario usuario { get; set; }
        //public SeleccionFuncionalidades formAnterior { get; set; }
        bool esNueva;
        int codPubli;
        int stockTraido;
        int estadoIndex = -1;
        bool esBorrador;
        bool esSubasta;

        //Constructor para generar publicacion nueva
        public GenerarPubliForm(string modo)
        {
            if (modo == "Nuevo")
            {
                InitializeComponent();
                CenterToScreen();
                llenarCombos();
                PermitirPreguntas_Checkbox.Checked = false;
                esNueva = true;
                //Ocultar();
            }
        }

        //Constructor para modificar publicacion
        public GenerarPubliForm(string modo, Publicacion unaPubli)
        {
            //TODO Permitir o no cambios en determinados campos, dependiendo del estado
            
            if (modo == "Modificar")
            {
                InitializeComponent();
                CenterToScreen();
                llenarCombos();

                codPubli = unaPubli.Cod_Publicacion;
                Visibilidad_ComboBox.Text = unaPubli.Cod_Visibilidad;
                Descrip_TextBox.Text = unaPubli.Descripcion;
                Stock_TextBox.Text = Convert.ToString(unaPubli.Stock);
                FechaFin_DateTimePicker.Text = Convert.ToString(unaPubli.Fecha_Vto);
                TipoPubli_ComboBox.Text = unaPubli.Tipo_Publicacion;
                Estado_ComboBox.Text = unaPubli.Estado_Publicacion;
                Precio_textBox.Text = Convert.ToString(unaPubli.Precio);
                PermitirPreguntas_Checkbox.Checked = unaPubli.Permiso_Preguntas;

                stockTraido = Convert.ToInt32(unaPubli.Stock);
                esNueva = false;

                if (unaPubli.Estado_Publicacion == "Borrador")
                {
                    esBorrador = true;
                }
                else
                {
                    esBorrador = false;
                }

                if (unaPubli.Tipo_Publicacion == "Subasta")
                {
                    esSubasta = true;
                }
                else
                {
                    esSubasta = false;
                }

                //Si se encuentra Publicada, sólo permitir modificar el estado a Pausada o Finalizada (Inmediata unicamente)
                if (esBorrador == false) 
                {
                        //llenarCombosModificables();

                        Visibilidad_ComboBox.Enabled = false;
                        Descrip_TextBox.Enabled = false;
                        //TODO Revisar cuestión de stock (permitir aumento)
                        FechaFin_DateTimePicker.Enabled = false;
                        TipoPubli_ComboBox.Enabled = false;
                        Precio_textBox.Enabled = false;
                        PermitirPreguntas_Checkbox.Enabled = false;

                }

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


        private void Limpiar_button_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
        }

        private void Guardar_button_Click(object sender, EventArgs e)
        {
            //Controlar que se completen todos los datos y asignar
            if (!Visibilidad_ComboBox.Text.Equals("") && !Descrip_TextBox.Text.Equals("") && !Stock_TextBox.Text.Equals("") && !FechaFin_DateTimePicker.Text.Equals("") && !Estado_ComboBox.Text.Equals("") && !TipoPubli_ComboBox.Text.Equals("") && !Precio_textBox.Text.Equals(""))
            {
                if(esNueva == true)
                {
                    codPubli = 0;
                }
                string visibilidad = Visibilidad_ComboBox.SelectedItem.ToString();
                int visibilidadIndex = Visibilidad_ComboBox.SelectedIndex;
                int idVendedor = usuario.ID_User;
                string descripcion = Descrip_TextBox.Text;
                int stock = Convert.ToInt32(Stock_TextBox.Text);
                //TODO Revisar la cuestión de las fechas (archivo config)
                DateTime fechaFin = Convert.ToDateTime(FechaFin_DateTimePicker.Text);
                DateTime fechaInicio = DateTime.Today;
                string estado = Convert.ToString(Estado_ComboBox.SelectedItem);
                int estadoIndex = Estado_ComboBox.SelectedIndex;
                string tipoPubli = Convert.ToString(TipoPubli_ComboBox.SelectedItem);
                int tipoPubliIndex = TipoPubli_ComboBox.SelectedIndex;
                decimal precio = Convert.ToDecimal(Precio_textBox.Text);
                bool permisoPreg = PermitirPreguntas_Checkbox.Checked;

                //Crear la publicacion con los parametros asignados
                Publicacion publi = new Publicacion(codPubli, visibilidad, idVendedor, descripcion, stock, fechaFin, fechaInicio, precio, estado, tipoPubli, permisoPreg, stock);

                //Comprobar si es nueva o para modificar
                if ((esNueva == true))
                {
                    //Si selecciona visibilidad gratuita, controlar Cant_Publi_Gratuitas de la tabla Usuarios
                    if (visibilidad == "Gratis")
                    {
                        if (usuario.Cant_Publi_Gratuitas < 3)
                        {
                            //Si no tiene Cant_Publi_Gratuitas en numero limite, sumar 1 a Cant_Publi_Gratuitas
                            usuario.sumarPubliGratuita();
                        }
                        else
                        {
                            //Si tiene Cant_Publi_Gratuitas en numero limite, mostrar error
                            MessageBox.Show("Ya posee 3 publicaciones gratuitas publicadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    //Invocar funcion que inserta publicacion en la tabla Publicaciones
                    Publicaciones.agregarPublicacion(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);

                }
                else
                {
                    //Comprueba que no se haya decrementado el stock
                    if (stockTraido > stock)
                    {
                        MessageBox.Show("No es posible decrementar el stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (esBorrador == false)
                        {
                            MessageBox.Show("No es posible modificar de Publicada a Borrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (esSubasta == false)
                        {
                            MessageBox.Show("No es posible modificar una Subasta que se encuentre Publicada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            //Si selecciona visibilidad gratuita, controlar Cant_Publi_Gratuitas de la tabla Usuarios
                            if (visibilidad == "Gratis")
                            {
                                if (usuario.Cant_Publi_Gratuitas < 3)
                                {
                                    //Si no tiene Cant_Publi_Gratuitas en numero limite, sumar 1 a Cant_Publi_Gratuitas
                                    usuario.sumarPubliGratuita();
                                }
                                else
                                {
                                    //Si tiene Cant_Publi_Gratuitas en numero limite, mostrar error
                                    MessageBox.Show("Ya posee 3 publicaciones gratuitas publicadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }

                            //Invocar funcion que actualiza la publicacion en la tabla Publicaciones
                            Publicaciones.actualizarPublicacion(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);
                            //TODO Revisar en caso de que sea borrador y pase a ser generada como gratuita!
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Para continuar, ingrese todos los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void GenerarPubliForm_Load(object sender, EventArgs e)
        {
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
            //TODO Controlar index!
            listaEstados.Add(new estadoComboBox("Borrador", 0));
            listaEstados.Add(new estadoComboBox("Publicada", 1));
            listaEstados.Add(new estadoComboBox("Pausada", 2));
            listaEstados.Add(new estadoComboBox("Finalizada", 3));
            this.Estado_ComboBox.DataSource = listaEstados;
            this.Estado_ComboBox.DisplayMember = "Nombre_Estado";
            this.Estado_ComboBox.ValueMember = "Cod_Estado";
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);
            //Estado_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<tipoComboBox> listaTipos = new List<tipoComboBox>();
            listaTipos.Add(new tipoComboBox("Subasta", 0));
            listaTipos.Add(new tipoComboBox("Inmediata", 1));
            this.TipoPubli_ComboBox.DataSource = listaTipos;
            this.TipoPubli_ComboBox.DisplayMember = "Nombre_Tipo";
            this.TipoPubli_ComboBox.ValueMember = "Cod_Tipo";
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);
            //TipoPubli_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

       /* public void llenarCombosModificables()
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
            //TODO Controlar index!
            listaEstados.Add(new estadoComboBox("Publicada", 1));
            listaEstados.Add(new estadoComboBox("Pausada", 2));
            listaEstados.Add(new estadoComboBox("Finalizada", 3));
            this.Estado_ComboBox.DataSource = listaEstados;
            this.Estado_ComboBox.DisplayMember = "Nombre_Estado";
            this.Estado_ComboBox.ValueMember = "Cod_Estado";
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);
            //Estado_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<tipoComboBox> listaTipos = new List<tipoComboBox>();
            listaTipos.Add(new tipoComboBox("Subasta", 0));
            listaTipos.Add(new tipoComboBox("Inmediata", 1));
            this.TipoPubli_ComboBox.DataSource = listaTipos;
            this.TipoPubli_ComboBox.DisplayMember = "Nombre_Tipo";
            this.TipoPubli_ComboBox.ValueMember = "Cod_Tipo";
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);
            //TipoPubli_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }*/

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

        private void permitirPreg_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /*private void volver_button_Click(object sender, EventArgs e)
        {
            this.Close();
            this.formAnterior.Show();
        }*/
    }
}
