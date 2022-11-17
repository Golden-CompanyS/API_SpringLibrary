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

    public Cliente(int idCli, string nomCli, boolean tipoCli, string celCli, string emailCli, string senhaCli,
        string cepCli, int numEndCli, string compEndCli)
        {
            IdCli = idCli;
            NomCli = nomCli;
            TipoCli = tipoCli;
            CelCli = celCli;
            EmailCli = emailCli;
            SenhaCli = senhaCli;
            CEPCli = cepCli;
            NumEndCli = numEndCli;
            CompEndCli = compEndCli;
        }
        public Cliente(string nomCli, boolean tipoCli, string celCli, string emailCli, string senhaCli,
    string cepCli, int numEndCli, string compEndCli)
        {
            NomCli = nomCli;
            TipoCli = tipoCli;
            CelCli = celCli;
            EmailCli = emailCli;
            SenhaCli = senhaCli;
            CEPCli = cepCli;
            NumEndCli = numEndCli;
            CompEndCli = compEndCli;
        }
        public Cliente()
        {
        }

        public int IdCli {  get; set; }
        public string NomCli { get; set; }
        public boolean TipoCli { get; set; }
        public string CelCli { get; set; }  
        public string EmailCli { get; set; }
        public string SenhaCli { get; set; }
        public string CEPCli { get; set; }
        public int NumEndCli { get; set; }
        public string CompEndCli { get; set; }
    }
}