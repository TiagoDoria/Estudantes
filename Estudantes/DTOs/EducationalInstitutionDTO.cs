namespace Estudantes.DTOs
{
    public class EducationalInstitutionDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CityId { get; set; }
        public CityDTO City { get; set; }
    }
}
