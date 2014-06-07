namespace FrbaCommerce.Abm_Visibilidad
{
    partial class ABMVisibilidad
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
            this.nuevaButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.dgvVisibilidades = new System.Windows.Forms.DataGridView();
            this.volverButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisibilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // nuevaButton
            // 
            this.nuevaButton.Location = new System.Drawing.Point(34, 28);
            this.nuevaButton.Name = "nuevaButton";
            this.nuevaButton.Size = new System.Drawing.Size(75, 23);
            this.nuevaButton.TabIndex = 0;
            this.nuevaButton.Text = "Nueva";
            this.nuevaButton.UseVisualStyleBackColor = true;
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(115, 28);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(75, 23);
            this.modificarButton.TabIndex = 1;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(196, 28);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(75, 23);
            this.eliminarButton.TabIndex = 2;
            this.eliminarButton.Text = "Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            // 
            // dgvVisibilidades
            // 
            this.dgvVisibilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisibilidades.Location = new System.Drawing.Point(34, 66);
            this.dgvVisibilidades.Name = "dgvVisibilidades";
            this.dgvVisibilidades.Size = new System.Drawing.Size(375, 150);
            this.dgvVisibilidades.TabIndex = 3;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(333, 238);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 23);
            this.volverButton.TabIndex = 4;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            // 
            // ABMVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 281);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.dgvVisibilidades);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.nuevaButton);
            this.Name = "ABMVisibilidad";
            this.Text = "ABM Visiblidades - MercadoNegro";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisibilidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nuevaButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.DataGridView dgvVisibilidades;
        private System.Windows.Forms.Button volverButton;
    }
}