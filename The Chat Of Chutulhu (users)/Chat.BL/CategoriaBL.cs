using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BL
{
    public class CategoriaBL
    {


        Contexto _contexto;
        public List<Categoria> Listadecategorias { get; set; }

        public CategoriaBL()
        {
            _contexto = new Contexto();
            Listadecategorias = new List<Categoria>();
        }

        public List<Categoria> Obtenercategoria()
        {
            Listadecategorias = _contexto.Categorias.ToList();
            return Listadecategorias;
        }

        public Categoria Obtenercategoria(int Id)
        {
            var categoria = _contexto.Categorias.Find(Id);
            return categoria;
        }

        public void Guardarcategoria(Categoria categoria)
        {
            if (categoria.ID == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var categoriaExistente = _contexto.Categorias.Find(categoria.ID);
                categoriaExistente.Nombre = categoria.Nombre;
                categoriaExistente.Descripcion = categoria.Descripcion;

            }
            _contexto.SaveChanges();
        }

        public void EliminarCategoria(int Id)
        {
            var categoria = _contexto.Categorias.Find(Id);
            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }
    }
}
