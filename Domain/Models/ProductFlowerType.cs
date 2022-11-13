using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ProductFlowerType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
