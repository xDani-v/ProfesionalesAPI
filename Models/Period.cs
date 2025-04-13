namespace ProfesionalesAPI.Dto
{
    public class Period : AuditEntity
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public int InstitucionId { get; set; }
        public Institution Institucion { get; set; }

        public ICollection<InternshipOffer> Ofertas { get; set; }
    }
}