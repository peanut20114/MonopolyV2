using System;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        public static ColorChoosing colorChoosing;
        public static string UserID;
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Account());
        }
    }

    internal class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string birthday { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string last_logged_in { get; set; }
        public string register_at { get; set; }
        public int[] friends { get; set; }
    }
    internal static class Gamemodes
    {
        public static bool Singleplayer { get; set; }
        public static bool Multiplayer { get; set; }
    }

    internal static class ConnectionOptions
    {
        public static string IP { get; set; }
        public static int Port { get; set; }
        public static string PlayerName { get; set; }
        public static bool NameRedIsTaken { get; set; }
        public static bool NameBlueIsTaken { get; set; }
    }
}