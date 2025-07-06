using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Data
{
    internal class RegistryManager
    {
        private RegistryKey baseKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Test");

        public bool SaveFirmInfoToRegeddit(string server, string database, string userId, string password, string firmName, out string errorMessage)
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
                    firmaKey.SetValue("SqlUserPass", firmUserpass);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void LoadServersAndDatabasesFromRegistry(ComboBox servers, ComboBox databases)
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

        public void SetDefaultServerAndDatabaseFromRegistry()
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
                    if (firmsKey.Length == 0)
                    {
                        MessageBox.Show("Hiç Alt Anahtar Yok.\n" +
                            "Test Anahtarı Otomatik Oluşturuldu", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (RegistryKey firmKey = baseKey.OpenSubKey(firmsKey[0]))
                    {
                        if (firmKey == null)
                        {
                            MessageBox.Show("Firma alt anahtarı açılamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        AppSession.SelectedServer = firmKey.GetValue("SqlServer")?.ToString();
                        AppSession.SelectedDatabase = firmKey.GetValue("SqlDatabase")?.ToString();
                    }
                }

            }
            catch (SqlException ex)
            {

            }
        }

        public void SetFirmsFromRegistry(ComboBox firms)
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

            }
        }
    }
}
