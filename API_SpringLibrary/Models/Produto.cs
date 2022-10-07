using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SpringLibrary.Models
{
    public class Produto
    {
        public int IdProd { get; set; } 
        public string NomeProd { get; set; }    
        public int QtdProd { get; set; }
        public float Preco { get; set; }    


    }
}