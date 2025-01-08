using Estudantes.Models;

namespace Estudantes.DTOs
{
    public class CityDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StateId { get; set; }
        public StateDTO State { get; set; }
    }
}
