using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using MiniERP.Backend.Managers;
using MiniERP.Backend.Services;
using MiniERP.Backend.Session;
using MiniERP.Data;

namespace MiniERP
{
    public partial class SettingsPage : Form
    {
        public SettingsPage()
        {
            InitializeComponent();
            setDesign();
            getSavedConnections();
            SetDefaultServerAndDatabase();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveInformations())
            {
                clearContents();
                getSavedConnections();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSetServerAndDB_Click(object sender, EventArgs e)
        {
            setServerandDatabase();
        }

        private void connectionControlButton_Click(object sender, EventArgs e)
        {
            TryConnection();
        }

        private void SettingsPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

            if (e.KeyCode == Keys.F2)
            {
                if (saveInformations())
                {
                    clearContents();
                    getSavedConnections();
                }
            }
        }

        private bool saveInformations()
        {
            string sqlUsername = userNameText.Text?.Trim();
            string sqlUserpass = txtUserPass.Text?.Trim();
            string server = txtServername.Text?.Trim();
            string database = txtDatabase.Text?.Trim();
            string firmName = txtFirm.Text?.Trim();

            List<string> errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(sqlUsername)) errorMessages.Add("SQL kullanıcı adı boş olamaz.");
            if (string.IsNullOrWhiteSpace(sqlUserpass)) errorMessages.Add("SQL şifre boş olamaz.");
            if (string.IsNullOrWhiteSpace(server)) errorMessages.Add("SQL sunucu adı boş olamaz.");
            if (string.IsNullOrWhiteSpace(database)) errorMessages.Add("Veritabanı adı boş olamaz.");
            if (string.IsNullOrWhiteSpace(firmName)) errorMessages.Add("Firma adı boş olamaz.");

            if (errorMessages.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errorMessages), "Eksik Bilgiler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            RegistryManager manager = new RegistryManager();
            bool saveToRegistry = manager.VerifyConnectionAndSave(server, database, sqlUsername, sqlUserpass, firmName, out string errorMessage);

            if (!saveToRegistry)
            {
                MessageBox.Show("Kayıt Tamamlanırken Sorun Oluştu \n" + errorMessage, "Durum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            FirmDatabaseService firmDatabaseService = new FirmDatabaseService();
            bool firmCreated = firmDatabaseService.AddFirm(server, database, sqlUsername, sqlUserpass, firmName);
            if (!firmCreated)
            {
                return false;
            }

            UserDatabaseService userService = new UserDatabaseService();
            bool userRelationCreated = userService.AddUser(sqlUsername, sqlUserpass, server, database, true, firmName);

            if (!userRelationCreated)
            {
                MessageBox.Show("Firma eklendi ancak kullanıcı-firma ilişkisi oluşturulamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            MessageBox.Show("Firma ve kullanıcı yetkilendirmesi başarıyla eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void TryConnection()
        {
            string userName = userNameText.Text?.Trim();
            string userPass = txtUserPass.Text?.Trim();
            string server = txtServername.Text?.Trim();
            string database = txtDatabase.Text?.Trim();

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userPass) ||
                string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database))
            {
                MessageBox.Show("Bütün Kutucuklar Dolu Olmalı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseManager db = new DatabaseManager();
            if (db.CheckConnection(server,database,userName, userPass, out string errorMessage))
            {
                MessageBox.Show("Bağlantı başarılı", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bağlantı başarısız.\n\n" + errorMessage, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setServerandDatabase()
        {
            string selectedServer = comboBoxServers.SelectedItem?.ToString();
            string selectedDatabase = comboBoxDatabases.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedServer))
            {
                MessageBox.Show("Server Seçili Değil", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedDatabase))
            {
                MessageBox.Show("Veri Tabanı Seçili Değil", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppSession.SetAppSession(selectedServer, selectedDatabase);

            labelSelectedServer.Text = "Sql Server : " + selectedServer;
            labelSelectedDatabase.Text = "Sql Database : " + selectedDatabase;
        }

        private void getSavedConnections()
        {
            RegistryManager manager = new RegistryManager();
            manager.GetServersAndDatabasesFromRegistry(comboBoxServers, comboBoxDatabases);
        }

        private void clearContents()
        {
            userNameText.Clear();
            txtUserPass.Clear();
            txtServername.Clear();
            txtDatabase.Clear();
            txtFirm.Clear();
        }

        private void setDesign()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = "Sistem Ayarları";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            txtUserPass.UseSystemPasswordChar = true;

            string server = AppSession.SelectedServer;
            string database = AppSession.SelectedDatabase;

            labelSelectedServer.Text = "Sql Server : " + server;
            labelSelectedDatabase.Text = "Sql Database : " + database;
        }

        private void SetDefaultServerAndDatabase()
        {
            if (!AppSession.IsConfigured) 
            {
                txtServername.Text = "Kaıyıtlı Anahtar Bulunamadı";
                txtDatabase.Text = "Kayıtlı Anahtar Bulunamadı";
                return;
            }

            txtServername.Text = AppSession.SelectedServer;
            txtDatabase.Text = AppSession.SelectedDatabase;
        }
    }

}
