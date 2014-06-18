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
            this.formaDePagoComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nombreUserLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.buscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ventas que aún no fueron facturadas:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rendirButton
            // 
            this.rendirButton.Location = new System.Drawing.Point(671, 330);
            this.rendirButton.Name = "rendirButton";
            this.rendirButton.Size = new System.Drawing.Size(75, 43);
            this.rendirButton.TabIndex = 2;
            this.rendirButton.Text = "Generar Factura";
            this.rendirButton.UseVisualStyleBackColor = true;
            this.rendirButton.Click += new System.EventHandler(this.rendirButton_Click);
            // 
            // dgvOperaciones
            // 
            this.dgvOperaciones.AllowUserToAddRows = false;
            this.dgvOperaciones.AllowUserToDeleteRows = false;
            this.dgvOperaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOperaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOperaciones.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperaciones.GridColor = System.Drawing.SystemColors.Window;
            this.dgvOperaciones.Location = new System.Drawing.Point(41, 53);
            this.dgvOperaciones.Name = "dgvOperaciones";
            this.dgvOperaciones.ReadOnly = true;
            this.dgvOperaciones.RowHeadersVisible = false;
            this.dgvOperaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperaciones.Size = new System.Drawing.Size(705, 247);
            this.dgvOperaciones.TabIndex = 0;
            this.dgvOperaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperaciones_CellContentClick);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(41, 330);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(76, 43);
            this.volverButton.TabIndex = 3;
            this.volverButton.Text = "< < Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // formaDePagoComboBox
            // 
            this.formaDePagoComboBox.FormattingEnabled = true;
            this.formaDePagoComboBox.Location = new System.Drawing.Point(517, 330);
            this.formaDePagoComboBox.Name = "formaDePagoComboBox";
            this.formaDePagoComboBox.Size = new System.Drawing.Size(121, 21);
            this.formaDePagoComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Forma de Pago (*):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(496, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Los campos marcados con (*) son OBLIGATORIOS";
            // 
            // nombreUserLabel
            // 
            this.nombreUserLabel.AutoSize = true;
            this.nombreUserLabel.Location = new System.Drawing.Point(321, 24);
            this.nombreUserLabel.Name = "nombreUserLabel";
            this.nombreUserLabel.Size = new System.Drawing.Size(55, 13);
            this.nombreUserLabel.TabIndex = 7;
            this.nombreUserLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(382, 24);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 8;
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(517, 24);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 9;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // FacturarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 412);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.nombreUserLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.formaDePagoComboBox);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.rendirButton);
            this.Controls.Add(this.dgvOperaciones);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
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
        private System.Windows.Forms.ComboBox formaDePagoComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nombreUserLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button buscarButton;
    }
}