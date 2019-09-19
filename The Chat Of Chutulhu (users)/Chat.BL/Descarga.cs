using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BL
{
    public class Descarga
    {
        public int Id { get; set; }
        public int libroId { get; set; }
        //public Libro Libro { get; set; }
        public bool Activo { get; set; }


        public Descarga()
        {
            Activo = true;
        }
    }

    public class Descargalibro
    {
        public int Id { get; set; }
        public int descargaid { get; set; }
        public Descarga Descarga { get; set; }
    }
}


