namespace FrbaCommerce.Comprar_Ofertar
{
    partial class ComprarOfertar
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
            this.Publicaciones_Datagrid = new System.Windows.Forms.DataGridView();
            this.btnAgregarRubros = new System.Windows.Forms.Button();
            this.btnAnteriorPag = new System.Windows.Forms.Button();
            this.btnSiguientePag = new System.Windows.Forms.Button();
            this.btnPrimerPag = new System.Windows.Forms.Button();
            this.btnUltimaPag = new System.Windows.Forms.Button();
            this.btnAbrirPublicacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbRubros = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnBorrarDescripcion = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCantPublicaciones = new System.Windows.Forms.Label();
            this.lblPaginaActual = new System.Windows.Forms.Label();
            this.txtCantPublicaciones = new System.Windows.Forms.TextBox();
            this.txtPaginaActual = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Publicaciones_Datagrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Publicaciones_Datagrid
            // 
            this.Publicaciones_Datagrid.AllowUserToAddRows = false;
            this.Publicaciones_Datagrid.AllowUserToDeleteRows = false;
            this.Publicaciones_Datagrid.AllowUserToResizeColumns = false;
            this.Publicaciones_Datagrid.AllowUserToResizeRows = false;
            this.Publicaciones_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Publicaciones_Datagrid.Location = new System.Drawing.Point(12, 96);
            this.Publicaciones_Datagrid.MultiSelect = false;
            this.Publicaciones_Datagrid.Name = "Publicaciones_Datagrid";
            this.Publicaciones_Datagrid.ReadOnly = true;
            this.Publicaciones_Datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Publicaciones_Datagrid.Size = new System.Drawing.Size(853, 422);
            this.Publicaciones_Datagrid.TabIndex = 0;
            // 
            // btnAgregarRubros
            // 
            this.btnAgregarRubros.Location = new System.Drawing.Point(276, 46);
            this.btnAgregarRubros.Name = "btnAgregarRubros";
            this.btnAgregarRubros.Size = new System.Drawing.Size(121, 23);
            this.btnAgregarRubros.TabIndex = 3;
            this.btnAgregarRubros.Text = "Agregar rubros";
            this.btnAgregarRubros.UseVisualStyleBackColor = true;
            this.btnAgregarRubros.Click += new System.EventHandler(this.btnAgregarRubros_Click);
            // 
            // btnAnteriorPag
            // 
            this.btnAnteriorPag.Location = new System.Drawing.Point(368, 540);
            this.btnAnteriorPag.Name = "btnAnteriorPag";
            this.btnAnteriorPag.Size = new System.Drawing.Size(19, 23);
            this.btnAnteriorPag.TabIndex = 5;
            this.btnAnteriorPag.Text = "<";
            this.btnAnteriorPag.UseVisualStyleBackColor = true;
            this.btnAnteriorPag.Click += new System.EventHandler(this.btnAnteriorPag_Click);
            // 
            // btnSiguientePag
            // 
            this.btnSiguientePag.Location = new System.Drawing.Point(393, 540);
            this.btnSiguientePag.Name = "btnSiguientePag";
            this.btnSiguientePag.Size = new System.Drawing.Size(19, 23);
            this.btnSiguientePag.TabIndex = 6;
            this.btnSiguientePag.Text = ">";
            this.btnSiguientePag.UseVisualStyleBackColor = true;
            this.btnSiguientePag.Click += new System.EventHandler(this.btnSiguientePag_Click);
            // 
            // btnPrimerPag
            // 
            this.btnPrimerPag.Location = new System.Drawing.Point(287, 540);
            this.btnPrimerPag.Name = "btnPrimerPag";
            this.btnPrimerPag.Size = new System.Drawing.Size(75, 23);
            this.btnPrimerPag.TabIndex = 7;
            this.btnPrimerPag.Text = "Primera";
            this.btnPrimerPag.UseVisualStyleBackColor = true;
            this.btnPrimerPag.Click += new System.EventHandler(this.btnPrimerPag_Click);
            // 
            // btnUltimaPag
            // 
            this.btnUltimaPag.Location = new System.Drawing.Point(418, 540);
            this.btnUltimaPag.Name = "btnUltimaPag";
            this.btnUltimaPag.Size = new System.Drawing.Size(75, 23);
            this.btnUltimaPag.TabIndex = 8;
            this.btnUltimaPag.Text = "Ultima";
            this.btnUltimaPag.UseVisualStyleBackColor = true;
            this.btnUltimaPag.Click += new System.EventHandler(this.btnUltimaPag_Click);
            // 
            // btnAbrirPublicacion
            // 
            this.btnAbrirPublicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirPublicacion.Location = new System.Drawing.Point(685, 532);
            this.btnAbrirPublicacion.Name = "btnAbrirPublicacion";
            this.btnAbrirPublicacion.Size = new System.Drawing.Size(180, 38);
            this.btnAbrirPublicacion.TabIndex = 9;
            this.btnAbrirPublicacion.Text = "Abrir Publicacion";
            this.btnAbrirPublicacion.UseVisualStyleBackColor = true;
            this.btnAbrirPublicacion.Click += new System.EventHandler(this.btnAbrirPublicacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Rubro/s:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnBorrarDescripcion);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.cmbRubros);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAgregarRubros);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 78);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(95, 19);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(175, 20);
            this.txtDescripcion.TabIndex = 13;
            // 
            // cmbRubros
            // 
            this.cmbRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRubros.FormattingEnabled = true;
            this.cmbRubros.Location = new System.Drawing.Point(95, 48);
            this.cmbRubros.Name = "cmbRubros";
            this.cmbRubros.Size = new System.Drawing.Size(175, 21);
            this.cmbRubros.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(417, 46);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(23, 22);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 14;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // btnBorrarDescripcion
            // 
            this.btnBorrarDescripcion.Location = new System.Drawing.Point(276, 17);
            this.btnBorrarDescripcion.Name = "btnBorrarDescripcion";
            this.btnBorrarDescripcion.Size = new System.Drawing.Size(121, 23);
            this.btnBorrarDescripcion.TabIndex = 15;
            this.btnBorrarDescripcion.Text = "Borrar descripción";
            this.btnBorrarDescripcion.UseVisualStyleBackColor = true;
            this.btnBorrarDescripcion.Click += new System.EventHandler(this.btnBorrarDescripcion_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(417, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(111, 23);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Sin filtros!";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPaginaActual);
            this.groupBox2.Controls.Add(this.txtCantPublicaciones);
            this.groupBox2.Controls.Add(this.lblPaginaActual);
            this.groupBox2.Controls.Add(this.lblCantPublicaciones);
            this.groupBox2.Location = new System.Drawing.Point(572, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 78);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados:";
            // 
            // lblCantPublicaciones
            // 
            this.lblCantPublicaciones.AutoSize = true;
            this.lblCantPublicaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantPublicaciones.Location = new System.Drawing.Point(23, 22);
            this.lblCantPublicaciones.Name = "lblCantPublicaciones";
            this.lblCantPublicaciones.Size = new System.Drawing.Size(135, 13);
            this.lblCantPublicaciones.TabIndex = 0;
            this.lblCantPublicaciones.Text = "Cantidad de publicaciones:";
            // 
            // lblPaginaActual
            // 
            this.lblPaginaActual.AutoSize = true;
            this.lblPaginaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginaActual.Location = new System.Drawing.Point(23, 51);
            this.lblPaginaActual.Name = "lblPaginaActual";
            this.lblPaginaActual.Size = new System.Drawing.Size(75, 13);
            this.lblPaginaActual.TabIndex = 1;
            this.lblPaginaActual.Text = "Página actual:";
            // 
            // txtCantPublicaciones
            // 
            this.txtCantPublicaciones.Enabled = false;
            this.txtCantPublicaciones.Location = new System.Drawing.Point(164, 19);
            this.txtCantPublicaciones.Name = "txtCantPublicaciones";
            this.txtCantPublicaciones.Size = new System.Drawing.Size(68, 20);
            this.txtCantPublicaciones.TabIndex = 2;
            // 
            // txtPaginaActual
            // 
            this.txtPaginaActual.Enabled = false;
            this.txtPaginaActual.Location = new System.Drawing.Point(164, 48);
            this.txtPaginaActual.Name = "txtPaginaActual";
            this.txtPaginaActual.Size = new System.Drawing.Size(68, 20);
            this.txtPaginaActual.TabIndex = 3;
            // 
            // ComprarOfertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 576);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAbrirPublicacion);
            this.Controls.Add(this.btnUltimaPag);
            this.Controls.Add(this.btnPrimerPag);
            this.Controls.Add(this.btnSiguientePag);
            this.Controls.Add(this.btnAnteriorPag);
            this.Controls.Add(this.Publicaciones_Datagrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ComprarOfertar";
            this.Text = "Comprar/Ofertar Publicaciones";
            ((System.ComponentModel.ISupportInitialize)(this.Publicaciones_Datagrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Publicaciones_Datagrid;
        private System.Windows.Forms.Button btnAgregarRubros;
        private System.Windows.Forms.Button btnAnteriorPag;
        private System.Windows.Forms.Button btnSiguientePag;
        private System.Windows.Forms.Button btnPrimerPag;
        private System.Windows.Forms.Button btnUltimaPag;
        private System.Windows.Forms.Button btnAbrirPublicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbRubros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBorrarDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCantPublicaciones;
        private System.Windows.Forms.Label lblPaginaActual;
        private System.Windows.Forms.Label lblCantPublicaciones;
        private System.Windows.Forms.TextBox txtPaginaActual;
    }
}