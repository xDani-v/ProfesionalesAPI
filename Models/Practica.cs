using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ProfesionalesAPI.Models
{
    public class Practica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EstudiantePeriodo { get; set; }
        [ForeignKey("EstudiantePeriodo")]
        [JsonIgnore]
        public EstudiantePeriodo? EstudiantePeriodoNavigation { get; set; }

        public int EmpresaPeriodo { get; set; }
        [ForeignKey("EmpresaPeriodo")]
        [JsonIgnore]
        public EmpresaPeriodo? EmpresaPeriodoNavigation { get; set; }

        public bool Estado { get; set; }

        [JsonIgnore]
        public ICollection<Bitacora>? Bitacoras { get; set; }
        [JsonIgnore]
        public ICollection<EvaluacionPractica>? Evaluaciones { get; set; }
    }

}
