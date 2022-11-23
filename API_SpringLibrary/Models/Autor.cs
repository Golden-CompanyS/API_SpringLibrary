using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Models
{
    public class Autor
    {
        public Autor(int idAut, string nomAut)
        {
            IdAut = idAut;
            NomAut = nomAut;
        }

        public Autor(string nomAut)
        {
            NomAut = nomAut;
        }

        public int IdAut { get; set; }

        public string NomAut { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        
        }
    }