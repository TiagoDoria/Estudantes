namespace Estudantes.Models
{
    public class Course
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime GraduationDate { get; set; }
        public string EducationalnstitutionId { get; set; }
        public Educationalnstitution Educationalnstitution { get; set; }
    }
}
