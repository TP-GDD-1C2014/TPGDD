namespace FrbaCommerce.Registro_de_Usuario
{
    partial class RegistroUsuarioForm1
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
            this.razonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cuit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.telefono = new System.Windows.Forms.TextBox();
            this.direccion = new System.Windows.Forms.TextBox();
            this.codigoPostal = new System.Windows.Forms.TextBox();
            this.ciudad = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.nombreContacto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razón Social (*)";
            // 
            // razonSocial
            // 
            this.razonSocial.Location = new System.Drawing.Point(117, 17);
            this.razonSocial.MaxLength = 255;
            this.razonSocial.Name = "razonSocial";
            this.razonSocial.Size = new System.Drawing.Size(158, 20);
            this.razonSocial.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CUIT (*)";
            // 
            // cuit
            // 
            this.cuit.Location = new System.Drawing.Point(117, 47);
            this.cuit.MaxLength = 50;
            this.cuit.Name = "cuit";
            this.cuit.Size = new System.Drawing.Size(158, 20);
            this.cuit.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Teléfono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Dirección (*)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Código postal (*)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ciudad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "E-mail (*)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Nombre de contacto";
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(117, 17);
            this.telefono.MaxLength = 18;
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(158, 20);
            this.telefono.TabIndex = 0;
            this.telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(117, 47);
            this.direccion.MaxLength = 255;
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(158, 20);
            this.direccion.TabIndex = 1;
            // 
            // codigoPostal
            // 
            this.codigoPostal.Location = new System.Drawing.Point(117, 77);
            this.codigoPostal.MaxLength = 50;
            this.codigoPostal.Name = "codigoPostal";
            this.codigoPostal.Size = new System.Drawing.Size(158, 20);
            this.codigoPostal.TabIndex = 2;
            this.codigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // ciudad
            // 
            this.ciudad.Location = new System.Drawing.Point(117, 107);
            this.ciudad.MaxLength = 50;
            this.ciudad.Name = "ciudad";
            this.ciudad.Size = new System.Drawing.Size(158, 20);
            this.ciudad.TabIndex = 3;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(117, 137);
            this.email.MaxLength = 50;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(158, 20);
            this.email.TabIndex = 4;
            // 
            // nombreContacto
            // 
            this.nombreContacto.Location = new System.Drawing.Point(117, 167);
            this.nombreContacto.MaxLength = 50;
            this.nombreContacto.Name = "nombreContacto";
            this.nombreContacto.Size = new System.Drawing.Size(158, 20);
            this.nombreContacto.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Registrarse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(231, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Los campos señalados con (*)  son obligatorios.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.razonSocial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cuit);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 77);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos identificatorios";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.telefono);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.direccion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nombreContacto);
            this.groupBox2.Controls.Add(this.codigoPostal);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.email);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ciudad);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(10, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 197);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos personales";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(10, 332);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(135, 30);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancelar";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // RegistroUsuarioForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 371);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegistroUsuarioForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Empresa - MercadoNegro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox razonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.TextBox codigoPostal;
        private System.Windows.Forms.TextBox ciudad;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox nombreContacto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cancel;
    }
}