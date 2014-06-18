namespace FrbaCommerce.Editar_Publicacion
{
    partial class EditarPubliForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Visibilidad_ComboBox = new System.Windows.Forms.ComboBox();
            this.Descrip_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Stock_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaFin_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.Estado_ComboBox = new System.Windows.Forms.ComboBox();
            this.TipoPubli_ComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Precio_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Guardar_Button = new System.Windows.Forms.Button();
            this.Limpiar_Button = new System.Windows.Forms.Button();
            this.PermitirPreguntas_Checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visibilidad";
            // 
            // Visibilidad_ComboBox
            // 
            this.Visibilidad_ComboBox.FormattingEnabled = true;
            this.Visibilidad_ComboBox.Location = new System.Drawing.Point(144, 24);
            this.Visibilidad_ComboBox.Name = "Visibilidad_ComboBox";
            this.Visibilidad_ComboBox.Size = new System.Drawing.Size(215, 21);
            this.Visibilidad_ComboBox.TabIndex = 1;
            this.Visibilidad_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_ComboBox_SelectedIndexChanged);
            // 
            // Descrip_TextBox
            // 
            this.Descrip_TextBox.Location = new System.Drawing.Point(144, 51);
            this.Descrip_TextBox.Name = "Descrip_TextBox";
            this.Descrip_TextBox.Size = new System.Drawing.Size(215, 20);
            this.Descrip_TextBox.TabIndex = 2;
            this.Descrip_TextBox.TextChanged += new System.EventHandler(this.Descrip_TextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // Stock_TextBox
            // 
            this.Stock_TextBox.Location = new System.Drawing.Point(144, 77);
            this.Stock_TextBox.Name = "Stock_TextBox";
            this.Stock_TextBox.Size = new System.Drawing.Size(71, 20);
            this.Stock_TextBox.TabIndex = 4;
            this.Stock_TextBox.TextChanged += new System.EventHandler(this.Stock_TextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stock";
            // 
            // FechaFin_DateTimePicker
            // 
            this.FechaFin_DateTimePicker.Location = new System.Drawing.Point(144, 103);
            this.FechaFin_DateTimePicker.Name = "FechaFin_DateTimePicker";
            this.FechaFin_DateTimePicker.Size = new System.Drawing.Size(213, 20);
            this.FechaFin_DateTimePicker.TabIndex = 6;
            this.FechaFin_DateTimePicker.ValueChanged += new System.EventHandler(this.FechaFin_DateTimePicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de Finalización";
            // 
            // Estado_ComboBox
            // 
            this.Estado_ComboBox.FormattingEnabled = true;
            this.Estado_ComboBox.Location = new System.Drawing.Point(144, 129);
            this.Estado_ComboBox.Name = "Estado_ComboBox";
            this.Estado_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.Estado_ComboBox.TabIndex = 8;
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);
            // 
            // TipoPubli_ComboBox
            // 
            this.TipoPubli_ComboBox.FormattingEnabled = true;
            this.TipoPubli_ComboBox.Location = new System.Drawing.Point(144, 156);
            this.TipoPubli_ComboBox.Name = "TipoPubli_ComboBox";
            this.TipoPubli_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.TipoPubli_ComboBox.TabIndex = 9;
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Estado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo";
            // 
            // Precio_textBox
            // 
            this.Precio_textBox.Location = new System.Drawing.Point(144, 183);
            this.Precio_textBox.Name = "Precio_textBox";
            this.Precio_textBox.Size = new System.Drawing.Size(71, 20);
            this.Precio_textBox.TabIndex = 12;
            this.Precio_textBox.TextChanged += new System.EventHandler(this.Precio_textBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Precio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Permitir Preguntas";
            // 
            // Guardar_Button
            // 
            this.Guardar_Button.Location = new System.Drawing.Point(73, 252);
            this.Guardar_Button.Name = "Guardar_Button";
            this.Guardar_Button.Size = new System.Drawing.Size(105, 38);
            this.Guardar_Button.TabIndex = 16;
            this.Guardar_Button.Text = "Guardar";
            this.Guardar_Button.UseVisualStyleBackColor = true;
            this.Guardar_Button.Click += new System.EventHandler(this.Guardar_Button_Click);
            // 
            // Limpiar_Button
            // 
            this.Limpiar_Button.Location = new System.Drawing.Point(254, 252);
            this.Limpiar_Button.Name = "Limpiar_Button";
            this.Limpiar_Button.Size = new System.Drawing.Size(105, 38);
            this.Limpiar_Button.TabIndex = 17;
            this.Limpiar_Button.Text = "Limpiar";
            this.Limpiar_Button.UseVisualStyleBackColor = true;
            // 
            // PermitirPreguntas_Checkbox
            // 
            this.PermitirPreguntas_Checkbox.AutoSize = true;
            this.PermitirPreguntas_Checkbox.Location = new System.Drawing.Point(144, 211);
            this.PermitirPreguntas_Checkbox.Name = "PermitirPreguntas_Checkbox";
            this.PermitirPreguntas_Checkbox.Size = new System.Drawing.Size(15, 14);
            this.PermitirPreguntas_Checkbox.TabIndex = 18;
            this.PermitirPreguntas_Checkbox.UseVisualStyleBackColor = true;
            this.PermitirPreguntas_Checkbox.CheckedChanged += new System.EventHandler(this.PermitirPreguntas_Checkbox_CheckedChanged);
            // 
            // EditarPubliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 332);
            this.Controls.Add(this.PermitirPreguntas_Checkbox);
            this.Controls.Add(this.Limpiar_Button);
            this.Controls.Add(this.Guardar_Button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Precio_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TipoPubli_ComboBox);
            this.Controls.Add(this.Estado_ComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FechaFin_DateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Stock_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Descrip_TextBox);
            this.Controls.Add(this.Visibilidad_ComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditarPubliForm";
            this.Text = "Editar Publicación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Visibilidad_ComboBox;
        private System.Windows.Forms.TextBox Descrip_TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Stock_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FechaFin_DateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Estado_ComboBox;
        private System.Windows.Forms.ComboBox TipoPubli_ComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Precio_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Guardar_Button;
        private System.Windows.Forms.Button Limpiar_Button;
        private System.Windows.Forms.CheckBox PermitirPreguntas_Checkbox;
    }
}