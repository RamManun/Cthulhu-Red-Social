using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.WebUsuarios.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categorias()
        {
            return View();
        }
        public ActionResult Descargas()
        {
            return View();
        }
    }
}