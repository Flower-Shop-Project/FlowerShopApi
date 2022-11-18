using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public List<IFormFile> Files { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        [Required]
        public ICollection<int> FlowerTypes { get; set; }
        [Required]
        public ICollection<int> Appointments { get; set; }
    }
}