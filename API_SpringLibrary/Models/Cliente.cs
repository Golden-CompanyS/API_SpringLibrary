 using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Models
{
    public class Cliente
    {

    public Cliente(int idCli, string nomCli, boolean tipoCli, string celCli, string emailCli, string senhaCli,
        string cepCli, int numEndCli, string compEndCli)
        {
            IdCli = idCli;
            NomCli = nomCli;
            TipoCli = tipoCli;
            CelCli = celCli;
            EmailCli = emailCli;
            SenhaCli = senhaCli;
            CEPCli = cepCli;
            NumEndCli = numEndCli;
            CompEndCli = compEndCli;
        }
        public Cliente(string nomCli, boolean tipoCli, string celCli, string emailCli, string senhaCli,
    string cepCli, int numEndCli, string compEndCli)
        {
            NomCli = nomCli;
            TipoCli = tipoCli;
            CelCli = celCli;
            EmailCli = emailCli;
            SenhaCli = senhaCli;
            CEPCli = cepCli;
            NumEndCli = numEndCli;
            CompEndCli = compEndCli;
        }
        public Cliente()
        {
        }

        public int IdCli {  get; set; }
        public string NomCli { get; set; }
        public boolean TipoCli { get; set; }
        public string CelCli { get; set; }  
        public string EmailCli { get; set; }
        public string SenhaCli { get; set; }
        public string CEPCli { get; set; }
        public int NumEndCli { get; set; }
        public string CompEndCli { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public Cliente AssignCli(MySqlDataReader reader)
        {
            Cliente tempCli = new Cliente();
            if (reader.Read())
            {
                tempCli.IdCli = int.Parse(reader["idCli"].ToString());
                tempCli.NomCli = reader["nomCli"].ToString();
                tempCli.TipoCli = boolean.Parse(reader["tipoCli"].ToString());
                tempCli.CelCli = reader["celCli"].ToString();
                tempCli.EmailCli = reader["emailCli"].ToString();
                tempCli.SenhaCli = reader["senhaCli"].ToString();
                tempCli.CEPCli = reader["CEPCli"].ToString();
                tempCli.NumEndCli = reader["numEndCli"].ToString();
                tempCli.CompEndCli = reader["compEndCli"].ToString();
            }
            return tempCli;
        }

        public List<Cliente> AssignClis(MySqlDataReader reader)
        {
            List<Cliente> editList = new List<Cliente>();
            while (reader.Read())
            {
                Cliente tempCli = new Cliente();
                tempCli.IdCli = int.Parse(reader["idCli"].ToString());
                tempCli.NomCli = reader["nomCli"].ToString();
                tempCli.TipoCli = boolean.Parse(reader["tipoCli"].ToString());
                tempCli.CelCli = reader["celCli"].ToString();
                tempCli.EmailCli = reader["emailCli"].ToString();
                tempCli.SenhaCli = reader["senhaCli"].ToString();
                tempCli.CEPCli = reader["CEPCli"].ToString();
                tempCli.NumEndCli = reader["numEndCli"].ToString();
                tempCli.CompEndCli = reader["compEndCli"].ToString();
                editList.Add(tempCli);
            }
            return editList;
        }

        //Metódos
        public List<Cliente> GetAllClientes()
        {
            command.CommandText = ("select * from vwcheckAllCli;");
            var reader = command.ExecuteReader();
            List<Cliente> clientes = this.AssignClis(reader);
            return clientes;
        }
        public Cliente GetCliByName(string nome)
        {
            command.CommandText = ("call spcheckCliByName(@nome);");
            command.Parameters.Add("@nome", MySqlDbType.Varchar).Value = nome;
            var reader = command.ExecuteReader();
            Cliente res = this.AssignCli(reader);
            return res;
        }
        public Cliente GetCliByEmail(string email)
        {
            command.CommandText = ("call spCheckCliByEmail(@email);");
            command.Parameters.Add("@email", MySqlDbType.Varchar).Value = email;
            var reader = command.ExecuteReader();
            Cliente res = this.AssignCli(reader);
            return res;
        }

        //Neste caso, a tabela cliente é um intermédio entre o físico e jurídico, então não terá metódos de cadastro aqui
        //Também seguindo conforme o banco de dados. 
    }
}