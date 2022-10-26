using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdutService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
    //    Task<User> GetUser(int id);
        Task Register(User user);
    //    Task DeleteUser(int id);
    }
}
