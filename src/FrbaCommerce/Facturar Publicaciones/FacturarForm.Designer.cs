namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class FacturarForm
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
            this.dataGridViewPublicaciones = new System.Windows.Forms.DataGridView();
            this.rendirButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cantidadComprasTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Publicaciones sin facturar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridViewPublicaciones
            // 
            this.dataGridViewPublicaciones.AllowUserToAddRows = false;
            this.dataGridViewPublicaciones.AllowUserToDeleteRows = false;
            this.dataGridViewPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPublicaciones.Location = new System.Drawing.Point(41, 53);
            this.dataGridViewPublicaciones.Name = "dataGridViewPublicaciones";
            this.dataGridViewPublicaciones.ReadOnly = true;
            this.dataGridViewPublicaciones.Size = new System.Drawing.Size(458, 150);
            this.dataGridViewPublicaciones.TabIndex = 1;
            this.dataGridViewPublicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // rendirButton
            // 
            this.rendirButton.Location = new System.Drawing.Point(423, 234);
            this.rendirButton.Name = "rendirButton";
            this.rendirButton.Size = new System.Drawing.Size(75, 43);
            this.rendirButton.TabIndex = 2;
            this.rendirButton.Text = "Rendir Factura";
            this.rendirButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad de Compras";
            // 
            // cantidadComprasTextBox
            // 
            this.cantidadComprasTextBox.Location = new System.Drawing.Point(287, 234);
            this.cantidadComprasTextBox.Name = "cantidadComprasTextBox";
            this.cantidadComprasTextBox.Size = new System.Drawing.Size(100, 20);
            this.cantidadComprasTextBox.TabIndex = 4;
            // 
            // FacturarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 305);
            this.Controls.Add(this.cantidadComprasTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rendirButton);
            this.Controls.Add(this.dataGridViewPublicaciones);
            this.Controls.Add(this.label1);
            this.Name = "FacturarForm";
            this.Text = "Facturar Publicaciones - MercadoNegro";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublicaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewPublicaciones;
        private System.Windows.Forms.Button rendirButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cantidadComprasTextBox;
    }
}