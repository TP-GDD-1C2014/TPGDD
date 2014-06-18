namespace FrbaCommerce.Abm_Cliente
{
    partial class ABMClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.registrar = new System.Windows.Forms.Button();
            this.cbAno = new System.Windows.Forms.ComboBox();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.cbDia = new System.Windows.Forms.ComboBox();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.tNombre = new System.Windows.Forms.TextBox();
            this.tApellido = new System.Windows.Forms.TextBox();
            this.tCodigoPostal = new System.Windows.Forms.TextBox();
            this.tDireccion = new System.Windows.Forms.TextBox();
            this.tTelefono = new System.Windows.Forms.TextBox();
            this.tEmail = new System.Windows.Forms.TextBox();
            this.tNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbFiltroTipoDocumento = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.tBusqueda = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.registrar);
            this.groupBox1.Controls.Add(this.cbAno);
            this.groupBox1.Controls.Add(this.cbMes);
            this.groupBox1.Controls.Add(this.cbDia);
            this.groupBox1.Controls.Add(this.cbTipoDocumento);
            this.groupBox1.Controls.Add(this.tNombre);
            this.groupBox1.Controls.Add(this.tApellido);
            this.groupBox1.Controls.Add(this.tCodigoPostal);
            this.groupBox1.Controls.Add(this.tDireccion);
            this.groupBox1.Controls.Add(this.tTelefono);
            this.groupBox1.Controls.Add(this.tEmail);
            this.groupBox1.Controls.Add(this.tNumeroDocumento);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo cliente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "(*) = Campo obligatorio";
            // 
            // registrar
            // 
            this.registrar.Location = new System.Drawing.Point(140, 287);
            this.registrar.Name = "registrar";
            this.registrar.Size = new System.Drawing.Size(152, 30);
            this.registrar.TabIndex = 11;
            this.registrar.Text = "Registrar";
            this.registrar.UseVisualStyleBackColor = true;
            this.registrar.Click += new System.EventHandler(this.registrar_Click);
            // 
            // cbAno
            // 
            this.cbAno.FormattingEnabled = true;
            this.cbAno.Location = new System.Drawing.Point(240, 257);
            this.cbAno.Name = "cbAno";
            this.cbAno.Size = new System.Drawing.Size(52, 21);
            this.cbAno.TabIndex = 10;
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(190, 257);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(40, 21);
            this.cbMes.TabIndex = 9;
            // 
            // cbDia
            // 
            this.cbDia.FormattingEnabled = true;
            this.cbDia.Location = new System.Drawing.Point(140, 257);
            this.cbDia.Name = "cbDia";
            this.cbDia.Size = new System.Drawing.Size(40, 21);
            this.cbDia.TabIndex = 8;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Location = new System.Drawing.Point(140, 77);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(152, 21);
            this.cbTipoDocumento.TabIndex = 2;
            // 
            // tNombre
            // 
            this.tNombre.Location = new System.Drawing.Point(140, 17);
            this.tNombre.MaxLength = 255;
            this.tNombre.Name = "tNombre";
            this.tNombre.Size = new System.Drawing.Size(152, 20);
            this.tNombre.TabIndex = 0;
            this.tNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNoNumerico_KeyPress);
            // 
            // tApellido
            // 
            this.tApellido.Location = new System.Drawing.Point(140, 47);
            this.tApellido.MaxLength = 255;
            this.tApellido.Name = "tApellido";
            this.tApellido.Size = new System.Drawing.Size(152, 20);
            this.tApellido.TabIndex = 1;
            this.tApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNoNumerico_KeyPress);
            // 
            // tCodigoPostal
            // 
            this.tCodigoPostal.Location = new System.Drawing.Point(140, 227);
            this.tCodigoPostal.MaxLength = 50;
            this.tCodigoPostal.Name = "tCodigoPostal";
            this.tCodigoPostal.Size = new System.Drawing.Size(152, 20);
            this.tCodigoPostal.TabIndex = 7;
            this.tCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // tDireccion
            // 
            this.tDireccion.Location = new System.Drawing.Point(140, 197);
            this.tDireccion.MaxLength = 255;
            this.tDireccion.Name = "tDireccion";
            this.tDireccion.Size = new System.Drawing.Size(152, 20);
            this.tDireccion.TabIndex = 6;
            // 
            // tTelefono
            // 
            this.tTelefono.Location = new System.Drawing.Point(140, 167);
            this.tTelefono.MaxLength = 18;
            this.tTelefono.Name = "tTelefono";
            this.tTelefono.Size = new System.Drawing.Size(152, 20);
            this.tTelefono.TabIndex = 5;
            this.tTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // tEmail
            // 
            this.tEmail.Location = new System.Drawing.Point(140, 137);
            this.tEmail.MaxLength = 255;
            this.tEmail.Name = "tEmail";
            this.tEmail.Size = new System.Drawing.Size(152, 20);
            this.tEmail.TabIndex = 4;
            // 
            // tNumeroDocumento
            // 
            this.tNumeroDocumento.Location = new System.Drawing.Point(140, 107);
            this.tNumeroDocumento.MaxLength = 18;
            this.tNumeroDocumento.Name = "tNumeroDocumento";
            this.tNumeroDocumento.Size = new System.Drawing.Size(152, 20);
            this.tNumeroDocumento.TabIndex = 3;
            this.tNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Fecha de nacimiento (*)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Código Postal (*)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Dirección (*)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Teléfono (*)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "E-mail (*)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Número de documento (*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de documento (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido (*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre (*)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbFiltroTipoDocumento);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbFiltro);
            this.groupBox2.Controls.Add(this.tBusqueda);
            this.groupBox2.Location = new System.Drawing.Point(10, 340);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 75);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Baja o modificación de clientes";
            // 
            // cbFiltroTipoDocumento
            // 
            this.cbFiltroTipoDocumento.FormattingEnabled = true;
            this.cbFiltroTipoDocumento.Location = new System.Drawing.Point(100, 42);
            this.cbFiltroTipoDocumento.Name = "cbFiltroTipoDocumento";
            this.cbFiltroTipoDocumento.Size = new System.Drawing.Size(130, 21);
            this.cbFiltroTipoDocumento.TabIndex = 1;
            this.cbFiltroTipoDocumento.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Filtrar por:";
            // 
            // cbFiltro
            // 
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(9, 42);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(82, 21);
            this.cbFiltro.TabIndex = 0;
            this.cbFiltro.SelectedIndexChanged += new System.EventHandler(this.cbFiltro_SelectedIndexChanged);
            // 
            // tBusqueda
            // 
            this.tBusqueda.Location = new System.Drawing.Point(100, 42);
            this.tBusqueda.MaxLength = 255;
            this.tBusqueda.Name = "tBusqueda";
            this.tBusqueda.Size = new System.Drawing.Size(130, 20);
            this.tBusqueda.TabIndex = 0;
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(10, 425);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(85, 30);
            this.back.TabIndex = 0;
            this.back.Text = "<< Volver";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click_1);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(222, 425);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(85, 30);
            this.limpiarButton.TabIndex = 2;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // ABMClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 464);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.back);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ABMClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Clientes - MercadoNegro";
            this.Load += new System.EventHandler(this.ABMClientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbDia;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.TextBox tApellido;
        private System.Windows.Forms.TextBox tCodigoPostal;
        private System.Windows.Forms.TextBox tDireccion;
        private System.Windows.Forms.TextBox tTelefono;
        private System.Windows.Forms.TextBox tEmail;
        private System.Windows.Forms.TextBox tNumeroDocumento;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbAno;
        private System.Windows.Forms.Button registrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.TextBox tBusqueda;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbFiltroTipoDocumento;
        private System.Windows.Forms.Button limpiarButton;
    }
}