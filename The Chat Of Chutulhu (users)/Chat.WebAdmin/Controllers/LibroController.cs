using Chat.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.WebAdmin.Controllers
{
    public class LibroController : Controller
    {
        LibroBL _libroBL;
        CategoriaBL _categoriasBL;
        DescargaBL _descargaBL;
        public LibroController()
        {
            _libroBL= new LibroBL();
            _categoriasBL = new CategoriaBL();
            _descargaBL = new DescargaBL(); 

        }
        // GET: Libro
        public ActionResult Index()
        {
            var lista_libros = _libroBL.MostrarLibros();
            return View(lista_libros);
        }

        public ActionResult Crear()
        {
            var Nueva_Libro = new Libro();
            return View(Nueva_Libro);
        }
        [HttpPost]
        public ActionResult Crear(Libro libro)
        {
            if (ModelState.IsValid)
            {
                if (libro.Sipnosis != libro.Sipnosis.Trim())
                {
                    ModelState.AddModelError("descripcion", "la descripcion no debe llevar espacios");
                    return View(libro);
                }
                _libroBL.GuardarLibro(libro);
                return RedirectToAction("Index");
            }
            return View(libro);
        }

  
        public ActionResult Editar(int id)
        {
            var libro = _libroBL.Mostrarlibros(id);

            return View(libro);
        }

           
        
        public ActionResult Detalle(int id)
        {
            var libro = _libroBL.Mostrarlibros(id);

            return View(libro);
        }
        public ActionResult Eliminar(int id)
        {
            var libro = _libroBL.Mostrarlibros(id);

            return View(libro);
        }
        [HttpPost]
        public ActionResult Eliminar(Libro libro)
        {
            _libroBL.EliminarLibro(libro.Id);
            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);
            return "/Imagenes/" + imagen.FileName;
        }


    }
}