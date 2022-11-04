using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task Add(Product product)
        {
            product.Id = default;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.Include(x => x.ImagePaths)
                                    .Include(x => x.Appointments)
                                    .Include(x => x.FlowerTypes)
                                    .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Include(x => x.ImagePaths).ToListAsync();
        }
        public async Task Delete(int id)
        {
            var product = _context.Products.Include(x => x.ImagePaths)
                                    .SingleOrDefault(x => x.Id == id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
