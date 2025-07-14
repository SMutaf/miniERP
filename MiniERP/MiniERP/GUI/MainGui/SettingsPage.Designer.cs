namespace MiniERP
{
    partial class SettingsPage
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
            sqlFormPanel = new Panel();
            txtUserPass = new TextBox();
            userNameText = new TextBox();
            txtDatabase = new TextBox();
            txtServername = new TextBox();
            connectionControlButton = new Button();
            sqlUserpasswordLabel = new Label();
            sqlUsernameLabel = new Label();
            sqlDatabaseLabel = new Label();
            sqlServerLabel = new Label();
            buttonsPanel = new Panel();
            cancelButton = new Button();
            saveButton = new Button();
            menuLabel = new Label();
            firmFormPanel = new Panel();
            txtFirm = new TextBox();
            frimNameLabel = new Label();
            serverSelectionsPanel = new Panel();
            buttonSetServerAndDB = new Button();
            databasesLabel = new Label();
            comboBoxDatabases = new ComboBox();
            comboBoxServers = new ComboBox();
            serversLabel = new Label();
            menuLabel2 = new Label();
            panel1 = new Panel();
            labelSelectedDatabase = new Label();
            labelSelectedServer = new Label();
            selectedServerandDBLabel = new Label();
            sqlFormPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            firmFormPanel.SuspendLayout();
            serverSelectionsPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // sqlFormPanel
            // 
            sqlFormPanel.BorderStyle = BorderStyle.FixedSingle;
            sqlFormPanel.Controls.Add(txtUserPass);
            sqlFormPanel.Controls.Add(userNameText);
            sqlFormPanel.Controls.Add(txtDatabase);
            sqlFormPanel.Controls.Add(txtServername);
            sqlFormPanel.Controls.Add(connectionControlButton);
            sqlFormPanel.Controls.Add(sqlUserpasswordLabel);
            sqlFormPanel.Controls.Add(sqlUsernameLabel);
            sqlFormPanel.Controls.Add(sqlDatabaseLabel);
            sqlFormPanel.Controls.Add(sqlServerLabel);
            sqlFormPanel.Location = new Point(12, 27);
            sqlFormPanel.Name = "sqlFormPanel";
            sqlFormPanel.Size = new Size(336, 215);
            sqlFormPanel.TabIndex = 0;
            // 
            // txtUserPass
            // 
            txtUserPass.Location = new Point(157, 103);
            txtUserPass.Name = "txtUserPass";
            txtUserPass.Size = new Size(149, 23);
            txtUserPass.TabIndex = 9;
            // 
            // userNameText
            // 
            userNameText.Location = new Point(157, 73);
            userNameText.Name = "userNameText";
            userNameText.Size = new Size(149, 23);
            userNameText.TabIndex = 8;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(157, 44);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(149, 23);
            txtDatabase.TabIndex = 7;
            // 
            // txtServername
            // 
            txtServername.Location = new Point(157, 15);
            txtServername.Name = "txtServername";
            txtServername.Size = new Size(149, 23);
            txtServername.TabIndex = 6;
            // 
            // connectionControlButton
            // 
            connectionControlButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            connectionControlButton.Location = new Point(195, 151);
            connectionControlButton.Name = "connectionControlButton";
            connectionControlButton.Size = new Size(120, 31);
            connectionControlButton.TabIndex = 4;
            connectionControlButton.Text = "Bağlantı Kontrol";
            connectionControlButton.UseVisualStyleBackColor = true;
            connectionControlButton.Click += connectionControlButton_Click;
            // 
            // sqlUserpasswordLabel
            // 
            sqlUserpasswordLabel.AutoSize = true;
            sqlUserpasswordLabel.Font = new Font("Segoe UI", 11.25F);
            sqlUserpasswordLabel.Location = new Point(12, 106);
            sqlUserpasswordLabel.Name = "sqlUserpasswordLabel";
            sqlUserpasswordLabel.Size = new Size(128, 20);
            sqlUserpasswordLabel.TabIndex = 3;
            sqlUserpasswordLabel.Text = "Sql User Password";
            // 
            // sqlUsernameLabel
            // 
            sqlUsernameLabel.AutoSize = true;
            sqlUsernameLabel.Font = new Font("Segoe UI", 11.25F);
            sqlUsernameLabel.Location = new Point(12, 73);
            sqlUsernameLabel.Name = "sqlUsernameLabel";
            sqlUsernameLabel.Size = new Size(107, 20);
            sqlUsernameLabel.TabIndex = 2;
            sqlUsernameLabel.Text = "Sql User Name";
            // 
            // sqlDatabaseLabel
            // 
            sqlDatabaseLabel.AutoSize = true;
            sqlDatabaseLabel.Font = new Font("Segoe UI", 11.25F);
            sqlDatabaseLabel.Location = new Point(12, 41);
            sqlDatabaseLabel.Name = "sqlDatabaseLabel";
            sqlDatabaseLabel.Size = new Size(97, 20);
            sqlDatabaseLabel.TabIndex = 1;
            sqlDatabaseLabel.Text = "Sql Database";
            // 
            // sqlServerLabel
            // 
            sqlServerLabel.AutoSize = true;
            sqlServerLabel.Font = new Font("Segoe UI", 11.25F);
            sqlServerLabel.Location = new Point(12, 14);
            sqlServerLabel.Name = "sqlServerLabel";
            sqlServerLabel.Size = new Size(75, 20);
            sqlServerLabel.TabIndex = 0;
            sqlServerLabel.Text = "Sql Server";
            // 
            // buttonsPanel
            // 
            buttonsPanel.BorderStyle = BorderStyle.FixedSingle;
            buttonsPanel.Controls.Add(cancelButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Location = new Point(12, 301);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(336, 31);
            buttonsPanel.TabIndex = 1;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(229, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(86, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "[Esc] Vazgeç";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(126, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(88, 23);
            saveButton.TabIndex = 0;
            saveButton.Text = "[F2] Kaydet";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // menuLabel
            // 
            menuLabel.AutoSize = true;
            menuLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            menuLabel.Location = new Point(12, 9);
            menuLabel.Name = "menuLabel";
            menuLabel.Size = new Size(43, 17);
            menuLabel.TabIndex = 2;
            menuLabel.Text = "Menü";
            // 
            // firmFormPanel
            // 
            firmFormPanel.BorderStyle = BorderStyle.FixedSingle;
            firmFormPanel.Controls.Add(txtFirm);
            firmFormPanel.Controls.Add(frimNameLabel);
            firmFormPanel.Location = new Point(12, 248);
            firmFormPanel.Name = "firmFormPanel";
            firmFormPanel.Size = new Size(336, 47);
            firmFormPanel.TabIndex = 3;
            // 
            // txtFirm
            // 
            txtFirm.Location = new Point(157, 9);
            txtFirm.Name = "txtFirm";
            txtFirm.Size = new Size(158, 23);
            txtFirm.TabIndex = 5;
            // 
            // frimNameLabel
            // 
            frimNameLabel.AutoSize = true;
            frimNameLabel.Font = new Font("Segoe UI", 11.25F);
            frimNameLabel.Location = new Point(12, 9);
            frimNameLabel.Name = "frimNameLabel";
            frimNameLabel.Size = new Size(73, 20);
            frimNameLabel.TabIndex = 4;
            frimNameLabel.Text = "Firma Adı";
            // 
            // serverSelectionsPanel
            // 
            serverSelectionsPanel.BorderStyle = BorderStyle.FixedSingle;
            serverSelectionsPanel.Controls.Add(buttonSetServerAndDB);
            serverSelectionsPanel.Controls.Add(databasesLabel);
            serverSelectionsPanel.Controls.Add(comboBoxDatabases);
            serverSelectionsPanel.Controls.Add(comboBoxServers);
            serverSelectionsPanel.Controls.Add(serversLabel);
            serverSelectionsPanel.Location = new Point(358, 72);
            serverSelectionsPanel.Name = "serverSelectionsPanel";
            serverSelectionsPanel.Size = new Size(231, 170);
            serverSelectionsPanel.TabIndex = 4;
            // 
            // buttonSetServerAndDB
            // 
            buttonSetServerAndDB.Location = new Point(86, 142);
            buttonSetServerAndDB.Name = "buttonSetServerAndDB";
            buttonSetServerAndDB.Size = new Size(98, 23);
            buttonSetServerAndDB.TabIndex = 5;
            buttonSetServerAndDB.Text = "Ayarla";
            buttonSetServerAndDB.UseVisualStyleBackColor = true;
            buttonSetServerAndDB.Click += buttonSetServerAndDB_Click;
            // 
            // databasesLabel
            // 
            databasesLabel.AutoSize = true;
            databasesLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            databasesLabel.Location = new Point(16, 75);
            databasesLabel.Name = "databasesLabel";
            databasesLabel.Size = new Size(86, 20);
            databasesLabel.TabIndex = 4;
            databasesLabel.Text = "Veri Tabanı";
            // 
            // comboBoxDatabases
            // 
            comboBoxDatabases.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDatabases.FormattingEnabled = true;
            comboBoxDatabases.Location = new Point(16, 98);
            comboBoxDatabases.Name = "comboBoxDatabases";
            comboBoxDatabases.Size = new Size(182, 23);
            comboBoxDatabases.TabIndex = 2;
            // 
            // comboBoxServers
            // 
            comboBoxServers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServers.FormattingEnabled = true;
            comboBoxServers.Location = new Point(16, 29);
            comboBoxServers.Name = "comboBoxServers";
            comboBoxServers.Size = new Size(182, 23);
            comboBoxServers.TabIndex = 1;
            // 
            // serversLabel
            // 
            serversLabel.AutoSize = true;
            serversLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            serversLabel.Location = new Point(16, 7);
            serversLabel.Name = "serversLabel";
            serversLabel.Size = new Size(54, 20);
            serversLabel.TabIndex = 0;
            serversLabel.Text = "Server";
            // 
            // menuLabel2
            // 
            menuLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            menuLabel2.Location = new Point(358, 27);
            menuLabel2.Name = "menuLabel2";
            menuLabel2.Size = new Size(185, 41);
            menuLabel2.TabIndex = 0;
            menuLabel2.Text = "Sql Server Ve Veri Tabanı Seçim Menüsü";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labelSelectedDatabase);
            panel1.Controls.Add(labelSelectedServer);
            panel1.Controls.Add(selectedServerandDBLabel);
            panel1.Location = new Point(358, 248);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 84);
            panel1.TabIndex = 5;
            // 
            // labelSelectedDatabase
            // 
            labelSelectedDatabase.AutoSize = true;
            labelSelectedDatabase.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            labelSelectedDatabase.Location = new Point(3, 53);
            labelSelectedDatabase.Name = "labelSelectedDatabase";
            labelSelectedDatabase.Size = new Size(92, 17);
            labelSelectedDatabase.TabIndex = 2;
            labelSelectedDatabase.Text = "Sql Database :";
            // 
            // labelSelectedServer
            // 
            labelSelectedServer.AutoSize = true;
            labelSelectedServer.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            labelSelectedServer.Location = new Point(4, 29);
            labelSelectedServer.Name = "labelSelectedServer";
            labelSelectedServer.Size = new Size(74, 17);
            labelSelectedServer.TabIndex = 1;
            labelSelectedServer.Text = "Sql Server :";
            // 
            // selectedServerandDBLabel
            // 
            selectedServerandDBLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            selectedServerandDBLabel.Location = new Point(4, 0);
            selectedServerandDBLabel.Name = "selectedServerandDBLabel";
            selectedServerandDBLabel.Size = new Size(194, 20);
            selectedServerandDBLabel.TabIndex = 0;
            selectedServerandDBLabel.Text = "Seçili Server Ve Veritabanı\r\n\r\n";
            // 
            // SettingsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 357);
            Controls.Add(panel1);
            Controls.Add(menuLabel2);
            Controls.Add(serverSelectionsPanel);
            Controls.Add(firmFormPanel);
            Controls.Add(menuLabel);
            Controls.Add(buttonsPanel);
            Controls.Add(sqlFormPanel);
            KeyPreview = true;
            Name = "SettingsPage";
            Text = "Sistem Ayarları";
            KeyDown += SettingsPage_KeyDown;
            sqlFormPanel.ResumeLayout(false);
            sqlFormPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            firmFormPanel.ResumeLayout(false);
            firmFormPanel.PerformLayout();
            serverSelectionsPanel.ResumeLayout(false);
            serverSelectionsPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel sqlFormPanel;
        private Button connectionControlButton;
        private Label sqlUserpasswordLabel;
        private Label sqlUsernameLabel;
        private Label sqlDatabaseLabel;
        private Label sqlServerLabel;
        private TextBox txtUserPass;
        private TextBox userNameText;
        private TextBox txtDatabase;
        private TextBox txtServername;
        private Panel buttonsPanel;
        private Button cancelButton;
        private Button saveButton;
        private Label menuLabel;
        private Panel firmFormPanel;
        private Label frimNameLabel;
        private TextBox txtFirm;
        private Panel serverSelectionsPanel;
        private Label menuLabel2;
        private Label databasesLabel;
        private ComboBox comboBoxDatabases;
        private ComboBox comboBoxServers;
        private Label serversLabel;
        private Button buttonSetServerAndDB;
        private Panel panel1;
        private Label selectedServerandDBLabel;
        private Label labelSelectedDatabase;
        private Label labelSelectedServer;
    }
}