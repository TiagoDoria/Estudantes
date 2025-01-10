using Estudantes.Models;

namespace Estudantes.DTOs
{
    public class AddressDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; }
        public string CityId { get; set; }
        public CityDTO City { get; set; }
    }
}
