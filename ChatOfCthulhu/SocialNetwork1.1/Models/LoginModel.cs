using System.ComponentModel.DataAnnotations;

namespace SocialNetwork1._1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Ingrese su Nombre de usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}