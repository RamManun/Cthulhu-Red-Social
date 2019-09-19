using Chat.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace The_Chat_of_Cuthulhu__users_.web.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            var cateBL = new CategoriaBL();
            var Lista_Categoria = cateBL.MostrarCategorias();

            return View(Lista_Categoria);
        }
    }
}