using Domain.Models;
using Repository.Repositories;
using Shared.Dtos;

namespace Services.ProdutService
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _repository.GetAll();
        }
        public async Task<Product> GetProduct(int id)
        {
            var product = await _repository.Get(id);
            
            return product;
        }
        public async Task CreateProduct(Product product)
        {
            await _repository.Add(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Product>> FindByRequirements(QueryProductsDto queryProductsDto)
        {
            return await _repository.QueryByRequierements(queryProductsDto);
        }
    }
}
