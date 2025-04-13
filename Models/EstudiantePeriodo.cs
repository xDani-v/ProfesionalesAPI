using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;



namespace ProfesionalesAPI.Models
{
    public class EstudiantePeriodo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]
        [JsonIgnore]
        public Usuario? Estudiante { get; set; }

        public int DocenteId { get; set; }
        [ForeignKey("DocenteId")]
        [JsonIgnore]
        public Usuario? Docente { get; set; }

        public int PeriodoId { get; set; }
        [ForeignKey("PeriodoId")]
        [JsonIgnore]
        public Periodo? Periodo { get; set; }

        public bool Estado { get; set; }

        [JsonIgnore]
        public ICollection<Practica>? Practicas { get; set; }
    }



}