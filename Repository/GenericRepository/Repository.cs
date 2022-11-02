using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _entities;
        public Repository(AppDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _entities = _context.Set<T>();
        }

        public async Task<T> Get(int id)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Remove(entity);
        }

        public async Task<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}