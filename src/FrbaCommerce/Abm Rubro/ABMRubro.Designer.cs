namespace FrbaCommerce.Abm_Rubro
{
    partial class ABMRubro
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
            this.cbRubros = new System.Windows.Forms.ComboBox();
            this.eliminar = new System.Windows.Forms.Button();
            this.crear = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.nuevoRubro = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.back = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRubros
            // 
            this.cbRubros.FormattingEnabled = true;
            this.cbRubros.Location = new System.Drawing.Point(10, 20);
            this.cbRubros.Name = "cbRubros";
            this.cbRubros.Size = new System.Drawing.Size(190, 21);
            this.cbRubros.TabIndex = 0;
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(111, 50);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(90, 30);
            this.eliminar.TabIndex = 2;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // crear
            // 
            this.crear.Location = new System.Drawing.Point(111, 50);
            this.crear.Name = "crear";
            this.crear.Size = new System.Drawing.Size(90, 30);
            this.crear.TabIndex = 1;
            this.crear.Text = "Crear";
            this.crear.UseVisualStyleBackColor = true;
            this.crear.Click += new System.EventHandler(this.nuevo_Click);
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(10, 50);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(90, 30);
            this.modificar.TabIndex = 1;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // nuevoRubro
            // 
            this.nuevoRubro.Location = new System.Drawing.Point(10, 20);
            this.nuevoRubro.MaxLength = 255;
            this.nuevoRubro.Name = "nuevoRubro";
            this.nuevoRubro.Size = new System.Drawing.Size(190, 20);
            this.nuevoRubro.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbRubros);
            this.groupBox1.Controls.Add(this.modificar);
            this.groupBox1.Controls.Add(this.eliminar);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 90);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rubros actuales";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nuevoRubro);
            this.groupBox2.Controls.Add(this.crear);
            this.groupBox2.Location = new System.Drawing.Point(10, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 90);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo rubro";
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(10, 210);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(85, 30);
            this.back.TabIndex = 0;
            this.back.Text = "<< Volver";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // ABMRubro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 249);
            this.Controls.Add(this.back);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ABMRubro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Rubros - MercadoNegro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRubros;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.Button crear;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.TextBox nuevoRubro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button back;
    }
}