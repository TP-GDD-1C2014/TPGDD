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


namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class EditorDeVisibilidades : Form
    {
        private Button botonSeleccionado { get; set; }
        private DataGridView dgv { get; set; }
        private List<Visibilidad> listaVisibilidadesBD { get; set; }
        private Visibilidad visibilidadVieja { get; set; }
   


        public EditorDeVisibilidades(Button botonSeleccionado, DataGridView dgv)
        {
            InitializeComponent();
            CenterToScreen();

            this.botonSeleccionado = botonSeleccionado;
            this.dgv = dgv;

            
          

            if (botonSeleccionado.Text == "Modificar")
            {
                //Ocultando un label
                this.label8.Hide();

                //Genero la lista de visibilidades para usarla como referencia si hay algun cambio
                listaVisibilidadesBD = this.generarVisibilidadesBD(this.dgv);
            
                //Guardando la visibilidad a modificar
                visibilidadVieja = dgv.CurrentRow.DataBoundItem as Visibilidad;
                
                //Cargando la form con los datos de la fila del DGV seleccionada
                //agregando al combo los codigos de visibilidad
                this.cargarComboBoxCodigos();

                this.cargarForm(visibilidadVieja);


            }
            else if (botonSeleccionado.Text == "Nueva")
            {
                this.label7.Hide();
                this.codigoComboBox.Hide();
            }
        }

        private List<Visibilidad> generarVisibilidadesBD(DataGridView dgv)
        {
            List<Visibilidad> listaVisibilidades = Visibilidad.ObtenerTodasLasVisibilidades();


            return listaVisibilidades;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cargarForm(Visibilidad visibilidad)
        {
            this.nombreTextBox.Text = visibilidad.Descripcion;
            this.costoTextBox.Text = Convert.ToString(visibilidad.Costo_Publicacion);
            this.porcentajeTextBox.Text = Convert.ToString(visibilidad.Porcentaje_Venta);
            this.checkBox.Checked = visibilidad.habilitada;
            this.codigoComboBox.SelectedItem = visibilidad.jerarquia;

            this.porcentajeTextBox.MaxLength = 3;
            
        ;

        }


        private void cargarComboBoxCodigos()
        {
           
            int i = Convert.ToInt32(this.dgv.Rows[0].Cells[0].Value);

            while (i < this.dgv.RowCount)
            {
                this.codigoComboBox.Items.Add(i);
                i++;
            }

     

        }


        private void ConfirmarButton_Click(object sender, EventArgs e)
        {


            //si la visibilidad es nueva
            if (this.botonSeleccionado.Text == "Nueva")
            {

                bool chequeado = this.chequearCampos();

                if (chequeado)
                {
                    if (!BDSQL.existeString(nombreTextBox.Text, "MERCADONEGRO.VISIBILIDADES", "DESCRIPCION"))
                    {


                        //Datos de la form
                        string nombre = this.nombreTextBox.Text;
                        decimal costo = Convert.ToDecimal(this.costoTextBox.Text);
                        decimal porcentajeVenta = Convert.ToDecimal(this.porcentajeTextBox.Text) / 100;
                        int jerarquia = Convert.ToInt32(this.codigoComboBox.SelectedItem);


                        int habilitada = 0;

                        if (this.checkBox.Checked)
                            habilitada = 1;


                        List<SqlParameter> parametros = new List<SqlParameter>();


                        BDSQL.agregarParametro(parametros, "@descripcion", nombre);
                        BDSQL.agregarParametro(parametros, "@costoPublicacion", costo);
                        BDSQL.agregarParametro(parametros, "@porcentajeVenta", porcentajeVenta);
                        BDSQL.agregarParametro(parametros, "@habilitada", habilitada);

                        SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
                        paramRet.Direction = System.Data.ParameterDirection.Output;
                        parametros.Add(paramRet);



                        int idInsertada = (int)BDSQL.ExecStoredProcedure("MERCADONEGRO.AgregarVisibilidad", parametros);
                        BDSQL.cerrarConexion();


                        MessageBox.Show("¡Visibilidad Agregada!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();


                        //Interfaz.diccionarioVisibilidades.Add(idInsertada, this.nombreTextBox.Text);
                        
                    }
                    else
                        MessageBox.Show("Ya existe una visibilidad con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }//si se quiere modificar
            else if (this.botonSeleccionado.Text == "Modificar")
            {

                bool chequeado = this.chequearCampos();

                if (chequeado)
                {

                    //Datos de la form
                    string nombre = this.nombreTextBox.Text;
                    decimal costo = Convert.ToDecimal(this.costoTextBox.Text);
                    decimal porcentajeVenta = Convert.ToDecimal(this.porcentajeTextBox.Text) / 100;
                    int jerarquia = Convert.ToInt32(this.codigoComboBox.SelectedItem);
                    bool habilitada = this.checkBox.Checked;


                    Visibilidad visibilidadNueva = new Visibilidad(jerarquia, nombre, costo, porcentajeVenta, habilitada);

                    //me fijo si tengo que updatear la jeraquia
                    if (visibilidadNueva.hayQueCambiarLaJerarquia(visibilidadVieja))
                    {
                        //Update unico de la jerarquia a la nueva visibilidad
                        this.actualizarJerarquia(visibilidadNueva, visibilidadVieja.Descripcion);

                        //updatear todas las demas jerarquias
                        if (visibilidadNueva.jerarquia > this.visibilidadVieja.jerarquia)
                        {
                            int primerIndice = visibilidadVieja.jerarquia;
                            int iteraciones = visibilidadNueva.jerarquia - this.visibilidadVieja.jerarquia;
                            int i = 0;

                            while (i < iteraciones)
                            {
                                Visibilidad visibilidadTemp = this.listaVisibilidadesBD.ElementAt(primerIndice+1);
                                visibilidadTemp.jerarquia--;
                                this.actualizarJerarquia(visibilidadTemp, visibilidadTemp.Descripcion);
                                

                                i++;
                                primerIndice++;
                            }

                       

                        }
                        else if (visibilidadNueva.jerarquia < this.visibilidadVieja.jerarquia)
                        {
                            int ultimoIndice = visibilidadVieja.jerarquia;
                            int iteraciones = this.visibilidadVieja.jerarquia - visibilidadNueva.jerarquia;
                            int i = 0;

                            while (i < iteraciones)
                            {
                                Visibilidad visibilidadTemp = this.listaVisibilidadesBD.ElementAt(ultimoIndice - 1);
                                visibilidadTemp.jerarquia++;
                                this.actualizarJerarquia(visibilidadTemp, visibilidadTemp.Descripcion);


                                i++;
                                ultimoIndice--;
                            }

                           


                        }

                        //updateando la nueva Visibilidad
                        this.editarVisibilidad(visibilidadNueva, this.visibilidadVieja);
                        this.Close();
                        

                    }
                    else
                    {
                        //updatear solo la visibilidad nueva
                        this.editarVisibilidad(visibilidadNueva, this.visibilidadVieja);

                      
                        this.Close();

                    }

                    //updateando diccionario visibilidades
                    //Interfaz.actualizarDiccionarioVisibilidades(visibilidadNueva.Descripcion, this.visibilidadVieja.Descripcion);

                }

            }
        }

        private void editarVisibilidad(Visibilidad visibilidadNueva, Visibilidad visibilidadVieja)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();


            BDSQL.agregarParametro(parametros, "@descripcion", visibilidadNueva.Descripcion);
            BDSQL.agregarParametro(parametros, "@costoPublicacion", visibilidadNueva.Costo_Publicacion);
            BDSQL.agregarParametro(parametros, "@porcentajeVenta", visibilidadNueva.Porcentaje_Venta);
            BDSQL.agregarParametro(parametros, "@habilitada", visibilidadNueva.habilitada);

            //nombre viejo, para usarlo en el string
            String nombreViejo = visibilidadVieja.Descripcion;

            BDSQL.agregarParametro(parametros, "@descripcionVieja", nombreViejo);

            //Exec storedProcedure
            BDSQL.ExecStoredProcedureSinRet("MERCADONEGRO.EditarVisibilidad", parametros);
            BDSQL.cerrarConexion();


            MessageBox.Show("¡Visibilidad Modificada!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void actualizarJerarquia(Visibilidad visibilidad, string descripcionVieja)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();


            BDSQL.agregarParametro(parametros, "@jerarquia", visibilidad.jerarquia);
            BDSQL.agregarParametro(parametros, "@descripcionVieja", descripcionVieja);

            BDSQL.ExecStoredProcedureSinRet("MERCADONEGRO.EditarJerarquia", parametros);
            BDSQL.cerrarConexion();

        }


        private bool chequearCampos()
        {

            bool chequeado = false;

            //chequeo de campos obligatorios
            if (this.nombreTextBox.Text.Equals("") || this.costoTextBox.Text.Equals("") || this.porcentajeTextBox.Text.Equals(""))
            {
                MessageBox.Show("Por favor complete los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToDecimal(this.porcentajeTextBox.Text) < 0 || Convert.ToDecimal(this.porcentajeTextBox.Text) > 100)
            {
                MessageBox.Show("Porcentaje de venta inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                chequeado = true;


            return chequeado;
        }


        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void costoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (costoTextBox.Text.Contains(','))
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

        private void porcentajeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
               if (porcentajeTextBox.Text.Contains(','))
           {
                      if(!char.IsDigit(e.KeyChar))
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
                          if(!char.IsDigit(e.KeyChar))
                          {
                                  e.Handled = true;
                           }

                           if(e.KeyChar==',' || e.KeyChar=='\b')
                          {
                                   e.Handled = false;
                          }
            }
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
        }

        


    }
}
