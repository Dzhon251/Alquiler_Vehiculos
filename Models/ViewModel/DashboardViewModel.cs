using Alquiler_Vehiculos.Models.Entity;

namespace Alquiler_Vehiculos.Models.ViewModel
{
    public class DashboardViewModel
    {
        public int Clientes { get; set; }
        public int Vehiculos { get; set; }
        public int Numero_Alquiler { get; set; }
        public double Total_Alquilados { get; set; }
        public List<AlquilerModel> UltimosAlquilados { get; set; }
    }
}
