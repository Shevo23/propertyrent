using System.ComponentModel.DataAnnotations;

namespace InmueblesWeb.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo paterno es obligatorio")]
        public string? Paterno { get; set; }

        [Required(ErrorMessage = "El campo materno es obligatorio")]
        public string? Materno { get; set; }

        [Required(ErrorMessage = "El campo email es obligatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El campo nombre usuario es obligatorio")]
        public string? NombreUsuario { get; set; }
        
        public string? Password { get; set; }

        [Required(ErrorMessage = "El campo celular es obligatorio")]
        public string? Movil { get; set; }
        
        public int Activo { get; set; }
    }
}
