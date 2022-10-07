using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class Endereco
    {
        public Endereco() { }
        public Endereco(int CEP)
        {
            this.CEP = CEP;
        }

        public Endereco(int IdEndereco,int CEP)
        {
            this.IdEndereco = IdEndereco;
            this.CEP = CEP;
        }

        public int IdEndereco { get; set; }
        public int CEP { get; set; }

        MySqlCommand command = DatabaseHelper.CreateComm();

        public Endereco GetCEPByID(int id)
        {
            Endereco tempCli = new Endereco();
            string query = "select * from Endereco where IdEndereco = id limit 1";
            query = query.Replace("id", id.ToString());
            command.CommandText = query;
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                tempCli.IdEndereco = id;
                tempCli.CEP = int.Parse(reader["CEP"].ToString());
            }
            return tempCli;
        }
        public void InsertNewEndereco(Endereco end)
        {
            string query = "insert into Endereco (CEP) values ('CEP')";
            query = query.Replace("CEP", end.CEP.ToString());
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
        public bool ValidEnde(Endereco end)
        {
            string query = "select * from Endereco where (CEP = 'CEP')";
            query = query.Replace("CEP", end.CEP.ToString());
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
