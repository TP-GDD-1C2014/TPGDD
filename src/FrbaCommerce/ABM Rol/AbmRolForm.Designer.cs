namespace FrbaCommerce.ABM_Rol
{
    partial class AbmRolForm
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
            this.Nuevo_Button = new System.Windows.Forms.Button();
            this.Modificar_Button = new System.Windows.Forms.Button();
            this.Eliminar_Button = new System.Windows.Forms.Button();
            this.Volver_Button = new System.Windows.Forms.Button();
            this.Roles_Datagrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Roles_Datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Nuevo_Button
            // 
            this.Nuevo_Button.Location = new System.Drawing.Point(12, 12);
            this.Nuevo_Button.Name = "Nuevo_Button";
            this.Nuevo_Button.Size = new System.Drawing.Size(75, 23);
            this.Nuevo_Button.TabIndex = 0;
            this.Nuevo_Button.Text = "Nuevo";
            this.Nuevo_Button.UseVisualStyleBackColor = true;
            this.Nuevo_Button.Click += new System.EventHandler(this.Nuevo_Button_Click);
            // 
            // Modificar_Button
            // 
            this.Modificar_Button.Location = new System.Drawing.Point(93, 12);
            this.Modificar_Button.Name = "Modificar_Button";
            this.Modificar_Button.Size = new System.Drawing.Size(75, 23);
            this.Modificar_Button.TabIndex = 1;
            this.Modificar_Button.Text = "Modificar";
            this.Modificar_Button.UseVisualStyleBackColor = true;
            this.Modificar_Button.Click += new System.EventHandler(this.Modificar_Button_Click);
            // 
            // Eliminar_Button
            // 
            this.Eliminar_Button.Location = new System.Drawing.Point(174, 12);
            this.Eliminar_Button.Name = "Eliminar_Button";
            this.Eliminar_Button.Size = new System.Drawing.Size(75, 23);
            this.Eliminar_Button.TabIndex = 2;
            this.Eliminar_Button.Text = "Eliminar";
            this.Eliminar_Button.UseVisualStyleBackColor = true;
            // 
            // Volver_Button
            // 
            this.Volver_Button.Location = new System.Drawing.Point(282, 284);
            this.Volver_Button.Name = "Volver_Button";
            this.Volver_Button.Size = new System.Drawing.Size(75, 23);
            this.Volver_Button.TabIndex = 3;
            this.Volver_Button.Text = "Volver";
            this.Volver_Button.UseVisualStyleBackColor = true;
            // 
            // Roles_Datagrid
            // 
            this.Roles_Datagrid.AllowUserToAddRows = false;
            this.Roles_Datagrid.AllowUserToDeleteRows = false;
            this.Roles_Datagrid.AllowUserToOrderColumns = true;
            this.Roles_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Roles_Datagrid.Location = new System.Drawing.Point(12, 52);
            this.Roles_Datagrid.MultiSelect = false;
            this.Roles_Datagrid.Name = "Roles_Datagrid";
            this.Roles_Datagrid.ReadOnly = true;
            this.Roles_Datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Roles_Datagrid.Size = new System.Drawing.Size(343, 184);
            this.Roles_Datagrid.TabIndex = 4;
            // 
            // AbmRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 319);
            this.Controls.Add(this.Roles_Datagrid);
            this.Controls.Add(this.Volver_Button);
            this.Controls.Add(this.Eliminar_Button);
            this.Controls.Add(this.Modificar_Button);
            this.Controls.Add(this.Nuevo_Button);
            this.Name = "AbmRolForm";
            this.Text = "Gestionar Roles";
            ((System.ComponentModel.ISupportInitialize)(this.Roles_Datagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Nuevo_Button;
        private System.Windows.Forms.Button Modificar_Button;
        private System.Windows.Forms.Button Eliminar_Button;
        private System.Windows.Forms.Button Volver_Button;
        private System.Windows.Forms.DataGridView Roles_Datagrid;
    }
}