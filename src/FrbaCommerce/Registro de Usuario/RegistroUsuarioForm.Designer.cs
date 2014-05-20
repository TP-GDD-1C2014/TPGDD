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
            this.Registrar_Button = new System.Windows.Forms.Button();
            this.Limpiar_Button = new System.Windows.Forms.Button();
            this.Rol_Combo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Location = new System.Drawing.Point(12, 12);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(96, 13);
            this.Username_Label.TabIndex = 0;
            this.Username_Label.Text = "Nombre de usuario";
            // 
            // Username_TextBox
            // 
            this.Username_TextBox.Location = new System.Drawing.Point(15, 35);
            this.Username_TextBox.Name = "Username_TextBox";
            this.Username_TextBox.Size = new System.Drawing.Size(282, 20);
            this.Username_TextBox.TabIndex = 1;
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Location = new System.Drawing.Point(12, 68);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(61, 13);
            this.Password_Label.TabIndex = 2;
            this.Password_Label.Text = "Contraseña";
            this.Password_Label.Click += new System.EventHandler(this.Contrasenia_Label_Click);
            // 
            // Rol_Label
            // 
            this.Rol_Label.AutoSize = true;
            this.Rol_Label.Location = new System.Drawing.Point(12, 129);
            this.Rol_Label.Name = "Rol_Label";
            this.Rol_Label.Size = new System.Drawing.Size(23, 13);
            this.Rol_Label.TabIndex = 3;
            this.Rol_Label.Text = "Rol";
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Location = new System.Drawing.Point(15, 93);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(282, 20);
            this.Password_TextBox.TabIndex = 4;
            this.Password_TextBox.TextChanged += new System.EventHandler(this.Password_TextBox_TextChanged);
            // 
            // Registrar_Button
            // 
            this.Registrar_Button.Location = new System.Drawing.Point(211, 192);
            this.Registrar_Button.Name = "Registrar_Button";
            this.Registrar_Button.Size = new System.Drawing.Size(86, 30);
            this.Registrar_Button.TabIndex = 6;
            this.Registrar_Button.Text = "Continuar >>";
            this.Registrar_Button.UseVisualStyleBackColor = true;
            this.Registrar_Button.Click += new System.EventHandler(this.Registrar_Button_Click);
            // 
            // Limpiar_Button
            // 
            this.Limpiar_Button.Location = new System.Drawing.Point(14, 192);
            this.Limpiar_Button.Name = "Limpiar_Button";
            this.Limpiar_Button.Size = new System.Drawing.Size(90, 30);
            this.Limpiar_Button.TabIndex = 7;
            this.Limpiar_Button.Text = "Limpiar";
            this.Limpiar_Button.UseVisualStyleBackColor = true;
            this.Limpiar_Button.Click += new System.EventHandler(this.Limpiar_Button_Click);
            // 
            // Rol_Combo
            // 
            this.Rol_Combo.FormattingEnabled = true;
            this.Rol_Combo.Location = new System.Drawing.Point(15, 154);
            this.Rol_Combo.Name = "Rol_Combo";
            this.Rol_Combo.Size = new System.Drawing.Size(282, 21);
            this.Rol_Combo.TabIndex = 8;
            this.Rol_Combo.SelectedIndexChanged += new System.EventHandler(this.Rol_Combo_SelectedIndexChanged);
            // 
            // RegistroUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 234);
            this.Controls.Add(this.Rol_Combo);
            this.Controls.Add(this.Limpiar_Button);
            this.Controls.Add(this.Registrar_Button);
            this.Controls.Add(this.Password_TextBox);
            this.Controls.Add(this.Rol_Label);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.Username_TextBox);
            this.Controls.Add(this.Username_Label);
            this.Name = "RegistroUsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Usuario - MercadoNegro";
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
        private System.Windows.Forms.Button Registrar_Button;
        private System.Windows.Forms.Button Limpiar_Button;
        private System.Windows.Forms.ComboBox Rol_Combo;
    }
}