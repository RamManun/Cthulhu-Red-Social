using RedSocial.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.WebAdmin.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        LibroBL _LibroBL;
        CategoriasBL _categoriasBL;

        public LibroController()
        {
            _LibroBL = new LibroBL();
            _categoriasBL = new CategoriasBL();
        }

        // GET: Libros
        public ActionResult Index()
        {
            var listadeLibros = _LibroBL.ObtenerLibros();

            return View(listadeLibros);
        }

        public ActionResult Crear()
        {
            var nuevoLibro = new Libro();
            var categorias = _categoriasBL.ObtenerCategorias();


            ViewBag.CategoriaId = 
                new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoLibro);
        }

        [HttpPost]
        public ActionResult Crear(Libro Libro, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (Libro.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(Libro);
                }

                if (imagen != null)
                {
                    Libro.UrlImagen = GuardarImagen(imagen);
                }

                _LibroBL.GuardarLibro(Libro);

                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(Libro);
        }

        public ActionResult Editar(int id)
        {
            var Libro = _LibroBL.ObtenerLibro(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion", Libro.CategoriaId);

            return View(Libro);
        }

        [HttpPost]
        public ActionResult Editar(Libro Libro, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (Libro.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(Libro);
                }

                if (imagen != null)
                {
                    Libro.UrlImagen = GuardarImagen(imagen);
                }

                _LibroBL.GuardarLibro(Libro);

                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(Libro);
        }

        public ActionResult Detalle(int id)
        {
            var Libro = _LibroBL.ObtenerLibro(id);

            return View(Libro);
        }

        public ActionResult Eliminar(int id)
        {
            var Libro = _LibroBL.ObtenerLibro(id);

            return View(Libro);
        }

        [HttpPost]
        public ActionResult Eliminar(Libro Libro)
        {
            _LibroBL.EliminarLibro(Libro.Id);

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