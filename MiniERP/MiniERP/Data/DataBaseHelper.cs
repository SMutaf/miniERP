using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MiniERP.Data
{
    public class DataBaseHelper
    {
        //veri tabanı bağlantı sağlamak için conn string
        //trusted connection açık olduğu için böyle yazdım eğer değilse  
        //  @"Server=...;Database=miniErpDB;User ID=;Password=;"      
        private readonly string connectionString = @"Server=Mutaf\SQLEXPRESS;Database=miniErpDB;Trusted_Connection=True";

        //veri tabanı bağlantsını oluşturuğ döndüren method
        public SqlConnection getConnection()
        {
            return new SqlConnection(connectionString);
        }

        //login pagede allttaki panelde server ve data base bilgilerinin çekilmesini
        //ve labellara yerleştirilmesini sağlar
        public void getConnectionInfo(Label serverLabel, Label dbLabel)
        {
            try
            {
                using (SqlConnection connection = getConnection())
                {
                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        serverLabel.Text += connection.DataSource;
                        dbLabel.Text += connection.Database;
                    }
                    else
                    {
                        throw new Exception("Bağlantı başarısız.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veri Tabanı Hatası:\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //firmaları veri tabanından çekip login page ekranı başlatıldığında comboboxa yerleştirir
        public void getFirms(ComboBox firmComboBox)
        {
            try
            {
                using (SqlConnection connection = getConnection())
                {
                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        String sql = "SELECT FirmName FROM Firms";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    firmComboBox.Items.Add(reader[0].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Bağlantı başarısız.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Firmaları Çekereken Bir Sorun Oluştu:\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //kullanıcı ismi şifre ve firma bilgilerinin eşleşip eşleşmediğini kontrol eder
        //eşlememsi durumda hangi bilginin yanlış olduğuyla beraber messagebox ile kullanıca geri
        //dönüş sağlar
        public bool adminAuthentication(string userNameTb, string passTb, string selectedFirm)
        {
            try
            {
                using (SqlConnection connection = getConnection())
                {
                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                      
        
                        if (string.IsNullOrEmpty(selectedFirm))
                        {
                            MessageBox.Show("Firma Seçmediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                       
                        string getFirmIdQuery = "SELECT FirmID FROM Firms WHERE FirmName = @firmName";
                        int firmId;

                        using (SqlCommand firmCommand = new SqlCommand(getFirmIdQuery, connection))
                        {
                            firmCommand.Parameters.AddWithValue("@firmName", selectedFirm);
                            object result = firmCommand.ExecuteScalar();

                            if (result == null)
                            {
                                MessageBox.Show("Firma bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            firmId = Convert.ToInt32(result);
                        }

                     
                        string sql = "SELECT PasswordHash FROM Admins WHERE UserName = @username AND FirmID = @firmId";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@username", userNameTb);
                            command.Parameters.AddWithValue("@firmId", firmId);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string pass = reader.GetString(0);

                                    if (pass == passTb)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Şifre yanlış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Kullanıcı bu firmaya bağlı değil veya bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Bağlantı başarısız.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Girişte hata:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        }
    }

