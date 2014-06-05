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
            this.rendirButton = new System.Windows.Forms.Button();
            this.dgvOperaciones = new System.Windows.Forms.DataGridView();
            this.volverButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ventas sin facturar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rendirButton
            // 
            this.rendirButton.Location = new System.Drawing.Point(671, 330);
            this.rendirButton.Name = "rendirButton";
            this.rendirButton.Size = new System.Drawing.Size(75, 43);
            this.rendirButton.TabIndex = 2;
            this.rendirButton.Text = "Siguiente";
            this.rendirButton.UseVisualStyleBackColor = true;
            // 
            // dgvOperaciones
            // 
            this.dgvOperaciones.AllowUserToAddRows = false;
            this.dgvOperaciones.AllowUserToDeleteRows = false;
            this.dgvOperaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOperaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperaciones.Location = new System.Drawing.Point(41, 53);
            this.dgvOperaciones.Name = "dgvOperaciones";
            this.dgvOperaciones.ReadOnly = true;
            this.dgvOperaciones.RowHeadersVisible = false;
            this.dgvOperaciones.Size = new System.Drawing.Size(705, 247);
            this.dgvOperaciones.TabIndex = 1;
            this.dgvOperaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperaciones_CellContentClick);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(41, 330);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(76, 43);
            this.volverButton.TabIndex = 3;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // FacturarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 412);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.rendirButton);
            this.Controls.Add(this.dgvOperaciones);
            this.Controls.Add(this.label1);
            this.Name = "FacturarForm";
            this.Text = "Facturar Publicaciones - MercadoNegro";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rendirButton;
        private System.Windows.Forms.DataGridView dgvOperaciones;
        private System.Windows.Forms.Button volverButton;
    }
}