using Domain.Models;
using Shared.Dtos;

namespace Services.ProdutService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task CreateProduct(Product product);
        Task DeleteProduct(int id);
        Task<ICollection<Product>> FindByRequirements(QueryProductsDto createProductDto);
    }
}
