namespace Alquiler_Vehiculos.Models.ViewModel
{
    public class ErrorViewModel
    {
        public string RespuestId { get; set; }
        public bool MostrarIdRespuesta => !string.IsNullOrEmpty(RespuestId);
    }
}
