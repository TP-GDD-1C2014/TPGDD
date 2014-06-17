namespace FrbaCommerce.Historial_Cliente
{
    partial class Historial
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgCompras = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgOfertas = new System.Windows.Forms.DataGridView();
            this.volver = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgSubastasGanadas = new System.Windows.Forms.DataGridView();
            this.historialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompras)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOfertas)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubastasGanadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historialBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgCompras);
            this.groupBox1.Location = new System.Drawing.Point(10, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compras";
            // 
            // dgCompras
            // 
            this.dgCompras.AllowUserToAddRows = false;
            this.dgCompras.AllowUserToDeleteRows = false;
            this.dgCompras.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompras.Location = new System.Drawing.Point(10, 20);
            this.dgCompras.Name = "dgCompras";
            this.dgCompras.ReadOnly = true;
            this.dgCompras.Size = new System.Drawing.Size(570, 150);
            this.dgCompras.TabIndex = 0;
            this.dgCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCompras_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgOfertas);
            this.groupBox2.Location = new System.Drawing.Point(10, 375);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 180);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ofertas";
            // 
            // dgOfertas
            // 
            this.dgOfertas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOfertas.Location = new System.Drawing.Point(10, 20);
            this.dgOfertas.Name = "dgOfertas";
            this.dgOfertas.Size = new System.Drawing.Size(570, 150);
            this.dgOfertas.TabIndex = 0;
            this.dgOfertas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOfertas_CellContentClick);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(10, 565);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(120, 30);
            this.volver.TabIndex = 5;
            this.volver.Text = "<< Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgSubastasGanadas);
            this.groupBox3.Location = new System.Drawing.Point(10, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(590, 180);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Subastas Ganadas";
            // 
            // dgSubastasGanadas
            // 
            this.dgSubastasGanadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubastasGanadas.Location = new System.Drawing.Point(10, 20);
            this.dgSubastasGanadas.Name = "dgSubastasGanadas";
            this.dgSubastasGanadas.Size = new System.Drawing.Size(570, 150);
            this.dgSubastasGanadas.TabIndex = 0;
            this.dgSubastasGanadas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSubastasGanadas_CellContentClick);
            // 
            // historialBindingSource
            // 
            this.historialBindingSource.DataSource = typeof(FrbaCommerce.Historial_Cliente.Historial);
            // 
            // Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 606);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Historial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Operaciones - MercadoNegro";
            this.Load += new System.EventHandler(this.Historial_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompras)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOfertas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSubastasGanadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historialBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource historialBindingSource;
        private System.Windows.Forms.DataGridView dgCompras;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgOfertas;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgSubastasGanadas;
    }
}