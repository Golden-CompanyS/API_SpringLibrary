using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Models
{
    public class Genero
    {
        public Genero(int idGen, string nomGen)
        {
            IdGen = idGen;
            NomGen = nomGen;
        }

        public Genero(string nomGen)
        {
            NomGen = nomGen;
        }

        public Genero()
        {
        }

        public int IdGen { get; set; }

        public string NomGen { get; set; }

        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public Genero AssignGen(MySqlDataReader reader)
        {
            Genero tempGen = new Genero();
            if (reader.Read())
            {
                tempGen.IdGen = int.Parse(reader["idGen"].ToString());
                tempGen.NomGen = reader["nomGen"].ToString();
            }
            return tempGen;
        }

        public List<Genero> AssignGens(MySqlDataReader reader)
        {
            List<Genero> editList = new List<Genero>();
            while (reader.Read())
            {
                Genero tempGen = new Genero();
                tempGen.IdGen = int.Parse(reader["idGen"].ToString());
                tempGen.NomGen = reader["nomGen"].ToString();
                editList.Add(tempGen);
            }
            return editList;
        }

        // Métodos:

        public List<Genero> GetAllGeneros()
        {
            command.CommandText = ("call spcheckAllGen();");
            var reader = command.ExecuteReader();
            List<Genero> generos = this.AssignGens(reader);
            return generos;
        }

        public Genero GetGenById(int id)
        {
            command.CommandText = ("call spcheckGenById(@id);");
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            var reader = command.ExecuteReader();
            Genero res = this.AssignGen(reader);
            return res;
        }

        public IEnumerable<Genero> GetGenByParameter(string column, string parVal)
        {
            string query = "select * from tbGenero where placeholder like 'parameter%'";
            query = query.Replace("parameter", parVal);
            query = query.Replace("placeholder", column);
            command.CommandText = query;
            var reader = command.ExecuteReader();
            IEnumerable<Genero> res = this.AssignGens(reader);
            return res;
        }

        public void PostNewGenero(Genero gen)
        {
            string query =
                "call spcadGen('nome');";
            query = query.Replace("nome", gen.NomGen);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }

        public void AlterGenero(int id, Genero gen)
        {
            string query =
                "call spaltGen(id, 'nome');";
            query = query.Replace("id", id.ToString());
            query = query.Replace("nome", gen.NomGen);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }

    }
}
