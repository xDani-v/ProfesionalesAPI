namespace ProfesionalesAPI.Dto
{
    public class Institution : AuditEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RUC { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string LogoUrl { get; set; }

        // Relaciones
        public ICollection<User> Users { get; set; }
        public ICollection<Period> Periods { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}