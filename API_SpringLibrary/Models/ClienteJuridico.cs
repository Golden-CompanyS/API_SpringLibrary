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
    }
}
