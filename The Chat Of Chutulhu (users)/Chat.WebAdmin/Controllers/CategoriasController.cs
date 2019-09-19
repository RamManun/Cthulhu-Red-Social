using Chat.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriaBL _categoriasBL;
        public CategoriasController()
        {
            _categoriasBL = new CategoriaBL();

        }
        // GET: Categorias
        public ActionResult Index()
        {
            var lista_Cate = _categoriasBL.Obtenercategoria();
            return View(lista_Cate);
        }
        public ActionResult Crear()
        {
            var Nueva_Categoria = new Categoria();
            return View(Nueva_Categoria);
        }
        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriasBL.Guardarcategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
        public ActionResult Editar(int id)
        {
            var categoria = _categoriasBL.Obtenercategoria(id);

            return View(categoria);
        }
        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            _categoriasBL.Guardarcategoria(categoria);
            return RedirectToAction("Index");
        }
        public ActionResult Detalle(int id)
        {
            var categoria = _categoriasBL.Obtenercategoria(id);

            return View(categoria);
        }
        public ActionResult Eliminar(int id)
        {
            var categoria = _categoriasBL.Obtenercategoria(id);

            return View(categoria);
        }
        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {
            _categoriasBL.EliminarCategoria(categoria.ID);
            return RedirectToAction("Index");
        }

    }
}