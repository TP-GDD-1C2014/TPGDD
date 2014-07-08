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
            this.Precio_textBox = new System.Windows.Forms.TextBox();
            this.Precio_Label = new System.Windows.Forms.Label();
            this.Limpiar_button = new System.Windows.Forms.Button();
            this.Guardar_button = new System.Windows.Forms.Button();
            this.PermitirPreg_label = new System.Windows.Forms.Label();
            this.PermitirPreguntas_Checkbox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.volverButton = new System.Windows.Forms.Button();
            this.Rubro_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Descrip_TextBox
            // 
            this.Descrip_TextBox.Location = new System.Drawing.Point(156, 59);
            this.Descrip_TextBox.Name = "Descrip_TextBox";
            this.Descrip_TextBox.Size = new System.Drawing.Size(200, 20);
            this.Descrip_TextBox.TabIndex = 2;
            this.Descrip_TextBox.TextChanged += new System.EventHandler(this.Descrip_TextBox_TextChanged);
            // 
            // Visibilidad_Label
            // 
            this.Visibilidad_Label.AutoSize = true;
            this.Visibilidad_Label.Location = new System.Drawing.Point(16, 35);
            this.Visibilidad_Label.Name = "Visibilidad_Label";
            this.Visibilidad_Label.Size = new System.Drawing.Size(53, 13);
            this.Visibilidad_Label.TabIndex = 1;
            this.Visibilidad_Label.Text = "Visibilidad";
            // 
            // Descripcion_Label
            // 
            this.Descripcion_Label.AutoSize = true;
            this.Descripcion_Label.Location = new System.Drawing.Point(16, 62);
            this.Descripcion_Label.Name = "Descripcion_Label";
            this.Descripcion_Label.Size = new System.Drawing.Size(63, 13);
            this.Descripcion_Label.TabIndex = 2;
            this.Descripcion_Label.Text = "Descripción";
            // 
            // Visibilidad_ComboBox
            // 
            this.Visibilidad_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Visibilidad_ComboBox.FormattingEnabled = true;
            this.Visibilidad_ComboBox.Location = new System.Drawing.Point(156, 32);
            this.Visibilidad_ComboBox.Name = "Visibilidad_ComboBox";
            this.Visibilidad_ComboBox.Size = new System.Drawing.Size(200, 21);
            this.Visibilidad_ComboBox.TabIndex = 1;
            this.Visibilidad_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_ComboBox_SelectedIndexChanged);
            // 
            // Stock_Label
            // 
            this.Stock_Label.AutoSize = true;
            this.Stock_Label.Location = new System.Drawing.Point(16, 88);
            this.Stock_Label.Name = "Stock_Label";
            this.Stock_Label.Size = new System.Drawing.Size(35, 13);
            this.Stock_Label.TabIndex = 4;
            this.Stock_Label.Text = "Stock";
            // 
            // Stock_TextBox
            // 
            this.Stock_TextBox.Location = new System.Drawing.Point(156, 85);
            this.Stock_TextBox.Name = "Stock_TextBox";
            this.Stock_TextBox.Size = new System.Drawing.Size(200, 20);
            this.Stock_TextBox.TabIndex = 3;
            this.Stock_TextBox.TextChanged += new System.EventHandler(this.Stock_TextBox_TextChanged);
            this.Stock_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Stock_TextBox_KeyPress);
            // 
            // FechaFin_Label
            // 
            this.FechaFin_Label.AutoSize = true;
            this.FechaFin_Label.Location = new System.Drawing.Point(16, 115);
            this.FechaFin_Label.Name = "FechaFin_Label";
            this.FechaFin_Label.Size = new System.Drawing.Size(110, 13);
            this.FechaFin_Label.TabIndex = 6;
            this.FechaFin_Label.Text = "Fecha de Finalización";
            // 
            // Estado_Label
            // 
            this.Estado_Label.AutoSize = true;
            this.Estado_Label.Location = new System.Drawing.Point(16, 140);
            this.Estado_Label.Name = "Estado_Label";
            this.Estado_Label.Size = new System.Drawing.Size(40, 13);
            this.Estado_Label.TabIndex = 8;
            this.Estado_Label.Text = "Estado";
            // 
            // Estado_ComboBox
            // 
            this.Estado_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Estado_ComboBox.FormattingEnabled = true;
            this.Estado_ComboBox.Location = new System.Drawing.Point(156, 137);
            this.Estado_ComboBox.Name = "Estado_ComboBox";
            this.Estado_ComboBox.Size = new System.Drawing.Size(200, 21);
            this.Estado_ComboBox.TabIndex = 5;
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);
            // 
            // Tipo_Label
            // 
            this.Tipo_Label.AutoSize = true;
            this.Tipo_Label.Location = new System.Drawing.Point(16, 167);
            this.Tipo_Label.Name = "Tipo_Label";
            this.Tipo_Label.Size = new System.Drawing.Size(28, 13);
            this.Tipo_Label.TabIndex = 11;
            this.Tipo_Label.Text = "Tipo";
            // 
            // TipoPubli_ComboBox
            // 
            this.TipoPubli_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoPubli_ComboBox.FormattingEnabled = true;
            this.TipoPubli_ComboBox.Location = new System.Drawing.Point(156, 164);
            this.TipoPubli_ComboBox.Name = "TipoPubli_ComboBox";
            this.TipoPubli_ComboBox.Size = new System.Drawing.Size(200, 21);
            this.TipoPubli_ComboBox.TabIndex = 6;
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);
            // 
            // FechaFin_DateTimePicker
            // 
            this.FechaFin_DateTimePicker.Location = new System.Drawing.Point(156, 111);
            this.FechaFin_DateTimePicker.Name = "FechaFin_DateTimePicker";
            this.FechaFin_DateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.FechaFin_DateTimePicker.TabIndex = 4;
            this.FechaFin_DateTimePicker.ValueChanged += new System.EventHandler(this.FechaFin_DateTimePicker_ValueChanged);
            // 
            // Precio_textBox
            // 
            this.Precio_textBox.Location = new System.Drawing.Point(156, 307);
            this.Precio_textBox.Name = "Precio_textBox";
            this.Precio_textBox.Size = new System.Drawing.Size(200, 20);
            this.Precio_textBox.TabIndex = 8;
            this.Precio_textBox.TextChanged += new System.EventHandler(this.Precio_textBox_TextChanged);
            this.Precio_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Precio_textBox_KeyPress);
            // 
            // Precio_Label
            // 
            this.Precio_Label.AutoSize = true;
            this.Precio_Label.Location = new System.Drawing.Point(16, 310);
            this.Precio_Label.Name = "Precio_Label";
            this.Precio_Label.Size = new System.Drawing.Size(37, 13);
            this.Precio_Label.TabIndex = 15;
            this.Precio_Label.Text = "Precio";
            // 
            // Limpiar_button
            // 
            this.Limpiar_button.Location = new System.Drawing.Point(142, 368);
            this.Limpiar_button.Name = "Limpiar_button";
            this.Limpiar_button.Size = new System.Drawing.Size(105, 38);
            this.Limpiar_button.TabIndex = 11;
            this.Limpiar_button.Text = "Limpiar";
            this.Limpiar_button.UseVisualStyleBackColor = true;
            this.Limpiar_button.Click += new System.EventHandler(this.Limpiar_button_Click);
            // 
            // Guardar_button
            // 
            this.Guardar_button.Location = new System.Drawing.Point(263, 368);
            this.Guardar_button.Name = "Guardar_button";
            this.Guardar_button.Size = new System.Drawing.Size(105, 38);
            this.Guardar_button.TabIndex = 10;
            this.Guardar_button.Text = "Guardar";
            this.Guardar_button.UseVisualStyleBackColor = true;
            this.Guardar_button.Click += new System.EventHandler(this.Guardar_button_Click);
            // 
            // PermitirPreg_label
            // 
            this.PermitirPreg_label.AutoSize = true;
            this.PermitirPreg_label.Location = new System.Drawing.Point(16, 333);
            this.PermitirPreg_label.Name = "PermitirPreg_label";
            this.PermitirPreg_label.Size = new System.Drawing.Size(92, 13);
            this.PermitirPreg_label.TabIndex = 21;
            this.PermitirPreg_label.Text = "Permitir Preguntas";
            // 
            // PermitirPreguntas_Checkbox
            // 
            this.PermitirPreguntas_Checkbox.AutoSize = true;
            this.PermitirPreguntas_Checkbox.Location = new System.Drawing.Point(156, 332);
            this.PermitirPreguntas_Checkbox.Name = "PermitirPreguntas_Checkbox";
            this.PermitirPreguntas_Checkbox.Size = new System.Drawing.Size(15, 14);
            this.PermitirPreguntas_Checkbox.TabIndex = 9;
            this.PermitirPreguntas_Checkbox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.volverButton);
            this.groupBox1.Controls.Add(this.Rubro_checkedListBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PermitirPreguntas_Checkbox);
            this.groupBox1.Controls.Add(this.PermitirPreg_label);
            this.groupBox1.Controls.Add(this.Guardar_button);
            this.groupBox1.Controls.Add(this.Limpiar_button);
            this.groupBox1.Controls.Add(this.Precio_Label);
            this.groupBox1.Controls.Add(this.Precio_textBox);
            this.groupBox1.Controls.Add(this.FechaFin_DateTimePicker);
            this.groupBox1.Controls.Add(this.TipoPubli_ComboBox);
            this.groupBox1.Controls.Add(this.Tipo_Label);
            this.groupBox1.Controls.Add(this.Estado_ComboBox);
            this.groupBox1.Controls.Add(this.Estado_Label);
            this.groupBox1.Controls.Add(this.FechaFin_Label);
            this.groupBox1.Controls.Add(this.Stock_TextBox);
            this.groupBox1.Controls.Add(this.Stock_Label);
            this.groupBox1.Controls.Add(this.Visibilidad_ComboBox);
            this.groupBox1.Controls.Add(this.Descripcion_Label);
            this.groupBox1.Controls.Add(this.Visibilidad_Label);
            this.groupBox1.Controls.Add(this.Descrip_TextBox);
            this.groupBox1.Location = new System.Drawing.Point(17, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 427);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Creación o Modificación de Publicación";
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(19, 368);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(105, 38);
            this.volverButton.TabIndex = 26;
            this.volverButton.Text = "<< Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // Rubro_checkedListBox
            // 
            this.Rubro_checkedListBox.FormattingEnabled = true;
            this.Rubro_checkedListBox.Location = new System.Drawing.Point(156, 192);
            this.Rubro_checkedListBox.Name = "Rubro_checkedListBox";
            this.Rubro_checkedListBox.Size = new System.Drawing.Size(200, 109);
            this.Rubro_checkedListBox.TabIndex = 7;
            this.Rubro_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.Rubro_checkedListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Rubro";
            // 
            // GenerarPubliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 453);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GenerarPubliForm";
            this.Text = "Administrar Publicaciones - Mercado Negro";
            this.Load += new System.EventHandler(this.GenerarPubliForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox Precio_textBox;
        private System.Windows.Forms.Label Precio_Label;
        private System.Windows.Forms.Button Limpiar_button;
        private System.Windows.Forms.Button Guardar_button;
        private System.Windows.Forms.Label PermitirPreg_label;
        private System.Windows.Forms.CheckBox PermitirPreguntas_Checkbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox Rubro_checkedListBox;
        private System.Windows.Forms.Button volverButton;
    }
}