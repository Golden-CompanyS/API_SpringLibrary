using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class Cargo
    {
        public Cargo() { }
        public Cargo(string nomCargo)
        {
            this.nomCargo = nomCargo;
        }

        public Cargo(int idCargo, string nomCargo)
        {
            this.idCargo = idCargo;
            this.nomCargo = nomCargo;
        }

        public int idCargo { get; set; }
        public string nomCargo { get; set; }

        MySqlCommand command = DatabaseHelper.CreateComm();

        public Cargo GetCargoByID(int id)
        {
            Cargo tempCli = new Cargo();
            string query = "select * from Cargo where idCargo = id limit 1";
            query = query.Replace("id", id.ToString());
            command.CommandText = query;
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                tempCli.idCargo = id;
                tempCli.nomCargo = reader["nomCargo"].ToString();
            }
            return tempCli;
        }
        public void InsertNewCargo(Cargo cargo)
        {
            string query = "call spInsertCargo('cargo')";
            query = query.Replace("cargo", cargo.nomCargo);
            command.CommandText = query;
            var executor = command.ExecuteNonQuery();
        }
        public bool ValidadeCargo(Cargo cargo)
        {
            string query = "select * from Cargo where (nomCargo='cargo')";
            query = query.Replace("cargo", cargo.nomCargo);
            command.CommandText = query;
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}