using Domain.Models;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdutService
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _repository.GetAll();
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _repository.Get(id);
        }
        public async Task CreateProduct(Product product)
        {
            await _repository.Add(product);
        }
        public async Task DeleteProduct(int id)
        {
            var product = await _repository.Get(id);
            _repository.Delete(product);
            await _repository.SaveChanges();
        }
    }
}
