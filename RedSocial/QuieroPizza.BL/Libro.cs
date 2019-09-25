using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class Libro
    {
        public Libro()
        {
            Activo = true;
        }

        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Ingrese la descripción")]
        [MinLength (3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        public string Descripcion { get; set; }

        [Display(Name = "Libro")]
        [Required(ErrorMessage = "Ingrese el nombre del libro")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string Nombre_libro { get; set; }

        [Display(Name = "Link de descarga")]
        [Required(ErrorMessage = "Ingrese el link")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        public string Link_Descarga { get; set; }


        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
    }
}
