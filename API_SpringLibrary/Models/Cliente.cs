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
                tempCli.celCli = int.Parse(reader["celCli"].ToString());
                tempCli.numEndCli = int.Parse(reader["numEndCli"].ToString());
            }
            return tempCli;
        }
        public void InsertNewCli(Cliente cli)
        {
            string query = "insert into Cliente (nomCli, emailCli, celCli, numEndCli, compEndCli) values ('nome', 'email', 'cel', 'numEnd', 'compEnd')";
            query = query.Replace("nome", cli.nomCli);
            query = query.Replace("email", cli.emailCli);
            query = query.Replace("cel", cli.celCli.ToString());
            query = query.Replace("numEnd", cli.numEndCli.ToString());
            query = query.Replace("compEnd", cli.compEndCli);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
        public bool ValidadeCli(Cliente cli)
        {
            string query = "select * from Cliente where (NomCli = 'nome')";
            query = query.Replace("nome", cli.nomCli);
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