using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SocialNetwork1._1.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Ingrese un nombre de usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre completo")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Ingrese su correo electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese su fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        
        public HttpPostedFileBase Photo { get; set; }

        [Required(ErrorMessage = "Ingrese su genero")]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "No coinciden las contraseñas")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}