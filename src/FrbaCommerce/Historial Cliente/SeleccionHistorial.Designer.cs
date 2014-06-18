namespace FrbaCommerce.Historial_Cliente
{
    partial class SeleccionHistorial
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bOfertas = new System.Windows.Forms.Button();
            this.bSubastas = new System.Windows.Forms.Button();
            this.bCompras = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bOfertas);
            this.groupBox1.Controls.Add(this.bSubastas);
            this.groupBox1.Controls.Add(this.bCompras);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operaciones";
            // 
            // bOfertas
            // 
            this.bOfertas.Location = new System.Drawing.Point(7, 92);
            this.bOfertas.Name = "bOfertas";
            this.bOfertas.Size = new System.Drawing.Size(100, 30);
            this.bOfertas.TabIndex = 2;
            this.bOfertas.Text = "Ofertas";
            this.bOfertas.UseVisualStyleBackColor = true;
            this.bOfertas.Click += new System.EventHandler(this.bOfertas_Click);
            // 
            // bSubastas
            // 
            this.bSubastas.Location = new System.Drawing.Point(7, 56);
            this.bSubastas.Name = "bSubastas";
            this.bSubastas.Size = new System.Drawing.Size(100, 30);
            this.bSubastas.TabIndex = 1;
            this.bSubastas.Text = "Subastas";
            this.bSubastas.UseVisualStyleBackColor = true;
            this.bSubastas.Click += new System.EventHandler(this.bSubastas_Click);
            // 
            // bCompras
            // 
            this.bCompras.Location = new System.Drawing.Point(7, 20);
            this.bCompras.Name = "bCompras";
            this.bCompras.Size = new System.Drawing.Size(100, 30);
            this.bCompras.TabIndex = 0;
            this.bCompras.Text = "Compras";
            this.bCompras.UseVisualStyleBackColor = true;
            this.bCompras.Click += new System.EventHandler(this.bCompras_Click);
            // 
            // bBack
            // 
            this.bBack.Location = new System.Drawing.Point(10, 150);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(115, 30);
            this.bBack.TabIndex = 6;
            this.bBack.Text = "<< Volver";
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // SeleccionHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(135, 188);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SeleccionHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de operaciones - MercadoNegro";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bCompras;
        private System.Windows.Forms.Button bOfertas;
        private System.Windows.Forms.Button bSubastas;
        private System.Windows.Forms.Button bBack;
    }
}