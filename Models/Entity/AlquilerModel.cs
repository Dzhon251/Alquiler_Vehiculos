using Alquiler_Vehiculos.Models.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alquiler_Vehiculos.Models.Entity
{
    public class AlquilerModel:BaseModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Fecha de Alquiler")]
        public DateTime FechaAlquiler { get; set; }
        [Display(Name = "Codigo de Alquiler")]
        public string Codigo_Alquiler { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public double Total_Alquiler { get; set; }
        [Display(Name = "ClienteId")]
        [ForeignKey("ClientesModel")]
        public int ClienteModelId { get; set; }
        public ClienteModel ClientesModel { get; set; }
        [Display(Name = "VehiculoId")]
        [ForeignKey("VehiculoModel")]
        public int VehiculoModelId { get; set; }
        public VehiculoModel VehiculoModel { get; set; }
    }
}
