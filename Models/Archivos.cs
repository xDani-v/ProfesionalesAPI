using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfesionalesAPI.Dto
{
    public class Archivos : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TipoEntidad { get; set; } = string.Empty;
        public string? TipoDocumento { get; set; }
        public string? NombreArchivo { get; set; }
        public string? Ruta { get; set; }
    }
}