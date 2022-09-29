using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class Funcionario
    {
        public Funcionario() { }
        public Funcionario(string nomFunc, string imgFunc, int CPFFunc, int celFunc, string emailFunc, string Senha)
        {
            this.nomFunc = nomFunc;
            this.imgFunc = imgFunc;
            this.CPFFunc = CPFFunc;
            this.celFunc = celFunc;
            this.emailFunc = emailFunc;
            this.Senha = Senha;
        }

        public Funcionario(int idFuncionario, string nomFunc, string emailFunc, int celFunc, int CPFFunc, string imgFunc, string Senha)
        {
            this.IdFunc = idFuncionario;
            this.nomFunc = nomFunc;
            this.emailFunc = emailFunc;
            this.celFunc = celFunc;
            this.CPFFunc = CPFFunc;
            this.imgFunc = imgFunc;
            this.Senha = Senha;
        }

        public int IdFunc { get; set; }
        public string nomFunc { get; set; }
        public string emailFunc { get; set; }
        public int celFunc { get; set; }
        public int CPFFunc { get; set; }
        public Cargo cargo { get; set; }  
        public string imgFunc { get; set; }
        public string Senha { get; set; }

        MySqlCommand command = DatabaseHelper.CreateComm();

        public Funcionario GetFuncByID(int id)
        {
            Funcionario tempCli = new Funcionario();
            string query = "select * from Funcionario where IdFunc = id limit 1";
            query = query.Replace("id", id.ToString());
            command.CommandText = query;
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                tempCli.IdFunc = id;
                tempCli.nomFunc = reader["nomFunc"].ToString();
                tempCli.emailFunc = reader["emailFunc"].ToString();
                tempCli.CPFFunc = int.Parse(reader["CPFFunc"].ToString());
                tempCli.celFunc = int.Parse(reader["celFunc"].ToString());
            }
            return tempCli;
        }
        public void InsertNewFunc(Funcionario cli)
        {
            string query = "insert into Funcionario (nomFunc, emailCli, CPF, numEndCli, compEndCli) values ('nome', 'email', 'cel', 'numEnd', 'compEnd')";
            query = query.Replace("nome", cli.nomCli);
            query = query.Replace("email", cli.emailCli);
            query = query.Replace("cel", cli.celCli.ToString());
            query = query.Replace("numEnd", cli.numEndCli.ToString());
            query = query.Replace("compEnd", cli.compEndCli);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
        public bool ValidadeCli(Funcionario cli)
        {
            string query = "select * from Funcionario where (NomCli = 'nome')";
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
}