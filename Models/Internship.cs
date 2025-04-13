namespace ProfesionalesAPI.Dto
{
    public class Internship : AuditEntity
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int HorasTotales { get; set; }
        public string Estado { get; set; }

        public int PostulacionId { get; set; }
        public Application Postulacion { get; set; }

        public ICollection<Logbook> Bitacoras { get; set; }
        public ICollection<Evaluation> Evaluaciones { get; set; }
    }

}