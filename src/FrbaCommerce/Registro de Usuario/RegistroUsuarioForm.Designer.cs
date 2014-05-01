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
            this.Usuario_Label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Contrasenia_Label = new System.Windows.Forms.Label();
            this.Rol_Label = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Usuario_Label
            // 
            this.Usuario_Label.AutoSize = true;
            this.Usuario_Label.Location = new System.Drawing.Point(57, 36);
            this.Usuario_Label.Name = "Usuario_Label";
            this.Usuario_Label.Size = new System.Drawing.Size(55, 13);
            this.Usuario_Label.TabIndex = 0;
            this.Usuario_Label.Text = "Username";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(199, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Contrasenia_Label
            // 
            this.Contrasenia_Label.AutoSize = true;
            this.Contrasenia_Label.Location = new System.Drawing.Point(57, 92);
            this.Contrasenia_Label.Name = "Contrasenia_Label";
            this.Contrasenia_Label.Size = new System.Drawing.Size(61, 13);
            this.Contrasenia_Label.TabIndex = 2;
            this.Contrasenia_Label.Text = "Contraseña";
            this.Contrasenia_Label.Click += new System.EventHandler(this.Contrasenia_Label_Click);
            // 
            // Rol_Label
            // 
            this.Rol_Label.AutoSize = true;
            this.Rol_Label.Location = new System.Drawing.Point(57, 160);
            this.Rol_Label.Name = "Rol_Label";
            this.Rol_Label.Size = new System.Drawing.Size(23, 13);
            this.Rol_Label.TabIndex = 3;
            this.Rol_Label.Text = "Rol";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(199, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // RegistroUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 332);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Rol_Label);
            this.Controls.Add(this.Contrasenia_Label);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Usuario_Label);
            this.Name = "RegistroUsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Usuario";
            this.Load += new System.EventHandler(this.RegistroUsuarioForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Usuario_Label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Contrasenia_Label;
        private System.Windows.Forms.Label Rol_Label;
        private System.Windows.Forms.TextBox textBox2;
    }
}