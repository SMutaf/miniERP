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
            string sqlUserpass = userPasswordText.Text?.Trim();
            string server = serverNameText.Text?.Trim();
            string database = databaseText.Text?.Trim();
            string firmName = txtFirm.Text?.Trim();

            if (string.IsNullOrWhiteSpace(sqlUsername) || string.IsNullOrWhiteSpace(sqlUserpass) ||
                string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database))
            {
                MessageBox.Show("SQL Bilgileri Eksik !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(firmName))
            {
                MessageBox.Show("Firma Bilgileri Eksik !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            RegistryManager manager = new RegistryManager();
            bool saveToRegistry = manager.SaveFirmInfoToRegeddit(server, database, sqlUsername, sqlUserpass, firmName, out string errorMessage);

            if (saveToRegistry)
            {
                FirmDatabaseService firmDatabaseService = new FirmDatabaseService();
                firmDatabaseService.AddFirm(server,database ,sqlUsername, sqlUserpass, firmName);
                MessageBox.Show("Kayıt Tamamlandı", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Kayıt Tamamlanırken Sorun Oluştu \n" + errorMessage, "Durum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void TryConnection()
        {
            string userName = userNameText.Text?.Trim();
            string userPass = userPasswordText.Text?.Trim();
            string server = serverNameText.Text?.Trim();
            string database = databaseText.Text?.Trim();

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
            manager.LoadServersAndDatabasesFromRegistry(comboBoxServers, comboBoxDatabases);
        }

        private void clearContents()
        {
            userNameText.Clear();
            userPasswordText.Clear();
            serverNameText.Clear();
            databaseText.Clear();
            txtFirm.Clear();
        }

        private void setDesign()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = "Sistem Ayarları";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            string server = AppSession.SelectedServer;
            string database = AppSession.SelectedDatabase;

            labelSelectedServer.Text = "Sql Server : " + server;
            labelSelectedDatabase.Text = "Sql Database : " + database;
        }
    }

}
