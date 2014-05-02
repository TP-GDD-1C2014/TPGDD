namespace FrbaCommerce.Registro_de_Usuario
{
    partial class RegistroUsuarioForm
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
            this.Username_Label = new System.Windows.Forms.Label();
            this.Username_TextBox = new System.Windows.Forms.TextBox();
            this.Password_Label = new System.Windows.Forms.Label();
            this.Rol_Label = new System.Windows.Forms.Label();
            this.Password_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Registrar_Button = new System.Windows.Forms.Button();
            this.Limpiar_Button = new System.Windows.Forms.Button();
            this.Rol_Combo = new System.Windows.Forms.ComboBox();
            this.Tipo_Doc_TextBox = new System.Windows.Forms.TextBox();
            this.Razon_Social_TextBox = new System.Windows.Forms.TextBox();
            this.Tipo_Doc_Label = new System.Windows.Forms.Label();
            this.Razon_Social_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Location = new System.Drawing.Point(57, 36);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(68, 13);
            this.Username_Label.TabIndex = 0;
            this.Username_Label.Text = "Username (*)";
            // 
            // Username_TextBox
            // 
            this.Username_TextBox.Location = new System.Drawing.Point(199, 36);
            this.Username_TextBox.Name = "Username_TextBox";
            this.Username_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Username_TextBox.TabIndex = 1;
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Location = new System.Drawing.Point(59, 77);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(66, 13);
            this.Password_Label.TabIndex = 2;
            this.Password_Label.Text = "Password (*)";
            this.Password_Label.Click += new System.EventHandler(this.Contrasenia_Label_Click);
            // 
            // Rol_Label
            // 
            this.Rol_Label.AutoSize = true;
            this.Rol_Label.Location = new System.Drawing.Point(57, 129);
            this.Rol_Label.Name = "Rol_Label";
            this.Rol_Label.Size = new System.Drawing.Size(23, 13);
            this.Rol_Label.TabIndex = 3;
            this.Rol_Label.Text = "Rol";
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Location = new System.Drawing.Point(199, 77);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Password_TextBox.TabIndex = 4;
            this.Password_TextBox.TextChanged += new System.EventHandler(this.Password_TextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "(*) El campo es OBLIGATORIO";
            // 
            // Registrar_Button
            // 
            this.Registrar_Button.Location = new System.Drawing.Point(262, 251);
            this.Registrar_Button.Name = "Registrar_Button";
            this.Registrar_Button.Size = new System.Drawing.Size(86, 45);
            this.Registrar_Button.TabIndex = 6;
            this.Registrar_Button.Text = "Registrar Usuario";
            this.Registrar_Button.UseVisualStyleBackColor = true;
            // 
            // Limpiar_Button
            // 
            this.Limpiar_Button.Location = new System.Drawing.Point(60, 251);
            this.Limpiar_Button.Name = "Limpiar_Button";
            this.Limpiar_Button.Size = new System.Drawing.Size(90, 45);
            this.Limpiar_Button.TabIndex = 7;
            this.Limpiar_Button.Text = "Limpiar";
            this.Limpiar_Button.UseVisualStyleBackColor = true;
            this.Limpiar_Button.Click += new System.EventHandler(this.Limpiar_Button_Click);
            // 
            // Rol_Combo
            // 
            this.Rol_Combo.FormattingEnabled = true;
            this.Rol_Combo.Location = new System.Drawing.Point(199, 129);
            this.Rol_Combo.Name = "Rol_Combo";
            this.Rol_Combo.Size = new System.Drawing.Size(121, 21);
            this.Rol_Combo.TabIndex = 8;
            this.Rol_Combo.SelectedIndexChanged += new System.EventHandler(this.Rol_Combo_SelectedIndexChanged);
            // 
            // Tipo_Doc_TextBox
            // 
            this.Tipo_Doc_TextBox.Location = new System.Drawing.Point(199, 170);
            this.Tipo_Doc_TextBox.Name = "Tipo_Doc_TextBox";
            this.Tipo_Doc_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Tipo_Doc_TextBox.TabIndex = 9;
            this.Tipo_Doc_TextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Razon_Social_TextBox
            // 
            this.Razon_Social_TextBox.Location = new System.Drawing.Point(199, 170);
            this.Razon_Social_TextBox.Name = "Razon_Social_TextBox";
            this.Razon_Social_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Razon_Social_TextBox.TabIndex = 10;
            // 
            // Tipo_Doc_Label
            // 
            this.Tipo_Doc_Label.AutoSize = true;
            this.Tipo_Doc_Label.Location = new System.Drawing.Point(59, 170);
            this.Tipo_Doc_Label.Name = "Tipo_Doc_Label";
            this.Tipo_Doc_Label.Size = new System.Drawing.Size(99, 13);
            this.Tipo_Doc_Label.TabIndex = 11;
            this.Tipo_Doc_Label.Text = "Tipo de documento";
            this.Tipo_Doc_Label.Click += new System.EventHandler(this.Tipo_Doc_Label_Click);
            // 
            // Razon_Social_Label
            // 
            this.Razon_Social_Label.AutoSize = true;
            this.Razon_Social_Label.Location = new System.Drawing.Point(59, 170);
            this.Razon_Social_Label.Name = "Razon_Social_Label";
            this.Razon_Social_Label.Size = new System.Drawing.Size(68, 13);
            this.Razon_Social_Label.TabIndex = 12;
            this.Razon_Social_Label.Text = "Razon social";
            // 
            // RegistroUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 332);
            this.Controls.Add(this.Razon_Social_Label);
            this.Controls.Add(this.Tipo_Doc_Label);
            this.Controls.Add(this.Razon_Social_TextBox);
            this.Controls.Add(this.Tipo_Doc_TextBox);
            this.Controls.Add(this.Rol_Combo);
            this.Controls.Add(this.Limpiar_Button);
            this.Controls.Add(this.Registrar_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password_TextBox);
            this.Controls.Add(this.Rol_Label);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.Username_TextBox);
            this.Controls.Add(this.Username_Label);
            this.Name = "RegistroUsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Nuevo Usuario - MercadoNegro";
            this.Load += new System.EventHandler(this.RegistroUsuarioForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Username_Label;
        private System.Windows.Forms.TextBox Username_TextBox;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.Label Rol_Label;
        private System.Windows.Forms.TextBox Password_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Registrar_Button;
        private System.Windows.Forms.Button Limpiar_Button;
        private System.Windows.Forms.ComboBox Rol_Combo;
        private System.Windows.Forms.TextBox Tipo_Doc_TextBox;
        private System.Windows.Forms.TextBox Razon_Social_TextBox;
        private System.Windows.Forms.Label Tipo_Doc_Label;
        private System.Windows.Forms.Label Razon_Social_Label;
    }
}