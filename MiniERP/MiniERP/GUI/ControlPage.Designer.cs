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
            panel1 = new Panel();
            btnDeleteEmployee = new Button();
            labelUserSession = new Label();
            labelSessionFirm = new Label();
            buttonEmployeeAdd = new Button();
            dataGridViewEmployees = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(btnDeleteEmployee);
            panel1.Controls.Add(labelUserSession);
            panel1.Controls.Add(labelSessionFirm);
            panel1.Controls.Add(buttonEmployeeAdd);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 43);
            panel1.TabIndex = 0;
            // 
            // btnDeleteEmployee
            // 
            btnDeleteEmployee.Location = new Point(143, 15);
            btnDeleteEmployee.Name = "btnDeleteEmployee";
            btnDeleteEmployee.Size = new Size(112, 23);
            btnDeleteEmployee.TabIndex = 3;
            btnDeleteEmployee.Text = "Çalışan Kaydı Sil";
            btnDeleteEmployee.UseVisualStyleBackColor = true;
            // 
            // labelUserSession
            // 
            labelUserSession.AutoSize = true;
            labelUserSession.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelUserSession.Location = new Point(576, 17);
            labelUserSession.Name = "labelUserSession";
            labelUserSession.Size = new Size(89, 21);
            labelUserSession.TabIndex = 2;
            labelUserSession.Text = "Kullanıcı : ";
            // 
            // labelSessionFirm
            // 
            labelSessionFirm.AutoSize = true;
            labelSessionFirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelSessionFirm.Location = new Point(376, 15);
            labelSessionFirm.Name = "labelSessionFirm";
            labelSessionFirm.Size = new Size(65, 21);
            labelSessionFirm.TabIndex = 0;
            labelSessionFirm.Text = "Firma : ";
            // 
            // buttonEmployeeAdd
            // 
            buttonEmployeeAdd.Location = new Point(12, 15);
            buttonEmployeeAdd.Name = "buttonEmployeeAdd";
            buttonEmployeeAdd.Size = new Size(112, 23);
            buttonEmployeeAdd.TabIndex = 1;
            buttonEmployeeAdd.Text = "Çalışan Kaydı Ekle";
            buttonEmployeeAdd.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEmployees
            // 
            dataGridViewEmployees.AllowUserToAddRows = false;
            dataGridViewEmployees.AllowUserToDeleteRows = false;
            dataGridViewEmployees.BackgroundColor = SystemColors.Control;
            dataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployees.Enabled = false;
            dataGridViewEmployees.Location = new Point(0, 129);
            dataGridViewEmployees.MultiSelect = false;
            dataGridViewEmployees.Name = "dataGridViewEmployees";
            dataGridViewEmployees.ReadOnly = true;
            dataGridViewEmployees.Size = new Size(800, 321);
            dataGridViewEmployees.TabIndex = 1;
            // 
            // ControlPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewEmployees);
            Controls.Add(panel1);
            Name = "ControlPage";
            Text = "ControlPage";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelSessionFirm;
        private DataGridView dataGridViewEmployees;
        private Button buttonEmployeeAdd;
        private Label labelUserSession;
        private Button btnDeleteEmployee;
    }
}