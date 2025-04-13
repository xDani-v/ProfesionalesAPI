namespace ProfesionalesAPI.Dto
{
    public class Evaluation : AuditEntity
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public decimal Calificacion { get; set; }
        public string Comentarios { get; set; }
        public DateTime Fecha { get; set; }

        public int PracticaId { get; set; }
        public Internship Practica { get; set; }

        public int DocenteId { get; set; }
        public User Docente { get; set; }
    }
}