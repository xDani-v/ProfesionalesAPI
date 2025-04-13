using Microsoft.EntityFrameworkCore;

using ProfesionalesAPI.Models; // Asegúrate de que esta ruta apunte a tus modelos

namespace ProfesionalesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Documento> Documentos { get; set; }

        public DbSet<Bitacora> Bitacoras { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<EmpresaPeriodo> EmpresasPeriodos { get; set; }

        public DbSet<Periodo> Periodos { get; set; }

        public DbSet<EstudiantePeriodo> EstudiantePeriodos { get; set; }

        public DbSet<EvaluacionPractica> EvaluacionPracticas { get; set; }

        public DbSet<Institucion> Instituciones { get; set; }

        public DbSet<Practica> Practicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}