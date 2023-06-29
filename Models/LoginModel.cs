using System.ComponentModel.DataAnnotations;

namespace InmueblesWeb.Models
{
    public class LoginModel
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El password es obligatorio")]
        public string? Password { get; set; }
    }
}
