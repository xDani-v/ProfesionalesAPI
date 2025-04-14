using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfesionalesAPI.Dto
{
    public class Periodo : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public int InstitucionId { get; set; }
        [ForeignKey("InstitucionId")]
        public Institucion? Institucion { get; set; }

        public ICollection<Oferta>? Ofertas { get; set; }

        public ICollection<DocentePeriodo>? Docentes { get; set; }

        public ICollection<EstudiantePeriodo>? Estudiantes { get; set; }
    }
}