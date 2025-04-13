namespace ProfesionalesAPI.Dto
{
    public class Role : AuditEntity
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<User>? Usuarios { get; set; }
    }

}