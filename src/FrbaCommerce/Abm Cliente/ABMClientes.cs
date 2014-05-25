using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Clases;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class ABMClientes : Form
    {
        public ABMClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón "Confirmar Documento"

            //Comprobar que el tipo y nro de doc en conjunto no se encuentren repetidos en la BD
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Botón "Agregar Cliente"

            //Luego de hacer la comprobación de datos, obtener los campos del usuario e insertarlo a la BD
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox4.Text.Equals("") && !textBox5.Text.Equals("") && !textBox6.Text.Equals("") && !textBox7.Text.Equals("") && !textBox8.Text.Equals(""))
            {
                //TODO Definir TipoDoc (Enum?)
                int nroDoc = Convert.ToInt32(textBox1.Text);
                String apellido = textBox2.Text;
                String nombre = textBox3.Text;
                String mail = textBox6.Text;
                int tel = Convert.ToInt32(textBox5.Text);
                String direcc = textBox7.Text;
                int codPostal = Convert.ToInt32(textBox4.Text);
                //Verificar si la fecha de nacimiento no debiera seleccionarse como DateTimePicker
                DateTime fechaFin = Convert.ToDateTime(textBox8.Text);
                //TODO Asignar un usuario y password automáticos (Password con X tiempo de vida)

                //Crear cliente
                //Cliente nuevoCli = new Cliente(...);

                //Invocar función que agregue un cliente a la BD
                //nuevoCli.crearCliente(...);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MoficiarEliminar_Button_Click(object sender, EventArgs e)
        {
            //Botón "Modificar o Eliminar Cliente"

            //Redirigir al usuario a una nueva form de búsqueda con la opción de modificar/eliminar uno de los campos buscados
        }
    }
}
