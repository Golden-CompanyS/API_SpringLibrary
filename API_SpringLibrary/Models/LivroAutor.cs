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
        public LivroAutor(string isbnLiv, int idAut, string nomLiv, string nomAut)
        {
            ISBNLiv = isbnLiv;
            IdAut = idAut;
            NomLiv = nomLiv;
            NomAut = nomAut;
        }

        public LivroAutor()
        {
        }

        public string ISBNLiv { get; set; }

        public int IdAut { get; set; }

        public string NomLiv { get; set; }

        public string NomAut { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public LivroAutor AssignLivAut(MySqlDataReader reader)
        {
            LivroAutor tempLivAut = new LivroAutor();
            if (reader.Read())
            {
                tempLivAut.IdAut = int.Parse(reader["idAut"].ToString());
                tempLivAut.ISBNLiv = reader["ISBNLiv"].ToString();
                tempLivAut.NomLiv = reader["nomLiv"].ToString();
                tempLivAut.NomAut = reader["nomAut"].ToString();
            }
            return tempLivAut;
        }

        public List<LivroAutor> AssignLivAuts(MySqlDataReader reader)
        {
            List<LivroAutor> editList = new List<LivroAutor>();
            while (reader.Read())
            {
                LivroAutor tempLivAut = new LivroAutor();
                tempLivAut.IdAut = int.Parse(reader["idAut"].ToString());
                tempLivAut.ISBNLiv = reader["ISBNLiv"].ToString();
                tempLivAut.NomLiv = reader["nomLiv"].ToString();
                tempLivAut.NomAut = reader["nomAut"].ToString();
                editList.Add(tempLivAut);
            }
            return editList;
        }

        public List<LivroAutor> GetAllLivAut()
        {
            command.CommandText = ("select lv.ISBNLiv, titLiv, nomAut from tbAutor as aut inner join tbLivroAutor as lva on aut.idAut = lva.idAut inner join tbLivro as lv on lva.ISBNLiv = lv.ISBNLiv;");
            var reader = command.ExecuteReader();
            List<LivroAutor> livroautores = this.AssignLivAuts(reader);
            return livroautores;
        }

    }
}