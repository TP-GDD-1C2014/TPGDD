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
        bool esBorrador;
        bool esGratuita;

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

                if(unaPubli.Cod_Visibilidad == "Gratis")
                {
                    esGratuita = true;
                }
                else{
                    esGratuita = false;
                }
                    
                //Si se encuentra Publicada, sólo permitir modificar el estado a Pausada o Finalizada (Inmediata unicamente)
                if (esBorrador == false) 
                {
                        //llenarCombosModificables();

                        Visibilidad_ComboBox.Enabled = false;
                        //Descrip_TextBox.Enabled = false;
                        //Revisar cuestión de stock (permitir aumento)
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

        //Combobox Rubro
        public class rubroComboBox
        {
            public string Nombre_Rubro { get; set; }
            public int Cod_Rubro { get; set; }
            public rubroComboBox(string nombre, int cod)
            {
                Nombre_Rubro = nombre;
                Cod_Rubro = cod;
            }
            public override string ToString()
            {
                return Nombre_Rubro;
            }
        }

        //Combobox Preguntas (bit)
        /*public class preguntasComboBox
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
        }*/


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
                DateTime fechaInicio = Interfaz.obtenerFecha();
                string estado = Convert.ToString(Estado_ComboBox.SelectedItem);
                int estadoIndex = Estado_ComboBox.SelectedIndex;
                string tipoPubli = Convert.ToString(TipoPubli_ComboBox.SelectedItem);
                int tipoPubliIndex = TipoPubli_ComboBox.SelectedIndex;
                string rubro = Convert.ToString(Rubro_checkedListBox.SelectedItem);
                int rubroIndex = Rubro_checkedListBox.SelectedIndex;
                decimal precio = Convert.ToDecimal(Precio_textBox.Text);
                bool permisoPreg = PermitirPreguntas_Checkbox.Checked;

                List<Rubro> listaRubrosSeleccionados = filtrarRubrosSeleccionados();

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
                    int nuevoCodPbli = Publicaciones.obtenerCodPublicacion(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);
                    MessageBox.Show(string.Format("La publicación creada tendrá el Código {0}", nuevoCodPbli), "Codigo de Publicación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Rubro.agregarRubroPublicacion(listaRubrosSeleccionados, nuevoCodPbli);
                    this.Close();
                }
                //Caso que sea para Modificar
                else
                {
                    //Comprueba que no se haya decrementado el stock
                    if (stockTraido > stock)
                    {
                        MessageBox.Show("No es posible decrementar el stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //Caso en que sea Publicada y quiera pasar a Borrador (no permitido)
                        if ((esBorrador == false) && (estado == "Borrador"))
                        {
                            MessageBox.Show("No es posible modificar de Publicada a Borrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            //Comprueba que si la publi seleccionada no era gratuita y la modifica
                            if (visibilidad == "Gratis" && (esGratuita == false))
                            {
                                //Si selecciona visibilidad gratuita, controlar Cant_Publi_Gratuitas de la tabla Usuarios
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
            /*List<visibilidadComboBox> listaVisibilidades = new List<visibilidadComboBox>();
            listaVisibilidades.Add(new visibilidadComboBox("Platino", 0));
            listaVisibilidades.Add(new visibilidadComboBox("Oro", 1));
            listaVisibilidades.Add(new visibilidadComboBox("Plata", 2));
            listaVisibilidades.Add(new visibilidadComboBox("Bronce", 3));
            listaVisibilidades.Add(new visibilidadComboBox("Gratis", 4));
            this.Visibilidad_ComboBox.DataSource = listaVisibilidades;*/
            List<Visibilidad> listaVisibilidades = Visibilidad.ObtenerVisibilidades();
            for (int i = 0; i < listaVisibilidades.Count(); i++)
            {
                this.Visibilidad_ComboBox.Items.Add(new visibilidadComboBox((listaVisibilidades[i].Descripcion), i));
            }

            this.Visibilidad_ComboBox.DisplayMember = "Descripcion_Visibilidad";
            this.Visibilidad_ComboBox.ValueMember = "Cod_Visibilidad";
            this.Visibilidad_ComboBox.SelectedIndex = 0;
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
            //Ojo con el index
            listaTipos.Add(new tipoComboBox("Subasta", 0));
            listaTipos.Add(new tipoComboBox("Compra Inmediata", 1));
            this.TipoPubli_ComboBox.DisplayMember = "Nombre_Tipo";
            this.TipoPubli_ComboBox.ValueMember = "Cod_Tipo";
            this.TipoPubli_ComboBox.DataSource = listaTipos;
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);
            //TipoPubli_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Rubro> listaRubros = Rubro.obtenerRubros();
            Rubro_checkedListBox.DisplayMember = "Descripcion";
            Rubro_checkedListBox.ValueMember = "ID_Rubro";
            for (int i = 0; i < listaRubros.Count(); i++)
            {
                Rubro_checkedListBox.Items.Add(new Rubro(listaRubros[i].ID_Rubro, listaRubros[i].Descripcion));
            }

            FechaFin_DateTimePicker.Text = Convert.ToString(Interfaz.obtenerFecha());
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

        private void Rubro_checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
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

        //Denegar el ingreso de datos no numéricos al textbox de Peso
        private void Precio_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Precio_textBox.Text.Contains(','))
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

        //Permitir unicamente el ingreso de datos numéricos enteros al textbox de Stock
        private void Stock_TextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private List<Rubro> filtrarRubrosSeleccionados()
        {
            List<Rubro> rubrosSeleccionados = new List<Rubro>();

            for (int i = 0; i < Rubro_checkedListBox.Items.Count; i++)
            {
                if (Rubro_checkedListBox.GetItemChecked(i))
                {
                    Rubro func = Rubro_checkedListBox.Items[i] as Rubro;
                    rubrosSeleccionados.Add(func);
                }
            }
            return rubrosSeleccionados;
        }



    }
}
