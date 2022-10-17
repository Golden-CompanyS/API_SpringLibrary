using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Controllers
{
    public class UserController : Controller
    {
        DatabaseHelper db = new DatabaseHelper();
        Cliente cli = new Cliente();

        // GET: CLIENTE
        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                db.OpenConnec();
                var all = cli.GetClientes();
                db.CloseConnec();
                return all;
            }
            catch(Exception e)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.Unau)
            }
         }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
