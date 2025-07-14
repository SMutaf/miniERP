namespace MiniERP.GUI
{
    partial class AddEmployeePage
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
            labelFullName = new Label();
            labelEmail = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBoxDepartman = new ComboBox();
            comboRole = new ComboBox();
            labelPhoneNum = new Label();
            labelAdress = new Label();
            labelDepertman = new Label();
            Role = new Label();
            btnSave = new Button();
            panelEmployeeInfo = new Panel();
            panelEmployeeInfo.SuspendLayout();
            SuspendLayout();
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Location = new Point(25, 27);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(79, 15);
            labelFullName.TabIndex = 0;
            labelFullName.Text = "İsim Soyisim :";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(25, 56);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(36, 15);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(166, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(141, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(166, 48);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(141, 23);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(166, 77);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(141, 23);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(166, 106);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(141, 23);
            textBox4.TabIndex = 5;
            // 
            // comboBoxDepartman
            // 
            comboBoxDepartman.FormattingEnabled = true;
            comboBoxDepartman.Location = new Point(166, 155);
            comboBoxDepartman.Name = "comboBoxDepartman";
            comboBoxDepartman.Size = new Size(121, 23);
            comboBoxDepartman.TabIndex = 6;
            // 
            // comboRole
            // 
            comboRole.FormattingEnabled = true;
            comboRole.Location = new Point(166, 183);
            comboRole.Name = "comboRole";
            comboRole.Size = new Size(121, 23);
            comboRole.TabIndex = 7;
            // 
            // labelPhoneNum
            // 
            labelPhoneNum.AutoSize = true;
            labelPhoneNum.Location = new Point(25, 85);
            labelPhoneNum.Name = "labelPhoneNum";
            labelPhoneNum.Size = new Size(106, 15);
            labelPhoneNum.TabIndex = 8;
            labelPhoneNum.Text = "Telefon Numarası :";
            // 
            // labelAdress
            // 
            labelAdress.AutoSize = true;
            labelAdress.Location = new Point(25, 114);
            labelAdress.Name = "labelAdress";
            labelAdress.Size = new Size(43, 15);
            labelAdress.TabIndex = 9;
            labelAdress.Text = "Adres :";
            // 
            // labelDepertman
            // 
            labelDepertman.AutoSize = true;
            labelDepertman.Location = new Point(25, 163);
            labelDepertman.Name = "labelDepertman";
            labelDepertman.Size = new Size(66, 15);
            labelDepertman.TabIndex = 10;
            labelDepertman.Text = "Departman";
            // 
            // Role
            // 
            Role.AutoSize = true;
            Role.Location = new Point(25, 191);
            Role.Name = "Role";
            Role.Size = new Size(31, 15);
            Role.TabIndex = 11;
            Role.Text = "Rolü";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(220, 326);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 12;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // panelEmployeeInfo
            // 
            panelEmployeeInfo.BorderStyle = BorderStyle.FixedSingle;
            panelEmployeeInfo.Controls.Add(labelFullName);
            panelEmployeeInfo.Controls.Add(textBox1);
            panelEmployeeInfo.Controls.Add(Role);
            panelEmployeeInfo.Controls.Add(labelEmail);
            panelEmployeeInfo.Controls.Add(labelDepertman);
            panelEmployeeInfo.Controls.Add(textBox2);
            panelEmployeeInfo.Controls.Add(labelAdress);
            panelEmployeeInfo.Controls.Add(textBox3);
            panelEmployeeInfo.Controls.Add(labelPhoneNum);
            panelEmployeeInfo.Controls.Add(textBox4);
            panelEmployeeInfo.Controls.Add(comboRole);
            panelEmployeeInfo.Controls.Add(comboBoxDepartman);
            panelEmployeeInfo.Location = new Point(12, 4);
            panelEmployeeInfo.Name = "panelEmployeeInfo";
            panelEmployeeInfo.Size = new Size(328, 277);
            panelEmployeeInfo.TabIndex = 13;
            // 
            // AddEmployeePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 375);
            Controls.Add(panelEmployeeInfo);
            Controls.Add(btnSave);
            Name = "AddEmployeePage";
            Text = "AddEmployeePage";
            panelEmployeeInfo.ResumeLayout(false);
            panelEmployeeInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelFullName;
        private Label labelEmail;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBoxDepartman;
        private ComboBox comboRole;
        private Label labelPhoneNum;
        private Label labelAdress;
        private Label labelDepertman;
        private Label Role;
        private Button btnSave;
        private Panel panelEmployeeInfo;
    }
}