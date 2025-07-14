using MiniERP.Backend.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniERP.Backend.Services
{
    internal class FirmDatabaseService
    {
        public bool AddFirm(string server, string database, string sqlUsername, string sqlUserpass, string firm)
        {
            string connString = $"Server={server};Database={database};User Id={sqlUsername};Password={sqlUserpass};";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    if (FirmExists(conn, firm))
                    {
                        MessageBox.Show("Bu isimde bir firma zaten kayıtlı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    string query = "INSERT INTO Firms (FirmName) VALUES (@Firm)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Firm", firm);
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Firma ekleme hatası: " + ex.Message);
                return false;
            }
        }

        public int GetFirmIdByName(string firmName)
        {
            string connString = UserSession.BuildConnectionString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT FirmID FROM Firms WHERE FirmName = @Name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", firmName);
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int firmId))
                        return firmId;

                    throw new Exception("Firma ID bulunamadı!");
                }
            }
        }

        private bool FirmExists(SqlConnection conn, string firmName)
        {
            string query = "SELECT COUNT(*) FROM Firms WHERE FirmName = @Name";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", firmName);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void GetRoleAndDepertmans(ComboBox depertman, ComboBox role)
        {
            try
            {
                string connString = UserSession.BuildConnectionString();

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmdDept = new SqlCommand("SELECT DepartmentID, DepartmentName FROM Departments", conn))
                    using (SqlDataReader reader = cmdDept.ExecuteReader())
                    {
                        var deptList = new List<KeyValuePair<int, string>>();
                        while (reader.Read())
                        {
                            deptList.Add(new KeyValuePair<int, string>(
                                reader.GetInt32(0), reader.GetString(1)));
                        }

                        depertman.DataSource = deptList;
                        depertman.DisplayMember = "Value";
                        depertman.ValueMember = "Key";
                    }

                    using (SqlCommand cmdRole = new SqlCommand("SELECT RoleID, RoleName FROM Roles", conn))
                    using (SqlDataReader reader = cmdRole.ExecuteReader())
                    {
                        var roleList = new List<KeyValuePair<int, string>>();
                        while (reader.Read())
                        {
                            roleList.Add(new KeyValuePair<int, string>(
                                reader.GetInt32(0), reader.GetString(1)));
                        }

                        role.DataSource = roleList;
                        role.DisplayMember = "Value";
                        role.ValueMember = "Key";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Departman/rol verileri yüklenemedi: " + ex.Message);
            }
        }

        public int GetFirmIdByName(string firmName, SqlConnection conn)
        {
            string query = "SELECT FirmID FROM Firms WHERE FirmName = @Name";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", firmName);
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int firmId))
                    return firmId;

                throw new Exception("Firma ID bulunamadı!");
            }
        }
    }

}
