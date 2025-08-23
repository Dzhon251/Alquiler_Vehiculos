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
        public string Nombre { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public double Monto { get; set; }

        public DateTime Create_At { get; set; } = DateTime.Now;
        public DateTime? Update_At { get; set; }
        public bool isDelete { get; set; } = false;

        [Required]
        [Display(Name = "Días de Alquiler")]
        public int Dias { get; set; }

        [Required]
        [Display(Name = "Precio por Día")]
        public double Precio { get; set; }

        [Required]
        [Display(Name = "Subtotal")]
        public double Subtotal { get; set; }

        [ForeignKey("AlquilerModel")]
        public int AlquilerModelId { get; set; }
        public AlquilerModel AlquilerModel { get; set; }

        [ForeignKey("VehiculoModel")]
        public int VehiculoModelId { get; set; }
        public VehiculoModel VehiculoModel { get; set; }
    }
}
