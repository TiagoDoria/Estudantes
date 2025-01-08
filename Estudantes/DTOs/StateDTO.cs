namespace Estudantes.DTOs
{
    public class StateDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<CityDTO> Cities { get; set; }
    }
}
