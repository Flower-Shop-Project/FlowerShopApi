using Domain.Models;

namespace Repository.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(int Id);
        Task Update(User entity);
        Task Add(User entity);
        Task SaveChanges();
    }
}
