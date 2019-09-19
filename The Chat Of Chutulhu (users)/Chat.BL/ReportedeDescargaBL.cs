using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BL
{
    public class ReportedeDescargaBL
    {
        Contexto _contexto;
        public List<ReportedeDescargas> ListadeDescargas { get; set; } 
        public ReportedeDescargaBL()
        {
            _contexto = new Contexto();
            ListadeDescargas = new List<ReportedeDescargas>();
        }

    }

}
