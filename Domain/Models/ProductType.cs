

namespace Domain.Models
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
