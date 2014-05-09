namespace FrbaCommerce.Editar_Publicacion
{
    partial class BuscarPubliForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CodPubli_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrip_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoPublic_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPublic_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrip_label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.stock_label = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.codPubli_label = new System.Windows.Forms.Label();
            this.estadoPubli_label = new System.Windows.Forms.Label();
            this.Estado_ComboBox = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tipoPubli_label = new System.Windows.Forms.Label();
            this.limpiar_button = new System.Windows.Forms.Button();
            this.buscar_button = new System.Windows.Forms.Button();
            this.seleccionar_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodPubli_Column,
            this.Descrip_Column,
            this.Stock_Column,
            this.EstadoPublic_Column,
            this.TipoPublic_Column});
            this.dataGridView1.Location = new System.Drawing.Point(57, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(543, 232);
            this.dataGridView1.TabIndex = 0;
            // 
            // CodPubli_Column
            // 
            this.CodPubli_Column.HeaderText = "Cod_Publicacion";
            this.CodPubli_Column.Name = "CodPubli_Column";
            this.CodPubli_Column.ReadOnly = true;
            // 
            // Descrip_Column
            // 
            this.Descrip_Column.HeaderText = "Descripcion";
            this.Descrip_Column.Name = "Descrip_Column";
            this.Descrip_Column.ReadOnly = true;
            // 
            // Stock_Column
            // 
            this.Stock_Column.HeaderText = "Stock";
            this.Stock_Column.Name = "Stock_Column";
            this.Stock_Column.ReadOnly = true;
            // 
            // EstadoPublic_Column
            // 
            this.EstadoPublic_Column.HeaderText = "Estado_Public";
            this.EstadoPublic_Column.Name = "EstadoPublic_Column";
            this.EstadoPublic_Column.ReadOnly = true;
            // 
            // TipoPublic_Column
            // 
            this.TipoPublic_Column.HeaderText = "Tipo_Public";
            this.TipoPublic_Column.Name = "TipoPublic_Column";
            this.TipoPublic_Column.ReadOnly = true;
            // 
            // descrip_label
            // 
            this.descrip_label.AutoSize = true;
            this.descrip_label.Location = new System.Drawing.Point(24, 42);
            this.descrip_label.Name = "descrip_label";
            this.descrip_label.Size = new System.Drawing.Size(63, 13);
            this.descrip_label.TabIndex = 1;
            this.descrip_label.Text = "Descripcion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 20);
            this.textBox1.TabIndex = 2;
            // 
            // stock_label
            // 
            this.stock_label.AutoSize = true;
            this.stock_label.Location = new System.Drawing.Point(24, 67);
            this.stock_label.Name = "stock_label";
            this.stock_label.Size = new System.Drawing.Size(35, 13);
            this.stock_label.TabIndex = 3;
            this.stock_label.Text = "Stock";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(128, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(71, 20);
            this.textBox3.TabIndex = 5;
            // 
            // codPubli_label
            // 
            this.codPubli_label.AutoSize = true;
            this.codPubli_label.Location = new System.Drawing.Point(24, 15);
            this.codPubli_label.Name = "codPubli_label";
            this.codPubli_label.Size = new System.Drawing.Size(98, 13);
            this.codPubli_label.TabIndex = 6;
            this.codPubli_label.Text = "Codigo Publicacion";
            // 
            // estadoPubli_label
            // 
            this.estadoPubli_label.AutoSize = true;
            this.estadoPubli_label.Location = new System.Drawing.Point(375, 15);
            this.estadoPubli_label.Name = "estadoPubli_label";
            this.estadoPubli_label.Size = new System.Drawing.Size(98, 13);
            this.estadoPubli_label.TabIndex = 7;
            this.estadoPubli_label.Text = "Estado Publicación";
            // 
            // Estado_ComboBox
            // 
            this.Estado_ComboBox.FormattingEnabled = true;
            this.Estado_ComboBox.Location = new System.Drawing.Point(479, 12);
            this.Estado_ComboBox.Name = "Estado_ComboBox";
            this.Estado_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.Estado_ComboBox.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(479, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // tipoPubli_label
            // 
            this.tipoPubli_label.AutoSize = true;
            this.tipoPubli_label.Location = new System.Drawing.Point(375, 42);
            this.tipoPubli_label.Name = "tipoPubli_label";
            this.tipoPubli_label.Size = new System.Drawing.Size(86, 13);
            this.tipoPubli_label.TabIndex = 12;
            this.tipoPubli_label.Text = "Tipo Publicacion";
            // 
            // limpiar_button
            // 
            this.limpiar_button.Location = new System.Drawing.Point(495, 340);
            this.limpiar_button.Name = "limpiar_button";
            this.limpiar_button.Size = new System.Drawing.Size(105, 38);
            this.limpiar_button.TabIndex = 20;
            this.limpiar_button.Text = "Limpiar";
            this.limpiar_button.UseVisualStyleBackColor = true;
            // 
            // buscar_button
            // 
            this.buscar_button.Location = new System.Drawing.Point(57, 340);
            this.buscar_button.Name = "buscar_button";
            this.buscar_button.Size = new System.Drawing.Size(105, 38);
            this.buscar_button.TabIndex = 21;
            this.buscar_button.Text = "Buscar";
            this.buscar_button.UseVisualStyleBackColor = true;
            // 
            // seleccionar_button
            // 
            this.seleccionar_button.Location = new System.Drawing.Point(266, 340);
            this.seleccionar_button.Name = "seleccionar_button";
            this.seleccionar_button.Size = new System.Drawing.Size(105, 38);
            this.seleccionar_button.TabIndex = 22;
            this.seleccionar_button.Text = "Seleccionar";
            this.seleccionar_button.UseVisualStyleBackColor = true;
            // 
            // BuscarPubliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 390);
            this.Controls.Add(this.seleccionar_button);
            this.Controls.Add(this.buscar_button);
            this.Controls.Add(this.limpiar_button);
            this.Controls.Add(this.tipoPubli_label);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Estado_ComboBox);
            this.Controls.Add(this.estadoPubli_label);
            this.Controls.Add(this.codPubli_label);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.stock_label);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.descrip_label);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BuscarPubliForm";
            this.Text = "Buscar Publicacion";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPubli_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoPublic_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPublic_Column;
        private System.Windows.Forms.Label descrip_label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label stock_label;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label codPubli_label;
        private System.Windows.Forms.Label estadoPubli_label;
        private System.Windows.Forms.ComboBox Estado_ComboBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label tipoPubli_label;
        private System.Windows.Forms.Button limpiar_button;
        private System.Windows.Forms.Button buscar_button;
        private System.Windows.Forms.Button seleccionar_button;

    }
}