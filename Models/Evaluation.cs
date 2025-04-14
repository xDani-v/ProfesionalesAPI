using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class Evaluation : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public decimal Calificacion { get; set; }
        public string? Comentarios { get; set; }
        public DateTime Fecha { get; set; }

        public int postulacionId { get; set; }
        [ForeignKey("postulacionId")]
        public Postulacion? Postulacion { get; set; }

        public int DocenteId { get; set; }
        [ForeignKey("DocenteId")]
        public Usuario? Docente { get; set; }
    }
}