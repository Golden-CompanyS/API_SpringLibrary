using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class Editora
    {
        public int idEdit { get; set; }

        public string nomEdit { get; set; }

        public int celEdit { get; set; }

        public string emailEdit { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadEditIfNotExists(Editora editora)
        {
            connection.Open();
            command.CommandText = "CALL spcadEditIfNotExists(@nomEdit, @celEdit, @emailEdit);"; // INSERIR tbEditora
            command.Parameters.Add("@nomEdit", MySqlDbType.String).Value = editora.nomEdit;
            command.Parameters.Add("@celEdit", MySqlDbType.Int64).Value = editora.idEdit;
            command.Parameters.Add("@emailEdit", MySqlDbType.String).Value = editora.emailEdit;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void altEdit(Editora editora)
        {
            connection.Open();
            command.CommandText = "CALL spaltEdit(@idEdit, @nomEdit, @celEdit, @emailEdit);"; // ALTERAR tbEditora
            command.Parameters.Add("@idEdit", MySqlDbType.Int64).Value = editora.idEdit;
            command.Parameters.Add("@nomEdit", MySqlDbType.String).Value = editora.nomEdit;
            command.Parameters.Add("@celEdit", MySqlDbType.Int64).Value = editora.idEdit;
            command.Parameters.Add("@emailEdit", MySqlDbType.String).Value = editora.emailEdit;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Editora> checkAllEdit()
        {
            connection.Open();
            command.CommandText = "CALL spcheckAllEdit();"; // SELECIONAR TUDO DA tbEditora
            command.Connection = connection;

            var readEdit = command.ExecuteReader();
            List<Editora> tempEditList = new List<Editora>();

            while (readEdit.Read())
            {
                var tempEdit = new Editora();

                tempEdit.idEdit = int.Parse(readEdit["idEdit"].ToString());
                tempEdit.nomEdit = readEdit["nomEdit"].ToString();
                tempEdit.celEdit = int.Parse(readEdit["celEdit"].ToString());
                tempEdit.emailEdit = readEdit["emailEdit"].ToString();

                tempEditList.Add(tempEdit);
            }

            readEdit.Close();
            connection.Close();

            return tempEditList;
        }

        public Editora checkEditById(int idEdit)
        {
            connection.Open();
            command.CommandText = "CALL spcheckEditById(@idEdit);"; // SELECIONAR tbEditora PELO ID
            command.Parameters.Add("@idEdit", MySqlDbType.Int64).Value = idEdit;
            command.Connection = connection;

            var readEdit = command.ExecuteReader();
            var tempEdit = new Editora();

            if (readEdit.Read())
            {
                tempEdit.idEdit = int.Parse(readEdit["idEdit"].ToString());
                tempEdit.nomEdit = readEdit["nomEdit"].ToString();
                tempEdit.celEdit = int.Parse(readEdit["celEdit"].ToString());
                tempEdit.emailEdit = readEdit["emailEdit"].ToString();
            }

            readEdit.Close();
            connection.Close();

            return tempEdit;
        }
    }
}