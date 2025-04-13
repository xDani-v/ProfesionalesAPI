using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ProfesionalesAPI.Models
{
    public class Institucion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? RUC { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public string? Logo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        [JsonIgnore]
        public ICollection<Usuario>? Usuarios { get; set; }
        [JsonIgnore]
        public ICollection<Periodo>? Periodos { get; set; }
        [JsonIgnore]
        public ICollection<Empresa>? Empresas { get; set; }
    }

}