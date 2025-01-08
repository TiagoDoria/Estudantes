namespace Estudantes.DTOs
{
    public class StudentDTO
    {
        public string Id { get; set; }
        public string Cpf { get; set; }
        public string AddressId { get; set; }
        public AddressDTO Address { get; set; }
        public string CourseId { get; set; }
        public CourseDTO Course { get; set; }
    }
}
