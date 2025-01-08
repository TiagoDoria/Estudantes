
namespace Estudantes.Models
{
    public class Address
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string CityId { get; set; }
        public City City { get; set; }
    }
}
