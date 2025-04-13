namespace ProfesionalesAPI.Dto
{
    public class Logbook : AuditEntity
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Actividades { get; set; }
        public string Observaciones { get; set; }
        public int HorasTrabajadas { get; set; }

        public int PracticaId { get; set; }
        public Internship Practica { get; set; }
    }
}