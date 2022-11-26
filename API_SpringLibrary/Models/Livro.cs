using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Models
{
    public class Livro
    {

        // Tirou funcionário pela API -> não vai usar no Mobile

        public Livro (string titLiv, string imgLiv, float precoLiv)
        {
            TitLiv = titLiv;
            ImgLiv = imgLiv;
            PrecoLiv = precoLiv;
        }

        public Livro(string isbnLiv, string titLiv, string titOriLiv, string sinopLiv, string imgLiv, string pratLiv, 
            int numPagLiv, int numEdicaoLiv, int anoLiv, float precoLiv, int qtdLiv, bool ativoLiv, int idEdit, 
            int idGen)
        {
            ISBNLiv = isbnLiv;
            TitLiv = titLiv;
            TitOriLiv = titOriLiv;
            SinopLiv = sinopLiv;
            ImgLiv = imgLiv;
            PratLiv = pratLiv;
            NumPagLiv = numPagLiv;
            NumEdicaoLiv = numEdicaoLiv;
            AnoLiv = anoLiv;
            PrecoLiv = precoLiv;
            QtdLiv = qtdLiv;
            AtivoLiv = ativoLiv;
            IdEdit = idEdit;
            IdGen = idGen;
        }

        public Livro()
        {
        }

        public string ISBNLiv { get; set; }

        public string TitLiv { get; set; }

        public string TitOriLiv { get; set; }

        public string SinopLiv { get; set; }

        public string ImgLiv { get; set; }

        public string PratLiv { get; set; }

        public int NumPagLiv { get; set; }

        public int NumEdicaoLiv { get; set; }

        public int AnoLiv { get; set; }

        public float PrecoLiv { get; set; }

        public int QtdLiv { get; set; }

        public bool AtivoLiv { get; set; }

        public int IdEdit { get; set; }

        public Editora EditLiv { get; set; }

        public int IdGen { get; set; }

        public Genero GenLiv { get; set; }


        MySqlCommand command = DatabaseHelper.CriaComando();

        // Agiliza o reader pra não ter que ficar repetindo com comando abaixo!
        public Livro AssignLiv(MySqlDataReader reader)
        {
            Livro tempLiv = new Livro();
            if (reader.Read())
            {
                tempLiv.ISBNLiv = reader["ISBNLiv"].ToString();
                tempLiv.TitLiv = reader["titLiv"].ToString();
                tempLiv.TitOriLiv = reader["titOriLiv"].ToString();
                tempLiv.SinopLiv = reader["sinopLiv"].ToString();
                tempLiv.ImgLiv = reader["imgLiv"].ToString();
                tempLiv.PratLiv = reader["pratLiv"].ToString();
                tempLiv.NumPagLiv = int.Parse(reader["numPagLiv"].ToString());
                tempLiv.NumEdicaoLiv = int.Parse(reader["numEdicaoLiv"].ToString());
                tempLiv.AnoLiv = int.Parse(reader["anoLiv"].ToString());
                tempLiv.PrecoLiv = float.Parse(reader["precoLiv"].ToString());
                tempLiv.QtdLiv = int.Parse(reader["qtdLiv"].ToString());
                tempLiv.AtivoLiv = bool.Parse(reader["ativoLiv"].ToString());
                tempLiv.IdEdit = int.Parse(reader["idEdit"].ToString());
                tempLiv.EditLiv = new Editora() { NomEdit = reader["nomEdit"].ToString() };
                tempLiv.IdGen = int.Parse(reader["idGen"].ToString());
                tempLiv.GenLiv = new Genero() { NomGen = reader["nomGen"].ToString() };
                
            }
            return tempLiv;
        }

        public List<Livro> AssignLivs(MySqlDataReader reader)
        {
            List<Livro> editList = new List<Livro>();
            while (reader.Read())
            {
                Livro tempLiv = new Livro();
                tempLiv.ISBNLiv = reader["ISBNLiv"].ToString();
                tempLiv.TitLiv = reader["titLiv"].ToString();
                tempLiv.TitOriLiv = reader["titOriLiv"].ToString();
                tempLiv.SinopLiv = reader["sinopLiv"].ToString();
                tempLiv.ImgLiv = reader["imgLiv"].ToString();
                tempLiv.PratLiv = reader["pratLiv"].ToString();
                tempLiv.NumPagLiv = int.Parse(reader["numPagLiv"].ToString());
                tempLiv.NumEdicaoLiv = int.Parse(reader["numEdicaoLiv"].ToString());
                tempLiv.AnoLiv = int.Parse(reader["anoLiv"].ToString());
                tempLiv.PrecoLiv = float.Parse(reader["precoLiv"].ToString());
                tempLiv.QtdLiv = int.Parse(reader["qtdLiv"].ToString());
                tempLiv.AtivoLiv = bool.Parse(reader["ativoLiv"].ToString());
                tempLiv.IdEdit = int.Parse(reader["idEdit"].ToString());
                tempLiv.EditLiv = new Editora() { NomEdit = reader["nomEdit"].ToString() };
                tempLiv.IdGen = int.Parse(reader["idGen"].ToString());
                tempLiv.GenLiv = new Genero() { NomGen = reader["nomGen"].ToString() };
                editList.Add(tempLiv);
            }
            return editList;
        }

        //Métodos

        public List<Livro> GetAllLivros()
        {
            command.CommandText = ("select ISBNLiv, titLiv, titOriLiv, sinopLiv, imgLiv, pratLiv, numPagLiv, numEdicaoLiv, anoLiv, precoLiv, qtdLiv, ativoLiv, nomGen, nomEdit from tbLivro as lv left join tbGenero as gen on lv.IdGen = gen.IdGen left join tbEditora as edit on lv.IdEdit = edit.IdEdit;");
            var reader = command.ExecuteReader();
            List<Livro> edits = this.AssignLivs(reader);
            return edits;
        }

    }
}
