using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BL
{
    public class Categoria
    {
       
        public int ID { get; set; }
        [Required(ErrorMessage ="Ingrese el Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese la Descripcion")]
        public string Descripcion { get; set; }
       
    }
}
