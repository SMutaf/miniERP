using Microsoft.Win32;
using MiniERP.Backend.Helpers;
using MiniERP.Backend.Managers;
using MiniERP.Backend.Session;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Data
{
    internal class RegistryManager
    {
        private RegistryKey baseKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Test");

        public bool VerifyConnectionAndSave(string server, string database, string userId, string password, string firmName, out string errorMessage)
        {
            try
            {
                DatabaseManager manager = new DatabaseManager();
                bool conn = manager.CheckConnection(server, database, userId, password,out string connErrorMessage);
    
                    if (conn == false)
                    {
                        errorMessage = connErrorMessage;
                        return false;
                    }

                    errorMessage = null;
                    return SaveToRegeddit(server, database, userId, password, firmName);
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private bool SaveToRegeddit(string server, string database, string firmUsername, string firmUserpass, string firmName)
        {
            try
            {
                using (RegistryKey firmaKey = baseKey.CreateSubKey(firmName))
                {
                    firmaKey.SetValue("SqlServer", server);
                    firmaKey.SetValue("SqlDatabase", database);
                    firmaKey.SetValue("SqlUserName", firmUsername);

                    string encryptedPassword = EncryptionHelper.Encrypt(firmUserpass);
                    firmaKey.SetValue("SqlPassword", encryptedPassword);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GetServersAndDatabasesFromRegistry(ComboBox servers, ComboBox databases)
        {
            using (RegistryKey baseKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Test"))
            {
                if (baseKey == null)
                {
                    MessageBox.Show("Kayıt bulunamadı.");
                    return;
                }

                string[] firmsKey = baseKey.GetSubKeyNames();

                foreach (string firm in firmsKey)
                {
                    using (RegistryKey firmKey = baseKey.OpenSubKey(firm))
                    {
                        if (firmKey != null)
                        {
                            string server = firmKey.GetValue("SqlServer")?.ToString();
                            string database = firmKey.GetValue("SqlDatabase")?.ToString();

                            if (!servers.Items.Contains(server))
                                servers.Items.Add(server);

                            if (!databases.Items.Contains(database))
                                databases.Items.Add(database);
                        }
                    }
                }
            }
        }

        public void GetFirmsFromRegistry(ComboBox firms)
        {
            try
            {
                using (RegistryKey baseKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Test"))
                {
                    if (baseKey == null)
                    {
                        MessageBox.Show("Regedit BaseKey Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string[] firmsKey = baseKey.GetSubKeyNames();

                    foreach (string firm in firmsKey)
                    {
                        firms.Items.Add(firm);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
