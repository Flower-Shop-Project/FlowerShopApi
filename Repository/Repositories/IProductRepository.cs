using Domain.Models;

namespace Repository.Repositories
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(int Id);
        Task Update(Product product);
        Task Delete(int id);
    }
}
