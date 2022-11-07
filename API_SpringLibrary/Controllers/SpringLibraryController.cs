using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using API_SpringLibrary.Models;
using MySql.Data.MySqlClient;


namespace API_SpringLibrary.Controllers
{
    public class SpringLibraryController : ApiController
    {
        // Para encontrar db
        DatabaseHelper db = new DatabaseHelper();

        // Models 

        Autor aut = new Autor();
        Cliente cli = new Cliente();
        ClienteFisico cliFis = new ClienteFisico();
        ClienteJuridico cliJur = new ClienteJuridico();
        Editora edit = new Editora();
        //Tirou a tabela endereço, consertar na API 
        Genero gen = new Genero();
        Livro liv = new Livro();
        //Tirou produto também, então consertar a API
    }
}