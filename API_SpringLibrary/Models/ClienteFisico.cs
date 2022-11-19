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
        public List<ClienteFisico> GetAllClientesF()
        {
            command.CommandText = ("select * from vwcheckCliFis;");
            var reader = command.ExecuteReader();
            List<ClienteFisico> clientes = this.AssignClisF(reader);
            return clientes;
        }
    }
}