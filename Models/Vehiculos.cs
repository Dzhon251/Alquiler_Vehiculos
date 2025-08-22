using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Alquiler_Vehiculos.Models
{
    public class Vehiculos
    {
        [Key]
        public int Vehiculo_Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Anio { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Disponible { get; set; }
    }
}