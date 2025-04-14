using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class Bitacora : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Actividades { get; set; }
        public string? Observaciones { get; set; }
        public int HorasTrabajadas { get; set; }

        public int PracticaId { get; set; }
        [ForeignKey("PracticaId")]
        public Postulacion? Practica { get; set; } = null!;
    }
}