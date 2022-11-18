using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_SpringLibrary.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;

namespace API_SpringLibrary.Controllers
{
    public class SpringLibraryController : ApiController
    {
        // Para encontrar db
        DatabaseHelper db = new DatabaseHelper();

        // Models 
        Editora edit = new Editora();
        Cliente cli = new Cliente();    

        // Editora metódos 

        // Metódos Get:

        //Pegando todas as editoras já cadastradas
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

        //Pegando as editoras pelo ID
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

        //Pegando as editoras pelo nome
        [HttpGet]
        [ActionName("getEditsByName")]
        public IEnumerable<Editora> GetEditsByName(string name)
        {
            try
            {
                db.OpenConexao();
                var res = edit.GetEditsByParameter("NomEdit", name);
                db.FechaConexao();
                return res;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }

        //Metódos Post:

        //Cadastrando nova editora
        [HttpPost]
        [ActionName("postNewEdit")]
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

        //Metódos Put:

        //Alterando uma editora
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

        //Metódo delete:]

        //Deletando uma editora
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

        // Cliente metódos 

        //Metódos get:

        //Pegando todos os clientes já cadastrados
        [HttpGet]
        [ActionName("getAllClis")]
        public IEnumerable<Cliente> GetAllClientes()
        {
            try
            {
                db.OpenConexao();
                var res = cli.GetAllClientes();
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

        //Pegando clientes pelo nome
        [HttpGet]
        [ActionName("GetCliByName")]
        public Cliente GetCliByName(string nome)
        {
                try
                {
                    db.OpenConexao();
                    var res = cli.GetCliByName(nome);
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

        //Pegando clientes pelo email
        [HttpGet]
        [ActionName("GetCliByEmail")]
        public Cliente GetCliByEmail(string email)
        {
            try
            {
                db.OpenConexao();
                var res = cli.GetCliByEmail(email);
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

        //Continuar a partir daqui
    }
}