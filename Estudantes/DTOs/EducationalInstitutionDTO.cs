namespace Estudantes.DTOs
{
    public class EducationalInstitutionDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string CityId { get; set; }
    }
}
