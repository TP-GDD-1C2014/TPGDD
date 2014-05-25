namespace FrbaCommerce.ABM_Rol
{
    partial class EditorDeRoles
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
            this.Nombre_Label = new System.Windows.Forms.Label();
            this.Nombre_Textbox = new System.Windows.Forms.TextBox();
            this.Funcionalidades_Checkboxlist = new System.Windows.Forms.CheckedListBox();
            this.Funcionalidades_Label = new System.Windows.Forms.Label();
            this.Habilitado_Label = new System.Windows.Forms.Label();
            this.Habilitado_Checkbox = new System.Windows.Forms.CheckBox();
            this.Cancelar_Button = new System.Windows.Forms.Button();
            this.Guardar_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Nombre_Label
            // 
            this.Nombre_Label.AutoSize = true;
            this.Nombre_Label.Location = new System.Drawing.Point(9, 9);
            this.Nombre_Label.Name = "Nombre_Label";
            this.Nombre_Label.Size = new System.Drawing.Size(44, 13);
            this.Nombre_Label.TabIndex = 0;
            this.Nombre_Label.Text = "Nombre";
            // 
            // Nombre_Textbox
            // 
            this.Nombre_Textbox.Location = new System.Drawing.Point(98, 9);
            this.Nombre_Textbox.Name = "Nombre_Textbox";
            this.Nombre_Textbox.Size = new System.Drawing.Size(182, 20);
            this.Nombre_Textbox.TabIndex = 1;
            // 
            // Funcionalidades_Checkboxlist
            // 
            this.Funcionalidades_Checkboxlist.FormattingEnabled = true;
            this.Funcionalidades_Checkboxlist.Location = new System.Drawing.Point(98, 46);
            this.Funcionalidades_Checkboxlist.Name = "Funcionalidades_Checkboxlist";
            this.Funcionalidades_Checkboxlist.Size = new System.Drawing.Size(182, 109);
            this.Funcionalidades_Checkboxlist.TabIndex = 2;
            // 
            // Funcionalidades_Label
            // 
            this.Funcionalidades_Label.AutoSize = true;
            this.Funcionalidades_Label.Location = new System.Drawing.Point(9, 46);
            this.Funcionalidades_Label.Name = "Funcionalidades_Label";
            this.Funcionalidades_Label.Size = new System.Drawing.Size(84, 13);
            this.Funcionalidades_Label.TabIndex = 3;
            this.Funcionalidades_Label.Text = "Funcionalidades";
            // 
            // Habilitado_Label
            // 
            this.Habilitado_Label.AutoSize = true;
            this.Habilitado_Label.Location = new System.Drawing.Point(9, 180);
            this.Habilitado_Label.Name = "Habilitado_Label";
            this.Habilitado_Label.Size = new System.Drawing.Size(54, 13);
            this.Habilitado_Label.TabIndex = 4;
            this.Habilitado_Label.Text = "Habilitado";
            // 
            // Habilitado_Checkbox
            // 
            this.Habilitado_Checkbox.AutoSize = true;
            this.Habilitado_Checkbox.Location = new System.Drawing.Point(98, 180);
            this.Habilitado_Checkbox.Name = "Habilitado_Checkbox";
            this.Habilitado_Checkbox.Size = new System.Drawing.Size(15, 14);
            this.Habilitado_Checkbox.TabIndex = 5;
            this.Habilitado_Checkbox.UseVisualStyleBackColor = true;
            // 
            // Cancelar_Button
            // 
            this.Cancelar_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar_Button.Location = new System.Drawing.Point(12, 238);
            this.Cancelar_Button.Name = "Cancelar_Button";
            this.Cancelar_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancelar_Button.TabIndex = 6;
            this.Cancelar_Button.Text = "Cancelar";
            this.Cancelar_Button.UseVisualStyleBackColor = true;
            // 
            // Guardar_Button
            // 
            this.Guardar_Button.Location = new System.Drawing.Point(205, 238);
            this.Guardar_Button.Name = "Guardar_Button";
            this.Guardar_Button.Size = new System.Drawing.Size(75, 23);
            this.Guardar_Button.TabIndex = 7;
            this.Guardar_Button.Text = "Guardar";
            this.Guardar_Button.UseVisualStyleBackColor = true;
            this.Guardar_Button.Click += new System.EventHandler(this.Guardar_Button_Click);
            // 
            // EditorDeRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.Guardar_Button);
            this.Controls.Add(this.Cancelar_Button);
            this.Controls.Add(this.Habilitado_Checkbox);
            this.Controls.Add(this.Habilitado_Label);
            this.Controls.Add(this.Funcionalidades_Label);
            this.Controls.Add(this.Funcionalidades_Checkboxlist);
            this.Controls.Add(this.Nombre_Textbox);
            this.Controls.Add(this.Nombre_Label);
            this.Name = "EditorDeRoles";
            this.Text = "EditorDeRoles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Nombre_Label;
        private System.Windows.Forms.TextBox Nombre_Textbox;
        private System.Windows.Forms.CheckedListBox Funcionalidades_Checkboxlist;
        private System.Windows.Forms.Label Funcionalidades_Label;
        private System.Windows.Forms.Label Habilitado_Label;
        private System.Windows.Forms.CheckBox Habilitado_Checkbox;
        private System.Windows.Forms.Button Cancelar_Button;
        private System.Windows.Forms.Button Guardar_Button;
    }
}