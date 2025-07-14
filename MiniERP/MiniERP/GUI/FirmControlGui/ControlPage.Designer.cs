namespace MiniERP
{
    partial class ControlPage
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
            panelControl = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            btnDeleteEmployee = new Button();
            btnEmployeeAdd = new Button();
            btnAddAdmin = new Button();
            labelUserSession = new Label();
            labelSessionFirm = new Label();
            dataGridViewEmployees = new DataGridView();
            panelUserInformation = new Panel();
            panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).BeginInit();
            panelUserInformation.SuspendLayout();
            SuspendLayout();
            // 
            // panelControl
            // 
            panelControl.BackColor = SystemColors.Control;
            panelControl.BorderStyle = BorderStyle.FixedSingle;
            panelControl.Controls.Add(button4);
            panelControl.Controls.Add(button3);
            panelControl.Controls.Add(button2);
            panelControl.Controls.Add(button1);
            panelControl.Controls.Add(btnDeleteEmployee);
            panelControl.Controls.Add(btnEmployeeAdd);
            panelControl.Location = new Point(12, 2);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(906, 87);
            panelControl.TabIndex = 0;
            // 
            // button4
            // 
            button4.Location = new Point(695, 12);
            button4.Name = "button4";
            button4.Size = new Size(89, 60);
            button4.TabIndex = 7;
            button4.Text = "Firma Yetkililerini Görüntüle";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(182, 42);
            button3.Name = "button3";
            button3.Size = new Size(102, 24);
            button3.TabIndex = 6;
            button3.Text = "Depertman Ekle";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(182, 12);
            button2.Name = "button2";
            button2.Size = new Size(102, 24);
            button2.TabIndex = 5;
            button2.Text = "Rol Ekle";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(790, 12);
            button1.Name = "button1";
            button1.Size = new Size(89, 60);
            button1.TabIndex = 4;
            button1.Text = "Çalışan İstatistiklerini Görüntüle";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEmployee
            // 
            btnDeleteEmployee.Location = new Point(29, 12);
            btnDeleteEmployee.Name = "btnDeleteEmployee";
            btnDeleteEmployee.Size = new Size(61, 60);
            btnDeleteEmployee.TabIndex = 3;
            btnDeleteEmployee.Text = "Çalışan Kaydı Sil";
            btnDeleteEmployee.UseVisualStyleBackColor = true;
            btnDeleteEmployee.Click += btnDeleteEmployee_Click;
            // 
            // btnEmployeeAdd
            // 
            btnEmployeeAdd.Location = new Point(96, 12);
            btnEmployeeAdd.Name = "btnEmployeeAdd";
            btnEmployeeAdd.Size = new Size(60, 60);
            btnEmployeeAdd.TabIndex = 1;
            btnEmployeeAdd.Text = "Çalışan Kaydı Ekle";
            btnEmployeeAdd.UseVisualStyleBackColor = true;
            btnEmployeeAdd.Click += buttonEmployeeAdd_Click;
            // 
            // btnAddAdmin
            // 
            btnAddAdmin.Location = new Point(165, 276);
            btnAddAdmin.Name = "btnAddAdmin";
            btnAddAdmin.Size = new Size(108, 23);
            btnAddAdmin.TabIndex = 4;
            btnAddAdmin.Text = "Admin Ekle";
            btnAddAdmin.UseVisualStyleBackColor = true;
            btnAddAdmin.Click += btnAddAdmin_Click;
            // 
            // labelUserSession
            // 
            labelUserSession.AutoSize = true;
            labelUserSession.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelUserSession.Location = new Point(3, 45);
            labelUserSession.Name = "labelUserSession";
            labelUserSession.Size = new Size(89, 21);
            labelUserSession.TabIndex = 2;
            labelUserSession.Text = "Kullanıcı : ";
            // 
            // labelSessionFirm
            // 
            labelSessionFirm.AutoSize = true;
            labelSessionFirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelSessionFirm.Location = new Point(3, 11);
            labelSessionFirm.Name = "labelSessionFirm";
            labelSessionFirm.Size = new Size(65, 21);
            labelSessionFirm.TabIndex = 0;
            labelSessionFirm.Text = "Firma : ";
            // 
            // dataGridViewEmployees
            // 
            dataGridViewEmployees.BackgroundColor = SystemColors.Control;
            dataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployees.Location = new Point(0, 212);
            dataGridViewEmployees.MultiSelect = false;
            dataGridViewEmployees.Name = "dataGridViewEmployees";
            dataGridViewEmployees.Size = new Size(640, 321);
            dataGridViewEmployees.TabIndex = 1;
            // 
            // panelUserInformation
            // 
            panelUserInformation.BorderStyle = BorderStyle.FixedSingle;
            panelUserInformation.Controls.Add(btnAddAdmin);
            panelUserInformation.Controls.Add(labelSessionFirm);
            panelUserInformation.Controls.Add(labelUserSession);
            panelUserInformation.Location = new Point(646, 212);
            panelUserInformation.Name = "panelUserInformation";
            panelUserInformation.Size = new Size(278, 304);
            panelUserInformation.TabIndex = 2;
            // 
            // ControlPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 528);
            Controls.Add(panelUserInformation);
            Controls.Add(dataGridViewEmployees);
            Controls.Add(panelControl);
            Name = "ControlPage";
            Text = "ControlPage";
            panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).EndInit();
            panelUserInformation.ResumeLayout(false);
            panelUserInformation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelControl;
        private Label labelSessionFirm;
        private DataGridView dataGridViewEmployees;
        private Button btnEmployeeAdd;
        private Label labelUserSession;
        private Button btnDeleteEmployee;
        private Button btnAddAdmin;
        private Panel panelUserInformation;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button4;
    }
}