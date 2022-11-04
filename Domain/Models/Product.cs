

namespace Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public ICollection<Image> ImagePaths { get; set; }
        public ProductType Type { get; set; }
        public ICollection<ProductFlowerType> FlowerTypes { get; set; }
        public ICollection<ProductAppointment> Appointments { get; set; }

    }
}
