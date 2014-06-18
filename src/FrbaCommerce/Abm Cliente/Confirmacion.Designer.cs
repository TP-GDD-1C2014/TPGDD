namespace FrbaCommerce.Abm_Cliente
{
    partial class Confirmacion
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tUsername = new System.Windows.Forms.TextBox();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.tGB = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alta de usuario realizada exitosamente.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puede ingresar al sistema con los siguientes datos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre de Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña:";
            // 
            // tUsername
            // 
            this.tUsername.Location = new System.Drawing.Point(113, 22);
            this.tUsername.Multiline = true;
            this.tUsername.Name = "tUsername";
            this.tUsername.ReadOnly = true;
            this.tUsername.Size = new System.Drawing.Size(150, 20);
            this.tUsername.TabIndex = 0;
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(113, 47);
            this.tPassword.Multiline = true;
            this.tPassword.Name = "tPassword";
            this.tPassword.ReadOnly = true;
            this.tPassword.Size = new System.Drawing.Size(150, 20);
            this.tPassword.TabIndex = 1;
            // 
            // tGB
            // 
            this.tGB.Controls.Add(this.label3);
            this.tGB.Controls.Add(this.tPassword);
            this.tGB.Controls.Add(this.label4);
            this.tGB.Controls.Add(this.tUsername);
            this.tGB.Location = new System.Drawing.Point(10, 60);
            this.tGB.Name = "tGB";
            this.tGB.Size = new System.Drawing.Size(272, 80);
            this.tGB.TabIndex = 6;
            this.tGB.TabStop = false;
            this.tGB.Text = "Datos de acceso";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Confirmacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 189);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tGB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Confirmacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos de acceso - MercadoNegro";
            this.tGB.ResumeLayout(false);
            this.tGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tUsername;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.GroupBox tGB;
        private System.Windows.Forms.Button button1;
    }
}