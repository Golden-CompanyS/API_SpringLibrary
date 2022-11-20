using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class ClienteJuridico
    {
        public ClienteJuridico(string cnpjCli, int idCli, string fantaCliJ, string represCliJ)
        {
            CNPJCli = cnpjCli;
            IdCli = idCli;
            FantaCliJ = fantaCliJ;
            RepresCliJ = represCliJ;
        }

        public ClienteJuridico(string cnpjCli, string fantaCliJ, string represCliJ)
        {
            CNPJCli = cnpjCli;
            FantaCliJ = fantaCliJ;
            RepresCliJ = represCliJ;
        }

        public ClienteJuridico()
        {
        }

        public string CNPJCli { get; set; }

        public int IdCli { get; set; }

        public string FantaCliJ { get; set; }

        public string RepresCliJ { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public ClienteJuridico AssignCliJ(MySqlDataReader reader)
        {
            ClienteJuridico tempCliJ = new ClienteJuridico();
            if (reader.Read())
            {
                tempCliJ.CNPJCli = reader["CNPJCli"].ToString();
                tempCliJ.IdCli = int.Parse(reader["idCli"].ToString());
                tempCliJ.FantaCliJ = reader["fantaCliJ"].ToString();
                tempCliJ.RepresCliJ = reader["represCliJ"].ToString();
            }
            return tempCliJ;
        }

        public List<ClienteJuridico> AssignClisJ(MySqlDataReader reader)
        {
            List<ClienteJuridico> editList = new List<ClienteJuridico>();
            while (reader.Read())
            {
                ClienteJuridico tempCliJ = new ClienteJuridico();
                tempCliJ.CNPJCli = reader["CNPJCli"].ToString();
                tempCliJ.IdCli = int.Parse(reader["idCli"].ToString());
                tempCliJ.FantaCliJ = reader["fantaCliJ"].ToString();
                tempCliJ.RepresCliJ = reader["represCliJ"].ToString();
                editList.Add(tempCliJ);
            }
            return editList;
        }

        //Visualizar todos os clientes jurídicos
        public List<ClienteJuridico> GetAllClientesJ()
        {
            command.CommandText = ("select * from vwcheckCliJur;");
            var reader = command.ExecuteReader();
            List<ClienteJuridico> clientes = this.AssignClisJ(reader);
            return clientes;
        }

        //Cadastrar novo cliente jurídico
        public void PostNewClienteJ(ClienteJuridico cliJ)
        {
            Cliente cli = new Cliente();
            string query =
                "call spcadCliJur('nome', 'celular', 'email', 'senha', 'cep', 'numEnd', 'complemento', 'cnpj', 'fantasia', 'representante');";
            query = query.Replace("nome", cli.NomCli);
            query = query.Replace("celular", cli.CelCli);
            query = query.Replace("senha", cli.SenhaCli);
            query = query.Replace("cep", cli.CEPCli);
            query = query.Replace("numEnd", cli.NumEndCli.ToString());
            query = query.Replace("complemento", cli.CompEndCli);
            query = query.Replace("cnpj", cliJ.CNPJCli);
            query = query.Replace("fantasia", cliJ.FantaCliJ);
            query = query.Replace("representante", cliJ.RepresCliJ);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }

        //Atualizar cliente juríridico
        public void AlterCliJ(int id, ClienteJuridico cliJ)
        {
            Cliente cli = new Cliente();
            string query =
                "call spautCliJur(id, 'celular', 'email', 'senha', 'cep', 'numEnd', 'complemento', 'cnpj', 'fantasia', 'representante');";
            query = query.Replace("id", id.ToString());
            query = query.Replace("nome", cli.NomCli);
            query = query.Replace("celular", cli.CelCli);
            query = query.Replace("senha", cli.SenhaCli);
            query = query.Replace("cep", cli.CEPCli);
            query = query.Replace("numEnd", cli.NumEndCli.ToString());
            query = query.Replace("complemento", cli.CompEndCli);
            query = query.Replace("cnpj", cliJ.CNPJCli);
            query = query.Replace("fantasia", cliJ.FantaCliJ);
            query = query.Replace("representante", cliJ.RepresCliJ);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
    }
}
