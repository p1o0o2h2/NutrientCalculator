using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace えいようちゃん
{
    static class MySQL
    {
        // MySQLへの接続情報
        static string server = "localhost";
        static string database = "mysql";
        static string user = "root";
        static string pass = "";
        static string charset = "utf8";
        static string connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Charset={4}", server, database, user, pass, charset);
            // MySQLへの接続
            
        public static string ConnectTest()
        {
            string rtn;
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                rtn ="OK";
                connection.Close();
            }
            catch (MySqlException me)
            {
                rtn = "ERROR: " + me.Message;
            }
            return rtn;
        }
    }
}
