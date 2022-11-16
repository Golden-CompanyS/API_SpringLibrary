using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using API_SpringLibrary.Models;
using MySql.Data.MySqlClient;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace API_SpringLibrary.Controllers
{
    public class SpringLibraryController : ApiController
    {
        // Para encontrar db
        DatabaseHelper db = new DatabaseHelper();

        // Models 

       // Autor aut = new Autor();
       // Cliente cli = new Cliente();
        //ClienteFisico cliFis = new ClienteFisico();
       // ClienteJuridico cliJur = new ClienteJuridico();
        Editora edit = new Editora();
        //Tirou a tabela endereço, consertar na API 
       // Genero gen = new Genero();
        //Livro liv = new Livro();
        //Tirou produto também, então consertar a API

        // Editora
        [HttpGet]
        [ActionName("getAllEdits")]
        public IEnumerable<Editora> GetAllEditoras()
        {
            try
            {
                db.OpenConexao();
                var res = edit.GetAllEdits();
                return res;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            finally
            {
                db.FechaConexao();
            }
        }

        [HttpGet]
        [ActionName("getEditByID")]
        public Editora GetEditById(int id)
        {
            if (id == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    var res = edit.GetEditById(id);
                    return res;
                }
                catch
                {
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
                }
                finally
                {
                    db.FechaConexao();
                }
            }
        }

        [HttpPost]
        [ActionName("postNewArt")]
        public HttpResponseMessage PostNewEdit([FromBody] Editora edit)
        {
            var res = new HttpResponseMessage();
            if (edit == null)
            {
                res.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    edit.PostNewEditora(edit);
                    res.StatusCode = HttpStatusCode.Created;
                }
                catch
                {
                    res.StatusCode = HttpStatusCode.NotAcceptable;
                }
                finally
                {
                    db.FechaConexao();
                }
            }
            return res;
        }

        [HttpPut]
        [ActionName("alterEdit")]
        public HttpResponseMessage UpdateEdit(int id, [FromBody] Editora editora)
        {
            var res = new HttpResponseMessage();
            if (editora == null)
            {
                res.StatusCode = HttpStatusCode.NotModified;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    edit.AlterEdit(id, editora);
                }
                catch
                {
                    res.StatusCode = HttpStatusCode.NotAcceptable;
                }
                finally
                {
                    db.FechaConexao();
                    res.StatusCode = HttpStatusCode.Created;
                }
            }
            return res;
        }

        [HttpDelete]
        [ActionName("deleteEdit")]
        public HttpResponseMessage DeleteEdit(int id)
        {
            var res = new HttpResponseMessage();
            if (id == 0)
            {
                res.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    edit.DeleteEdit(id);
                    res.StatusCode = HttpStatusCode.OK;
                }
                catch
                {
                    res.StatusCode = HttpStatusCode.Forbidden;
                }
                finally
                {
                    db.FechaConexao();
                }
            }
            return res;
        }
    }
}