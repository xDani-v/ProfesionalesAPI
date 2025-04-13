namespace ProfesionalesAPI.Dto
{
    public class Company : AuditEntity
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string NombreLegal { get; set; }
        public string NombreComercial { get; set; }
        public string Representante { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }

        public int InstitucionId { get; set; }
        public Institution Institucion { get; set; }

        public ICollection<InternshipOffer> Ofertas { get; set; }
    }

}