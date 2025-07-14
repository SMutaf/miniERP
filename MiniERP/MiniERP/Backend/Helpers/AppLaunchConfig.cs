using Microsoft.Win32;
using MiniERP.Backend.Session;
using System;
using System.Windows.Forms;

namespace MiniERP.Backend.Helpers
{
    internal class AppLaunchConfig
    {
        private const string RegistryBasePath = @"SOFTWARE\Test";

        public static void SetDefaultRegistryConfiguration()
        {
            try
            {
  
                using (RegistryKey baseKey = Registry.CurrentUser.OpenSubKey(RegistryBasePath, true))
                {
                    if (baseKey == null)
                    {

                        CreateTestKey();
                        MessageBox.Show("Test anahtarı otomatik olarak oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string[] firmsKey = baseKey.GetSubKeyNames();
                    if (firmsKey.Length == 0)
                    {
                        CreateTestKey();
                        MessageBox.Show("Test anahtarı otomatik olarak oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show("Registry işlemlerinde hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CreateTestKey()
        {
            try
            {
                using (RegistryKey baseKey = Registry.CurrentUser.CreateSubKey(RegistryBasePath))
                using (RegistryKey firmaKey = baseKey.CreateSubKey("TestFirm"))
                {
                    string server = "Kullanıcı\\SQLEXPRESS";
                    string database = "master";
                    string firmUsername = "DenemeAdmin";
                    string firmUserpass = "123";

                    firmaKey.SetValue("SqlServer", server);
                    firmaKey.SetValue("SqlDatabase", database);
                    firmaKey.SetValue("SqlUserName", firmUsername);
                    firmaKey.SetValue("SqlUserPass", firmUserpass);

                    AppSession.SelectedServer = server;
                    AppSession.SelectedDatabase = database;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test anahtarı oluşturulurken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}