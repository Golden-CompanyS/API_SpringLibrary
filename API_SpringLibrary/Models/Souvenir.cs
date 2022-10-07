using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class Souvenir
    {
        public int IdSouv { get; set; }
        public string nomeSouv { get; set; }
        public string dimenSouv { get; set; }
        public Produto IdProd { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadSouvIfNotExists(Souvenir souvenir)
        {
            
        }
    }
}