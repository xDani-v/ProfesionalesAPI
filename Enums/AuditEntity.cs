namespace ProfesionalesAPI.Dto
{
    public abstract class AuditEntity
    {
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Estado { get; set; }
    }
}