using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class Oferta : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? periodoId { get; set; }
        [ForeignKey("periodoId")]
        public Periodo? Periodo { get; set; }
        public int? institucionId { get; set; }
        [ForeignKey("institucionId")]
        public Institucion? Institucion { get; set; }

        public string? Area { get; set; }

        public string? Descripcion { get; set; }

        public int? Vacantes { get; set; }

        public string? Actividades { get; set; }

        public ICollection<Bitacora>? Bitacoras { get; set; }
        public ICollection<Evaluation>? Evaluaciones { get; set; }

        public ICollection<Postulacion>? Postulaciones { get; set; }
    }

}