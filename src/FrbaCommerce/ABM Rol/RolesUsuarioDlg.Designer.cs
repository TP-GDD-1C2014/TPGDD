namespace FrbaCommerce.ABM_Rol
{
    partial class RolesUsuarioDlg
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblIdUser = new System.Windows.Forms.Label();
            this.txtIdUser = new System.Windows.Forms.TextBox();
            this.cblRoles = new System.Windows.Forms.CheckedListBox();
            this.lblRoles = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.lblIdUser);
            this.groupBox1.Controls.Add(this.txtIdUser);
            this.groupBox1.Controls.Add(this.cblRoles);
            this.groupBox1.Controls.Add(this.lblRoles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 38);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(95, 38);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(182, 20);
            this.txtUsername.TabIndex = 9;
            // 
            // lblIdUser
            // 
            this.lblIdUser.AutoSize = true;
            this.lblIdUser.Location = new System.Drawing.Point(6, 64);
            this.lblIdUser.Name = "lblIdUser";
            this.lblIdUser.Size = new System.Drawing.Size(46, 13);
            this.lblIdUser.TabIndex = 4;
            this.lblIdUser.Text = "ID User:";
            // 
            // txtIdUser
            // 
            this.txtIdUser.Location = new System.Drawing.Point(95, 64);
            this.txtIdUser.Name = "txtIdUser";
            this.txtIdUser.ReadOnly = true;
            this.txtIdUser.Size = new System.Drawing.Size(182, 20);
            this.txtIdUser.TabIndex = 5;
            // 
            // cblRoles
            // 
            this.cblRoles.FormattingEnabled = true;
            this.cblRoles.Location = new System.Drawing.Point(95, 101);
            this.cblRoles.Name = "cblRoles";
            this.cblRoles.Size = new System.Drawing.Size(182, 109);
            this.cblRoles.TabIndex = 6;
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(6, 101);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(37, 13);
            this.lblRoles.TabIndex = 7;
            this.lblRoles.Text = "Roles:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RolesUsuarioDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 282);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "RolesUsuarioDlg";
            this.Text = "RolesUsuarioDlg";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblIdUser;
        private System.Windows.Forms.TextBox txtIdUser;
        private System.Windows.Forms.CheckedListBox cblRoles;
        private System.Windows.Forms.Label lblRoles;
    }
}