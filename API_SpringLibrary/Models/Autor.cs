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
        public Autor(string nomAut)
        {
            NomAut = nomAut;
        }

        public Autor(int idAut, string nomAut)
        {
            IdAut = idAut;
            NomAut = nomAut;
        }

        public Autor()
        {
        }

        public int IdAut { get; set; }

        public string NomAut { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public Autor AssignAut(MySqlDataReader reader)
        {
            Autor tempAut = new Autor();
            if (reader.Read())
            {
                tempAut.IdAut = int.Parse(reader["idAut"].ToString());
                tempAut.NomAut = reader["nomAut"].ToString();
            }
            return tempAut;
        }

        public List<Autor> AssignAuts(MySqlDataReader reader)
        {
            List<Autor> editList = new List<Autor>();
            while (reader.Read())
            {
                Autor tempAut = new Autor();
                tempAut.IdAut = int.Parse(reader["idAut"].ToString());
                tempAut.NomAut = reader["nomAut"].ToString();
                editList.Add(tempAut);
            }
            return editList;
        }

        //Metódos

        public List<Autor> GetAllAutores()
        {
            command.CommandText = ("call spcheckAllAut();");
            var reader = command.ExecuteReader();
            List<Autor> autores = this.AssignAuts(reader);
            return autores;
        }

        public Autor GetAutById(int id)
        {
            command.CommandText = ("call spcheckAutById(@id);");
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            var reader = command.ExecuteReader();
            Autor res = this.AssignAut(reader);
            return res;
        }

        public IEnumerable<Autor> GetAutByParameter(string column, string parVal)
        {
            string query = "select * from tbAutor where placeholder like 'parameter%'";
            query = query.Replace("parameter", parVal);
            query = query.Replace("placeholder", column);
            command.CommandText = query;
            var reader = command.ExecuteReader();
            IEnumerable<Autor> res = this.AssignAuts(reader);
            return res;
        }

        public void PostNewAutor(Autor aut)
        {
            string query =
                "call spcadAut('nome');";
            query = query.Replace("nome", aut.NomAut);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }

        public void AlterAutor(int id, Autor aut)
        {
            string query =
                "call spaltAut(id, 'nome');";
            query = query.Replace("id", id.ToString());
            query = query.Replace("nome", aut.NomAut);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }

    }
    }