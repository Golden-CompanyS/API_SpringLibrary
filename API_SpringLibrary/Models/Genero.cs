using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class Genero
    {
        public int idGen { get; set; }
        public string nomGen { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadGenIfNotExists(Genero genero)
        {
            connection.Open();
            command.CommandText = "CALL spcadGenIfNotExists(@nomGen);"; // INSERIR tbGenero
            command.Parameters.Add("@nomGen", MySqlDbType.Int64).Value = genero.nomGen;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void altGen(Genero genero)
        {
            connection.Open();
            command.CommandText = "CALL spaltGen(@idGen, @nomGen);";  // ALTERAR tbGenero
            command.Parameters.Add("@idGen", MySqlDbType.Int64).Value = genero.idGen;
            command.Parameters.Add("@nomGen", MySqlDbType.Int64).Value = genero.nomGen;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Genero> checkAllGen()
        {
            connection.Open();
            command.CommandText = "CALL spcheckAllGen();"; // SELECIONAR TUDO DA tbGenero
            command.Connection = connection;

            var readGen = command.ExecuteReader();
            List<Genero> tempGenList = new List<Genero>();

            while (readGen.Read())
            {
                var tempGen = new Genero();

                tempGen.idGen = int.Parse(readGen["idEdit"].ToString());
                tempGen.nomGen = readGen["nomEdit"].ToString();

                tempGenList.Add(tempGen);
            }

            readGen.Close();
            connection.Close();

            return tempGenList;
        }

        public Genero checkGenById(int idGen)
        {
            connection.Open();
            command.CommandText = "CALL spcheckGenById(@idGen);"; // SELECIONAR tbGenero PELO ID
            command.Parameters.Add("@idGen", MySqlDbType.Int64).Value = idGen;
            command.Connection = connection;

            var readGen = command.ExecuteReader();
            var tempGen = new Genero();

            if (readGen.Read())
            {
                tempGen.idGen = int.Parse(readGen["idGen"].ToString());
                tempGen.nomGen = readGen["nomGen"].ToString();
            }

            readGen.Close();
            connection.Close();

            return tempGen;
        }
    }
}
