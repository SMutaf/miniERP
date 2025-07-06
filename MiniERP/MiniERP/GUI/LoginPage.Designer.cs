namespace MiniERP
{
    partial class LoginPage
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
            LoginPanel = new Panel();
            firmComboBox = new ComboBox();
            loginButton = new Button();
            firmNameLabel = new Label();
            passwordTextBox = new TextBox();
            passwordBoxLabel = new Label();
            userNameTextBox = new TextBox();
            userNameLabel = new Label();
            informationPanel = new Panel();
            dataBaseLabel = new Label();
            serverLabel = new Label();
            settingsButton = new Button();
            LoginPanel.SuspendLayout();
            informationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LoginPanel
            // 
            LoginPanel.BackColor = SystemColors.AppWorkspace;
            LoginPanel.Controls.Add(firmComboBox);
            LoginPanel.Controls.Add(loginButton);
            LoginPanel.Controls.Add(firmNameLabel);
            LoginPanel.Controls.Add(passwordTextBox);
            LoginPanel.Controls.Add(passwordBoxLabel);
            LoginPanel.Controls.Add(userNameTextBox);
            LoginPanel.Controls.Add(userNameLabel);
            LoginPanel.Location = new Point(116, 39);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(350, 256);
            LoginPanel.TabIndex = 0;
            // 
            // firmComboBox
            // 
            firmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            firmComboBox.FormattingEnabled = true;
            firmComboBox.Location = new Point(158, 163);
            firmComboBox.Name = "firmComboBox";
            firmComboBox.Size = new Size(121, 23);
            firmComboBox.TabIndex = 9;
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            loginButton.Location = new Point(215, 221);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(91, 28);
            loginButton.TabIndex = 7;
            loginButton.Text = "GİRİŞ";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // firmNameLabel
            // 
            firmNameLabel.AutoSize = true;
            firmNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            firmNameLabel.Location = new Point(51, 163);
            firmNameLabel.Name = "firmNameLabel";
            firmNameLabel.Size = new Size(56, 17);
            firmNameLabel.TabIndex = 4;
            firmNameLabel.Text = "FİRMA :";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(158, 125);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(128, 23);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // passwordBoxLabel
            // 
            passwordBoxLabel.AutoSize = true;
            passwordBoxLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            passwordBoxLabel.Location = new Point(51, 126);
            passwordBoxLabel.Name = "passwordBoxLabel";
            passwordBoxLabel.Size = new Size(49, 17);
            passwordBoxLabel.TabIndex = 2;
            passwordBoxLabel.Text = "ŞİFRE :";
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(158, 87);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(128, 23);
            userNameTextBox.TabIndex = 1;
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            userNameLabel.Location = new Point(51, 88);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(109, 17);
            userNameLabel.TabIndex = 0;
            userNameLabel.Text = "KULLANICI ADI :";
            // 
            // informationPanel
            // 
            informationPanel.BackColor = SystemColors.AppWorkspace;
            informationPanel.Controls.Add(dataBaseLabel);
            informationPanel.Controls.Add(serverLabel);
            informationPanel.Controls.Add(settingsButton);
            informationPanel.Location = new Point(-2, 339);
            informationPanel.Name = "informationPanel";
            informationPanel.Size = new Size(587, 30);
            informationPanel.TabIndex = 1;
            // 
            // dataBaseLabel
            // 
            dataBaseLabel.AutoSize = true;
            dataBaseLabel.Location = new Point(404, 9);
            dataBaseLabel.Name = "dataBaseLabel";
            dataBaseLabel.Size = new Size(64, 15);
            dataBaseLabel.TabIndex = 3;
            dataBaseLabel.Text = "DataBase : ";
            // 
            // serverLabel
            // 
            serverLabel.AutoSize = true;
            serverLabel.Location = new Point(201, 9);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new Size(48, 15);
            serverLabel.TabIndex = 2;
            serverLabel.Text = "Server : ";
            // 
            // settingsButton
            // 
            settingsButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            settingsButton.Location = new Point(14, 3);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(75, 24);
            settingsButton.TabIndex = 0;
            settingsButton.Text = "Ayarlar";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingButton_Click;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(584, 367);
            Controls.Add(informationPanel);
            Controls.Add(LoginPanel);
            Name = "LoginPage";
            Text = "LoginPage";
            LoginPanel.ResumeLayout(false);
            LoginPanel.PerformLayout();
            informationPanel.ResumeLayout(false);
            informationPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel LoginPanel;
        private Label userNameLabel;
        private TextBox userNameTextBox;
        private Label firmNameLabel;
        private TextBox passwordTextBox;
        private Label passwordBoxLabel;
        private Button loginButton;
        private Panel informationPanel;
        private Button settingsButton;
        private Label dataBaseLabel;
        private Label serverLabel;
        private ComboBox firmComboBox;
    }
}