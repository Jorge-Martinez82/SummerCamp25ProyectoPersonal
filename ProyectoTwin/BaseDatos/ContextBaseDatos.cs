using Microsoft.EntityFrameworkCore;
using ProyectoTwin.Entidades;

namespace ProyectoTwin.BaseDatos
{
    public class ContextBaseDatos : DbContext
    {
        public ContextBaseDatos(DbContextOptions<ContextBaseDatos> options) : base(options) { }

        public DbSet<ComponenteTwin> ComponentesTwin { get; set; }

        // Puedes agregar más DbSet para otras entidades aquí

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales si es necesario
        }
    }
}
