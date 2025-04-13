using System.Text.Json;

using Microsoft.EntityFrameworkCore;

namespace ProfesionalesAPI.Dto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Institution> Instituciones { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Period> Periodos { get; set; }
        public DbSet<Company> Empresas { get; set; }
        public DbSet<InternshipOffer> OfertasPracticas { get; set; }
        public DbSet<Application> Postulaciones { get; set; }
        public DbSet<Internship> Practicas { get; set; }
        public DbSet<Logbook> Bitacoras { get; set; }
        public DbSet<Evaluation> Evaluaciones { get; set; }
        public DbSet<Document> Documentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<User>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Estudiante)
                .WithMany(u => u.Postulaciones)
                .HasForeignKey(a => a.EstudianteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.DocenteAsignado)
                .WithMany()
                .HasForeignKey(a => a.DocenteAsignadoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar el borrado en cascada donde sea apropiado
            modelBuilder.Entity<Internship>()
                .HasOne(p => p.Postulacion)
                .WithOne(a => a.Practica)
                .HasForeignKey<Internship>(p => p.PostulacionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InternshipOffer>()
    .HasOne(o => o.Periodo)
    .WithMany(p => p.Ofertas)
    .HasForeignKey(o => o.PeriodoId)
    .OnDelete(DeleteBehavior.Restrict); // Cambiar de Cascade a Restrict

            modelBuilder.Entity<InternshipOffer>()
                .HasOne(o => o.Empresa)
                .WithMany(e => e.Ofertas)
                .HasForeignKey(o => o.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict); // Cambiar de Cascade a Restrict

            // Configurar índices únicos
            modelBuilder.Entity<Institution>()
                .HasIndex(i => i.RUC)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Correo)
                .IsUnique();


        }
    }
}