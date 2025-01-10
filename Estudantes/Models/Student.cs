namespace Estudantes.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string AddressId { get; set; }
        public Address Address { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
    }
}
