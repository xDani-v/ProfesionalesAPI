using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class EstudiantePeriodo : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? EstudianteId { get; set; }
        public int? PeriodoId { get; set; }

        [ForeignKey("EstudianteId")]
        public Usuario? Estudiante { get; set; }

        [ForeignKey("PeriodoId")]
        public Periodo? Periodo { get; set; }

        public ICollection<Postulacion>? Postulaciones { get; set; }
    }
}