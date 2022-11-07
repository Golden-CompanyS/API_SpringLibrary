using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_SpringLibrary.Controllers
{
    public class SpringLibraryController : Controller
    {
        // GET: SpringLibrary
        public ActionResult Index()
        {
            return View();
        }
    }
}