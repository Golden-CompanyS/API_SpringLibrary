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

        public Livro Titulo { get; set; }

        public Autor AutLiv { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public LivroAutor AssignLivAut(MySqlDataReader reader)
        {
            LivroAutor tempLivAut = new LivroAutor();
            if (reader.Read())
            {
                tempLivAut.IdAut = int.Parse(reader["idAut"].ToString());
                tempLivAut.ISBNLiv = reader["ISBNLiv"].ToString();
                tempLivAut.Titulo = new Livro() { TitLiv = reader["titLiv"].ToString() };
                tempLivAut.AutLiv = new Autor() { NomAut = reader["nomAut"].ToString() };
            }
            return tempLivAut;
        }

        public List<LivroAutor> AssignLivAuts(MySqlDataReader reader)
        {
            List<LivroAutor> editList = new List<LivroAutor>();
            while (reader.Read())
            {
                LivroAutor tempLivAut = new LivroAutor();
                //tempLivAut.IdAut = int.Parse(reader["idAut"].ToString());
                //tempLivAut.ISBNLiv = reader["ISBNLiv"].ToString();
                tempLivAut.Titulo = new Livro() { TitLiv = reader["titLiv"].ToString() };
                tempLivAut.AutLiv = new Autor() { NomAut = reader["nomAut"].ToString() };
                editList.Add(tempLivAut);
            }
            return editList;
        }

        //Métodos
        public List<LivroAutor> GetAllLivroAutores()
        {
            command.CommandText = ("select titLiv, nomAut from tbAutor as aut inner join tbLivroAutor as lva on aut.idAut = lva.idAut inner join tbLivro as lv on lva.ISBNLiv = lv.ISBNLiv;");
            var reader = command.ExecuteReader();
            List<LivroAutor> edits = this.AssignLivAuts(reader);
            return edits;
        }



    }
}