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
            this.Username_TextBox = new System.Windows.Forms.TextBox();
            this.Password_TextBox = new System.Windows.Forms.TextBox();
            this.Registrar_Button = new System.Windows.Forms.Button();
            this.Limpiar_Button = new System.Windows.Forms.Button();
            this.Rol_Combo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Username_TextBox
            // 
            this.Username_TextBox.Location = new System.Drawing.Point(10, 20);
            this.Username_TextBox.MaxLength = 255;
            this.Username_TextBox.Name = "Username_TextBox";
            this.Username_TextBox.Size = new System.Drawing.Size(196, 20);
            this.Username_TextBox.TabIndex = 0;
            this.Username_TextBox.TextChanged += new System.EventHandler(this.Username_TextBox_TextChanged);
            this.Username_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Username_KeyPress);
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Location = new System.Drawing.Point(10, 20);
            this.Password_TextBox.MaxLength = 255;
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(196, 20);
            this.Password_TextBox.TabIndex = 0;
            this.Password_TextBox.TextChanged += new System.EventHandler(this.Password_TextBox_TextChanged);
            // 
            // Registrar_Button
            // 
            this.Registrar_Button.Location = new System.Drawing.Point(123, 203);
            this.Registrar_Button.Name = "Registrar_Button";
            this.Registrar_Button.Size = new System.Drawing.Size(104, 30);
            this.Registrar_Button.TabIndex = 0;
            this.Registrar_Button.Text = "Continuar >>";
            this.Registrar_Button.UseVisualStyleBackColor = true;
            this.Registrar_Button.Click += new System.EventHandler(this.Registrar_Button_Click);
            // 
            // Limpiar_Button
            // 
            this.Limpiar_Button.Location = new System.Drawing.Point(10, 203);
            this.Limpiar_Button.Name = "Limpiar_Button";
            this.Limpiar_Button.Size = new System.Drawing.Size(104, 30);
            this.Limpiar_Button.TabIndex = 1;
            this.Limpiar_Button.Text = "<< Volver";
            this.Limpiar_Button.UseVisualStyleBackColor = true;
            this.Limpiar_Button.Click += new System.EventHandler(this.Limpiar_Button_Click);
            // 
            // Rol_Combo
            // 
            this.Rol_Combo.FormattingEnabled = true;
            this.Rol_Combo.Location = new System.Drawing.Point(10, 20);
            this.Rol_Combo.Name = "Rol_Combo";
            this.Rol_Combo.Size = new System.Drawing.Size(196, 21);
            this.Rol_Combo.TabIndex = 0;
            this.Rol_Combo.SelectedIndexChanged += new System.EventHandler(this.Rol_Combo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Username_TextBox);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 52);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nombre de usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Password_TextBox);
            this.groupBox2.Location = new System.Drawing.Point(10, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 52);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contraseña";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Rol_Combo);
            this.groupBox3.Location = new System.Drawing.Point(10, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 52);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rol";
            // 
            // RegistroUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 242);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Limpiar_Button);
            this.Controls.Add(this.Registrar_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegistroUsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Usuario - MercadoNegro";
            this.Load += new System.EventHandler(this.RegistroUsuarioForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Username_TextBox;
        private System.Windows.Forms.TextBox Password_TextBox;
        private System.Windows.Forms.Button Registrar_Button;
        private System.Windows.Forms.Button Limpiar_Button;
        private System.Windows.Forms.ComboBox Rol_Combo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}