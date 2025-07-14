using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Backend.Session
{
    internal class AppSession
    {
        public static string SelectedServer { get; set; }
        public static string SelectedDatabase { get; set; }

        
        public static bool IsConfigured =>
            !string.IsNullOrWhiteSpace(SelectedServer) &&
            !string.IsNullOrWhiteSpace(SelectedDatabase);

        public static string BuildConnectionString(string userId, string password)
        {
            return $"Server={SelectedServer};Database={SelectedDatabase};User Id={userId};Password={password};";
        }

        public static void SetAppSession(string server, string database)
        {
            SelectedServer = server;
            SelectedDatabase = database;
        }
    }
}
