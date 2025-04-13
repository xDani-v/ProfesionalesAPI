using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ProfesionalesAPI.Models
{
    public class EmpresaPeriodo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PeriodoId { get; set; }
        [ForeignKey("PeriodoId")]
        [JsonIgnore]
        public Periodo? Periodo { get; set; }

        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        [JsonIgnore]
        public Empresa? Empresa { get; set; }

        public string? Area { get; set; }
        public int CantidadPasantes { get; set; }
        public string? Actividades { get; set; } // json como string
        public bool Estado { get; set; }

        [JsonIgnore]
        public ICollection<Practica>? Practicas { get; set; }
    }


}