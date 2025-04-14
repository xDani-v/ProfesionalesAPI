using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class Usuario : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string? Identificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public DateTime? UltimoCambioPassword { get; set; }
        public int IntentosFallidos { get; set; }
        public DateTime? BloqueoHasta { get; set; }

        public int? RolId { get; set; }
        [ForeignKey("RolId")]
        public Role? Rol { get; set; }

        public int? InstitucionId { get; set; }
        [ForeignKey("InstitucionId")]
        public Institucion? Institucion { get; set; }

        public ICollection<DocentePeriodo>? Docentes { get; set; }
        public ICollection<EstudiantePeriodo>? Estudiantes { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }

    }
}