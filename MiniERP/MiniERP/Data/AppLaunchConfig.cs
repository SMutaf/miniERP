using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Data
{
    internal class AppLaunchConfig
    {

        static private RegistryKey baseKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Test");

        public static void SetTestKey()
        {
            try
            {
                using (RegistryKey firmaKey = baseKey.CreateSubKey("TestFirm"))
                {
                    string server = "Seçilmedi";
                    string database = "Seçilmedi";
                    string firmUsername = "DenemeAdmin";
                    string firmUserpass = "123";

                    firmaKey.SetValue("SqlServer", server);
                    firmaKey.SetValue("SqlDatabase", database);
                    firmaKey.SetValue("SqlUserName", firmUsername);
                    firmaKey.SetValue("SqlUserPass", firmUserpass);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AppLaunchConfig Hatası" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
        }
    }
}
