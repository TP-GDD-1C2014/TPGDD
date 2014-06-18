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
            this.label1 = new System.Windows.Forms.Label();
            this.buscarButton = new System.Windows.Forms.Button();
            this.tipoListadoCombo = new System.Windows.Forms.ComboBox();
            this.TipoListadoLabel = new System.Windows.Forms.Label();
            this.trimestreCombo = new System.Windows.Forms.ComboBox();
            this.TrimestreLabel = new System.Windows.Forms.Label();
            this.anioTextbox = new System.Windows.Forms.TextBox();
            this.anioLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mesTextBox = new System.Windows.Forms.TextBox();
            this.mesLabel = new System.Windows.Forms.Label();
            this.visibilidadComboBox = new System.Windows.Forms.ComboBox();
            this.visibilidadLabel = new System.Windows.Forms.Label();
            this.top5DataGriedView = new System.Windows.Forms.DataGridView();
            this.limpiarBoton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top5DataGriedView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.tipoListadoCombo);
            this.groupBox1.Controls.Add(this.TipoListadoLabel);
            this.groupBox1.Controls.Add(this.trimestreCombo);
            this.groupBox1.Controls.Add(this.TrimestreLabel);
            this.groupBox1.Controls.Add(this.anioTextbox);
            this.groupBox1.Controls.Add(this.anioLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Los campos marcados con (*) son OBLIGATORIOS";
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(415, 116);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 3;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // tipoListadoCombo
            // 
            this.tipoListadoCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.TipoListadoLabel.Size = new System.Drawing.Size(96, 13);
            this.TipoListadoLabel.TabIndex = 4;
            this.TipoListadoLabel.Text = "Tipo de Listado (*):";
            // 
            // trimestreCombo
            // 
            this.trimestreCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trimestreCombo.FormattingEnabled = true;
            this.trimestreCombo.Location = new System.Drawing.Point(343, 77);
            this.trimestreCombo.Name = "trimestreCombo";
            this.trimestreCombo.Size = new System.Drawing.Size(147, 21);
            this.trimestreCombo.TabIndex = 2;
            // 
            // TrimestreLabel
            // 
            this.TrimestreLabel.AutoSize = true;
            this.TrimestreLabel.Location = new System.Drawing.Point(274, 80);
            this.TrimestreLabel.Name = "TrimestreLabel";
            this.TrimestreLabel.Size = new System.Drawing.Size(66, 13);
            this.TrimestreLabel.TabIndex = 2;
            this.TrimestreLabel.Text = "Trimestre (*):";
            // 
            // anioTextbox
            // 
            this.anioTextbox.Location = new System.Drawing.Point(136, 77);
            this.anioTextbox.Name = "anioTextbox";
            this.anioTextbox.Size = new System.Drawing.Size(100, 20);
            this.anioTextbox.TabIndex = 1;
            this.anioTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anioTextbox_KeyPress);
            // 
            // anioLabel
            // 
            this.anioLabel.AutoSize = true;
            this.anioLabel.Location = new System.Drawing.Point(37, 80);
            this.anioLabel.Name = "anioLabel";
            this.anioLabel.Size = new System.Drawing.Size(42, 13);
            this.anioLabel.TabIndex = 0;
            this.anioLabel.Text = "Año (*):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mesTextBox);
            this.groupBox2.Controls.Add(this.mesLabel);
            this.groupBox2.Controls.Add(this.visibilidadComboBox);
            this.groupBox2.Controls.Add(this.visibilidadLabel);
            this.groupBox2.Controls.Add(this.top5DataGriedView);
            this.groupBox2.Location = new System.Drawing.Point(12, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 183);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TOP 5:";
            // 
            // mesTextBox
            // 
            this.mesTextBox.Location = new System.Drawing.Point(213, 21);
            this.mesTextBox.Name = "mesTextBox";
            this.mesTextBox.Size = new System.Drawing.Size(100, 20);
            this.mesTextBox.TabIndex = 17;
            // 
            // mesLabel
            // 
            this.mesLabel.AutoSize = true;
            this.mesLabel.Location = new System.Drawing.Point(180, 24);
            this.mesLabel.Name = "mesLabel";
            this.mesLabel.Size = new System.Drawing.Size(30, 13);
            this.mesLabel.TabIndex = 16;
            this.mesLabel.Text = "Mes:";
            // 
            // visibilidadComboBox
            // 
            this.visibilidadComboBox.FormattingEnabled = true;
            this.visibilidadComboBox.Location = new System.Drawing.Point(68, 21);
            this.visibilidadComboBox.Name = "visibilidadComboBox";
            this.visibilidadComboBox.Size = new System.Drawing.Size(92, 21);
            this.visibilidadComboBox.TabIndex = 15;
            // 
            // visibilidadLabel
            // 
            this.visibilidadLabel.AutoSize = true;
            this.visibilidadLabel.Location = new System.Drawing.Point(6, 24);
            this.visibilidadLabel.Name = "visibilidadLabel";
            this.visibilidadLabel.Size = new System.Drawing.Size(56, 13);
            this.visibilidadLabel.TabIndex = 14;
            this.visibilidadLabel.Text = "Visibilidad:";
            // 
            // top5DataGriedView
            // 
            this.top5DataGriedView.AllowUserToAddRows = false;
            this.top5DataGriedView.AllowUserToDeleteRows = false;
            this.top5DataGriedView.AllowUserToResizeColumns = false;
            this.top5DataGriedView.AllowUserToResizeRows = false;
            this.top5DataGriedView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.top5DataGriedView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.top5DataGriedView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.top5DataGriedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.top5DataGriedView.GridColor = System.Drawing.SystemColors.Window;
            this.top5DataGriedView.Location = new System.Drawing.Point(6, 48);
            this.top5DataGriedView.Name = "top5DataGriedView";
            this.top5DataGriedView.ReadOnly = true;
            this.top5DataGriedView.RowHeadersVisible = false;
            this.top5DataGriedView.Size = new System.Drawing.Size(494, 123);
            this.top5DataGriedView.TabIndex = 11;
            // 
            // limpiarBoton
            // 
            this.limpiarBoton.Location = new System.Drawing.Point(11, 361);
            this.limpiarBoton.Name = "limpiarBoton";
            this.limpiarBoton.Size = new System.Drawing.Size(134, 27);
            this.limpiarBoton.TabIndex = 18;
            this.limpiarBoton.Text = "Limpiar";
            this.limpiarBoton.UseVisualStyleBackColor = true;
            this.limpiarBoton.Click += new System.EventHandler(this.limpiarBoton_Click);
            // 
            // volverButton
            // 
            this.volverButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.volverButton.Location = new System.Drawing.Point(384, 361);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(134, 27);
            this.volverButton.TabIndex = 10;
            this.volverButton.Text = "< < Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            // 
            // ListadoEstadisticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 395);
            this.ControlBox = false;
            this.Controls.Add(this.limpiarBoton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.volverButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ListadoEstadisticoForm";
            this.Text = "Listado Estadístico - MercadoNegro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top5DataGriedView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TrimestreLabel;
        private System.Windows.Forms.TextBox anioTextbox;
        private System.Windows.Forms.Label anioLabel;
        private System.Windows.Forms.ComboBox tipoListadoCombo;
        private System.Windows.Forms.Label TipoListadoLabel;
        private System.Windows.Forms.ComboBox trimestreCombo;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox mesTextBox;
        private System.Windows.Forms.Label mesLabel;
        private System.Windows.Forms.ComboBox visibilidadComboBox;
        private System.Windows.Forms.Label visibilidadLabel;
        private System.Windows.Forms.DataGridView top5DataGriedView;
        private System.Windows.Forms.Button limpiarBoton;
        private System.Windows.Forms.Button volverButton;
    }
}