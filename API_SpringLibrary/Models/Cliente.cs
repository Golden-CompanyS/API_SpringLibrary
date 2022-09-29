using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace API_SpringLibrary.Models
{
    public class Cliente
    {
        public Cliente() { }
        public Cliente(string nomCli, string emailCli, int celCli, int numEndCli, string compEndCli)
        {
            this.nomCli = nomCli;
            this.emailCli=emailCli;
            this.celCli=celCli;
        }

        public Cliente(int idCliente, string NomCli, string emailCli, int celCli, int numEndCli, string compEndCli)
        {
            this.IdCli = idCliente;
            this.nomCli = NomCli;
            this.emailCli = emailCli;
            this.celCli = celCli;
            this.numEndCli = numEndCli;
            this.compEndCli = compEndCli;
        }

        public int IdCli { get; set; }
        public string nomCli { get; set; }
        public string emailCli { get; set; }
        public int celCli { get; set; }
        public int numEndCli { get; set; }
        public string compEndCli { get; set; }

        MySqlCommand command = DatabaseHelper.CreateComm();

        public Cliente GetCliByID(int id)
        {
            Cliente tempCli = new Cliente();
            string query = "select * from Cliente where IdCli = id limit 1";
            query = query.Replace("id", id.ToString());
            command.CommandText = query;
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                tempCli.IdCli = id;
                tempCli.nomCli = reader["nomCli"].ToString();
                tempCli.emailCli = reader["emailCli"].ToString();
                tempCli.celCli = reader["celCli"].ToString(celCli);
                tempCli.numEndCli = reader["numEndCli"].ToString();
            }
            return tempUser;
        }
        public void InsertNewUser(User user)
        {
            string query = "insert into tbUser (Username, PassUser) values ('user', 'pass')";
            query = query.Replace("user", user.Username);
            query = query.Replace("pass", user.PassUser);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
        public bool ValidadeUser(User user)
        {
            string query = "select * from tbUser where (Username = 'user' AND PassUser = 'pass')";
            query = query.Replace("user", user.Username);
            query = query.Replace("pass", user.PassUser);
            command.CommandText = query;
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}