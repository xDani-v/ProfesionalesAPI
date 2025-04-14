using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class Institucion : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? RUC { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public string? LogoUrl { get; set; }

        // Relaciones
        public ICollection<Usuario>? Users { get; set; }
        public ICollection<Periodo>? Periodos { get; set; }
        public ICollection<Convenio>? Convenios { get; set; }
    }
}