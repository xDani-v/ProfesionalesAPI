using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class Postulacion : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]
        public EstudiantePeriodo Estudiante { get; set; } = null!;

        public int? OfertaId { get; set; }
        [ForeignKey("OfertaId")]
        public Oferta Oferta { get; set; } = null!;

        public int? DocenteId { get; set; }
        [ForeignKey("DocenteId")]
        public DocentePeriodo Docente { get; set; } = null!;

        public ICollection<Bitacora>? Bitacoras { get; set; }

        public ICollection<Evaluation>? Evaluaciones { get; set; }

    }
}