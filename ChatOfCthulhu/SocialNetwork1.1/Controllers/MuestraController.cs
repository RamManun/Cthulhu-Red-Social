using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork1._1.Controllers
{
    public class MuestraController : Controller
    {
        // GET: Muestra
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