using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using System.Collections.Generic;

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
            _context.Products.Attach(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.Include(x => x.ImagePaths)
                                    .Include(x => x.Appointments)
                                    .Include(x => x.FlowerTypes)
                                    .Include(x => x.Type)
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

        public async Task<ICollection<Product> > QueryByRequierements(QueryProductsDto queryStatements)
        {
            ProductType requiredProductType = null;
            IQueryable<Product> products = _context.Products;

            if (queryStatements.Type != null)
            {
                requiredProductType = await _context.ProductTypes.SingleOrDefaultAsync(x => x.Name == queryStatements.Type);
                if (requiredProductType == null)
                    return new List<Product>();

                products = products.Where(x => x.ProductTypeId == requiredProductType.Id);
            }
            
            if (queryStatements.FlowerTypes != null)
                products = products.Where(x => x.FlowerTypes.Any(x => queryStatements.FlowerTypes.Any(y => y == x.Name)));

            if (queryStatements.Appointments != null)
                products = products.Where(x => x.Appointments.Any(x => queryStatements.Appointments.Any(y => y == x.Name)));

            if (queryStatements.MaxPrice != null)
                products = products.Where(x => x.Price <= queryStatements.MaxPrice);

            if (queryStatements.MinPrice != null)
                products = products.Where(x => x.Price >= queryStatements.MinPrice);

            if (!String.IsNullOrEmpty(queryStatements.Search))
                products = products.Where(x => x.Name.ToLower().Contains(queryStatements.Search.Trim().ToLower()));

            return await products.ToArrayAsync();
        }
    }
}
