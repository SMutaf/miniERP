namespace MiniERP.GUI.FirmControlGui
{
    partial class FormAddAdmin
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
            txtPassword = new TextBox();
            txtPasswordAgain = new TextBox();
            txtAdminName = new TextBox();
            btnAddAdmin = new Button();
            panelAdminInfo = new Panel();
            labelAdminPassAgain = new Label();
            labelAdminPass = new Label();
            labelAdminName = new Label();
            panelAdminInfo.SuspendLayout();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(105, 61);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(111, 23);
            txtPassword.TabIndex = 0;
            // 
            // txtPasswordAgain
            // 
            txtPasswordAgain.Location = new Point(105, 111);
            txtPasswordAgain.Name = "txtPasswordAgain";
            txtPasswordAgain.Size = new Size(111, 23);
            txtPasswordAgain.TabIndex = 1;
            // 
            // txtAdminName
            // 
            txtAdminName.Location = new Point(105, 14);
            txtAdminName.Name = "txtAdminName";
            txtAdminName.Size = new Size(111, 23);
            txtAdminName.TabIndex = 2;
            // 
            // btnAddAdmin
            // 
            btnAddAdmin.Location = new Point(171, 193);
            btnAddAdmin.Name = "btnAddAdmin";
            btnAddAdmin.Size = new Size(75, 23);
            btnAddAdmin.TabIndex = 3;
            btnAddAdmin.Text = "Admin Ekle";
            btnAddAdmin.UseVisualStyleBackColor = true;
            btnAddAdmin.Click += btnAddAdmin_Click;
            // 
            // panelAdminInfo
            // 
            panelAdminInfo.BorderStyle = BorderStyle.FixedSingle;
            panelAdminInfo.Controls.Add(labelAdminPassAgain);
            panelAdminInfo.Controls.Add(labelAdminPass);
            panelAdminInfo.Controls.Add(labelAdminName);
            panelAdminInfo.Controls.Add(txtAdminName);
            panelAdminInfo.Controls.Add(txtPassword);
            panelAdminInfo.Controls.Add(txtPasswordAgain);
            panelAdminInfo.Location = new Point(12, 12);
            panelAdminInfo.Name = "panelAdminInfo";
            panelAdminInfo.Size = new Size(234, 162);
            panelAdminInfo.TabIndex = 4;
            // 
            // labelAdminPassAgain
            // 
            labelAdminPassAgain.AutoSize = true;
            labelAdminPassAgain.Location = new Point(12, 114);
            labelAdminPassAgain.Name = "labelAdminPassAgain";
            labelAdminPassAgain.Size = new Size(81, 15);
            labelAdminPassAgain.TabIndex = 5;
            labelAdminPassAgain.Text = "Şifre Yeniden :";
            // 
            // labelAdminPass
            // 
            labelAdminPass.AutoSize = true;
            labelAdminPass.Location = new Point(12, 64);
            labelAdminPass.Name = "labelAdminPass";
            labelAdminPass.Size = new Size(36, 15);
            labelAdminPass.TabIndex = 4;
            labelAdminPass.Text = "Şİfre :";
            // 
            // labelAdminName
            // 
            labelAdminName.AutoSize = true;
            labelAdminName.Location = new Point(12, 17);
            labelAdminName.Name = "labelAdminName";
            labelAdminName.Size = new Size(74, 15);
            labelAdminName.TabIndex = 3;
            labelAdminName.Text = "Yeni Admin :";
            // 
            // FormAddAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 234);
            Controls.Add(panelAdminInfo);
            Controls.Add(btnAddAdmin);
            Name = "FormAddAdmin";
            Text = "FormAddAdmin";
            panelAdminInfo.ResumeLayout(false);
            panelAdminInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtPasswordAgain;
        private TextBox txtAdminName;
        private Button btnAddAdmin;
        private Panel panelAdminInfo;
        private Label labelAdminPassAgain;
        private Label labelAdminPass;
        private Label labelAdminName;
    }
}