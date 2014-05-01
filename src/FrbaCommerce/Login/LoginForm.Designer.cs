namespace FrbaCommerce.Login
{
    partial class LoginForm
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
            this.Password_Label = new System.Windows.Forms.Label();
            this.Username_TextBox = new System.Windows.Forms.TextBox();
            this.Password_TextBox = new System.Windows.Forms.TextBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.RegistrarUsuario_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Location = new System.Drawing.Point(54, 69);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(55, 13);
            this.Username_Label.TabIndex = 0;
            this.Username_Label.Text = "Username";
            this.Username_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Location = new System.Drawing.Point(54, 125);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(53, 13);
            this.Password_Label.TabIndex = 1;
            this.Password_Label.Text = "Password";
            this.Password_Label.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Username_TextBox
            // 
            this.Username_TextBox.Location = new System.Drawing.Point(170, 69);
            this.Username_TextBox.Name = "Username_TextBox";
            this.Username_TextBox.Size = new System.Drawing.Size(140, 20);
            this.Username_TextBox.TabIndex = 2;
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Location = new System.Drawing.Point(170, 125);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(140, 20);
            this.Password_TextBox.TabIndex = 3;
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(217, 227);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(93, 38);
            this.Login_Button.TabIndex = 4;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // RegistrarUsuario_Button
            // 
            this.RegistrarUsuario_Button.Location = new System.Drawing.Point(57, 227);
            this.RegistrarUsuario_Button.Name = "RegistrarUsuario_Button";
            this.RegistrarUsuario_Button.Size = new System.Drawing.Size(105, 38);
            this.RegistrarUsuario_Button.TabIndex = 5;
            this.RegistrarUsuario_Button.Text = "Registrar Usuario";
            this.RegistrarUsuario_Button.UseVisualStyleBackColor = true;
            this.RegistrarUsuario_Button.Click += new System.EventHandler(this.RegistrarUsuario_Button_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 332);
            this.Controls.Add(this.RegistrarUsuario_Button);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Password_TextBox);
            this.Controls.Add(this.Username_TextBox);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.Username_Label);
            this.Name = "LoginForm";
            this.Text = "Login - MercadoNegro";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Username_Label;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.TextBox Username_TextBox;
        private System.Windows.Forms.TextBox Password_TextBox;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Button RegistrarUsuario_Button;

    }
}