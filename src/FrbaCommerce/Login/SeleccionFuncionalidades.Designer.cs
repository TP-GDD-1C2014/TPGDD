namespace FrbaCommerce.Login
{
    partial class SeleccionFuncionalidades
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
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFuncionalidades = new System.Windows.Forms.ComboBox();
            this.continuar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Qué desea hacer?";
            // 
            // cbFuncionalidades
            // 
            this.cbFuncionalidades.FormattingEnabled = true;
            this.cbFuncionalidades.Location = new System.Drawing.Point(12, 38);
            this.cbFuncionalidades.Name = "cbFuncionalidades";
            this.cbFuncionalidades.Size = new System.Drawing.Size(288, 21);
            this.cbFuncionalidades.TabIndex = 1;
            // 
            // continuar
            // 
            this.continuar.Location = new System.Drawing.Point(215, 74);
            this.continuar.Name = "continuar";
            this.continuar.Size = new System.Drawing.Size(85, 30);
            this.continuar.TabIndex = 2;
            this.continuar.Text = "Continuar >>";
            this.continuar.UseVisualStyleBackColor = true;
            this.continuar.Click += new System.EventHandler(this.continuar_Click);
            // 
            // SeleccionFuncionalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 116);
            this.Controls.Add(this.continuar);
            this.Controls.Add(this.cbFuncionalidades);
            this.Controls.Add(this.label1);
            this.Name = "SeleccionFuncionalidades";
            this.Text = "Funcionalidades - MercadoNegro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFuncionalidades;
        private System.Windows.Forms.Button continuar;
    }
}