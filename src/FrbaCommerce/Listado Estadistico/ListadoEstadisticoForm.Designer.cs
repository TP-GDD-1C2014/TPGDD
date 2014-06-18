namespace FrbaCommerce.Listado_Estadistico
{
    partial class ListadoEstadisticoForm
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
            this.limpiarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.tipoListadoCombo = new System.Windows.Forms.ComboBox();
            this.TipoListadoLabel = new System.Windows.Forms.Label();
            this.trimestreCombo = new System.Windows.Forms.ComboBox();
            this.TrimestreLabel = new System.Windows.Forms.Label();
            this.anioTextbox = new System.Windows.Forms.TextBox();
            this.anioLabel = new System.Windows.Forms.Label();
            this.top5DataGriedView = new System.Windows.Forms.DataGridView();
            this.top5Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.volverButton = new System.Windows.Forms.Button();
            this.visibilidadLabel = new System.Windows.Forms.Label();
            this.visibilidadComboBox = new System.Windows.Forms.ComboBox();
            this.mesLabel = new System.Windows.Forms.Label();
            this.mesTextBox = new System.Windows.Forms.TextBox();
            this.limpiarBoton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top5DataGriedView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.tipoListadoCombo);
            this.groupBox1.Controls.Add(this.TipoListadoLabel);
            this.groupBox1.Controls.Add(this.trimestreCombo);
            this.groupBox1.Controls.Add(this.TrimestreLabel);
            this.groupBox1.Controls.Add(this.anioTextbox);
            this.groupBox1.Controls.Add(this.anioLabel);
            this.groupBox1.Location = new System.Drawing.Point(89, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(43, 139);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 4;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(509, 139);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 3;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // tipoListadoCombo
            // 
            this.tipoListadoCombo.FormattingEnabled = true;
            this.tipoListadoCombo.Location = new System.Drawing.Point(136, 39);
            this.tipoListadoCombo.Name = "tipoListadoCombo";
            this.tipoListadoCombo.Size = new System.Drawing.Size(354, 21);
            this.tipoListadoCombo.TabIndex = 0;
            this.tipoListadoCombo.SelectedIndexChanged += new System.EventHandler(this.tipoListadoCombo_SelectedIndexChanged);
            // 
            // TipoListadoLabel
            // 
            this.TipoListadoLabel.AutoSize = true;
            this.TipoListadoLabel.Location = new System.Drawing.Point(37, 39);
            this.TipoListadoLabel.Name = "TipoListadoLabel";
            this.TipoListadoLabel.Size = new System.Drawing.Size(93, 13);
            this.TipoListadoLabel.TabIndex = 4;
            this.TipoListadoLabel.Text = "Tipo de Listado (*)";
            // 
            // trimestreCombo
            // 
            this.trimestreCombo.FormattingEnabled = true;
            this.trimestreCombo.Location = new System.Drawing.Point(343, 96);
            this.trimestreCombo.Name = "trimestreCombo";
            this.trimestreCombo.Size = new System.Drawing.Size(121, 21);
            this.trimestreCombo.TabIndex = 2;
            this.trimestreCombo.SelectedIndexChanged += new System.EventHandler(this.trimestreCombo_SelectedIndexChanged);
            // 
            // TrimestreLabel
            // 
            this.TrimestreLabel.AutoSize = true;
            this.TrimestreLabel.Location = new System.Drawing.Point(274, 96);
            this.TrimestreLabel.Name = "TrimestreLabel";
            this.TrimestreLabel.Size = new System.Drawing.Size(63, 13);
            this.TrimestreLabel.TabIndex = 2;
            this.TrimestreLabel.Text = "Trimestre (*)";
            // 
            // anioTextbox
            // 
            this.anioTextbox.Location = new System.Drawing.Point(85, 96);
            this.anioTextbox.Name = "anioTextbox";
            this.anioTextbox.Size = new System.Drawing.Size(100, 20);
            this.anioTextbox.TabIndex = 1;
            this.anioTextbox.TextChanged += new System.EventHandler(this.anioTextbox_TextChanged);
            this.anioTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anioTextbox_KeyPress);
            // 
            // anioLabel
            // 
            this.anioLabel.AutoSize = true;
            this.anioLabel.Location = new System.Drawing.Point(40, 96);
            this.anioLabel.Name = "anioLabel";
            this.anioLabel.Size = new System.Drawing.Size(39, 13);
            this.anioLabel.TabIndex = 0;
            this.anioLabel.Text = "Año (*)";
            this.anioLabel.Click += new System.EventHandler(this.anioLabel_Click);
            // 
            // top5DataGriedView
            // 
            this.top5DataGriedView.AllowUserToAddRows = false;
            this.top5DataGriedView.AllowUserToDeleteRows = false;
            this.top5DataGriedView.AllowUserToResizeColumns = false;
            this.top5DataGriedView.AllowUserToResizeRows = false;
            this.top5DataGriedView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.top5DataGriedView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.top5DataGriedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.top5DataGriedView.GridColor = System.Drawing.SystemColors.Window;
            this.top5DataGriedView.Location = new System.Drawing.Point(89, 257);
            this.top5DataGriedView.Name = "top5DataGriedView";
            this.top5DataGriedView.ReadOnly = true;
            this.top5DataGriedView.RowHeadersVisible = false;
            this.top5DataGriedView.Size = new System.Drawing.Size(590, 120);
            this.top5DataGriedView.TabIndex = 1;
            this.top5DataGriedView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.top5DataGriedView_CellContentClick);
            // 
            // top5Label
            // 
            this.top5Label.AutoSize = true;
            this.top5Label.Location = new System.Drawing.Point(89, 238);
            this.top5Label.Name = "top5Label";
            this.top5Label.Size = new System.Drawing.Size(41, 13);
            this.top5Label.TabIndex = 2;
            this.top5Label.Text = "TOP 5:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Los campos marcados con (*) son OBLIGATORIOS";
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(89, 412);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(134, 27);
            this.volverButton.TabIndex = 0;
            this.volverButton.Text = "< < Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // visibilidadLabel
            // 
            this.visibilidadLabel.AutoSize = true;
            this.visibilidadLabel.Location = new System.Drawing.Point(360, 230);
            this.visibilidadLabel.Name = "visibilidadLabel";
            this.visibilidadLabel.Size = new System.Drawing.Size(53, 13);
            this.visibilidadLabel.TabIndex = 4;
            this.visibilidadLabel.Text = "Visibilidad";
            // 
            // visibilidadComboBox
            // 
            this.visibilidadComboBox.FormattingEnabled = true;
            this.visibilidadComboBox.Location = new System.Drawing.Point(432, 230);
            this.visibilidadComboBox.Name = "visibilidadComboBox";
            this.visibilidadComboBox.Size = new System.Drawing.Size(92, 21);
            this.visibilidadComboBox.TabIndex = 6;
            this.visibilidadComboBox.SelectedIndexChanged += new System.EventHandler(this.visibilidadComboBox_SelectedIndexChanged);
            // 
            // mesLabel
            // 
            this.mesLabel.AutoSize = true;
            this.mesLabel.Location = new System.Drawing.Point(545, 230);
            this.mesLabel.Name = "mesLabel";
            this.mesLabel.Size = new System.Drawing.Size(27, 13);
            this.mesLabel.TabIndex = 7;
            this.mesLabel.Text = "Mes";
            // 
            // mesTextBox
            // 
            this.mesTextBox.Location = new System.Drawing.Point(573, 230);
            this.mesTextBox.Name = "mesTextBox";
            this.mesTextBox.Size = new System.Drawing.Size(100, 20);
            this.mesTextBox.TabIndex = 8;
            this.mesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anioTextbox_KeyPress);
            // 
            // limpiarBoton
            // 
            this.limpiarBoton.Location = new System.Drawing.Point(229, 412);
            this.limpiarBoton.Name = "limpiarBoton";
            this.limpiarBoton.Size = new System.Drawing.Size(134, 27);
            this.limpiarBoton.TabIndex = 9;
            this.limpiarBoton.Text = "Limpiar";
            this.limpiarBoton.UseVisualStyleBackColor = true;
            this.limpiarBoton.Click += new System.EventHandler(this.limpiarBoton_Click);
            // 
            // ListadoEstadisticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 448);
            this.ControlBox = false;
            this.Controls.Add(this.limpiarBoton);
            this.Controls.Add(this.mesTextBox);
            this.Controls.Add(this.mesLabel);
            this.Controls.Add(this.visibilidadComboBox);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.visibilidadLabel);
            this.Controls.Add(this.top5Label);
            this.Controls.Add(this.top5DataGriedView);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ListadoEstadisticoForm";
            this.Text = "Listado Estadístico - MercadoNegro";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top5DataGriedView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TrimestreLabel;
        private System.Windows.Forms.TextBox anioTextbox;
        private System.Windows.Forms.Label anioLabel;
        private System.Windows.Forms.ComboBox tipoListadoCombo;
        private System.Windows.Forms.Label TipoListadoLabel;
        private System.Windows.Forms.ComboBox trimestreCombo;
        private System.Windows.Forms.DataGridView top5DataGriedView;
        private System.Windows.Forms.Label top5Label;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Label visibilidadLabel;
        private System.Windows.Forms.ComboBox visibilidadComboBox;
        private System.Windows.Forms.Label mesLabel;
        private System.Windows.Forms.TextBox mesTextBox;
        private System.Windows.Forms.Button limpiarBoton;
    }
}