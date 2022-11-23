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
        /* anoLiv SMALLINT NOT NULL,
        precoLiv FLOAT(10,2) NOT NULL,
        qtdLiv INT DEFAULT(0),
        ativoLiv boolean,
        idEdit INT NOT NULL,
        FOREIGN KEY(idEdit)
            REFERENCES tbEditora(idEdit),
        idGen INT NOT NULL,
        FOREIGN KEY(idGen)
            REFERENCES tbGenero(idGen),
        idFunc INT NOT NULL,
        FOREIGN KEY(idFunc) 
         REFERENCES tbFuncionario(idFunc) */


        public string ISBNLiv { get; set; }

        public string TitLiv { get; set; }

        public string TitOriLiv { get; set; }

        public string SinopLiv { get; set; }

        public string ImgLiv { get; set; }

        public string PratLiv { get; set; }

        public int NumPagLiv { get; set; }

        public int NumEdicaoLiv { get; set; }
    }
}
