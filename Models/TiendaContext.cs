using Microsoft.EntityFrameworkCore;

namespace BackendTiendaVirtual.Models
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> settings)
            : base(settings) { }


        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;

    }
}
