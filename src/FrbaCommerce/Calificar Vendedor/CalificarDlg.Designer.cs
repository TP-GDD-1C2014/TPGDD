namespace FrbaCommerce.Calificar_Vendedor
{
    partial class CalificarDlg
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
            this.btnBorrar = new System.Windows.Forms.Button();
            this.cmbOpciones = new System.Windows.Forms.ComboBox();
            this.rbOpciones = new System.Windows.Forms.RadioButton();
            this.rbTextoLibre = new System.Windows.Forms.RadioButton();
            this.txtTextoLibre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEstrellas = new System.Windows.Forms.ComboBox();
            this.lblEstrellas = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBorrar);
            this.groupBox1.Controls.Add(this.cmbOpciones);
            this.groupBox1.Controls.Add(this.rbOpciones);
            this.groupBox1.Controls.Add(this.rbTextoLibre);
            this.groupBox1.Controls.Add(this.txtTextoLibre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbEstrellas);
            this.groupBox1.Controls.Add(this.lblEstrellas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione la cantidad de estrellas que desea puntuar:";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(6, 260);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 6;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // cmbOpciones
            // 
            this.cmbOpciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOpciones.FormattingEnabled = true;
            this.cmbOpciones.Location = new System.Drawing.Point(147, 111);
            this.cmbOpciones.Name = "cmbOpciones";
            this.cmbOpciones.Size = new System.Drawing.Size(121, 21);
            this.cmbOpciones.TabIndex = 3;
            // 
            // rbOpciones
            // 
            this.rbOpciones.AutoSize = true;
            this.rbOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpciones.Location = new System.Drawing.Point(6, 111);
            this.rbOpciones.Name = "rbOpciones";
            this.rbOpciones.Size = new System.Drawing.Size(137, 17);
            this.rbOpciones.TabIndex = 2;
            this.rbOpciones.TabStop = true;
            this.rbOpciones.Text = "Seleccione una opción:";
            this.rbOpciones.UseVisualStyleBackColor = true;
            this.rbOpciones.CheckedChanged += new System.EventHandler(this.rbOpciones_CheckedChanged);
            // 
            // rbTextoLibre
            // 
            this.rbTextoLibre.AutoSize = true;
            this.rbTextoLibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTextoLibre.Location = new System.Drawing.Point(6, 155);
            this.rbTextoLibre.Name = "rbTextoLibre";
            this.rbTextoLibre.Size = new System.Drawing.Size(77, 17);
            this.rbTextoLibre.TabIndex = 4;
            this.rbTextoLibre.TabStop = true;
            this.rbTextoLibre.Text = "Texto libre:";
            this.rbTextoLibre.UseVisualStyleBackColor = true;
            this.rbTextoLibre.CheckedChanged += new System.EventHandler(this.rbTextoLibre_CheckedChanged);
            // 
            // txtTextoLibre
            // 
            this.txtTextoLibre.Location = new System.Drawing.Point(6, 178);
            this.txtTextoLibre.Multiline = true;
            this.txtTextoLibre.Name = "txtTextoLibre";
            this.txtTextoLibre.Size = new System.Drawing.Size(262, 76);
            this.txtTextoLibre.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Describa su experiencia (OPCIONAL) :";
            // 
            // cmbEstrellas
            // 
            this.cmbEstrellas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstrellas.FormattingEnabled = true;
            this.cmbEstrellas.Location = new System.Drawing.Point(61, 28);
            this.cmbEstrellas.Name = "cmbEstrellas";
            this.cmbEstrellas.Size = new System.Drawing.Size(121, 21);
            this.cmbEstrellas.TabIndex = 1;
            // 
            // lblEstrellas
            // 
            this.lblEstrellas.AutoSize = true;
            this.lblEstrellas.Location = new System.Drawing.Point(6, 31);
            this.lblEstrellas.Name = "lblEstrellas";
            this.lblEstrellas.Size = new System.Drawing.Size(49, 13);
            this.lblEstrellas.TabIndex = 2;
            this.lblEstrellas.Text = "Estrellas:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(246, 307);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(165, 307);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // CalificarDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 342);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CalificarDlg";
            this.Text = "Calificación de la compra - MercadoNegro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbEstrellas;
        private System.Windows.Forms.Label lblEstrellas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOpciones;
        private System.Windows.Forms.RadioButton rbOpciones;
        private System.Windows.Forms.RadioButton rbTextoLibre;
        private System.Windows.Forms.TextBox txtTextoLibre;
        private System.Windows.Forms.Button btnBorrar;
    }
}