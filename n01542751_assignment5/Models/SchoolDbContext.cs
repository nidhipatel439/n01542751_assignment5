using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace n01542751_assignment5.Models
{
    public class SchoolDbContext
    {
        private static string User { get { return "root"; } }

        private static string Password { get { return "root"; } }

        private static string Port { get { return "3306"; } }

        private static string Server { get { return "localhost"; } }

        private static string Database { get { return "school"; } }

        protected static string ConnectionString
        {
            get
            {
                return "server =" + Server + "; port =" + Port + "; user = " + User
                    + "; password =" + Password + "; database =" + Database + "; convert zero datetime = true";
            }
        }

        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}