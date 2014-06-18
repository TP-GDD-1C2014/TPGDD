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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.volverButton = new System.Windows.Forms.Button();
            this.dgvVisibilidades = new System.Windows.Forms.DataGridView();
            this.modificarButton = new System.Windows.Forms.Button();
            this.nuevaButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisibilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvVisibilidades);
            this.groupBox1.Controls.Add(this.modificarButton);
            this.groupBox1.Controls.Add(this.nuevaButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 214);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestión de visibilidades";
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(584, 232);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 38);
            this.volverButton.TabIndex = 8;
            this.volverButton.Text = "< < Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            // 
            // dgvVisibilidades
            // 
            this.dgvVisibilidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisibilidades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVisibilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisibilidades.GridColor = System.Drawing.SystemColors.Window;
            this.dgvVisibilidades.Location = new System.Drawing.Point(6, 55);
            this.dgvVisibilidades.MultiSelect = false;
            this.dgvVisibilidades.Name = "dgvVisibilidades";
            this.dgvVisibilidades.ReadOnly = true;
            this.dgvVisibilidades.RowHeadersVisible = false;
            this.dgvVisibilidades.Size = new System.Drawing.Size(635, 153);
            this.dgvVisibilidades.TabIndex = 7;
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(87, 26);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(75, 23);
            this.modificarButton.TabIndex = 6;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            // 
            // nuevaButton
            // 
            this.nuevaButton.Location = new System.Drawing.Point(6, 26);
            this.nuevaButton.Name = "nuevaButton";
            this.nuevaButton.Size = new System.Drawing.Size(75, 23);
            this.nuevaButton.TabIndex = 5;
            this.nuevaButton.Text = "Nueva";
            this.nuevaButton.UseVisualStyleBackColor = true;
            // 
            // ABMVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 281);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ABMVisibilidad";
            this.Text = "ABM Visiblidades - MercadoNegro";
            this.Load += new System.EventHandler(this.ABMVisibilidad_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisibilidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvVisibilidades;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button nuevaButton;
        private System.Windows.Forms.Button volverButton;

    }
}