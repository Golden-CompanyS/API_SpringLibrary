using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace API_SpringLibrary.Models
{
    public class DatabaseHelper
    {
        static MySqlConnection conexao = new MySqlConnection("server=localhost" +
                                            ";Database=dbSpringLibrary" +
                                            ";User ID=root" +
                                            ";Password=1234567.;");
        public static MySqlCommand CreateComm()
        {
            MySqlCommand command = new MySqlCommand(null, conexao);
            return command;
        }
        public void OpenConnec()
        {
            conexao.Open();
        }
        public void CloseConnec()
        {
            conexao.Close();
        }
    }
}