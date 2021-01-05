using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule_04
{
    class DB
    {
        //public static string connectString = @"Integrated Security=false; User Id = root; Password = root; Initial Catalog = shedule; server = DESKTOP-80LGH2G\SQLEXPRESS";
        //public static string connectString = @"Integrated Security=false; User Id = root; Password = root; Initial Catalog = shedule; server = DESKTOP-R35231Q\MYDB";

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
