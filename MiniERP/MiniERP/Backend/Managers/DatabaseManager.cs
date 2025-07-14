using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using MiniERP.Backend.Session;
using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MiniERP.Backend.Managers
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

        public void CreateDatabaseAdminUser(string username, string password)
        {
            string connectionString = UserSession.BuildConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. SQL Server'da login oluştur (varsa oluşturmaz)
                string createLoginSql = @"
        IF NOT EXISTS (SELECT name FROM master.sys.server_principals WHERE name = @Username)
        BEGIN
            DECLARE @loginSql NVARCHAR(500);
            SET @loginSql = 'CREATE LOGIN [' + @Username + '] WITH PASSWORD = ''' + @Password + ''', CHECK_POLICY = ON';
            EXEC sp_executesql @loginSql;
        END";

                using (SqlCommand cmd = new SqlCommand(createLoginSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                }

                // 2. Veritabanında kullanıcı oluştur (varsa oluşturmaz)
                string createUserSql = $@"
        USE [{AppSession.SelectedDatabase}];
        IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = @Username)
        BEGIN
            CREATE USER [{username}] FOR LOGIN [{username}];
        END";

                using (SqlCommand cmd = new SqlCommand(createUserSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();
                }

                // 3. Temel yetkileri ver
                string grantPermissionsSql = $@"
        USE [{AppSession.SelectedDatabase}];
        GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO [{username}];
        GRANT EXECUTE ON SCHEMA::dbo TO [{username}];";

                using (SqlCommand cmd = new SqlCommand(grantPermissionsSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 4. Kullanıcıyı Users tablosuna ekle (varsa ekleme)
                string addUserSql = @"
        IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = @Username)
        BEGIN
            INSERT INTO Users (Username, PasswordHash, IsAdmin)
            VALUES (@Username, @Password, 1);
        END";

                using (SqlCommand cmd = new SqlCommand(addUserSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                }

                // 5. Kullanıcıyı mevcut firmaya bağla (varsa bağlama)
                string linkToFirmSql = @"
        DECLARE @UserId INT = (SELECT UserID FROM Users WHERE Username = @Username);
        DECLARE @FirmId INT = (SELECT FirmID FROM Firms WHERE FirmName = @FirmName);
        
        IF NOT EXISTS (SELECT 1 FROM UserFirms WHERE UserID = @UserId AND FirmID = @FirmId)
        BEGIN
            INSERT INTO UserFirms (UserID, FirmID)
            VALUES (@UserId, @FirmId);
        END";

                using (SqlCommand cmd = new SqlCommand(linkToFirmSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@FirmName", UserSession.firm);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
