using Microsoft.EntityFrameworkCore;
using ProyectoTwin.Entidades;

namespace ProyectoTwin.BaseDatos
{
    public class ContextBaseDatos : DbContext
    {
        public ContextBaseDatos(DbContextOptions<ContextBaseDatos> options) : base(options) { }

        public DbSet<ComponenteTwin> ComponentesTwin { get; set; }

        // Puedes agregar m�s DbSet para otras entidades aqu�

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales si es necesario
        }
    }
}
