using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API_SpringLibrary.Models;

namespace API_SpringLibrary.Controllers
{
    public class FuncController : Controller
    {

        DatabaseHelper db = new DatabaseHelper();

        // GET: Func
        public ActionResult Index()
        {
            return View();
        }

        // GET: Func/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Func/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Func/Create
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

        // GET: Func/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Func/Edit/5
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

        // GET: Func/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Func/Delete/5
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
