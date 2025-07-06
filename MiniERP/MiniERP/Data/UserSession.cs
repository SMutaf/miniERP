using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Data
{
    internal class UserSession
    {
        public static string sqlUser { get; set; }
        public static string sqlPass { get; set; }

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

        public static void SetUserSession(string sqlUsername, string sqlPassword)
        {
            sqlUser = sqlUsername;
            sqlPass = sqlPassword;
        }
    }
}
