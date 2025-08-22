using Alquiler_Vehiculos.Models.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alquiler_Vehiculos.Models.Entity
{
    [Table("VehiculosAlquilados")]
    public class VehiculosAlquiladosModel:BaseModel
    {
        [Required]
        public int VehiculosModelId { get; set; }
        public VehiculoModel VehiculosModel { get; set; }

        public string Nombre { get; set; }

        [Required]
        public double Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double Monto { get; set; }

        [Display(Name = "Alquiler")]
        [ForeignKey("AlquilerModel")]
        public int AlquilerModelId { get; set; }
        [JsonIgnore]
        public AlquilerModel AlquilerModel { get; set; }
    }
}
