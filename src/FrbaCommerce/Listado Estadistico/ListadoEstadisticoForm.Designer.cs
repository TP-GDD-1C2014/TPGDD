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
            this.buscarButton = new System.Windows.Forms.Button();
            this.tipoListadoCombo = new System.Windows.Forms.ComboBox();
            this.TipoListadoLabel = new System.Windows.Forms.Label();
            this.trimestreCombo = new System.Windows.Forms.ComboBox();
            this.TrimestreLabel = new System.Windows.Forms.Label();
            this.anioTextbox = new System.Windows.Forms.TextBox();
            this.anioLabel = new System.Windows.Forms.Label();
            this.top5DataGriedView = new System.Windows.Forms.DataGridView();
            this.top5Label = new System.Windows.Forms.Label();
            this.limpiarButton = new System.Windows.Forms.Button();
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
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(509, 139);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 6;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // tipoListadoCombo
            // 
            this.tipoListadoCombo.FormattingEnabled = true;
            this.tipoListadoCombo.Location = new System.Drawing.Point(126, 94);
            this.tipoListadoCombo.Name = "tipoListadoCombo";
            this.tipoListadoCombo.Size = new System.Drawing.Size(354, 21);
            this.tipoListadoCombo.TabIndex = 5;
            this.tipoListadoCombo.SelectedIndexChanged += new System.EventHandler(this.tipoListadoCombo_SelectedIndexChanged);
            // 
            // TipoListadoLabel
            // 
            this.TipoListadoLabel.AutoSize = true;
            this.TipoListadoLabel.Location = new System.Drawing.Point(40, 94);
            this.TipoListadoLabel.Name = "TipoListadoLabel";
            this.TipoListadoLabel.Size = new System.Drawing.Size(80, 13);
            this.TipoListadoLabel.TabIndex = 4;
            this.TipoListadoLabel.Text = "Tipo de Listado";
            // 
            // trimestreCombo
            // 
            this.trimestreCombo.FormattingEnabled = true;
            this.trimestreCombo.Location = new System.Drawing.Point(359, 32);
            this.trimestreCombo.Name = "trimestreCombo";
            this.trimestreCombo.Size = new System.Drawing.Size(121, 21);
            this.trimestreCombo.TabIndex = 3;
            this.trimestreCombo.SelectedIndexChanged += new System.EventHandler(this.trimestreCombo_SelectedIndexChanged);
            // 
            // TrimestreLabel
            // 
            this.TrimestreLabel.AutoSize = true;
            this.TrimestreLabel.Location = new System.Drawing.Point(303, 32);
            this.TrimestreLabel.Name = "TrimestreLabel";
            this.TrimestreLabel.Size = new System.Drawing.Size(50, 13);
            this.TrimestreLabel.TabIndex = 2;
            this.TrimestreLabel.Text = "Trimestre";
            // 
            // anioTextbox
            // 
            this.anioTextbox.Location = new System.Drawing.Point(89, 33);
            this.anioTextbox.Name = "anioTextbox";
            this.anioTextbox.Size = new System.Drawing.Size(100, 20);
            this.anioTextbox.TabIndex = 1;
            this.anioTextbox.TextChanged += new System.EventHandler(this.anioTextbox_TextChanged);
            this.anioTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anioTextbox_KeyPress);
            // 
            // anioLabel
            // 
            this.anioLabel.AutoSize = true;
            this.anioLabel.Location = new System.Drawing.Point(40, 33);
            this.anioLabel.Name = "anioLabel";
            this.anioLabel.Size = new System.Drawing.Size(26, 13);
            this.anioLabel.TabIndex = 0;
            this.anioLabel.Text = "Año";
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
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(43, 139);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 7;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // ListadoEstadisticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 467);
            this.Controls.Add(this.top5Label);
            this.Controls.Add(this.top5DataGriedView);
            this.Controls.Add(this.groupBox1);
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
    }
}