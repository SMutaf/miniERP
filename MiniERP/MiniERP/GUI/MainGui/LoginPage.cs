using MiniERP.Backend.Helpers;
using MiniERP.Backend.Managers;
using MiniERP.Backend.Services;
using MiniERP.Backend.Session;
using MiniERP.Data;
using System;
using System.Data.SqlClient;
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
            SetFormDesign();
            setDefaultInformations();
            LoadFirms();
        }


        private void settingButton_Click(object sender, EventArgs e)
        {
            SettingsPage settingsPage = new SettingsPage();
            settingsPage.ShowDialog();

            LoadFirms();
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

            UserDatabaseService service = new UserDatabaseService();
            if (!service.IsUserAuthorizedForFirm(username, userpass, firm))
            {
                MessageBox.Show("Bu kullanıcının seçilen firmada yetkisi yok. \n Veya Böyle Bir Kullanıcı Yok", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatabaseManager databaseManager = new DatabaseManager();
            bool authentication = databaseManager.AuthenticateUser(username, userpass,out string errMessage);

            if(authentication == false)
            {
                MessageBox.Show(errMessage,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            UserSession.SetUserSession(username, userpass, firm);

            
            this.Hide();
            ControlPage controlPage = new ControlPage(username, userpass, firm);
            controlPage.FormClosed += (s, args) => this.Close();
            controlPage.Show();

        }

        private void setDefaultInformations()
        {
            AppLaunchConfig.SetDefaultRegistryConfiguration();
            serverLabel.Text = "Server : " + AppSession.SelectedServer;
            dataBaseLabel.Text = "Database : " + AppSession.SelectedDatabase;
        }

        private void UptadeAppSessionInformation()
        {
            serverLabel.Text = "Server : " + AppSession.SelectedServer;
            dataBaseLabel.Text = "Database : " + AppSession.SelectedDatabase;
        }

        private void LoadFirms()
        {
            RegistryManager manager = new RegistryManager();
            firmComboBox.Items.Clear();
            manager.GetFirmsFromRegistry(firmComboBox);
        }

        private void SetFormDesign()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = "Giriş Ekranı";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            passwordTextBox.UseSystemPasswordChar = true;

            SetLoginPanelPosition();
        }

        private void SetLoginPanelPosition()
        {
            LoginPanel.Location = new Point(
                (this.ClientSize.Width - LoginPanel.Width) / 2,
                (this.ClientSize.Height - LoginPanel.Height) / 2
            );
        }

    }
}
