using System.ComponentModel.DataAnnotations;

namespace Alquiler_Vehiculos.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del Cliente")]
        [Length(3,100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
            
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Licencia { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Telefono { get; set; }
    }
}
