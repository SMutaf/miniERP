using MiniERP.Backend.Session;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniERP.Backend.Services
{
    internal class UserDatabaseService
    {
        public bool AddUser(string sqlUsername, string sqlUserpass, string server, string database, bool isAdmin, string firm)
        {
            string connString = $"Server={server};Database={database};User Id={sqlUsername};Password={sqlUserpass};";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    FirmDatabaseService firmDatabaseService = new FirmDatabaseService();
                    int firmID = firmDatabaseService.GetFirmIdByName(firm, conn);


                    int userID = GetOrCreateUser(conn, sqlUsername, sqlUserpass, isAdmin);

                    // Kullanıcı-Firma ilişkisini kontrol et ve ekle
                    if (!UserFirmRelationExists(conn, userID, firmID))
                    {
                        string query = @"INSERT INTO UserFirms (UserID, FirmID)
                                 VALUES (@UserID, @FirmID)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userID);
                            cmd.Parameters.AddWithValue("@FirmID", firmID);
                            int result = cmd.ExecuteNonQuery();
                            return result > 0;
                        }
                    }
                    return true; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı ekleme hatası: " + ex.Message);
                return false;
            }
        }

        public bool IsUserAuthorizedForFirm(string username, string password, string firmName)
        {
            try
            {
                string connString = AppSession.BuildConnectionString(username, password);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT COUNT(*) 
                            FROM UserFirms uf
                            JOIN Users u ON uf.UserID = u.UserID
                            JOIN Firms f ON uf.FirmID = f.FirmID
                            WHERE u.Username = @Username AND f.FirmName = @FirmName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@FirmName", firmName);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private int GetOrCreateUser(SqlConnection conn, string username, string password, bool isAdmin)
        {
            // Kullanıcı var mı kontrol et
            string query = "SELECT UserID FROM Users WHERE Username = @Username";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }

            // Kullanıcı yoksa oluştur
            query = @"INSERT INTO Users (Username, PasswordHash, IsAdmin)
              VALUES (@Username, @Password, @IsAdmin);
              SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@IsAdmin", isAdmin);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private bool UserFirmRelationExists(SqlConnection conn, int userID, int firmID)
        {
            string query = "SELECT COUNT(*) FROM UserFirms WHERE UserID = @UserID AND FirmID = @FirmID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@FirmID", firmID);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        
    }
}
