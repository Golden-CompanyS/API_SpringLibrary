using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_SpringLibrary.Models;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace API_SpringLibrary.Controllers
{
    public class SpringLibraryController : ApiController
    {
        // Para encontrar DatabaseHelper!
        DatabaseHelper db = new DatabaseHelper();

        // Models para melhor localização ao decorrer do código
        Editora edit = new Editora();
        Cliente cli = new Cliente();
        ClienteFisico cliF = new ClienteFisico();
        ClienteJuridico cliJ = new ClienteJuridico();
        Autor aut = new Autor();
        Genero gen = new Genero();
        Livro liv = new Livro();
        LivroAutor livaut = new LivroAutor();

        //Comando caso necessário
        MySqlCommand command = DatabaseHelper.CriaComando();

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

        // Cliente metódos 

        //Metódos get:

        //Pegando todos os clientes já cadastrados
        [HttpGet]
        [ActionName("GetAllClientes")]
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

        //Validando user
        [HttpPost]
        [ActionName("validateUser")]
        public bool ValidateUser([FromBody] Cliente user)
        {
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    bool validator = cli.ValidateUser(user);
                    return validator;
                }
                catch
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                finally
                {
                    db.FechaConexao();
                }
            }
        }

        // Cliente Físico metódos 

        //Metódos Get:

        //Visualizar todos os clientes
        [HttpGet]
        [ActionName("GetAllClientesF")]
        public IEnumerable<ClienteFisico> GetAllClientesF()
        {
            try
            {
                db.OpenConexao();
                var res = cliF.GetAllClientesF();
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

        // Metódos Post:

        //Cadastrar novo cliente físico
        [HttpPost]
        [ActionName("PostNewClienteF")]
        public HttpResponseMessage PostNewClienteF([FromBody] ClienteFisico cliF)
        {
            var res = new HttpResponseMessage();
            if (cliF == null)
            {
                res.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    cliF.PostNewClienteF(cliF);
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
        
        // Metódos Put: 

        //Atualizar um cliente físico
        [HttpPut]
        [ActionName("AlterCliF")]
        public HttpResponseMessage UpdateCliF(int id, [FromBody] ClienteFisico cliF)
        {
            var res = new HttpResponseMessage();
            if (cliF == null)
            {
                res.StatusCode = HttpStatusCode.NotModified;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    cliF.AlterCliF(id, cliF);
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

        // Cliente Jurídico métodos

        // Métódos GET:

        //Visualizar todos os clientes jurídicos
        [HttpGet]
        [ActionName("GetAllClientesJ")]
        public IEnumerable<ClienteJuridico> GetAllClientesJ()
        {
            try
            {
                db.OpenConexao();
                var res = cliJ.GetAllClientesJ();
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

        // Metódos Post:

        //Cadastrar novo cliente jurídico
        [HttpPost]
        [ActionName("PostNewClienteJ")]
        public HttpResponseMessage PostNewClienteJ([FromBody] ClienteJuridico cliJ)
        {
            var res = new HttpResponseMessage();
            if (cliJ == null)
            {
                res.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    cliJ.PostNewClienteJ(cliJ);
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

        // Metódos Put: 

        //Atualizar um cliente jurídico
        [HttpPut]
        [ActionName("AlterCliJ")]
        public HttpResponseMessage UpdateCliJ(int id, [FromBody] ClienteJuridico cliJ)
        {
            var res = new HttpResponseMessage();
            if (cliJ == null)
            {
                res.StatusCode = HttpStatusCode.NotModified;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    cliJ.AlterCliJ(id, cliJ);
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


        // Autor métodos 

        // Métodos Get:

        // Pegando todos os autores cadastrados
        [HttpGet]
        [ActionName("GetAllAutores")]
        public IEnumerable<Autor> GetAllAutores()
        {
            try
            {
                db.OpenConexao();
                var res = aut.GetAllAutores();
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

        //Pegando autores pelo ID
        [HttpGet]
        [ActionName("GetAutById")]
        public Autor GetAutById(int id)
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
                    var res = aut.GetAutById(id);
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

        //Pegando autores pelo nome
        [HttpGet]
        [ActionName("getAutByName")]
        public IEnumerable<Autor> getAutByName(string name)
        {
            try
            {
                db.OpenConexao();
                var res = aut.GetAutByParameter("NomAut", name);
                db.FechaConexao();
                return res;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }

        //Metódos Post:

        //Cadastrando novo autor
        [HttpPost]
        [ActionName("PostNewAutor")]
        public HttpResponseMessage PostNewAutor([FromBody] Autor aut)
        {
            var res = new HttpResponseMessage();
            if (aut == null)
            {
                res.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    aut.PostNewAutor(aut);
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

        //Alterando um autor
        [HttpPut]
        [ActionName("AlterAutor")]
        public HttpResponseMessage UpdateAutor(int id, [FromBody] Autor autor)
        {
            var res = new HttpResponseMessage();
            if (autor == null)
            {
                res.StatusCode = HttpStatusCode.NotModified;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    aut.AlterAutor(id, autor);
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

        // Gênero métodos 

        // Métodos Get:

        // Pegando todos os gêneros cadastrados
        [HttpGet]
        [ActionName("GetAllGeneros")]
        public IEnumerable<Genero> GetAllGeneros()
        {
            try
            {
                db.OpenConexao();
                var res = gen.GetAllGeneros();
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

        //Pegando gêneros pelo ID
        [HttpGet]
        [ActionName("GetGenById")]
        public Genero GetGenById(int id)
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
                    var res = gen.GetGenById(id);
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

        //Pegando autores pelo nome
        [HttpGet]
        [ActionName("getGenByName")]
        public IEnumerable<Genero> getGenByName(string name)
        {
            try
            {
                db.OpenConexao();
                var res = gen.GetGenByParameter("NomGen", name);
                db.FechaConexao();
                return res;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }

        //Metódos Post:

        //Cadastrando novo gênero
        [HttpPost]
        [ActionName("PostNewGenero")]
        public HttpResponseMessage PostNewGenero([FromBody] Genero gen)
        {
            var res = new HttpResponseMessage();
            if (gen == null)
            {
                res.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    gen.PostNewGenero(gen);
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

        //Alterando um gênero
        [HttpPut]
        [ActionName("AlterGenero")]
        public HttpResponseMessage UpdateGenero(int id, [FromBody] Genero genero)
        {
            var res = new HttpResponseMessage();
            if (genero == null)
            {
                res.StatusCode = HttpStatusCode.NotModified;
            }
            else
            {
                try
                {
                    db.OpenConexao();
                    gen.AlterGenero(id, genero);
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

        // Livro métodos

        // Get:

        //Todos os livros
        [HttpGet]
        [ActionName("getAllLivros")]
        public IEnumerable<Livro> GetAllLivros()
        {
            try
            {
                db.OpenConexao();
                var res = liv.GetAllLivros();
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

        //Livro por gênero

        [HttpGet]
        [ActionName("getLivByGenero")]
        public IEnumerable<Livro> GetLivByGenero(string genero)
        {
            try
            {
                db.OpenConexao();
                var res = liv.GetLivByGenero(genero);
                db.FechaConexao();
                return res;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getLivByEditora")]
        public IEnumerable<Livro> GetLivByEditora(string editora)
        {
            try
            {
                db.OpenConexao();
                var res = liv.GetLivByEditora(editora);
                db.FechaConexao();
                return res;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }

        // LivroAutor métodos 

        // Metódos Get:

        //Pegando todas os livro e autores juntos já cadastrados
        [HttpGet]
        [ActionName("getAllLivroAutores")]
        public IEnumerable<LivroAutor> GetAllLivroAutores()
        {
            try
            {
                db.OpenConexao();
                var res = livaut.GetAllLivroAutores();
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

        //Pegando autores pelo nome
        [HttpGet]
        [ActionName("getAutLivByName")]
        public IEnumerable<LivroAutor> GetAutLivByName(string name)
        {
            try
            {
                db.OpenConexao();
                var res = livaut.GetAutLivByName(name);
                db.FechaConexao();
                return res;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }



    }
}