namespace ProfesionalesAPI.Dto
{
    public class User : AuditEntity
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? UltimoCambioPassword { get; set; }
        public int IntentosFallidos { get; set; }
        public DateTime? BloqueoHasta { get; set; }
        // Relaciones
        public int RolId { get; set; }
        public Role Rol { get; set; }

        public int InstitucionId { get; set; }
        public Institution Institucion { get; set; }

        public ICollection<Application> Postulaciones { get; set; }
        public ICollection<Evaluation> Evaluaciones { get; set; }
        public ICollection<Document> Documentos { get; set; }
    }
}