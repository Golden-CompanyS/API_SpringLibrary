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

       //Metódos 
    }
}