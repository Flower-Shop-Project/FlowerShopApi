using Domain.Models;
using Repository.Repository;
using Services.ProdutService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserService
{
    public class UserService : IUserService
    {
        private IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAll();
        }

        public async Task Register(User user)
        {
            await _repository.Add(user);
        }
    }
}
