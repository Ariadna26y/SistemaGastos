using Microsoft.EntityFrameworkCore;

namespace SistemaGastos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Estas propiedades representan tus tablas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
    }
}
