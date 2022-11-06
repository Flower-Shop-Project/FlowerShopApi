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
        public string Price { get; set; }
        [Required]
        public List<IFormFile> Files { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
    }
}