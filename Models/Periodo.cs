using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProfesionalesAPI.Models
{
    public class Periodo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Etapa { get; set; }

        public int InstitucionId { get; set; }
        [ForeignKey("InstitucionId")]
        [JsonIgnore]
        public Institucion? Institucion { get; set; }

        public bool Estado { get; set; }

        [JsonIgnore]
        public ICollection<EmpresaPeriodo>? EmpresaPeriodos { get; set; }
        [JsonIgnore]
        public ICollection<EstudiantePeriodo>? EstudiantePeriodos { get; set; }
    }

}