namespace ProfesionalesAPI.Dto
{
    public class InternshipOffer : AuditEntity
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Descripcion { get; set; }
        public int CantidadVacantes { get; set; }
        public string Requisitos { get; set; } // JSON

        public int PeriodoId { get; set; }
        public Period Periodo { get; set; }

        public int EmpresaId { get; set; }
        public Company Empresa { get; set; }

        public ICollection<Application> Postulaciones { get; set; }
    }

}