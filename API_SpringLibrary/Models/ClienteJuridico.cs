using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class ClienteJuridico : Cliente  
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
                tempCliJ.IdCli = int.Parse(reader["idCli"].ToString());
                tempCliJ.NomCli = reader["nomCli"].ToString();
                tempCliJ.TipoCli = bool.Parse(reader["tipoCli"].ToString());
                tempCliJ.CelCli = reader["celCli"].ToString();
                tempCliJ.EmailCli = reader["emailCli"].ToString();
                tempCliJ.SenhaCli = reader["senhaCli"].ToString();
                tempCliJ.CEPCli = reader["CEPCli"].ToString();
                tempCliJ.NumEndCli = int.Parse(reader["numEndCli"].ToString());
                tempCliJ.CompEndCli = reader["compEndCli"].ToString();
                tempCliJ.CNPJCli = reader["CNPJCli"].ToString();
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
            command.CommandText = ("select tbCliente.idCli, nomCli, tipoCli, celCli, emailCli, senhaCli, CEPCli, numEndCli, compEndCli, CNPJCli, fantaCliJ, represCliJ from tbCliente inner join tbCliJur on tbCliente.idCli = tbCliJur.idCli;");
            var reader = command.ExecuteReader();
            List<ClienteJuridico> clientes = this.AssignClisJ(reader);
            return clientes;
        }

        //Cadastrar novo cliente jurídico
        public void PostNewClienteJ(ClienteJuridico cliJ)
        {
            string query =
                "call spcadCliJur('nome', 'celular', 'email', 'senha', 'cep', 'numEnd', 'complemento', 'cnpj', 'fantasia', 'representante');";
            query = query.Replace("nome", cliJ.NomCli);
            query = query.Replace("celular", cliJ.CelCli);
            query = query.Replace("senha", cliJ.SenhaCli);
            query = query.Replace("cep", cliJ.CEPCli);
            query = query.Replace("numEnd", cliJ.NumEndCli.ToString());
            query = query.Replace("complemento", cliJ.CompEndCli);
            query = query.Replace("cnpj", cliJ.CNPJCli);
            query = query.Replace("fantasia", cliJ.FantaCliJ);
            query = query.Replace("representante", cliJ.RepresCliJ);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }

        //Atualizar cliente juríridico
        public void AlterCliJ(int id, ClienteJuridico cliJ)
        {
            string query =
                "call spautCliJur(id, 'celular', 'email', 'senha', 'cep', 'numEnd', 'complemento', 'cnpj', 'fantasia', 'representante');";
            query = query.Replace("id", id.ToString());
            query = query.Replace("nome", cliJ.NomCli);
            query = query.Replace("celular", cliJ.CelCli);
            query = query.Replace("senha", cliJ.SenhaCli);
            query = query.Replace("cep", cliJ.CEPCli);
            query = query.Replace("numEnd", cliJ.NumEndCli.ToString());
            query = query.Replace("complemento", cliJ.CompEndCli);
            query = query.Replace("cnpj", cliJ.CNPJCli);
            query = query.Replace("fantasia", cliJ.FantaCliJ);
            query = query.Replace("representante", cliJ.RepresCliJ);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
    }
}
