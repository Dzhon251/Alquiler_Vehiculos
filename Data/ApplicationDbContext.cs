using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Alquiler_Vehiculos.Models;

namespace Alquiler_Vehiculos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op) { }
        public DbSet<Alquiler_Vehiculos.Models.Clientes> Clientes { get; set; }
        public DbSet<Alquiler_Vehiculos.Models.Vehiculos> Vehiculos { get; set; }
    }
}
