using Estudantes.Models;

namespace Estudantes.DTOs
{
    public class CourseDTO
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public DateTime GraduationDate { get; set; }
        public string EducationalnstitutionId { get; set; }
        public EducationalInstitutionDTO Educationalnstitution { get; set; }
    }
}
