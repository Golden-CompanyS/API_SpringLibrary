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
        public Editora (int idEdit, string nomEdit, string celEdit, string emailEdit)
        {
            IdEdit = idEdit;
            NomEdit = nomEdit;
            CelEdit = celEdit;
            EmailEdit = emailEdit;
        }

        public Editora()
        {
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
                tempEdit.IdEdit = int.Parse(reader["idEdit"].ToString());
                tempEdit.NomEdit = reader["nomEdit"].ToString();
                tempEdit.CelEdit = reader["celEdit"].ToString();
                tempEdit.EmailEdit = reader["emailEdit"].ToString();
            }
            return tempEdit;
        }

        public List<Editora> AssignEdits(MySqlDataReader reader)
        {
            List<Editora> editList = new List<Editora>();
            while (reader.Read())
            {
                Editora tempEdit = new Editora();
                tempEdit.IdEdit = int.Parse(reader["idEdit"].ToString());
                tempEdit.NomEdit = reader["nomEdit"].ToString();
                tempEdit.CelEdit = reader["celEdit"].ToString();
                tempEdit.EmailEdit = reader["emailEdit"].ToString();
                editList.Add(tempEdit);
            }
            return editList;
        }

        //comandos a partir daqui
        public List<Editora> GetAllEdits()
        {
            command.CommandText = ("call spcheckAllEdit();");
            var reader = command.ExecuteReader();
            List<Editora> edits = this.AssignEdits(reader);
            return edits;
        }
        public Editora GetEditById(int id)
        {
            command.CommandText = ("call spcheckEditById(@id);");
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            var reader = command.ExecuteReader();
            Editora res = this.AssignEdit(reader);
            return res;
        }
        public void PostNewEditora(Editora edit)
        {
            string query =
                "call spcadEdit('nome', 'celular', 'email');";
            query = query.Replace("nome", edit.NomEdit);
            query = query.Replace("celular", edit.CelEdit);
            query = query.Replace("email", edit.EmailEdit);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
        public void AlterEdit(int id, Editora edit)
        {
            string query =
                "call spaltEdit(id, 'nome', 'celular', 'email');";
            query = query.Replace("id", id.ToString());
            query = query.Replace("nome", edit.NomEdit);
            query = query.Replace("celular", edit.CelEdit);
            query = query.Replace("email", edit.EmailEdit);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
        public void DeleteEdit(int id)
        {
            string query = "delete from tbEditora where idEdit = id;";
            query = query.Replace("id", id.ToString());
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
    }
}