namespace Shedule_04
{
    class DB
    {
        public static string login;
        public static string password;
        public static string database;
        public static string server;

        public static string connectString;

        public string getConnectString()
        {
            connectString = @"Integrated Security=false; User Id = "
            + login + "; Password = " + password + "; Initial Catalog = " +
            database + "; server = " + server;
            return connectString;
        }
    }
}
