using Chat.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.WebAdmin.Controllers
{
    public class DescargaController : Controller
    {
        DescargaBL _descargaBL;
        public DescargaController()
        {
            _descargaBL = new DescargaBL();
        }
        // GET: Descarga
        public ActionResult Index()
        {
            var listaLinks = _descargaBL.MostrarLinks();
            return View(listaLinks);
        }
        public ActionResult Crear()
        {
            var Nuevolink = new Descarga();


            return View(Nuevolink);
        }

    }
}