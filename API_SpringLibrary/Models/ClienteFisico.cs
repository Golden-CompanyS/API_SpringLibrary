using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Models
{
    public class ClienteFisico
    {
        public ClienteFisico(string cpfCli, int idCli, DateTime dtNascCliF)
        {
            CPFCliF = cpfCli;
            IdCli = idCli;
            DtNascCliF = dtNascCliF;
        }

        public ClienteFisico(string cpfCli, DateTime dtNascCliF)
        {
            CPFCliF = cpfCli;
            DtNascCliF = dtNascCliF;
        }

        public ClienteFisico()
        {
        }

       public string CPFCliF { get; set; }

       public int IdCli { get; set; }

        public DateTime DtNascCliF { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public ClienteFisico AssignCliF(MySqlDataReader reader)
        {
            ClienteFisico tempCliF = new ClienteFisico();
            if (reader.Read())
            {
                tempCliF.CPFCliF = reader["CPFCliF"].ToString();
                tempCliF.IdCli = int.Parse(reader["idCli"].ToString());
                tempCliF.DtNascCliF = DateTime.Parse(reader["dtNascCliFF"].ToString());
            }
            return tempCliF;
        }

        public List<ClienteFisico> AssignClisF(MySqlDataReader reader)
        {
            List<ClienteFisico> editList = new List<ClienteFisico>();
            while (reader.Read())
            {
                ClienteFisico tempCliF = new ClienteFisico();
                tempCliF.CPFCliF = reader["CPFCliF"].ToString();
                tempCliF.IdCli = int.Parse(reader["idCli"].ToString());
                tempCliF.DtNascCliF = DateTime.Parse(reader["dtNascCliFF"].ToString());
                editList.Add(tempCliF);
            }
            return editList;
        }

        //Metódos 

        //Visualizar todos os clientes cadastrados
        public List<ClienteFisico> GetAllClientesF()
        {
            command.CommandText = ("select * from vwcheckCliFis;");
            var reader = command.ExecuteReader();
            List<ClienteFisico> clientes = this.AssignClisF(reader);
            return clientes;
        }





        //Cadastrar novo cliente físico
        public void PostNewClienteF(ClienteFisico cliF)
        {
            Cliente cli = new Cliente();
            string query =
                "call spcadCliFis('nome', 'celular', 'email', 'senha', 'cep', 'numEnd', 'complemento', 'cpf', 'dtNasc');";
            query = query.Replace("nome", cli.NomCli);
            query = query.Replace("celular", cli.CelCli);
            query = query.Replace("senha", cli.SenhaCli);
            query = query.Replace("cep", cli.CEPCli);
            query = query.Replace("numEnd", cli.NumEndCli.ToString());
            query = query.Replace("complemento", cli.CompEndCli);
            query = query.Replace("cpf", cliF.CPFCliF);
            query = query.Replace("dtNasc", cliF.DtNascCliF.ToString());
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }

        //Atualizar cliente físico
        public void AlterCliF(int id, ClienteFisico cliF)
        {
            Cliente cli = new Cliente();
            string query =
                "call spaltCliFis(id, 'celular', 'email', 'senha', 'cep', 'numEnd', 'complemento', 'cpf', 'dtNasc');";
            query = query.Replace("id", id.ToString());
            query = query.Replace("nome", cli.NomCli);
            query = query.Replace("celular", cli.CelCli);
            query = query.Replace("senha", cli.SenhaCli);
            query = query.Replace("cep", cli.CEPCli);
            query = query.Replace("numEnd", cli.NumEndCli.ToString());
            query = query.Replace("complemento", cli.CompEndCli);
            query = query.Replace("cpf", cliF.CPFCliF);
            query = query.Replace("dtNasc", cliF.DtNascCliF.ToString());
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
    }
}