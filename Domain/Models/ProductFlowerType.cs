

namespace Domain.Models
{
    public class ProductFlowerType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
