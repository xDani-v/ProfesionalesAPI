using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfesionalesAPI.Dto
{
    public class Convenio : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        public int InstitucionlId { get; set; }

        [ForeignKey("EmpresaId")]
        public Company? Empresa { get; set; }

        [ForeignKey("InstitucionlId")]
        public Institucion? Institucion { get; set; }

    }

}