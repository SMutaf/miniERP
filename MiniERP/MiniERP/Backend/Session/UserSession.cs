using MiniERP.Backend.Session;
using System.Data.SqlClient;

internal class UserSession
{
    public static string sqlUser { get; set; }
    public static string sqlPass { get; set; }
    public static string firm { get; set; }
    public static List<string> AuthorizedFirms { get; set; } // Kullanıcının yetkili olduğu firmalar

    public static bool IsConfigured =>
        !string.IsNullOrWhiteSpace(sqlUser) &&
        !string.IsNullOrWhiteSpace(sqlPass);

    public static string BuildConnectionString()
    {
        if (!AppSession.IsConfigured)
        {
            throw new Exception("Sunucu veya veritabanı ayarlanmamış!");
        }
        if (!IsConfigured)
        {
            throw new Exception("SQL kullanıcı bilgileri eksik!");
        }
        return $"Server={AppSession.SelectedServer};Database={AppSession.SelectedDatabase};User Id={sqlUser};Password={sqlPass};";
    }

    public static void SetUserSession(string sqlUsername, string sqlPassword, string firmName)
    {
        sqlUser = sqlUsername;
        sqlPass = sqlPassword;
        firm = firmName;
       
        LoadAuthorizedFirms();
    }

    private static void LoadAuthorizedFirms()
    {
        AuthorizedFirms = new List<string>();
        try
        {
            string connString = BuildConnectionString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"SELECT f.FirmName 
                               FROM UserFirms uf
                               JOIN Firms f ON uf.FirmID = f.FirmID
                               JOIN Users u ON uf.UserID = u.UserID
                               WHERE u.Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", sqlUser);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AuthorizedFirms.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Firma bilgileri yüklenirken hata: " + ex.Message);
        }
    }
}