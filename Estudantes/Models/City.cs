namespace Estudantes.Models
{
    public class City
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StateId { get; set; }
        public State State { get; set; }
    }
}
