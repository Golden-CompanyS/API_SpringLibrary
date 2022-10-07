using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class Autor
    {
        public int idAut { get; set; }

        //[Required]
        //[MaxLength(30, ErrorMessage="Limite de 30 caracteres excedido.")]
        public string nomAut { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadAutIfNotExists(Autor autor)
        {
            connection.Open();
            command.CommandText = "CALL spcadAutIfNotExists(@nomAut);"; // INSERIR tbAutor
            command.Parameters.Add("@nomAut", MySqlDbType.String).Value = autor.nomAut;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void altAut(Autor autor)
        {
            connection.Open();
            command.CommandText = "CALL spaltAut(@idAut, @nomAut);"; // ALTERAR tbAutor
            command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = autor.idAut;
            command.Parameters.Add("@nomAut", MySqlDbType.String).Value = autor.nomAut;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Autor> checkAllAut()
        {
            connection.Open();
            command.CommandText = "CALL spcheckAllAut();"; // SELECIONAR TUDO DA tbAutor
            command.Connection = connection;

            var readAut = command.ExecuteReader();
            List<Autor> tempAutList = new List<Autor>();

            while (readAut.Read())
            {
                var tempAut = new Autor();

                tempAut.idAut = int.Parse(readAut["idAut"].ToString());
                tempAut.nomAut = readAut["nomAut"].ToString();

                tempAutList.Add(tempAut);
            }

            readAut.Close();
            connection.Close();

            return tempAutList;
        }

        public Autor checkAutById(int idAut)
        {
            connection.Open();
            command.CommandText = "CALL spcheckAutById(@idAut);"; // SELECIONAR tbAutor PELO ID
            command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = idAut;
            command.Connection = connection;

            var readAut = command.ExecuteReader();
            var tempAut = new Autor();

            if (readAut.Read())
            {
                tempAut.idAut = int.Parse(readAut["idAut"].ToString());
                tempAut.nomAut = readAut["nomAut"].ToString();
            }

            readAut.Close();
            connection.Close();

            return tempAut;
        }

        public List<Autor> checkAutListByLivId(int idLiv)
        {
            connection.Open();
            command.CommandText = "CALL spcheckAutListByLivId(@idLiv);"; // SELECIONAR TUDO DA tbAutor PELO ID DO LIVRO
            command.Parameters.Add("@idLiv", MySqlDbType.Int64).Value = idLiv;
            command.Connection = connection;

            var readAut = command.ExecuteReader();
            List<Autor> tempAutList = new List<Autor>();

            while (readAut.Read())
            {
                var tempAut = new Autor();

                tempAut.idAut = int.Parse(readAut["idAut"].ToString());
                tempAut.nomAut = readAut["nomAut"].ToString();

                tempAutList.Add(tempAut);
            }

            readAut.Close();
            connection.Close();

            return tempAutList;
        }
    }
}