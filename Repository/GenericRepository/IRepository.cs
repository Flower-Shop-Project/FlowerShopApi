using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int Id);
        Task Add(T entity);
        Task Update(T entity);
        void Delete(T entity);
        Task SaveChanges();
    }
}
