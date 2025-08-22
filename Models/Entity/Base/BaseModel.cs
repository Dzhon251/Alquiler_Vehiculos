using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alquiler_Vehiculos.Models.Entity.Base
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Create_At { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Update_At { get; set; }
        public bool isDelete { get; set; }
    }
}
