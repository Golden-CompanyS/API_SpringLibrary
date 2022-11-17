using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Models
{
    public class Cliente
    {
        //finalizar
        public Cliente()
        {

        }

        public int IdCli {  get; set; }
        public string NomCli { get; set; }
        public bool TipoCli { get; set; }
        public string CelCli { get; set; }  
        public string EmailCli { get; set; }
        public string SenhaCli { get; set; }
        public string CEPCli { get; set; }
        public int NumEndCli { get; set; }
        public string CompEndCli { get; set; }
    }
}