using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.Sql;

namespace MiniERP.Data
{
    internal class DatabaseManager
    {
        private RegistryKey baseKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Test");

        private string BuildConnectionString(string server, string database, string sqlUser, string sqlPass)
        {
            return $"Server={server};Database={database};User Id={sqlUser};Password={sqlPass};";
        }
        
        public bool AuthenticateUser(string userId, string password,out string errorMessage)
        {
            try
            {
                string connURL = AppSession.BuildConnectionString(userId,password);
                using (SqlConnection conn = new SqlConnection(connURL))
                {
                    conn.Open();
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        errorMessage = "Veri Tabanı Balantı Hatası";
                        return false;
                    }

                    errorMessage = null;
                    return true;
                }
            }
            catch(SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool CheckConnection(string server, string database, string userId, string password,out string errorMessage)
        {
            try
            {
                string connURL = BuildConnectionString(server,database,userId, password);
                using (SqlConnection conn = new SqlConnection(connURL))
                {
                    conn.Open();
                    errorMessage = null;
                    return conn.State == System.Data.ConnectionState.Open;
                }
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }


    }
}
