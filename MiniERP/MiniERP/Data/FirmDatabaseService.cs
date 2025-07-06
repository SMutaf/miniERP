using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Data
{
    internal class FirmDatabaseService
    {
        public void AddFirm(string server, string database,string sqlUsername,string sqlUserpass, string firm)
        {
            string connString = $"Server={server};Database={database};User Id={sqlUsername};Password={sqlUserpass};";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "INSERT INTO Firms (FirmName) VALUES (@Firm)";

                    using (SqlCommand command = new SqlCommand(query, conn)) 
                    {
                        command.Parameters.AddWithValue("@Firm", firm);

                        int rowsAffected = command.ExecuteNonQuery();

                        if ((rowsAffected == 0))
                        {
                            MessageBox.Show(connString);
                        }
                         
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                    
        }
        public DataTable GetEmployees( string firmName, out string errorMessage)
        {
            errorMessage = "";
            DataTable dt = new DataTable();
                   
            try
            {
                string connURL = UserSession.BuildConnectionString();

                using (SqlConnection conn = new SqlConnection(connURL))
                {
                    conn.Open();

                    string query = @"
                SELECT e.FullName AS [Ad Soyad],
                       e.Email AS [E-Posta],
                       e.PhoneNumber AS [Telefon],
                       e.Address AS [Adres],
                       d.DepartmentName AS [Departman],
                       r.RoleName AS [Görev]
                FROM Employees e
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                LEFT JOIN Roles r ON e.RoleID = r.RoleID
                INNER JOIN Firms f ON e.FirmID = f.FirmID
                WHERE f.FirmName = @FirmName AND e.IsActive = 1";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirmName", firmName);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return dt;
        }

    }
}
