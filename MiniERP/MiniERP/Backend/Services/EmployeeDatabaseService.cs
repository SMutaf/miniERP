using MiniERP.Backend.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Backend.Services
{
    internal class EmployeeDataBaseService
    {
        public DataTable GetEmployees(out string errorMessage)
        {
            errorMessage = "";
            DataTable dt = new DataTable();
            string firmName = UserSession.firm;

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


        public bool AddEmployee(string fullName, string email, string phone, string address, int departmentId, int roleId, int firmId, out string errorMessage)
        {
            try
            {
                string connString = UserSession.BuildConnectionString();

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO Employees (FirmID, FullName, Email, PhoneNumber, Address, DepartmentId, RoleId)
                        VALUES (@FirmID, @FullName, @Email, @Phone, @Address, @DepartmentId, @RoleId)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirmID", firmId);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                        cmd.Parameters.AddWithValue("@RoleId", roleId);

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            errorMessage = null;
                            return true;
                        }
                        else
                        {
                            errorMessage = "Kayıt eklenemedi.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }


        public bool DeleteEmployee(int employeeId, out string errorMessage)
        {
            try
            {
                string connString = UserSession.BuildConnectionString();

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "UPDATE Employees SET IsActive = 0 WHERE EmployeeID = @EmpId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpId", employeeId);

                        int affectedRows = cmd.ExecuteNonQuery();
                        errorMessage = affectedRows > 0 ? null : "Silme başarısız, kayıt bulunamadı.";
                        return affectedRows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public int GetEmployeeIdByFullName(string fullName)
        {
            try
            {
                string connString = UserSession.BuildConnectionString();
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID FROM Employees WHERE FullName = @FullName AND IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch
            {
                return -1;
            }

        }
    }
}
