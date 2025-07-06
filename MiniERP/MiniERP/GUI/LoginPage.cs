using MiniERP.Data;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MiniERP
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            setDesign();
            setDefaultInformations();
            SetFirms();
            AppLaunchConfig.SetTestKey();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            SettingsPage settingsPage = new SettingsPage();
            settingsPage.ShowDialog();

            SetFirms();
            UptadeAppSessionInformation();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            AuthenticateUser();
        }

        private void AuthenticateUser()
        {
            string username = userNameTextBox?.Text;
            string userpass = passwordTextBox?.Text;
            string firm = firmComboBox.SelectedItem?.ToString();

            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(userpass) || string.IsNullOrWhiteSpace(firm))
            {
                MessageBox.Show("Lütfen Bütün Kutucukları Doldurunuz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DatabaseManager databaseManager = new DatabaseManager();
            bool authentication = databaseManager.AuthenticateUser(username, userpass,out string errMessage);

            if(authentication == false)
            {
                MessageBox.Show(errMessage,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            UserSession.SetUserSession(username, userpass);

            //Düzenlenicek
            
            this.Hide();
            ControlPage controlPage = new ControlPage(username, userpass, firm);
            controlPage.FormClosed += (s, args) => this.Close();
            controlPage.Show();

        }

        private void setDefaultInformations()
        {
            RegistryManager manager = new RegistryManager();
            manager.SetDefaultServerAndDatabaseFromRegistry();

            serverLabel.Text = "Server : " + AppSession.SelectedServer;
            dataBaseLabel.Text = "Database : " + AppSession.SelectedDatabase;
        }

        private void UptadeAppSessionInformation()
        {
            serverLabel.Text = "Server : " + AppSession.SelectedServer;
            dataBaseLabel.Text = "Database : " + AppSession.SelectedDatabase;
        }

        private void SetFirms()
        {
            RegistryManager manager = new RegistryManager();
            firmComboBox.Items.Clear();
            manager.SetFirmsFromRegistry(firmComboBox);
        }

        private void setDesign()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = "";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            setLoginPanelPosition();
        }

        private void setLoginPanelPosition()
        {
            LoginPanel.Location = new Point(
                (this.ClientSize.Width - LoginPanel.Width) / 2,
                (this.ClientSize.Height - LoginPanel.Height) / 2
            );
        }

    }
}
