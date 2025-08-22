using System.ComponentModel.DataAnnotations;

namespace Alquiler_Vehiculos.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Password { get; set; }
    }
}
