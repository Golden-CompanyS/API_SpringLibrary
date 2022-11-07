using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Models
{
    public class Editora
    {
        public Editora() { }
        public Editora (int idEdit, string nomEdit, string celEdit, string emailEdit)
        {
            IdEdit = idEdit;
            NomEdit = nomEdit;
            CelEdit = celEdit;
            EmailEdit = emailEdit;
        }

        public int IdEdit { get; set; }

        public string NomEdit { get; set; }

        public string CelEdit { get; set; }

        public string EmailEdit { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public Editora AssignEdit(MySqlDataReader reader)
        {
            Editora tempEdit = new Editora();
            if (reader.Read())
            {
                tempEdit.IdEdit = int.Parse(reader["IdEdit"].ToString());
                tempEdit.NomEdit = reader["NomEdit"].ToString();
                tempEdit.CelEdit = reader["CelEdit"].ToString();
                tempEdit.EmailEdit = reader["EmailEdit"].ToString();
            }
            return tempEdit;
        }

       
    }
}