using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace API_SpringLibrary.Models
{
    public class Produto:   Livro
    {
        public int IdProd { get; set; } 
        public string NomeProd { get; set; }    
        public int QtdProd { get; set; }
        public float Preco { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        //ARRUMAR MÉTODO (AINDA N FINALIZADO)
        public void cadProdIfNotExists(Produto prod, Livro livro, Editora editora)
        {
            connection.Open();
            command.CommandText = "CALL spInsertProdutoLivro(@nomLivro, @QtdProd, @Preco, @NomOriLiv, " +
                                  "              @ISBNLiv, @publiLiv, @pagLiv,                " +
                                  "              @anoLiv, @Nomdit, @telEdit, @emailEdit, @NomGen, @NomAutor);                    "; // INSERIR tbLivro
            command.Parameters.Add("@nomLivro", MySqlDbType.VarChar).Value = livro.NomLivro;
            command.Parameters.Add("@sinopLiv", MySqlDbType.String).Value = livro.sinopLiv;
            command.Parameters.Add("@nomOriLiv", MySqlDbType.String).Value = livro.nomOriLiv;
            command.Parameters.Add("@pratLiv", MySqlDbType.Int64).Value = livro.pratLiv;
            command.Parameters.Add("@publLiv", MySqlDbType.Int64).Value = livro.publLiv;
            command.Parameters.Add("@pagLiv", MySqlDbType.Int64).Value = livro.pagLiv;
            command.Parameters.Add("@anoLiv", MySqlDbType.Int64).Value = livro.anoLiv;
            command.Parameters.Add("@FKeditLiv", MySqlDbType.Int64).Value = livro.editLiv.idEdit; // ID da Editora
            command.Parameters.Add("@FKgenLiv", MySqlDbType.Int64).Value = livro.genLiv.idGen; // ID do Genero
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();

            foreach (Autor autor in livro.autLiv)
            {
                cadAutLiv(autor, livro); // INSERIR tbLivro_Autor
            }
        }

    }
}