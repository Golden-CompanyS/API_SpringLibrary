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
        public Cliente(string nomCli, string emailCli, int celCli, int numEndCli, string compEndCli, string senha)
        {
            this.nomCli = nomCli;
            this.emailCli = emailCli;
            this.celCli = celCli;
            this.Senha = senha;  
        }

        public Cliente(int idCliente, string NomCli, string emailCli, int celCli, int numEndCli, string compEndCli, string senha)
        {
            this.IdCli = idCliente;
            this.nomCli = NomCli;
            this.emailCli = emailCli;
            this.celCli = celCli;
            this.numEndCli = numEndCli;
            this.compEndCli = compEndCli;
            this.Senha = senha;
        }

        public int IdCli { get; set; }
        public string nomCli { get; set; }
        public string emailCli { get; set; }
        public int celCli { get; set; }
        public int numEndCli { get; set; }
        public string compEndCli { get; set; }
        public string Senha { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

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
            string query = "insert into Cliente (nomCli, emailCli, celCli, numEndCli, compEndCli, senha) values ('nome', 'email', 'cel', 'numEnd', 'compEnd', 'senha')";
            query = query.Replace("nome", cli.nomCli);
            query = query.Replace("email", cli.emailCli);
            query = query.Replace("cel", cli.celCli.ToString());
            query = query.Replace("numEnd", cli.numEndCli.ToString());
            query = query.Replace("compEnd", cli.compEndCli);
            query = query.Replace("senha", cli.Senha);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }

        public List<Cliente> GetClientes()
        {
            MySqlDataReader reader;

            command.CommandText = "SELECT * FROM Cliente";
            reader = command.ExecuteReader();
            List<Cliente> cli = new List<Cliente>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cli.Add(new Cliente(int.Parse(reader["idCliente"].ToString()),
                        reader["NomCli"].ToString(),
                        reader["emailCli"].ToString(),
                        int.Parse(reader["celCli"].ToString()),
                        int.Parse(reader["numEndCli"].ToString()),
                        reader["compEndCli"].ToString(),
                        reader["Senha"].ToString()));

                }
            }
            return cli;
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