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
            this.nuevaButton.Click += new System.EventHandler(this.nuevaButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(115, 28);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(75, 23);
            this.modificarButton.TabIndex = 1;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // dgvVisibilidades
            // 
            this.dgvVisibilidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisibilidades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVisibilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisibilidades.GridColor = System.Drawing.SystemColors.Window;
            this.dgvVisibilidades.Location = new System.Drawing.Point(34, 66);
            this.dgvVisibilidades.MultiSelect = false;
            this.dgvVisibilidades.Name = "dgvVisibilidades";
            this.dgvVisibilidades.ReadOnly = true;
            this.dgvVisibilidades.RowHeadersVisible = false;
            this.dgvVisibilidades.Size = new System.Drawing.Size(617, 121);
            this.dgvVisibilidades.TabIndex = 3;
            this.dgvVisibilidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVisibilidades_CellContentClick);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(576, 213);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 38);
            this.volverButton.TabIndex = 4;
            this.volverButton.Text = "< < Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // ABMVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 281);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.dgvVisibilidades);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.nuevaButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ABMVisibilidad";
            this.Text = "ABM Visiblidades - MercadoNegro";
            this.Load += new System.EventHandler(this.ABMVisibilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisibilidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nuevaButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.DataGridView dgvVisibilidades;
        private System.Windows.Forms.Button volverButton;
    }
}