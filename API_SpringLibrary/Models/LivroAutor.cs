using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Models
{
    public class LivroAutor
    {
        public LivroAutor(string isbnLiv, int idAut)
        {
            ISBNLiv = isbnLiv;
            IdAut = idAut;
        }

        public LivroAutor()
        {
        }

        public string ISBNLiv { get; set; }

        public int IdAut { get; set; }

        public Livro NomLiv { get; set; }

        public Autor NomAut { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public LivroAutor AssignLivAut(MySqlDataReader reader)
        {
            LivroAutor tempLivAut = new LivroAutor();
            if (reader.Read())
            {
                tempLivAut.IdAut = int.Parse(reader["idAut"].ToString());
                tempLivAut.ISBNLiv = reader["ISBNLiv"].ToString();
                string nome = reader["nomLiv"].ToString();
                tempLivAut.NomLiv = nome;
                tempLivAut.NomAut = reader["nomAut"].ToString();
            }
            return tempLivAut;
        }


    }
}