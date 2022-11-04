

namespace Domain.Models
{
    public class ProductAppointment : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}