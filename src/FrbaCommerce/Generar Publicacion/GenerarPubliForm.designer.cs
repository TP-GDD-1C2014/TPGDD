namespace FrbaCommerce.Generar_Publicacion
{
    partial class GenerarPubliForm
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
            this.Descrip_TextBox = new System.Windows.Forms.TextBox();
            this.Visibilidad_Label = new System.Windows.Forms.Label();
            this.Descripcion_Label = new System.Windows.Forms.Label();
            this.Visibilidad_ComboBox = new System.Windows.Forms.ComboBox();
            this.Stock_Label = new System.Windows.Forms.Label();
            this.Stock_TextBox = new System.Windows.Forms.TextBox();
            this.FechaFin_Label = new System.Windows.Forms.Label();
            this.Estado_Label = new System.Windows.Forms.Label();
            this.Estado_ComboBox = new System.Windows.Forms.ComboBox();
            this.Tipo_Label = new System.Windows.Forms.Label();
            this.TipoPubli_ComboBox = new System.Windows.Forms.ComboBox();
            this.FechaFin_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.PrecioUnit_textBox = new System.Windows.Forms.TextBox();
            this.PrecioUnit_Label = new System.Windows.Forms.Label();
            this.PrecioTotal_Label = new System.Windows.Forms.Label();
            this.PrecioTotal_textBox = new System.Windows.Forms.TextBox();
            this.Limpiar_button = new System.Windows.Forms.Button();
            this.Guardar_button = new System.Windows.Forms.Button();
            this.PermitirPreg_label = new System.Windows.Forms.Label();
            this.permitirPreg_combobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Descrip_TextBox
            // 
            this.Descrip_TextBox.Location = new System.Drawing.Point(144, 51);
            this.Descrip_TextBox.Name = "Descrip_TextBox";
            this.Descrip_TextBox.Size = new System.Drawing.Size(215, 20);
            this.Descrip_TextBox.TabIndex = 0;
            this.Descrip_TextBox.TextChanged += new System.EventHandler(this.Descrip_TextBox_TextChanged);
            // 
            // Visibilidad_Label
            // 
            this.Visibilidad_Label.AutoSize = true;
            this.Visibilidad_Label.Location = new System.Drawing.Point(15, 27);
            this.Visibilidad_Label.Name = "Visibilidad_Label";
            this.Visibilidad_Label.Size = new System.Drawing.Size(53, 13);
            this.Visibilidad_Label.TabIndex = 1;
            this.Visibilidad_Label.Text = "Visibilidad";
            this.Visibilidad_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // Descripcion_Label
            // 
            this.Descripcion_Label.AutoSize = true;
            this.Descripcion_Label.Location = new System.Drawing.Point(15, 54);
            this.Descripcion_Label.Name = "Descripcion_Label";
            this.Descripcion_Label.Size = new System.Drawing.Size(63, 13);
            this.Descripcion_Label.TabIndex = 2;
            this.Descripcion_Label.Text = "Descripción";
            // 
            // Visibilidad_ComboBox
            // 
            this.Visibilidad_ComboBox.FormattingEnabled = true;
            this.Visibilidad_ComboBox.Location = new System.Drawing.Point(144, 24);
            this.Visibilidad_ComboBox.Name = "Visibilidad_ComboBox";
            this.Visibilidad_ComboBox.Size = new System.Drawing.Size(215, 21);
            this.Visibilidad_ComboBox.TabIndex = 3;
            this.Visibilidad_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_ComboBox_SelectedIndexChanged);
            // 
            // Stock_Label
            // 
            this.Stock_Label.AutoSize = true;
            this.Stock_Label.Location = new System.Drawing.Point(15, 80);
            this.Stock_Label.Name = "Stock_Label";
            this.Stock_Label.Size = new System.Drawing.Size(65, 13);
            this.Stock_Label.TabIndex = 4;
            this.Stock_Label.Text = "Stock Inicial";
            // 
            // Stock_TextBox
            // 
            this.Stock_TextBox.Location = new System.Drawing.Point(144, 77);
            this.Stock_TextBox.Name = "Stock_TextBox";
            this.Stock_TextBox.Size = new System.Drawing.Size(71, 20);
            this.Stock_TextBox.TabIndex = 5;
            this.Stock_TextBox.TextChanged += new System.EventHandler(this.Stock_TextBox_TextChanged);
            // 
            // FechaFin_Label
            // 
            this.FechaFin_Label.AutoSize = true;
            this.FechaFin_Label.Location = new System.Drawing.Point(15, 107);
            this.FechaFin_Label.Name = "FechaFin_Label";
            this.FechaFin_Label.Size = new System.Drawing.Size(110, 13);
            this.FechaFin_Label.TabIndex = 6;
            this.FechaFin_Label.Text = "Fecha de Finalización";
            // 
            // Estado_Label
            // 
            this.Estado_Label.AutoSize = true;
            this.Estado_Label.Location = new System.Drawing.Point(15, 132);
            this.Estado_Label.Name = "Estado_Label";
            this.Estado_Label.Size = new System.Drawing.Size(40, 13);
            this.Estado_Label.TabIndex = 8;
            this.Estado_Label.Text = "Estado";
            // 
            // Estado_ComboBox
            // 
            this.Estado_ComboBox.FormattingEnabled = true;
            this.Estado_ComboBox.Location = new System.Drawing.Point(144, 129);
            this.Estado_ComboBox.Name = "Estado_ComboBox";
            this.Estado_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.Estado_ComboBox.TabIndex = 9;
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);
            // 
            // Tipo_Label
            // 
            this.Tipo_Label.AutoSize = true;
            this.Tipo_Label.Location = new System.Drawing.Point(15, 159);
            this.Tipo_Label.Name = "Tipo_Label";
            this.Tipo_Label.Size = new System.Drawing.Size(28, 13);
            this.Tipo_Label.TabIndex = 11;
            this.Tipo_Label.Text = "Tipo";
            // 
            // TipoPubli_ComboBox
            // 
            this.TipoPubli_ComboBox.FormattingEnabled = true;
            this.TipoPubli_ComboBox.Location = new System.Drawing.Point(144, 156);
            this.TipoPubli_ComboBox.Name = "TipoPubli_ComboBox";
            this.TipoPubli_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.TipoPubli_ComboBox.TabIndex = 12;
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);
            // 
            // FechaFin_DateTimePicker
            // 
            this.FechaFin_DateTimePicker.Location = new System.Drawing.Point(144, 103);
            this.FechaFin_DateTimePicker.Name = "FechaFin_DateTimePicker";
            this.FechaFin_DateTimePicker.Size = new System.Drawing.Size(213, 20);
            this.FechaFin_DateTimePicker.TabIndex = 13;
            this.FechaFin_DateTimePicker.ValueChanged += new System.EventHandler(this.FechaFin_DateTimePicker_ValueChanged);
            // 
            // PrecioUnit_textBox
            // 
            this.PrecioUnit_textBox.Location = new System.Drawing.Point(144, 183);
            this.PrecioUnit_textBox.Name = "PrecioUnit_textBox";
            this.PrecioUnit_textBox.Size = new System.Drawing.Size(71, 20);
            this.PrecioUnit_textBox.TabIndex = 14;
            this.PrecioUnit_textBox.TextChanged += new System.EventHandler(this.PrecioUnit_textBox_TextChanged);
            // 
            // PrecioUnit_Label
            // 
            this.PrecioUnit_Label.AutoSize = true;
            this.PrecioUnit_Label.Location = new System.Drawing.Point(15, 186);
            this.PrecioUnit_Label.Name = "PrecioUnit_Label";
            this.PrecioUnit_Label.Size = new System.Drawing.Size(76, 13);
            this.PrecioUnit_Label.TabIndex = 15;
            this.PrecioUnit_Label.Text = "Precio Unitario";
            // 
            // PrecioTotal_Label
            // 
            this.PrecioTotal_Label.AutoSize = true;
            this.PrecioTotal_Label.Location = new System.Drawing.Point(15, 186);
            this.PrecioTotal_Label.Name = "PrecioTotal_Label";
            this.PrecioTotal_Label.Size = new System.Drawing.Size(64, 13);
            this.PrecioTotal_Label.TabIndex = 16;
            this.PrecioTotal_Label.Text = "Precio Total";
            // 
            // PrecioTotal_textBox
            // 
            this.PrecioTotal_textBox.Location = new System.Drawing.Point(144, 183);
            this.PrecioTotal_textBox.Name = "PrecioTotal_textBox";
            this.PrecioTotal_textBox.Size = new System.Drawing.Size(71, 20);
            this.PrecioTotal_textBox.TabIndex = 17;
            // 
            // Limpiar_button
            // 
            this.Limpiar_button.Location = new System.Drawing.Point(82, 252);
            this.Limpiar_button.Name = "Limpiar_button";
            this.Limpiar_button.Size = new System.Drawing.Size(105, 38);
            this.Limpiar_button.TabIndex = 19;
            this.Limpiar_button.Text = "Limpiar";
            this.Limpiar_button.UseVisualStyleBackColor = true;
            this.Limpiar_button.Click += new System.EventHandler(this.Limpiar_button_Click);
            // 
            // Guardar_button
            // 
            this.Guardar_button.Location = new System.Drawing.Point(239, 252);
            this.Guardar_button.Name = "Guardar_button";
            this.Guardar_button.Size = new System.Drawing.Size(105, 38);
            this.Guardar_button.TabIndex = 20;
            this.Guardar_button.Text = "Guardar";
            this.Guardar_button.UseVisualStyleBackColor = true;
            this.Guardar_button.Click += new System.EventHandler(this.Guardar_button_Click);
            // 
            // PermitirPreg_label
            // 
            this.PermitirPreg_label.AutoSize = true;
            this.PermitirPreg_label.Location = new System.Drawing.Point(15, 213);
            this.PermitirPreg_label.Name = "PermitirPreg_label";
            this.PermitirPreg_label.Size = new System.Drawing.Size(92, 13);
            this.PermitirPreg_label.TabIndex = 21;
            this.PermitirPreg_label.Text = "Permitir Preguntas";
            // 
            // permitirPreg_combobox
            // 
            this.permitirPreg_combobox.FormattingEnabled = true;
            this.permitirPreg_combobox.Location = new System.Drawing.Point(144, 210);
            this.permitirPreg_combobox.Name = "permitirPreg_combobox";
            this.permitirPreg_combobox.Size = new System.Drawing.Size(71, 21);
            this.permitirPreg_combobox.TabIndex = 22;
            this.permitirPreg_combobox.SelectedIndexChanged += new System.EventHandler(this.permitirPreg_combobox_SelectedIndexChanged);
            // 
            // GenerarPubliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 332);
            this.Controls.Add(this.permitirPreg_combobox);
            this.Controls.Add(this.PermitirPreg_label);
            this.Controls.Add(this.Guardar_button);
            this.Controls.Add(this.Limpiar_button);
            this.Controls.Add(this.PrecioTotal_textBox);
            this.Controls.Add(this.PrecioTotal_Label);
            this.Controls.Add(this.PrecioUnit_Label);
            this.Controls.Add(this.PrecioUnit_textBox);
            this.Controls.Add(this.FechaFin_DateTimePicker);
            this.Controls.Add(this.TipoPubli_ComboBox);
            this.Controls.Add(this.Tipo_Label);
            this.Controls.Add(this.Estado_ComboBox);
            this.Controls.Add(this.Estado_Label);
            this.Controls.Add(this.FechaFin_Label);
            this.Controls.Add(this.Stock_TextBox);
            this.Controls.Add(this.Stock_Label);
            this.Controls.Add(this.Visibilidad_ComboBox);
            this.Controls.Add(this.Descripcion_Label);
            this.Controls.Add(this.Visibilidad_Label);
            this.Controls.Add(this.Descrip_TextBox);
            this.Name = "GenerarPubliForm";
            this.Text = "Generar Publicación";
            this.Load += new System.EventHandler(this.GenerarPubliForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Descrip_TextBox;
        private System.Windows.Forms.Label Visibilidad_Label;
        private System.Windows.Forms.Label Descripcion_Label;
        private System.Windows.Forms.ComboBox Visibilidad_ComboBox;
        private System.Windows.Forms.Label Stock_Label;
        private System.Windows.Forms.TextBox Stock_TextBox;
        private System.Windows.Forms.Label FechaFin_Label;
        private System.Windows.Forms.Label Estado_Label;
        private System.Windows.Forms.ComboBox Estado_ComboBox;
        private System.Windows.Forms.Label Tipo_Label;
        private System.Windows.Forms.ComboBox TipoPubli_ComboBox;
        private System.Windows.Forms.DateTimePicker FechaFin_DateTimePicker;
        private System.Windows.Forms.TextBox PrecioUnit_textBox;
        private System.Windows.Forms.Label PrecioUnit_Label;
        private System.Windows.Forms.Label PrecioTotal_Label;
        private System.Windows.Forms.TextBox PrecioTotal_textBox;
        private System.Windows.Forms.Button Limpiar_button;
        private System.Windows.Forms.Button Guardar_button;
        private System.Windows.Forms.Label PermitirPreg_label;
        private System.Windows.Forms.ComboBox permitirPreg_combobox;
    }
}