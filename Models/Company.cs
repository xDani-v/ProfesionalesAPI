using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class Company : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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

        public int usuarioId { get; set; }
        [ForeignKey("usuarioId")]
        public Usuario? user { get; set; }

        public ICollection<Oferta>? Ofertas { get; set; }

        public ICollection<Convenio>? Convenios { get; set; }
    }

}