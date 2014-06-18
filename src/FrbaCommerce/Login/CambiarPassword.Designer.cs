namespace FrbaCommerce.Login
{
    partial class CambiarPassword
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
            this.pass1 = new System.Windows.Forms.TextBox();
            this.pass2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.passViejoNH = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pass1
            // 
            this.pass1.Location = new System.Drawing.Point(10, 20);
            this.pass1.Name = "pass1";
            this.pass1.Size = new System.Drawing.Size(196, 20);
            this.pass1.TabIndex = 0;
            this.pass1.TextChanged += new System.EventHandler(this.pass1_TextChanged);
            // 
            // pass2
            // 
            this.pass2.Location = new System.Drawing.Point(10, 20);
            this.pass2.Name = "pass2";
            this.pass2.Size = new System.Drawing.Size(196, 20);
            this.pass2.TabIndex = 0;
            this.pass2.TextChanged += new System.EventHandler(this.pass2_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Continuar >>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.passViejoNH);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contraseña vieja";
            // 
            // passViejoNH
            // 
            this.passViejoNH.Location = new System.Drawing.Point(10, 20);
            this.passViejoNH.Multiline = true;
            this.passViejoNH.Name = "passViejoNH";
            this.passViejoNH.Size = new System.Drawing.Size(196, 20);
            this.passViejoNH.TabIndex = 0;
            this.passViejoNH.TextChanged += new System.EventHandler(this.passViejo_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pass1);
            this.groupBox2.Location = new System.Drawing.Point(10, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 52);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nueva contraseña";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pass2);
            this.groupBox3.Location = new System.Drawing.Point(10, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 52);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Confirmar nueva contraseña";
            // 
            // CambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 243);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CambiarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar contraseña - MercadoNegro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox pass1;
        private System.Windows.Forms.TextBox pass2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox passViejoNH;
    }
}