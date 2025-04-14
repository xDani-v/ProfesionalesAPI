using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class DocentePeriodo : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? DocenteId { get; set; }
        public int? PeriodoId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        [ForeignKey("DocenteId")]
        public Usuario? Docente { get; set; }
        [ForeignKey("PeriodoId")]
        public Periodo? Periodo { get; set; }

        public ICollection<Postulacion>? Postulaciones { get; set; }
    }
}