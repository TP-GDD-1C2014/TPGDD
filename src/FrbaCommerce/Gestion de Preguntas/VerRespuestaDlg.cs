﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class VerRespuestaDlg : Form
    {
        public VerRespuestaDlg(string pregunta, string respuesta, DateTime fechaRespuesta)
        {
            InitializeComponent();
            txtPregunta.Text = pregunta;
            txtRespuesta.Text = respuesta;
            txtFechaRespuesta.Text = Convert.ToString(fechaRespuesta);
        }
    }
}
