namespace ProfesionalesAPI.Dto
{
    public class Application : AuditEntity
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPostulacion { get; set; }

        public int EstudianteId { get; set; }
        public User Estudiante { get; set; }

        public int OfertaId { get; set; }
        public InternshipOffer Oferta { get; set; }

        public int? DocenteAsignadoId { get; set; }
        public User DocenteAsignado { get; set; }

        public Internship Practica { get; set; }
    }
}