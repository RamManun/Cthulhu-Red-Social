using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BL
{
    public class DescargaBL
    {
        Contexto _contexto;
        public List<Descarga> ListaDescargas { get; set; }

        public DescargaBL()
        {
            _contexto = new Contexto();
            ListaDescargas = new List<Descarga>();
        }

        public List<Descarga> MostrarLinks()
        {
            ListaDescargas = _contexto.links
                .OrderBy(r => r.libroId)
                .ToList();
            return ListaDescargas;
        }

    }
}
