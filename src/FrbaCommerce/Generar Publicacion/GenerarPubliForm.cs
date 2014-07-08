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
        bool esNueva;
        int codPubli;
        int stockTraido;
        bool esBorrador;
        int dueñoPublicacion;
        bool esAdmin = false;

        //Constructor para Generar publicacion
        public GenerarPubliForm(string modo)
        {
            if (modo == "Nuevo")
            {
                InitializeComponent();
                CenterToScreen();
                llenarCombos();
                PermitirPreguntas_Checkbox.Checked = false;
                esNueva = true;
            }
        }


        //Constructor para Modificar publicacion
        public GenerarPubliForm(string modo, Publicacion unaPubli)
        {
            if (modo == "Modificar")
            {
                InitializeComponent();
                CenterToScreen();
                llenarCombos();
                llenarCheckedList(unaPubli.Cod_Publicacion);

                //Completar form con datos traido de BuscarPubliForm
                codPubli = unaPubli.Cod_Publicacion;
                Visibilidad_ComboBox.Text = unaPubli.Cod_Visibilidad;
                Descrip_TextBox.Text = unaPubli.Descripcion;
                Stock_TextBox.Text = Convert.ToString(unaPubli.Stock);
                FechaFin_DateTimePicker.Text = Convert.ToString(unaPubli.Fecha_Vto);
                TipoPubli_ComboBox.Text = unaPubli.Tipo_Publicacion;
                Estado_ComboBox.Text = unaPubli.Estado_Publicacion;
                Precio_textBox.Text = Convert.ToString(unaPubli.Precio);
                PermitirPreguntas_Checkbox.Checked = unaPubli.Permiso_Preguntas;
                dueñoPublicacion = unaPubli.ID_Vendedor;

                stockTraido = Convert.ToInt32(unaPubli.Stock);
                esNueva = false;

                if (unaPubli.Estado_Publicacion == "Borrador"){
                    esBorrador = true;
                }
                else{
                    esBorrador = false;
                }
                    
                //Si estado=Publicada => permitir modificar el estado a Pausada o Finalizada (Inmediata unicamente)
                if (esBorrador == false) 
                {
                        Visibilidad_ComboBox.Enabled = false;
                        FechaFin_DateTimePicker.Enabled = false;
                        TipoPubli_ComboBox.Enabled = false;
                        Precio_textBox.Enabled = false;
                        PermitirPreguntas_Checkbox.Enabled = false;
                        Rubro_checkedListBox.Enabled = false;
                }

                //Comprueba si el usuario es administrador o no
                esAdmin = Usuario.controlarRol(usuario.ID_User);
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



        //BOTON LIMPIAR
        private void Limpiar_button_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
        }



        //BOTON GUARDAR
        private void Guardar_button_Click(object sender, EventArgs e)
        {
            int cantRubrosSelecc = Rubro_checkedListBox.CheckedItems.Count;
            //Controlar que se completen todos los datos y asignar
            if (!Visibilidad_ComboBox.Text.Equals("") && !Descrip_TextBox.Text.Equals("") && !Stock_TextBox.Text.Equals("") && !FechaFin_DateTimePicker.Text.Equals("") && !Estado_ComboBox.Text.Equals("") && !TipoPubli_ComboBox.Text.Equals("") && !Precio_textBox.Text.Equals("") && (cantRubrosSelecc >= 1))
            {
                //Asigna los valores a la publicacion
                
                if(esNueva == true)
                {
                    codPubli = 0;
                }
                string visibilidad = Visibilidad_ComboBox.SelectedItem.ToString();
                int visibilidadIndex = Visibilidad_ComboBox.SelectedIndex;
                int idVendedor;
                if (esAdmin == true)
                {
                    idVendedor = dueñoPublicacion;
                }
                else
                {
                    idVendedor = usuario.ID_User;
                }
                string descripcion = Descrip_TextBox.Text;
                int stock = Convert.ToInt32(Stock_TextBox.Text);
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



                //Nueva
                if ((esNueva == true))
                {
                    if (fechaFin > Interfaz.obtenerFecha())
                    {

                        //Nueva + (Stock<=0)
                        if (stock < 1)
                        {
                            MessageBox.Show("El Stock no puede ser menor a 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //Nueva + Gratis + Publicada
                            if ((visibilidad == "Gratis") && (estadoIndex == 1))
                            {
                                //Obtiene la cantidad de publicaciones gratuitas del usuario
                                int idUser = Convert.ToInt32(usuario.ID_User);
                                int cantidadPubliGratuitas = Usuario.obtenerPublisGratuitas(idUser);


                                //Nueva + Gratis + Publicada + (CantGratis<3)
                                if (cantidadPubliGratuitas < 3)
                                {
                                    //Sumar 1 a Cant_Publi_Gratuitas
                                    usuario.sumarPubliGratuita();

                                    //Inserta publicacion en la tabla Publicaciones
                                    int publiExitosa = Publicaciones.agregarPublicacion(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);
                                    if (publiExitosa == -1)
                                    {
                                        MessageBox.Show("Falló al generar Publicacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        int nuevoCodPbli = Publicaciones.obtenerCodPublicacion(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);
                                        MessageBox.Show(string.Format("La publicación creada tendrá el Código {0}", nuevoCodPbli), "Codigo de Publicación", MessageBoxButtons.OK);
                                        Rubro.agregarRubroPublicacion(listaRubrosSeleccionados, nuevoCodPbli);
                                    }

                                }
                                //Nueva + Gratis + Publicada + (CantGratis>=3)
                                else
                                {
                                    MessageBox.Show("Ya posee 3 publicaciones gratuitas publicadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }

                            //Nueva + No (Gratis + Publicada) + No (Subasta + Publicada)
                            else
                            {
                                //Inserta publicacion en la tabla Publicaciones
                                int publiExitosa = Publicaciones.agregarPublicacion(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);
                                if (publiExitosa == -1)
                                {
                                    MessageBox.Show("Falló al generar Publicacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    int nuevoCodPbli = Publicaciones.obtenerCodPublicacion(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);
                                    MessageBox.Show(string.Format("La publicación creada tendrá el Código {0}", nuevoCodPbli), "Codigo de Publicación", MessageBoxButtons.OK);
                                    Rubro.agregarRubroPublicacion(listaRubrosSeleccionados, nuevoCodPbli);
                                }
                            }

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La fecha de vencimiento no puede ser menor a la actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

                //Modificar
                else
                {
                    //Modificar + StockBien
                    if (stockTraido > stock)
                    {
                        MessageBox.Show("No es posible decrementar el stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        // Modificar + StockBien + No(Publicada-->Borrador)
                        if ((esBorrador == false) && (estado == "Borrador"))
                        {
                            MessageBox.Show("No es posible pasar de Publicada a Borrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        // Nueva + Subasta + Publicada + (NuevoEstado = Finalizada)
                        else if ((tipoPubli == "Subasta") && (esBorrador == false) && (estado == "Finalizada"))
                        {
                            
                            
                            //Incluir última Subasta en Operaciones
                            decimal montoOferta = Oferta.cargarOfertaMasAlta(codPubli);
                            int idGanador = Oferta.getIdGanador(codPubli, montoOferta);

                            if (idGanador == -1)
                            {
                                DialogResult dlg = MessageBox.Show("Nadie ofertó por esta subasta, ¿Desea cerrarla de todos modos?", "Atención!", MessageBoxButtons.YesNo);

                                if (dlg == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {   
                                    //updateo el estado de la publicacion
                                    Publicaciones.updateEstado(publi.Cod_Publicacion, "Finalizada");

                                    MessageBox.Show("Subasta finalizada, no hubo ofertas.", "Atención!", MessageBoxButtons.OK);

                                    this.Close();
                                }
                            }
                            else
                            {
                                Compra compra = new Compra(idVendedor, idGanador, codPubli, 0, montoOferta, false);
                                //inserto la compra a operaciones y 
                                Compra.insertarCompra(compra);

                                //updateo el campo ventas_sin_rendir al id_vendedor
                                Usuario.updateVentasSinRendir(compra);

                                //updateo el estado de la publicacion
                                Publicaciones.updateEstado(publi.Cod_Publicacion, "Finalizada");

                                MessageBox.Show("Subasta finalizada! Avisar al ganador.", "Succes!", MessageBoxButtons.OK);

                                this.Close();
                            }
                        }
                        else
                        {
                            // Modificar + StockBien + No(Publicada-->Borrador) + (Gratis + NoBorrador)
                            if (visibilidad == "Gratis" && estado == "Publicada")
                            {
                                //Obtiene la cantidad de publicaciones gratuitas del usuario
                                int idUser = Convert.ToInt32(usuario.ID_User);
                                int cantidadPubliGratuitas = Usuario.obtenerPublisGratuitas(idUser);
                                MessageBox.Show(string.Format("Tiene {0}", cantidadPubliGratuitas), "CantPubliGratuitas", MessageBoxButtons.OK);
                                if (cantidadPubliGratuitas < 3)
                                {
                                    //Si no tiene Cant_Publi_Gratuitas en numero limite, sumar 1 a Cant_Publi_Gratuitas
                                    usuario.sumarPubliGratuita();

                                    //Actualiza los rubros
                                    List<int> listaRubrosDePublicacion = Rubro.obtenerRubrosDePublicacion(publi.Cod_Publicacion);
                                    Rubro.eliminarRubroPublicacion(listaRubrosDePublicacion, publi.Cod_Publicacion);
                                    //Publicaciones.eliminarPublicacion(publi);
                                    Rubro.agregarRubroPublicacion(listaRubrosSeleccionados, codPubli);

                                    //Actualiza la publicacion en la tabla Publicaciones
                                    Publicaciones.actualizarPublicacion(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);

                                    this.Close();
                                }
                                else
                                {
                                    //Si tiene Cant_Publi_Gratuitas en numero limite, mostrar error
                                    MessageBox.Show("Ya posee 3 publicaciones gratuitas publicadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }

                            }

                            // Modificar + StockBien + No(Publicada-->Borrador)
                            else
                            {
                                //Actualiza la publicacion en la tabla Publicaciones
                                Publicaciones.actualizarPublicacion(publi, visibilidadIndex, estadoIndex, tipoPubliIndex);
                                Rubro.actualizarRubroPublicacion(listaRubrosSeleccionados, codPubli);
                                this.Close();
                            }
                        }
                    }
                }
            }

            //Caso que no haya completado todos los datos para generar la publi
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
            //Completa Combobox de Visibilidad
            List<Visibilidad> listaVisibilidades = Visibilidad.ObtenerVisibilidades();
            for (int i = 0; i < listaVisibilidades.Count(); i++)
            {
                this.Visibilidad_ComboBox.Items.Add(new visibilidadComboBox((listaVisibilidades[i].Descripcion), i));
            }
            this.Visibilidad_ComboBox.DisplayMember = "Descripcion_Visibilidad";
            this.Visibilidad_ComboBox.ValueMember = "Cod_Visibilidad";
            this.Visibilidad_ComboBox.SelectedIndex = 0;
            this.Visibilidad_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_ComboBox_SelectedIndexChanged);

            //Completa Combobox de Estado
            List<estadoComboBox> listaEstados = new List<estadoComboBox>();
            listaEstados.Add(new estadoComboBox("Borrador", 0));
            listaEstados.Add(new estadoComboBox("Publicada", 1));
            listaEstados.Add(new estadoComboBox("Pausada", 2));
            listaEstados.Add(new estadoComboBox("Finalizada", 3));
            this.Estado_ComboBox.DataSource = listaEstados;
            this.Estado_ComboBox.DisplayMember = "Nombre_Estado";
            this.Estado_ComboBox.ValueMember = "Cod_Estado";
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);

            //Completa Combobox de Tipo
            List<tipoComboBox> listaTipos = new List<tipoComboBox>();
            listaTipos.Add(new tipoComboBox("Subasta", 0));
            listaTipos.Add(new tipoComboBox("Compra Inmediata", 1));
            this.TipoPubli_ComboBox.DisplayMember = "Nombre_Tipo";
            this.TipoPubli_ComboBox.ValueMember = "Cod_Tipo";
            this.TipoPubli_ComboBox.DataSource = listaTipos;
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);

            //Completa CheckedListBox de Rubro
            List<Rubro> listaRubros = Rubro.obtenerRubros();
            Rubro_checkedListBox.DisplayMember = "Descripcion";
            Rubro_checkedListBox.ValueMember = "ID_Rubro";
            for (int i = 0; i < listaRubros.Count(); i++)
            {
                Rubro_checkedListBox.Items.Add(new Rubro(listaRubros[i].ID_Rubro, listaRubros[i].Descripcion));
            }

            //Setea FechaFin por defecto
            FechaFin_DateTimePicker.Text = Convert.ToString(Interfaz.obtenerFecha());
        }



        public void llenarCheckedList(int codPubli)
        {
            List<Rubro> listaRubros = Rubro.obtenerRubros();
            Rubro_checkedListBox.DisplayMember = "Descripcion";
            Rubro_checkedListBox.ValueMember = "ID_Rubro";
            for (int i = 0; i < listaRubros.Count(); i++)
            {
                Rubro_checkedListBox.Items.Add(new Rubro(listaRubros[i].ID_Rubro, listaRubros[i].Descripcion));
                int rubroExistente = Rubro.encontrarRubroPublicacion(codPubli, listaRubros[i].ID_Rubro);
                if (rubroExistente == 1)
                {
                    Rubro_checkedListBox.SetItemChecked(i, true);
                }

            }
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

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}