using Domain.Models;

namespace Shared.Dtos
{
    public class ProductCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> images { get; set; }
        public int Price { get; set; }
        public ProductType Type { get; set; }
        public IEnumerable<ProductFlowerType> FlowerTypes { get; set; }
        public IEnumerable<ProductAppointment> Appointments { get; set; }
    }
}
