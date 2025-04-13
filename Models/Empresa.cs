using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ProfesionalesAPI.Models
{

    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int InstitucionId { get; set; }
        [ForeignKey("InstitucionId")]
        [JsonIgnore]
        public Institucion? Institucion { get; set; }

        public string? Ruc { get; set; }
        public string? NombreLegal { get; set; }
        public string? NombreComercial { get; set; }
        public string? Representante { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public string? Logo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        [JsonIgnore]
        public ICollection<EmpresaPeriodo>? EmpresaPeriodos { get; set; }
    }

}