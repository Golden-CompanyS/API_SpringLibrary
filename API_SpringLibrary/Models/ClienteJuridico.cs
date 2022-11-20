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


    }
}
