using Domain.Models;

namespace Shared.Dtos
{
    public class ProductCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Images { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public IEnumerable<string> FlowerTypes { get; set; }
        public IEnumerable<string> Appointments { get; set; }
    }
}
