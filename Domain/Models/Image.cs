

namespace Domain.Models
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
    }
}
