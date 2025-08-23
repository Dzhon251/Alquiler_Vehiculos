using Alquiler_Vehiculos.Models.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alquiler_Vehiculos.Models.Entity
{
    [Table("Vehiculos")]
    public class VehiculoModel:BaseModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Anio { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Disponible { get; set; }
        [Required(ErrorMessage = "El precio diario es requerido")]
        [Display(Name = "Precio Diario")]
        public double Precio_Diario { get; set; }
    }
}
