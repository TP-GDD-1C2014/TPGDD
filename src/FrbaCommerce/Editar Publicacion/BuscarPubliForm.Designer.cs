namespace FrbaCommerce.Editar_Publicacion
{
    partial class BuscarPubliForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.descrip_label = new System.Windows.Forms.Label();
            this.Descrip_TextBox = new System.Windows.Forms.TextBox();
            this.stockInic_label = new System.Windows.Forms.Label();
            this.StockInicial_TextBox = new System.Windows.Forms.TextBox();
            this.CodPubli_textBox = new System.Windows.Forms.TextBox();
            this.codPubli_label = new System.Windows.Forms.Label();
            this.estadoPubli_label = new System.Windows.Forms.Label();
            this.Estado_ComboBox = new System.Windows.Forms.ComboBox();
            this.TipoPubli_ComboBox = new System.Windows.Forms.ComboBox();
            this.tipoPubli_label = new System.Windows.Forms.Label();
            this.limpiar_button = new System.Windows.Forms.Button();
            this.filtrar_button = new System.Windows.Forms.Button();
            this.modificar_button = new System.Windows.Forms.Button();
            this.codVisib_label = new System.Windows.Forms.Label();
            this.Visibilidad_ComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.precio_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.borrar_button = new System.Windows.Forms.Button();
            this.volver_button = new System.Windows.Forms.Button();
            this.fechaVenc_checkBox = new System.Windows.Forms.CheckBox();
            this.fechaInic_checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 189);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(675, 265);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // descrip_label
            // 
            this.descrip_label.AutoSize = true;
            this.descrip_label.Location = new System.Drawing.Point(24, 68);
            this.descrip_label.Name = "descrip_label";
            this.descrip_label.Size = new System.Drawing.Size(63, 13);
            this.descrip_label.TabIndex = 1;
            this.descrip_label.Text = "Descripcion";
            // 
            // Descrip_TextBox
            // 
            this.Descrip_TextBox.Location = new System.Drawing.Point(128, 65);
            this.Descrip_TextBox.Name = "Descrip_TextBox";
            this.Descrip_TextBox.Size = new System.Drawing.Size(215, 20);
            this.Descrip_TextBox.TabIndex = 2;
            this.Descrip_TextBox.TextChanged += new System.EventHandler(this.Descrip_TextBox_TextChanged);
            // 
            // stockInic_label
            // 
            this.stockInic_label.AutoSize = true;
            this.stockInic_label.Location = new System.Drawing.Point(24, 94);
            this.stockInic_label.Name = "stockInic_label";
            this.stockInic_label.Size = new System.Drawing.Size(35, 13);
            this.stockInic_label.TabIndex = 3;
            this.stockInic_label.Text = "Stock";
            // 
            // StockInicial_TextBox
            // 
            this.StockInicial_TextBox.Location = new System.Drawing.Point(128, 91);
            this.StockInicial_TextBox.Name = "StockInicial_TextBox";
            this.StockInicial_TextBox.Size = new System.Drawing.Size(71, 20);
            this.StockInicial_TextBox.TabIndex = 4;
            // 
            // CodPubli_textBox
            // 
            this.CodPubli_textBox.Location = new System.Drawing.Point(128, 12);
            this.CodPubli_textBox.Name = "CodPubli_textBox";
            this.CodPubli_textBox.Size = new System.Drawing.Size(71, 20);
            this.CodPubli_textBox.TabIndex = 5;
            // 
            // codPubli_label
            // 
            this.codPubli_label.AutoSize = true;
            this.codPubli_label.Location = new System.Drawing.Point(24, 15);
            this.codPubli_label.Name = "codPubli_label";
            this.codPubli_label.Size = new System.Drawing.Size(98, 13);
            this.codPubli_label.TabIndex = 6;
            this.codPubli_label.Text = "Codigo Publicacion";
            // 
            // estadoPubli_label
            // 
            this.estadoPubli_label.AutoSize = true;
            this.estadoPubli_label.Location = new System.Drawing.Point(362, 66);
            this.estadoPubli_label.Name = "estadoPubli_label";
            this.estadoPubli_label.Size = new System.Drawing.Size(98, 13);
            this.estadoPubli_label.TabIndex = 7;
            this.estadoPubli_label.Text = "Estado Publicación";
            // 
            // Estado_ComboBox
            // 
            this.Estado_ComboBox.FormattingEnabled = true;
            this.Estado_ComboBox.Location = new System.Drawing.Point(478, 63);
            this.Estado_ComboBox.Name = "Estado_ComboBox";
            this.Estado_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.Estado_ComboBox.TabIndex = 10;
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);
            // 
            // TipoPubli_ComboBox
            // 
            this.TipoPubli_ComboBox.FormattingEnabled = true;
            this.TipoPubli_ComboBox.Location = new System.Drawing.Point(478, 90);
            this.TipoPubli_ComboBox.Name = "TipoPubli_ComboBox";
            this.TipoPubli_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.TipoPubli_ComboBox.TabIndex = 11;
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);
            // 
            // tipoPubli_label
            // 
            this.tipoPubli_label.AutoSize = true;
            this.tipoPubli_label.Location = new System.Drawing.Point(362, 93);
            this.tipoPubli_label.Name = "tipoPubli_label";
            this.tipoPubli_label.Size = new System.Drawing.Size(86, 13);
            this.tipoPubli_label.TabIndex = 12;
            this.tipoPubli_label.Text = "Tipo Publicacion";
            // 
            // limpiar_button
            // 
            this.limpiar_button.Location = new System.Drawing.Point(553, 121);
            this.limpiar_button.Name = "limpiar_button";
            this.limpiar_button.Size = new System.Drawing.Size(125, 45);
            this.limpiar_button.TabIndex = 20;
            this.limpiar_button.Text = "Limpiar";
            this.limpiar_button.UseVisualStyleBackColor = true;
            this.limpiar_button.Click += new System.EventHandler(this.limpiar_button_Click);
            // 
            // filtrar_button
            // 
            this.filtrar_button.BackColor = System.Drawing.SystemColors.Control;
            this.filtrar_button.Location = new System.Drawing.Point(365, 121);
            this.filtrar_button.Name = "filtrar_button";
            this.filtrar_button.Size = new System.Drawing.Size(125, 45);
            this.filtrar_button.TabIndex = 21;
            this.filtrar_button.Text = "Filtrar";
            this.filtrar_button.UseVisualStyleBackColor = false;
            this.filtrar_button.Click += new System.EventHandler(this.filtrar_button_Click);
            // 
            // modificar_button
            // 
            this.modificar_button.Location = new System.Drawing.Point(27, 460);
            this.modificar_button.Name = "modificar_button";
            this.modificar_button.Size = new System.Drawing.Size(125, 45);
            this.modificar_button.TabIndex = 22;
            this.modificar_button.Text = "Modificar";
            this.modificar_button.UseVisualStyleBackColor = true;
            this.modificar_button.Click += new System.EventHandler(this.modificar_button_Click_1);
            // 
            // codVisib_label
            // 
            this.codVisib_label.AutoSize = true;
            this.codVisib_label.Location = new System.Drawing.Point(24, 41);
            this.codVisib_label.Name = "codVisib_label";
            this.codVisib_label.Size = new System.Drawing.Size(89, 13);
            this.codVisib_label.TabIndex = 23;
            this.codVisib_label.Text = "Codigo Visibilidad";
            // 
            // Visibilidad_ComboBox
            // 
            this.Visibilidad_ComboBox.FormattingEnabled = true;
            this.Visibilidad_ComboBox.Location = new System.Drawing.Point(128, 38);
            this.Visibilidad_ComboBox.Name = "Visibilidad_ComboBox";
            this.Visibilidad_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.Visibilidad_ComboBox.TabIndex = 24;
            this.Visibilidad_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_ComboBox_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(478, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 27;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(478, 37);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 28;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Fecha Vencimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Fecha Inicial";
            // 
            // precio_textBox
            // 
            this.precio_textBox.Location = new System.Drawing.Point(128, 118);
            this.precio_textBox.Name = "precio_textBox";
            this.precio_textBox.Size = new System.Drawing.Size(71, 20);
            this.precio_textBox.TabIndex = 31;
            this.precio_textBox.TextChanged += new System.EventHandler(this.precio_textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Precio";
            // 
            // borrar_button
            // 
            this.borrar_button.Location = new System.Drawing.Point(304, 460);
            this.borrar_button.Name = "borrar_button";
            this.borrar_button.Size = new System.Drawing.Size(125, 45);
            this.borrar_button.TabIndex = 35;
            this.borrar_button.Text = "Borrar";
            this.borrar_button.UseVisualStyleBackColor = true;
            this.borrar_button.Click += new System.EventHandler(this.borrar_button_Click);
            // 
            // volver_button
            // 
            this.volver_button.Location = new System.Drawing.Point(577, 460);
            this.volver_button.Name = "volver_button";
            this.volver_button.Size = new System.Drawing.Size(125, 45);
            this.volver_button.TabIndex = 36;
            this.volver_button.Text = "Volver";
            this.volver_button.UseVisualStyleBackColor = true;
            this.volver_button.Click += new System.EventHandler(this.volver_button_Click);
            // 
            // fechaVenc_checkBox
            // 
            this.fechaVenc_checkBox.AutoSize = true;
            this.fechaVenc_checkBox.Location = new System.Drawing.Point(684, 15);
            this.fechaVenc_checkBox.Name = "fechaVenc_checkBox";
            this.fechaVenc_checkBox.Size = new System.Drawing.Size(15, 14);
            this.fechaVenc_checkBox.TabIndex = 37;
            this.fechaVenc_checkBox.UseVisualStyleBackColor = true;
            this.fechaVenc_checkBox.CheckedChanged += new System.EventHandler(this.fechaVenc_checkBox_CheckedChanged);
            // 
            // fechaInic_checkBox
            // 
            this.fechaInic_checkBox.AutoSize = true;
            this.fechaInic_checkBox.Location = new System.Drawing.Point(684, 41);
            this.fechaInic_checkBox.Name = "fechaInic_checkBox";
            this.fechaInic_checkBox.Size = new System.Drawing.Size(15, 14);
            this.fechaInic_checkBox.TabIndex = 38;
            this.fechaInic_checkBox.UseVisualStyleBackColor = true;
            this.fechaInic_checkBox.CheckedChanged += new System.EventHandler(this.fechaInic_checkBox_CheckedChanged);
            // 
            // BuscarPubliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 517);
            this.Controls.Add(this.fechaInic_checkBox);
            this.Controls.Add(this.fechaVenc_checkBox);
            this.Controls.Add(this.volver_button);
            this.Controls.Add(this.borrar_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.precio_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Visibilidad_ComboBox);
            this.Controls.Add(this.codVisib_label);
            this.Controls.Add(this.modificar_button);
            this.Controls.Add(this.filtrar_button);
            this.Controls.Add(this.limpiar_button);
            this.Controls.Add(this.tipoPubli_label);
            this.Controls.Add(this.TipoPubli_ComboBox);
            this.Controls.Add(this.Estado_ComboBox);
            this.Controls.Add(this.estadoPubli_label);
            this.Controls.Add(this.codPubli_label);
            this.Controls.Add(this.CodPubli_textBox);
            this.Controls.Add(this.StockInicial_TextBox);
            this.Controls.Add(this.stockInic_label);
            this.Controls.Add(this.Descrip_TextBox);
            this.Controls.Add(this.descrip_label);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BuscarPubliForm";
            this.Text = "Buscar Publicacion";
            this.Load += new System.EventHandler(this.BuscarPubliForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label descrip_label;
        private System.Windows.Forms.TextBox Descrip_TextBox;
        private System.Windows.Forms.Label stockInic_label;
        private System.Windows.Forms.TextBox StockInicial_TextBox;
        private System.Windows.Forms.TextBox CodPubli_textBox;
        private System.Windows.Forms.Label codPubli_label;
        private System.Windows.Forms.Label estadoPubli_label;
        private System.Windows.Forms.ComboBox Estado_ComboBox;
        private System.Windows.Forms.ComboBox TipoPubli_ComboBox;
        private System.Windows.Forms.Label tipoPubli_label;
        private System.Windows.Forms.Button limpiar_button;
        private System.Windows.Forms.Button filtrar_button;
        private System.Windows.Forms.Button modificar_button;
        private System.Windows.Forms.Label codVisib_label;
        private System.Windows.Forms.ComboBox Visibilidad_ComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox precio_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button borrar_button;
        private System.Windows.Forms.Button volver_button;
        private System.Windows.Forms.CheckBox fechaVenc_checkBox;
        private System.Windows.Forms.CheckBox fechaInic_checkBox;

    }
}