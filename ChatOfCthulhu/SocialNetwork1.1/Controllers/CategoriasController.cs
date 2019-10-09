using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUsuarios.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: CateMues
        public ActionResult Infantil()
        {
            return View();
        }

        public ActionResult Drama()
        {

            return View();
        }

        public ActionResult Novelas()
        {

            return View();
        }

        public ActionResult Ficcion()
        {

            return View();
        }
    }
}