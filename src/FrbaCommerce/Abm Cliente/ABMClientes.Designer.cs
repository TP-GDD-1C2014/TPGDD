namespace FrbaCommerce.Abm_Cliente
{
    partial class ABMClientes
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
            this.Confirmar_Button = new System.Windows.Forms.Button();
            this.TipoDoc_Label = new System.Windows.Forms.Label();
            this.NroDoc_Label = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CompletarDOCyNRO_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Confirmar_Button
            // 
            this.Confirmar_Button.Location = new System.Drawing.Point(655, 67);
            this.Confirmar_Button.Name = "Confirmar_Button";
            this.Confirmar_Button.Size = new System.Drawing.Size(75, 23);
            this.Confirmar_Button.TabIndex = 0;
            this.Confirmar_Button.Text = "Confirmar";
            this.Confirmar_Button.UseVisualStyleBackColor = true;
            this.Confirmar_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // TipoDoc_Label
            // 
            this.TipoDoc_Label.AutoSize = true;
            this.TipoDoc_Label.Location = new System.Drawing.Point(77, 67);
            this.TipoDoc_Label.Name = "TipoDoc_Label";
            this.TipoDoc_Label.Size = new System.Drawing.Size(101, 13);
            this.TipoDoc_Label.TabIndex = 1;
            this.TipoDoc_Label.Text = "Tipo de Documento";
            this.TipoDoc_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // NroDoc_Label
            // 
            this.NroDoc_Label.AutoSize = true;
            this.NroDoc_Label.Location = new System.Drawing.Point(375, 67);
            this.NroDoc_Label.Name = "NroDoc_Label";
            this.NroDoc_Label.Size = new System.Drawing.Size(117, 13);
            this.NroDoc_Label.TabIndex = 2;
            this.NroDoc_Label.Text = "Número de Documento";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(184, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(510, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CompletarDOCyNRO_Label
            // 
            this.CompletarDOCyNRO_Label.AutoSize = true;
            this.CompletarDOCyNRO_Label.Location = new System.Drawing.Point(77, 25);
            this.CompletarDOCyNRO_Label.Name = "CompletarDOCyNRO_Label";
            this.CompletarDOCyNRO_Label.Size = new System.Drawing.Size(228, 13);
            this.CompletarDOCyNRO_Label.TabIndex = 5;
            this.CompletarDOCyNRO_Label.Text = "Complete los siguientes campos para continuar";
            this.CompletarDOCyNRO_Label.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // ABMClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 362);
            this.Controls.Add(this.CompletarDOCyNRO_Label);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.NroDoc_Label);
            this.Controls.Add(this.TipoDoc_Label);
            this.Controls.Add(this.Confirmar_Button);
            this.Name = "ABMClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMB Clientes - MercadoNegro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Confirmar_Button;
        private System.Windows.Forms.Label TipoDoc_Label;
        private System.Windows.Forms.Label NroDoc_Label;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label CompletarDOCyNRO_Label;
    }
}