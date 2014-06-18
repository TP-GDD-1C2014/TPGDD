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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAsignarRoles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Roles_Datagrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nuevo_Button
            // 
            this.Nuevo_Button.Location = new System.Drawing.Point(6, 19);
            this.Nuevo_Button.Name = "Nuevo_Button";
            this.Nuevo_Button.Size = new System.Drawing.Size(75, 23);
            this.Nuevo_Button.TabIndex = 1;
            this.Nuevo_Button.Text = "Nuevo";
            this.Nuevo_Button.UseVisualStyleBackColor = true;
            this.Nuevo_Button.Click += new System.EventHandler(this.Nuevo_Button_Click);
            // 
            // Modificar_Button
            // 
            this.Modificar_Button.Location = new System.Drawing.Point(87, 19);
            this.Modificar_Button.Name = "Modificar_Button";
            this.Modificar_Button.Size = new System.Drawing.Size(75, 23);
            this.Modificar_Button.TabIndex = 2;
            this.Modificar_Button.Text = "Modificar";
            this.Modificar_Button.UseVisualStyleBackColor = true;
            this.Modificar_Button.Click += new System.EventHandler(this.Modificar_Button_Click);
            // 
            // Eliminar_Button
            // 
            this.Eliminar_Button.Location = new System.Drawing.Point(168, 19);
            this.Eliminar_Button.Name = "Eliminar_Button";
            this.Eliminar_Button.Size = new System.Drawing.Size(75, 23);
            this.Eliminar_Button.TabIndex = 3;
            this.Eliminar_Button.Text = "Eliminar";
            this.Eliminar_Button.UseVisualStyleBackColor = true;
            this.Eliminar_Button.Click += new System.EventHandler(this.Eliminar_Button_Click);
            // 
            // Volver_Button
            // 
            this.Volver_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Volver_Button.Location = new System.Drawing.Point(347, 294);
            this.Volver_Button.Name = "Volver_Button";
            this.Volver_Button.Size = new System.Drawing.Size(75, 23);
            this.Volver_Button.TabIndex = 5;
            this.Volver_Button.Text = "Volver";
            this.Volver_Button.UseVisualStyleBackColor = true;
            // 
            // Roles_Datagrid
            // 
            this.Roles_Datagrid.AllowUserToAddRows = false;
            this.Roles_Datagrid.AllowUserToDeleteRows = false;
            this.Roles_Datagrid.AllowUserToOrderColumns = true;
            this.Roles_Datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Roles_Datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Roles_Datagrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Roles_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Roles_Datagrid.Location = new System.Drawing.Point(6, 48);
            this.Roles_Datagrid.MultiSelect = false;
            this.Roles_Datagrid.Name = "Roles_Datagrid";
            this.Roles_Datagrid.ReadOnly = true;
            this.Roles_Datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Roles_Datagrid.Size = new System.Drawing.Size(398, 222);
            this.Roles_Datagrid.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAsignarRoles);
            this.groupBox1.Controls.Add(this.Nuevo_Button);
            this.groupBox1.Controls.Add(this.Roles_Datagrid);
            this.groupBox1.Controls.Add(this.Modificar_Button);
            this.groupBox1.Controls.Add(this.Eliminar_Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 276);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestión de Roles";
            // 
            // btnAsignarRoles
            // 
            this.btnAsignarRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarRoles.Location = new System.Drawing.Point(308, 19);
            this.btnAsignarRoles.Name = "btnAsignarRoles";
            this.btnAsignarRoles.Size = new System.Drawing.Size(96, 23);
            this.btnAsignarRoles.TabIndex = 4;
            this.btnAsignarRoles.Text = "Asignar roles";
            this.btnAsignarRoles.UseVisualStyleBackColor = true;
            this.btnAsignarRoles.Click += new System.EventHandler(this.btnAsignarRoles_Click);
            // 
            // AbmRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 323);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Volver_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AbmRolForm";
            this.Text = "Gestionar Roles - MercadoNegro";
            ((System.ComponentModel.ISupportInitialize)(this.Roles_Datagrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Nuevo_Button;
        private System.Windows.Forms.Button Modificar_Button;
        private System.Windows.Forms.Button Eliminar_Button;
        private System.Windows.Forms.Button Volver_Button;
        private System.Windows.Forms.DataGridView Roles_Datagrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAsignarRoles;
    }
}