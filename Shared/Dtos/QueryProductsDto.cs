

namespace Shared.Dtos
{
    public class QueryProductsDto
    {
        public string? Type { get; set; }
        public ICollection<string>? Appointments { get; set; }
        public ICollection<string>? FlowerTypes { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? Search { get; set; }
    }
}
