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
            this.descrip_label = new System.Windows.Forms.Label();
            this.Descrip_TextBox = new System.Windows.Forms.TextBox();
            this.stockInic_label = new System.Windows.Forms.Label();
            this.StockInic_TextBox = new System.Windows.Forms.TextBox();
            this.CodPubli_textBox = new System.Windows.Forms.TextBox();
            this.codPubli_label = new System.Windows.Forms.Label();
            this.estadoPubli_label = new System.Windows.Forms.Label();
            this.Estado_ComboBox = new System.Windows.Forms.ComboBox();
            this.TipoPubli_ComboBox = new System.Windows.Forms.ComboBox();
            this.tipoPubli_label = new System.Windows.Forms.Label();
            this.limpiar_button = new System.Windows.Forms.Button();
            this.buscar_button = new System.Windows.Forms.Button();
            this.seleccionar_button = new System.Windows.Forms.Button();
            this.codVisib_label = new System.Windows.Forms.Label();
            this.Visibilidad_ComboBox = new System.Windows.Forms.ComboBox();
            this.CodPubli_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrip_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockInic_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoPublic_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPublic_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodPubli_Column,
            this.Descrip_Column,
            this.StockInic_Column,
            this.EstadoPublic_Column,
            this.TipoPublic_Column});
            this.dataGridView1.Location = new System.Drawing.Point(27, 219);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(600, 232);
            this.dataGridView1.TabIndex = 0;
            // 
            // descrip_label
            // 
            this.descrip_label.AutoSize = true;
            this.descrip_label.Location = new System.Drawing.Point(24, 68);
            this.descrip_label.Name = "descrip_label";
            this.descrip_label.Size = new System.Drawing.Size(63, 13);
            this.descrip_label.TabIndex = 1;
            this.descrip_label.Text = "Descripcion";
            // 
            // Descrip_TextBox
            // 
            this.Descrip_TextBox.Location = new System.Drawing.Point(128, 65);
            this.Descrip_TextBox.Name = "Descrip_TextBox";
            this.Descrip_TextBox.Size = new System.Drawing.Size(215, 20);
            this.Descrip_TextBox.TabIndex = 2;
            this.Descrip_TextBox.TextChanged += new System.EventHandler(this.Descrip_TextBox_TextChanged);
            // 
            // stockInic_label
            // 
            this.stockInic_label.AutoSize = true;
            this.stockInic_label.Location = new System.Drawing.Point(24, 94);
            this.stockInic_label.Name = "stockInic_label";
            this.stockInic_label.Size = new System.Drawing.Size(65, 13);
            this.stockInic_label.TabIndex = 3;
            this.stockInic_label.Text = "Stock Inicial";
            // 
            // StockInic_TextBox
            // 
            this.StockInic_TextBox.Location = new System.Drawing.Point(128, 91);
            this.StockInic_TextBox.Name = "StockInic_TextBox";
            this.StockInic_TextBox.Size = new System.Drawing.Size(71, 20);
            this.StockInic_TextBox.TabIndex = 4;
            this.StockInic_TextBox.TextChanged += new System.EventHandler(this.Stock_TextBox_TextChanged);
            // 
            // CodPubli_textBox
            // 
            this.CodPubli_textBox.Location = new System.Drawing.Point(128, 12);
            this.CodPubli_textBox.Name = "CodPubli_textBox";
            this.CodPubli_textBox.Size = new System.Drawing.Size(71, 20);
            this.CodPubli_textBox.TabIndex = 5;
            this.CodPubli_textBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
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
            this.estadoPubli_label.Location = new System.Drawing.Point(24, 120);
            this.estadoPubli_label.Name = "estadoPubli_label";
            this.estadoPubli_label.Size = new System.Drawing.Size(98, 13);
            this.estadoPubli_label.TabIndex = 7;
            this.estadoPubli_label.Text = "Estado Publicación";
            // 
            // Estado_ComboBox
            // 
            this.Estado_ComboBox.FormattingEnabled = true;
            this.Estado_ComboBox.Location = new System.Drawing.Point(128, 117);
            this.Estado_ComboBox.Name = "Estado_ComboBox";
            this.Estado_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.Estado_ComboBox.TabIndex = 10;
            this.Estado_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Estado_ComboBox_SelectedIndexChanged);
            // 
            // TipoPubli_ComboBox
            // 
            this.TipoPubli_ComboBox.FormattingEnabled = true;
            this.TipoPubli_ComboBox.Location = new System.Drawing.Point(128, 144);
            this.TipoPubli_ComboBox.Name = "TipoPubli_ComboBox";
            this.TipoPubli_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.TipoPubli_ComboBox.TabIndex = 11;
            this.TipoPubli_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPubli_ComboBox_SelectedIndexChanged);
            // 
            // tipoPubli_label
            // 
            this.tipoPubli_label.AutoSize = true;
            this.tipoPubli_label.Location = new System.Drawing.Point(24, 147);
            this.tipoPubli_label.Name = "tipoPubli_label";
            this.tipoPubli_label.Size = new System.Drawing.Size(86, 13);
            this.tipoPubli_label.TabIndex = 12;
            this.tipoPubli_label.Text = "Tipo Publicacion";
            // 
            // limpiar_button
            // 
            this.limpiar_button.Location = new System.Drawing.Point(522, 467);
            this.limpiar_button.Name = "limpiar_button";
            this.limpiar_button.Size = new System.Drawing.Size(105, 38);
            this.limpiar_button.TabIndex = 20;
            this.limpiar_button.Text = "Limpiar";
            this.limpiar_button.UseVisualStyleBackColor = true;
            this.limpiar_button.Click += new System.EventHandler(this.limpiar_button_Click);
            // 
            // buscar_button
            // 
            this.buscar_button.Location = new System.Drawing.Point(27, 467);
            this.buscar_button.Name = "buscar_button";
            this.buscar_button.Size = new System.Drawing.Size(105, 38);
            this.buscar_button.TabIndex = 21;
            this.buscar_button.Text = "Buscar";
            this.buscar_button.UseVisualStyleBackColor = true;
            this.buscar_button.Click += new System.EventHandler(this.buscar_button_Click);
            // 
            // seleccionar_button
            // 
            this.seleccionar_button.Location = new System.Drawing.Point(266, 467);
            this.seleccionar_button.Name = "seleccionar_button";
            this.seleccionar_button.Size = new System.Drawing.Size(105, 38);
            this.seleccionar_button.TabIndex = 22;
            this.seleccionar_button.Text = "Seleccionar";
            this.seleccionar_button.UseVisualStyleBackColor = true;
            this.seleccionar_button.Click += new System.EventHandler(this.seleccionar_button_Click);
            // 
            // codVisib_label
            // 
            this.codVisib_label.AutoSize = true;
            this.codVisib_label.Location = new System.Drawing.Point(24, 41);
            this.codVisib_label.Name = "codVisib_label";
            this.codVisib_label.Size = new System.Drawing.Size(89, 13);
            this.codVisib_label.TabIndex = 23;
            this.codVisib_label.Text = "Codigo Visibilidad";
            // 
            // Visibilidad_ComboBox
            // 
            this.Visibilidad_ComboBox.FormattingEnabled = true;
            this.Visibilidad_ComboBox.Location = new System.Drawing.Point(128, 38);
            this.Visibilidad_ComboBox.Name = "Visibilidad_ComboBox";
            this.Visibilidad_ComboBox.Size = new System.Drawing.Size(149, 21);
            this.Visibilidad_ComboBox.TabIndex = 24;
            this.Visibilidad_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Visibilidad_ComboBox_SelectedIndexChanged);
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
            // StockInic_Column
            // 
            this.StockInic_Column.HeaderText = "Stock Inicial";
            this.StockInic_Column.Name = "StockInic_Column";
            this.StockInic_Column.ReadOnly = true;
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
            // BuscarPubliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 517);
            this.Controls.Add(this.Visibilidad_ComboBox);
            this.Controls.Add(this.codVisib_label);
            this.Controls.Add(this.seleccionar_button);
            this.Controls.Add(this.buscar_button);
            this.Controls.Add(this.limpiar_button);
            this.Controls.Add(this.tipoPubli_label);
            this.Controls.Add(this.TipoPubli_ComboBox);
            this.Controls.Add(this.Estado_ComboBox);
            this.Controls.Add(this.estadoPubli_label);
            this.Controls.Add(this.codPubli_label);
            this.Controls.Add(this.CodPubli_textBox);
            this.Controls.Add(this.StockInic_TextBox);
            this.Controls.Add(this.stockInic_label);
            this.Controls.Add(this.Descrip_TextBox);
            this.Controls.Add(this.descrip_label);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BuscarPubliForm";
            this.Text = "Buscar Publicacion";
            this.Load += new System.EventHandler(this.BuscarPubliForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label descrip_label;
        private System.Windows.Forms.TextBox Descrip_TextBox;
        private System.Windows.Forms.Label stockInic_label;
        private System.Windows.Forms.TextBox StockInic_TextBox;
        private System.Windows.Forms.TextBox CodPubli_textBox;
        private System.Windows.Forms.Label codPubli_label;
        private System.Windows.Forms.Label estadoPubli_label;
        private System.Windows.Forms.ComboBox Estado_ComboBox;
        private System.Windows.Forms.ComboBox TipoPubli_ComboBox;
        private System.Windows.Forms.Label tipoPubli_label;
        private System.Windows.Forms.Button limpiar_button;
        private System.Windows.Forms.Button buscar_button;
        private System.Windows.Forms.Button seleccionar_button;
        private System.Windows.Forms.Label codVisib_label;
        private System.Windows.Forms.ComboBox Visibilidad_ComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPubli_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockInic_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoPublic_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPublic_Column;

    }
}