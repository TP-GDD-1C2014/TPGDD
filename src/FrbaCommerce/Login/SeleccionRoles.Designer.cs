﻿namespace FrbaCommerce.Login
{
    partial class SeleccionRoles
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
            this.comboBox_Roles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.continuar_Boton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_Roles
            // 
            this.comboBox_Roles.FormattingEnabled = true;
            this.comboBox_Roles.Location = new System.Drawing.Point(12, 38);
            this.comboBox_Roles.Name = "comboBox_Roles";
            this.comboBox_Roles.Size = new System.Drawing.Size(288, 21);
            this.comboBox_Roles.TabIndex = 0;
            this.comboBox_Roles.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Por favor, escoja un rol:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // continuar_Boton
            // 
            this.continuar_Boton.Location = new System.Drawing.Point(215, 74);
            this.continuar_Boton.Name = "continuar_Boton";
            this.continuar_Boton.Size = new System.Drawing.Size(85, 30);
            this.continuar_Boton.TabIndex = 2;
            this.continuar_Boton.Text = "Continuar >>";
            this.continuar_Boton.UseVisualStyleBackColor = true;
            this.continuar_Boton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SeleccionRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 116);
            this.Controls.Add(this.continuar_Boton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Roles);
            this.Name = "SeleccionRoles";
            this.Text = "Ingreso - MercadoNegro";
            this.Load += new System.EventHandler(this.SeleccionRoles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Roles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button continuar_Boton;

    }
}