using CrudRazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudRazorApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets existentes
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }

        // Nuevo DbSet para Tareas
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para Proyectos
            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("Proyectos");
                entity.HasKey(e => e.ProyectoId);
                entity.Property(e => e.ProyectoId).ValueGeneratedOnAdd();
            });

            // Configuración para Tareas
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("Tareas");
                entity.HasKey(e => e.TareaId);
                entity.Property(e => e.TareaId).ValueGeneratedOnAdd();

                // Relación con Proyectos
                entity.HasOne(t => t.Proyecto)
                    .WithMany()
                    .HasForeignKey(t => t.ProyectoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}









/* using CrudRazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudRazorApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
    }
} */