using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Alquiler_Vehiculos.Models;
using Alquiler_Vehiculos.Models.Entity;

namespace Alquiler_Vehiculos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions op) : base(op) { }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<VehiculoModel> Vehiculos { get; set; }
        public DbSet<VehiculosAlquiladosModel> VehiculosAlquilados { get; set; }
        public DbSet<AlquilerModel> Alquilados { get; set; }
    }
}
