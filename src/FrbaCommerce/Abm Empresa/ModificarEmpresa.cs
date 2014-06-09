﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class ModificarEmpresa : Form
    {
        public BuscarEmpresa formAnterior { get; set; }

        public int ID_User { get; set; }

        public string vUsername { get; set; }
        public string vPassword { get; set; }
        public int vHabilitado { get; set; }
        public string vPublicacionesGratuitas { get; set; }

        public string vRazonSocial { get; set; }
        public string vCUIT { get; set; }
        public string vTelefono { get; set; }
        public string vDireccion { get; set; }
        public string vCodigoPostal { get; set; }
        public string vCiudad { get; set; }
        public string vEmail { get; set; }
        public string vNombreDeContacto { get; set; }
        public int vDia { get; set; }
        public int vMes { get; set; }
        public int vAno { get; set; }

        public ModificarEmpresa(int _ID_User, BuscarEmpresa _formAnterior)
        {
            this.ID_User = _ID_User;
            this.formAnterior = _formAnterior;

            InitializeComponent();

            setearComboBoxes();
            cargarDatosUsuario();
            cargarDatosEmpresa();

            cargarDatosViejos();
        }

        public void cargarDatosViejos()
        {
            this.vUsername = tUsername.Text;
            this.vPassword = tPassword.Text;
            this.vHabilitado = cbHabilitado.SelectedIndex;
            this.vPublicacionesGratuitas = tPublicacionesGratuitas.Text;

            this.vRazonSocial = tRazonSocial.Text;
            this.vCUIT = tCUIT.Text;
            this.vTelefono = tTelefono.Text;
            this.vDireccion = tDireccion.Text;
            this.vCodigoPostal = tCodigoPostal.Text;
            this.vCiudad = tCiudad.Text;
            this.vEmail = tEmail.Text;
            this.vNombreDeContacto = tNombreDeContacto.Text;
            this.vDia = cbDia.SelectedIndex;
            this.vMes = cbMes.SelectedIndex;
            this.vAno = cbAno.SelectedIndex;
        }

        public void setearComboBoxes()
        {
            cbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHabilitado.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarCbDia();
            llenarCbMes();
            llenarCbAno();
            llenarCbHabilitado();
        }

        public void llenarCbHabilitado()
        {
            this.cbHabilitado.Items.Add("No");
            this.cbHabilitado.Items.Add("Sí");
        }

        public void llenarCbDia()
        {
            int i;
            for (i = 0; i <= 31; i++)
            {
                this.cbDia.Items.Add(i.ToString());
            }
        }

        public void llenarCbMes()
        {
            int i;
            for (i = 0; i <= 12; i++)
            {
                this.cbMes.Items.Add(i.ToString());
            }
        }

        public void llenarCbAno()
        {
            int i;
            for (i = 1000; i <= 2014; i++)
            {
                this.cbAno.Items.Add(i.ToString());
            }
        }

        public void cargarDatosEmpresa()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Razon_Social, CUIT, Telefono, Direccion, Codigo_Postal, Ciudad, Mail, Nombre_Contacto, DAY(Fecha_Creacion) AS Fecha_Creacion_Dia, MONTH(Fecha_Creacion) AS Fecha_Creacion_Mes, YEAR(Fecha_Creacion) AS Fecha_Creacion_Ano  FROM MERCADONEGRO.Empresas WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            lector.Read();

            tRazonSocial.Text = Convert.ToString(lector["Razon_Social"]);
            tCUIT.Text = Convert.ToString(lector["CUIT"]);

            if (lector["Telefono"] != DBNull.Value)
            {
                tTelefono.Text = Convert.ToInt32(lector["Telefono"]).ToString();
            }
            else
            {
                tTelefono.Text = "";
            }

            tDireccion.Text = Convert.ToString(lector["Direccion"]);
            tCodigoPostal.Text = Convert.ToString(lector["Codigo_Postal"]);

            if (lector["Ciudad"] != DBNull.Value)
            {
                tCiudad.Text = Convert.ToString(lector["Ciudad"]);
            }
            else
            {
                tCiudad.Text = "";
            }

            tEmail.Text = Convert.ToString(lector["Mail"]);

            if (lector["Nombre_Contacto"] != DBNull.Value)
            {
                tNombreDeContacto.Text = Convert.ToString(lector["Nombre_Contacto"]);
            }
            else
            {
                tNombreDeContacto.Text = "";
            }

            cbDia.SelectedIndex = Convert.ToInt32(lector["Fecha_Creacion_Dia"]);
            cbMes.SelectedIndex = Convert.ToInt32(lector["Fecha_Creacion_Mes"]);
            cbAno.SelectedIndex = Convert.ToInt32(lector["Fecha_Creacion_Ano"]) - 1000;

            BDSQL.cerrarConexion();
        }

        public void cargarDatosUsuario()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            SqlDataReader lector = BDSQL.ejecutarReader("SELECT Username, Habilitado, Cant_Publi_Gratuitas FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            lector.Read();

            tUsername.Text = Convert.ToString(lector["Username"]);

            if (Convert.ToInt32(lector["Habilitado"]) == 0)
            {
                cbHabilitado.SelectedIndex = 0;
            }
            else
            {
                cbHabilitado.SelectedIndex = 1;
            }

            tPublicacionesGratuitas.Text = Convert.ToString(lector["Cant_Publi_Gratuitas"]);

            BDSQL.cerrarConexion();
        }

        private void ModificarEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formAnterior.Show();
        }

        public Boolean cambioString(string string1, string string2)
        {
            return string1.Equals(string2);
        }

        public Boolean cambioInt(int int1, int int2)
        {
            if (int1 == int2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[i].ToString("X2"));
            }
            return salida.ToString();
        }

        public void cambiarStringUsuarios(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Valor", valor);
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public void cambiarIntUsuarios(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            BDSQL.agregarParametro(listaParametros, "@Valor", valor);
            BDSQL.agregarParametro(listaParametros, "@ID_User", this.ID_User);
            BDSQL.ejecutarQuery("UPDATE MERCADONEGRO.Usuarios SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, BDSQL.iniciarConexion());
            BDSQL.cerrarConexion();
        }

        public string hashear(string valor)
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(valor));
            return bytesDeHasheoToString(bytesDeHasheo);
        }

        public Boolean usernameValido()
        {
            if (!tUsername.Text.Equals("") && !BDSQL.existeString(tUsername.Text, "MERCADONEGRO.Usuarios", "Username"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void bModificar_Click(object sender, EventArgs e)
        {
            if (cambioString(this.vUsername, tUsername.Text))
            {
                if (usernameValido())
                {
                    cambiarStringUsuarios("Username", tUsername.Text);
                }
                else
                {
                    MessageBox.Show("Nombre de usuario inválido.", "Error");
                }
            }

            if (cambioString(this.vPassword, tPassword.Text))
            {
                cambiarStringUsuarios("Password", hashear(tPassword.Text));
            }

            if (cambioInt(this.vHabilitado, cbHabilitado.SelectedIndex))
            {
                cambiarIntUsuarios("Habilitado", cbHabilitado.SelectedIndex);
            }

            if (cambioString(this.vPublicacionesGratuitas, tPublicacionesGratuitas.Text))
            {
                if ((Convert.ToInt32(tPublicacionesGratuitas.Text) <= 255) && (Convert.ToInt32(tPublicacionesGratuitas.Text) >= 0))
                {
                    cambiarIntUsuarios("Cant_Publi_Gratuitas", (Convert.ToInt32(tPublicacionesGratuitas.Text)));
                }
                else
                {
                    MessageBox.Show("Cantidad de publicaciones gratuitas inválida.", "Error");
                }
            }

            if (cambioString(this.vRazonSocial, tRazonSocial.Text))
            {
            }

            if (cambioString(this.vCUIT, tCUIT.Text))
            {
            }

            if (cambioString(this.vTelefono, tTelefono.Text))
            {
            }

            if (cambioString(this.vDireccion, tDireccion.Text))
            {
            }

            if (cambioString(this.vCodigoPostal, tCodigoPostal.Text))
            {
            }

            if (cambioString(this.vCiudad, tCiudad.Text))
            {
            }

            if (cambioString(this.vEmail, tEmail.Text))
            {
            }

            if (cambioString(this.vNombreDeContacto, tNombreDeContacto.Text))
            {
            }

            if (cambioInt(vDia, cbDia.SelectedIndex) || cambioInt(vMes, cbMes.SelectedIndex) || cambioInt(vAno, cbAno.SelectedIndex))
            {
            }
        }
    }
}
