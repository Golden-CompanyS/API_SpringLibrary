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

        public Livro TitLiv { get; set; }

        public Autor NomAut { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public LivroAutor AssignLivAut(MySqlDataReader reader)
        {
            LivroAutor tempLivAut = new LivroAutor();
            Autor tempAut = new Autor();
            Livro tempLiv = new Livro();
            if (reader.Read())
            {
                tempLivAut.IdAut = int.Parse(reader["idAut"].ToString());
                tempLivAut.ISBNLiv = reader["ISBNLiv"].ToString();
                tempLiv.TitLiv = reader["titLiv"].ToString();
                tempAut.NomAut = reader["nomAut"].ToString();
            }
            return tempLivAut;
        }

        public List<LivroAutor> AssignLivAuts(MySqlDataReader reader)
        {
            List<LivroAutor> editList = new List<LivroAutor>();
            while (reader.Read())
            {
                LivroAutor tempLivAut = new LivroAutor();
                Autor tempAut = new Autor();
                Livro tempLiv = new Livro();
                tempLivAut.IdAut = int.Parse(reader["idAut"].ToString());
                tempLivAut.ISBNLiv = reader["ISBNLiv"].ToString();
                tempLiv.TitLiv = reader["titLiv"].ToString();
                tempAut.NomAut = reader["nomAut"].ToString();
                editList.Add(tempLivAut);
            }
            return editList;
        }


    }
}