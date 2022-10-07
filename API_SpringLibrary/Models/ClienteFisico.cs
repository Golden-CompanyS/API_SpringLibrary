using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class ClienteFisico
    {
        public ClienteFisico() { }
        public ClienteFisico(Cliente nomCli, Cliente emailCli, Cliente celCli, int CPFCli, string fantaCliJ, string represCliJ)
        {
            this.nomCli = nomCli;
            this.emailCli = emailCli;
            this.celCli = celCli;
            this.CPFCli = CPFCli;
            this.celCli = celCli;
           
        }

        public ClienteFisico(Cliente idCliente, int CPFCli, DateTime dtNascCliF, Cliente nomCli, Cliente emailCli, Cliente celCli)
        {
            this.IdCli = idCliente;
            this.nomCli = nomCli;
            this.emailCli = emailCli;
            this.celCli = celCli;
            this.CPFCli = CPFCli;
            this.dtNascCliF = dtNascCliF;
        }

        public Cliente IdCli { get; set; }
        public DateTime dtNascCliF { get; set; }
        public int CPFCli { get; set; }
        public Cliente nomCli { get; set; }
        public Cliente emailCli { get; set; }
        public Cliente celCli { get; set; }
        public Cliente numEndCli { get; set; }
        public Cliente compEndCli { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = DatabaseHelper.CreateComm();

        public ClienteFisico checkCliFByID(int id)
        {
            connection.Open();
            command.CommandText = "select * from, ClienteFisico where IdCli=@idCli;";
            command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = IdCli;
            command.Connection = connection;

            var readCliF = command.ExecuteReader();
            var tempCliF = new ClienteFisico();

            if (readCliF.Read())
            {
                tempCliF.IdCli = new Cliente().GetCliByID(id);
                tempCliF.CPFCli = int.Parse(readCliF["CPFCli"].ToString());
                tempCliF.dtNascCliF = DateTime.Parse(readCliF["fantaCliJ"].ToString());
            }

            readCliF.Close();
            connection.Close();

            return tempCliF;
        }

        //CONTINUAR DAQUI
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