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
        public ClienteJuridico() { }
        public ClienteJuridico(Cliente nomCli,Cliente emailCli, Cliente celCli, int CNPJCli, string fantaCliJ, string represCliJ)
        {
            this.nomCli = nomCli;
            this.emailCli = emailCli;
            this.celCli = celCli;
            this.CNPJCli = CNPJCli;
            this.fantaCliJ = fantaCliJ;
            this.represCliJ = represCliJ;
        }

        public ClienteJuridico(Cliente idCliente, int CNPJCli, string fantaCliJ, string represCliJ)
        {
            this.IdCli = idCliente;
            this.CNPJCli = CNPJCli;
            this.fantaCliJ = fantaCliJ;
            this.represCliJ = represCliJ;
        }

        public Cliente IdCli { get; set; }
        public string fantaCliJ { get; set; }
        public string represCliJ { get; set; }
        public int CNPJCli {get; set; }
        public Cliente nomCli { get; set; }
        public Cliente emailCli { get; set; }
        public Cliente celCli { get; set; }
        public Cliente numEndCli { get; set; }
        public Cliente compEndCli { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = DatabaseHelper.CreateComm();

        public ClienteJuridico checkCliJByID(int id)
        {
            connection.Open();
            command.CommandText = "select * from, ClienteJuridico where IdCli='@idCli';"; // SELECIONAR tbLivro PELO ID
            command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = IdCli;
            command.Connection = connection;

            var readCliJ = command.ExecuteReader();
            var tempCliJ = new ClienteJuridico();

            if (readCliJ.Read())
            {
                tempCliJ.IdCli = new Cliente().GetCliByID(id);
                tempCliJ.CNPJCli = int.Parse(readCliJ["CNPJCli"].ToString());
                tempCliJ.fantaCliJ = readCliJ["fantaCliJ"].ToString();
                tempCliJ.represCliJ = readCliJ["represCliJ"].ToString();
            }

            readCliJ.Close();
            connection.Close();

            return tempCliJ;
        }

        public void cadNewCliJuridico(ClienteJuridico cliJ, Cliente cli, Endereco end)
        {
            connection.Open();
            command.CommandText = "CALL spInsertCliJuridico(@nomCli, @celCli, @emailCli, @CEP, @numEndCli, @compEndCli, @CNPJ, @fantaCliJ, @represCliJ);"; // INSERIR tbCliJuridico
            command.Parameters.Add("@nomCli", MySqlDbType.Int64).Value = cli.nomCli;
            command.Parameters.Add("@celCli", MySqlDbType.VarChar).Value = cli.celCli;
            command.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = cli.emailCli;
            command.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = end.CEP;
            command.Parameters.Add("@numEndCli", MySqlDbType.Int64).Value = cli.numEndCli;
            command.Parameters.Add("@compEndCli", MySqlDbType.VarChar).Value = cli.compEndCli;
            command.Parameters.Add("@CNPJ", MySqlDbType.Int64).Value = cliJ.CNPJCli;
            command.Parameters.Add("@fantaCliJ", MySqlDbType.VarChar).Value = cliJ.fantaCliJ;
            command.Parameters.Add("@represCliJ", MySqlDbType.VarChar).Value = cliJ.represCliJ;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
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
