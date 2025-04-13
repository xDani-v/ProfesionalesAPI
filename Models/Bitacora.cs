using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProfesionalesAPI.Models
{

    public class Bitacora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PracticaId { get; set; }
        [ForeignKey("PracticaId")]
        [JsonIgnore]
        public Practica? Practica { get; set; }

        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string? Actividad { get; set; }
        public string? Observaciones { get; set; }
        public bool Estado { get; set; }
    }

}