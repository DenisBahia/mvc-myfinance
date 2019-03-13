using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication1.Util
{
    public class DAL
    {

        private static string server = "denisbahiaserver.mysql.database.azure.com";
        private static string database = "financeiro";
        private static string user = "denis.bahia@denisbahiaserver";
        private static string password = "dou85eki!@";
        //Server=denisbahiaserver.mysql.database.azure.com; Port=3306; Database={your_database}; Uid=denis.bahia@denisbahiaserver; Pwd={your_password}; SslMode=Preferred;
        private string connectionString = $"Server={server};database={database};uid={user};pwd={password};Allow Zero Datetime=true;SslMode=Preferred";

        private MySqlConnection connection;

        public DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }

        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

    }
}
