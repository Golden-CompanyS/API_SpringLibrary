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
        //Finalizar
        public ClienteFisico()
        {
        }

        public string CPFCli { get; set; }
        public int IdCli { get; set; }
        public date DtNascCli { get; set; }

       //Metódos 
    }
}