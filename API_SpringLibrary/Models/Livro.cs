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
        public Livro(string isbnLiv, string titLiv, string titOriLiv, string sinopLiv, string imgLiv, string pratLiv, 
            int numPagLiv, int numEdicaoLiv, int anoLiv, float precoLiv, int qtdLiv, bool ativoLiv, int idEdit, 
            int idGen, int idFunc)
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
            IdFunc = idFunc;
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

        public int IdGen { get; set; }

        public int IdFunc { get; set; }

    }
}
