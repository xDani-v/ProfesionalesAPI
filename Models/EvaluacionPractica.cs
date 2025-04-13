using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ProfesionalesAPI.Models
{
    public class EvaluacionPractica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PracticaId { get; set; }
        [ForeignKey("PracticaId")]
        [JsonIgnore]
        public Practica? Practica { get; set; }

        public int DocenteId { get; set; }
        [ForeignKey("DocenteId")]
        [JsonIgnore]
        public Usuario? Docente { get; set; }

        public DateTime Fecha { get; set; }
        public int Puntaje { get; set; }
        public string? Observaciones { get; set; }
        public bool Estado { get; set; }
    }
}