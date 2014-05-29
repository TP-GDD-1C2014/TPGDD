using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using System.Data.SqlClient;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class ComprarOfertar : Form
    {
        public ComprarOfertar()
        {
            InitializeComponent();
            cargarPublicaciones(0,50);
        }

        public void cargarPublicaciones(int cant, int desde)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@cant", cant);
            BDSQL.agregarParametro(listaParametros, "@desde", desde);
            /*
            String commandtext = ("SELECT TOP (@cant) * " +
            "FROM MERCADONEGRO.Publicaciones " +
            "WHERE Cod_Publicacion NOT IN(Select TOP (@desde) Cod_Publicacion from MERCADONEGRO.Publicaciones) " +
            "AND Estado_Publicacion = 0 " +
            "AND Stock > 0 " +
            "AND Fecha_Vencimiento < GETUTCDATE() " +
            "ORDER BY Cod_Visibilidad" );
            */
            String commandtext = "WITH NumberedMyTable AS (SELECT Cod_Publicacion, Stock, ROW_NUMBER() OVER (ORDER BY Cod_Visibilidad) AS RowNumber " +
            "FROM MERCADONEGRO.Publicaciones WHERE Estado_Publicacion = 0 AND Stock > 0 AND Fecha_Vencimiento < GETUTCDATE() ) SELECT Cod_Publicacion,Stock FROM NumberedMyTable " +
            "WHERE RowNumber BETWEEN @cant AND @desde";
            DataTable ret = BDSQL.obtenerDataTable(commandtext, "T", listaParametros);

            dataGridView1.DataSource = ret;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                int filtro = Convert.ToInt32(textBox3.Text);
                cargarPublicaciones(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), filtro);
            }
            else cargarPublicaciones(Convert.ToInt32(textBox1.Text),Convert.ToInt32(textBox2.Text));
        }


        public void cargarPublicaciones(int desde, int hasta, int filtro)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@desde", desde);
            BDSQL.agregarParametro(listaParametros, "@hasta", hasta);
            BDSQL.agregarParametro(listaParametros, "@filtro", filtro);

            /*
            String commandtext = ("SELECT TOP (@cant) * " +
            "FROM MERCADONEGRO.Publicaciones " +
            "WHERE Cod_Publicacion NOT IN(Select TOP (@desde) Cod_Publicacion from MERCADONEGRO.Publicaciones) " +
            "AND Estado_Publicacion = 0 " +
            "AND Stock > 0 " +
            "AND Fecha_Vencimiento < GETUTCDATE() " +
            "ORDER BY Cod_Visibilidad" );
            */
            String commandtext = "WITH NumberedMyTable AS (SELECT Cod_Publicacion, Stock, ROW_NUMBER() OVER (ORDER BY Cod_Visibilidad) AS RowNumber " +
            "FROM MERCADONEGRO.Publicaciones WHERE Stock = @filtro AND Estado_Publicacion = 0 AND Stock > 0 AND Fecha_Vencimiento < GETUTCDATE() ) SELECT Cod_Publicacion,Stock FROM NumberedMyTable " +
            "WHERE RowNumber BETWEEN @cant AND @desde";
            DataTable ret = BDSQL.obtenerDataTable(commandtext, "T", listaParametros);

            dataGridView1.DataSource = ret;


        }

    }
    
}
