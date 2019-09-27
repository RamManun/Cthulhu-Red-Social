using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.BL
{
    public class LibroBL
    {
        Contexto _contexto;
        public List<Libro> ListadeLibros { get; set; }

        public LibroBL()
        {
            _contexto = new Contexto();
            ListadeLibros = new List<Libro>();
        }

        public List<Libro> ObtenerLibros()
        {
            ListadeLibros = _contexto.Libros
                .Include("Categoria")
                .OrderBy(r => r.Categoria.Descripcion)
                .ThenBy(r => r.Descripcion)
                .ToList();

            return ListadeLibros;
        }

        public List<Libro> ObtenerLibrosActivos()
        {
            ListadeLibros = _contexto.Libros
                .Include("Categoria")
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Descripcion)
                .ToList();

            return ListadeLibros;
        }

        public void GuardarLibro(Libro Libro)
        {
            if(Libro.Id == 0)
            {
                _contexto.Libros.Add(Libro);
            } else
            {
                var LibroExistente = _contexto.Libros.Find(Libro.Id);

                LibroExistente.Descripcion = Libro.Descripcion;
                LibroExistente.CategoriaId = Libro.CategoriaId;
                LibroExistente.Nombre_libro = Libro.Nombre_libro;
                LibroExistente.Link_Descarga = Libro.Link_Descarga;
                LibroExistente.UrlImagen = Libro.UrlImagen;
            }
            
            _contexto.SaveChanges();
        }

        public Libro ObtenerLibro(int id)
        {
            var Libro = _contexto.Libros
                .Include("Categoria").FirstOrDefault(p => p.Id == id);

            return Libro;
        }

        public void EliminarLibro(int id)
        {
            var Libro = _contexto.Libros.Find(id);

            _contexto.Libros.Remove(Libro);
            _contexto.SaveChanges();
        }
    }
}
