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
            this.Visibilidad_Combobox = new System.Windows.Forms.ComboBox();
            this.Descripcion_Textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Stock_Textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.Estado_Combobox = new System.Windows.Forms.ComboBox();
            this.Tipo_Combobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Precio_Textbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PermisoPreg_Combobox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Guardar_Button = new System.Windows.Forms.Button();
            this.Limpiar_Button = new System.Windows.Forms.Button();
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
            // Visibilidad_Combobox
            // 
            this.Visibilidad_Combobox.FormattingEnabled = true;
            this.Visibilidad_Combobox.Location = new System.Drawing.Point(144, 24);
            this.Visibilidad_Combobox.Name = "Visibilidad_Combobox";
            this.Visibilidad_Combobox.Size = new System.Drawing.Size(215, 21);
            this.Visibilidad_Combobox.TabIndex = 1;
            this.Visibilidad_Combobox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_Combobox_SelectedIndexChanged);
            // 
            // Descripcion_Textbox
            // 
            this.Descripcion_Textbox.Location = new System.Drawing.Point(144, 51);
            this.Descripcion_Textbox.Name = "Descripcion_Textbox";
            this.Descripcion_Textbox.Size = new System.Drawing.Size(215, 20);
            this.Descripcion_Textbox.TabIndex = 2;
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
            // Stock_Textbox
            // 
            this.Stock_Textbox.Location = new System.Drawing.Point(144, 77);
            this.Stock_Textbox.Name = "Stock_Textbox";
            this.Stock_Textbox.Size = new System.Drawing.Size(71, 20);
            this.Stock_Textbox.TabIndex = 4;
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(144, 103);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(213, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
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
            // Estado_Combobox
            // 
            this.Estado_Combobox.FormattingEnabled = true;
            this.Estado_Combobox.Location = new System.Drawing.Point(144, 129);
            this.Estado_Combobox.Name = "Estado_Combobox";
            this.Estado_Combobox.Size = new System.Drawing.Size(149, 21);
            this.Estado_Combobox.TabIndex = 8;
            this.Estado_Combobox.SelectedIndexChanged += new System.EventHandler(this.Estado_Combobox_SelectedIndexChanged);
            // 
            // Tipo_Combobox
            // 
            this.Tipo_Combobox.FormattingEnabled = true;
            this.Tipo_Combobox.Location = new System.Drawing.Point(144, 156);
            this.Tipo_Combobox.Name = "Tipo_Combobox";
            this.Tipo_Combobox.Size = new System.Drawing.Size(149, 21);
            this.Tipo_Combobox.TabIndex = 9;
            this.Tipo_Combobox.SelectedIndexChanged += new System.EventHandler(this.Tipo_Combobox_SelectedIndexChanged);
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
            // Precio_Textbox
            // 
            this.Precio_Textbox.Location = new System.Drawing.Point(144, 183);
            this.Precio_Textbox.Name = "Precio_Textbox";
            this.Precio_Textbox.Size = new System.Drawing.Size(71, 20);
            this.Precio_Textbox.TabIndex = 12;
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
            // PermisoPreg_Combobox
            // 
            this.PermisoPreg_Combobox.FormattingEnabled = true;
            this.PermisoPreg_Combobox.Location = new System.Drawing.Point(144, 209);
            this.PermisoPreg_Combobox.Name = "PermisoPreg_Combobox";
            this.PermisoPreg_Combobox.Size = new System.Drawing.Size(71, 21);
            this.PermisoPreg_Combobox.TabIndex = 14;
            this.PermisoPreg_Combobox.SelectedIndexChanged += new System.EventHandler(this.PermisoPreg_Combobox_SelectedIndexChanged);
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
            this.Limpiar_Button.Click += new System.EventHandler(this.Limpiar_Button_Click);
            // 
            // EditarPubliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 332);
            this.Controls.Add(this.Limpiar_Button);
            this.Controls.Add(this.Guardar_Button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PermisoPreg_Combobox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Precio_Textbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tipo_Combobox);
            this.Controls.Add(this.Estado_Combobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Stock_Textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Descripcion_Textbox);
            this.Controls.Add(this.Visibilidad_Combobox);
            this.Controls.Add(this.label1);
            this.Name = "EditarPubliForm";
            this.Text = "Editar Publicación";
            this.Load += new System.EventHandler(this.EditarPubliForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Visibilidad_Combobox;
        private System.Windows.Forms.TextBox Descripcion_Textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Stock_Textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Estado_Combobox;
        private System.Windows.Forms.ComboBox Tipo_Combobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Precio_Textbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox PermisoPreg_Combobox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Guardar_Button;
        private System.Windows.Forms.Button Limpiar_Button;
    }
}