namespace ProfesionalesAPI.Dto
{
    public class Document : AuditEntity
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreArchivo { get; set; }
        public string Ruta { get; set; }
        public DateTime FechaSubida { get; set; }

        // Relación polimórfica
        public int EntidadId { get; set; }
        public EntityType TipoEntidad { get; set; }
    }
}