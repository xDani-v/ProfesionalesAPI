using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ProfesionalesAPI.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Rol { get; set; }
        [ForeignKey("Rol")]
        [JsonIgnore]
        public Rol? RolNavigation { get; set; }

        public int InstitucionId { get; set; }
        [ForeignKey("InstitucionId")]
        [JsonIgnore]
        public Institucion? Institucion { get; set; }

        public string? Identificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

        public string? Password { get; set; }
        public bool Estado { get; set; }

        [JsonIgnore]
        public ICollection<EstudiantePeriodo>? EstudiantePeriodos { get; set; }
        [JsonIgnore]
        public ICollection<EstudiantePeriodo>? DocentePeriodos { get; set; }
        [JsonIgnore]
        public ICollection<Documento>? Documentos { get; set; }
        [JsonIgnore]
        public ICollection<EvaluacionPractica>? EvaluacionesDocente { get; set; }
    }
}