namespace FrbaCommerce.Historial_Cliente
{
    partial class HistorialCompras
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
            this.pAnterior = new System.Windows.Forms.Button();
            this.pSiguiente = new System.Windows.Forms.Button();
            this.dgCompras = new System.Windows.Forms.DataGridView();
            this.bBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pAnterior);
            this.groupBox1.Controls.Add(this.pSiguiente);
            this.groupBox1.Controls.Add(this.dgCompras);
            this.groupBox1.Controls.Add(this.bBack);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 308);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compras realizadas";
            // 
            // pAnterior
            // 
            this.pAnterior.Location = new System.Drawing.Point(504, 270);
            this.pAnterior.Name = "pAnterior";
            this.pAnterior.Size = new System.Drawing.Size(35, 30);
            this.pAnterior.TabIndex = 9;
            this.pAnterior.Text = "<<";
            this.pAnterior.UseVisualStyleBackColor = true;
            this.pAnterior.Click += new System.EventHandler(this.pAnterior_Click);
            // 
            // pSiguiente
            // 
            this.pSiguiente.Location = new System.Drawing.Point(546, 270);
            this.pSiguiente.Name = "pSiguiente";
            this.pSiguiente.Size = new System.Drawing.Size(35, 30);
            this.pSiguiente.TabIndex = 8;
            this.pSiguiente.Text = ">>";
            this.pSiguiente.UseVisualStyleBackColor = true;
            this.pSiguiente.Click += new System.EventHandler(this.pSiguiente_Click);
            // 
            // dgCompras
            // 
            this.dgCompras.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompras.Location = new System.Drawing.Point(10, 20);
            this.dgCompras.Name = "dgCompras";
            this.dgCompras.Size = new System.Drawing.Size(570, 243);
            this.dgCompras.TabIndex = 7;
            this.dgCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCompras_CellContentClick_1);
            // 
            // bBack
            // 
            this.bBack.Location = new System.Drawing.Point(9, 270);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(120, 30);
            this.bBack.TabIndex = 6;
            this.bBack.Text = "<< Volver";
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // HistorialCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 329);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HistorialCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de compras - MercadoNegro";
            this.Load += new System.EventHandler(this.HistorialCompras_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button pAnterior;
        private System.Windows.Forms.Button pSiguiente;
        private System.Windows.Forms.DataGridView dgCompras;
        private System.Windows.Forms.Button bBack;
    }
}