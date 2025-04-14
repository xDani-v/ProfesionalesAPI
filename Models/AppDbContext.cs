using System.Text.Json;

using Microsoft.EntityFrameworkCore;

namespace ProfesionalesAPI.Dto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Archivos> Archivos { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Company> Empresas { get; set; }
        public DbSet<Convenio> Convenios { get; set; }
        public DbSet<DocentePeriodo> docentePeriodos { get; set; }
        public DbSet<EstudiantePeriodo> estudiantePeriodos { get; set; }
        public DbSet<Evaluation> Evaluaciones { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Periodo> Periodos { get; set; }

        public DbSet<Postulacion> Postulaciones { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }
    }
}