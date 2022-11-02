using Domain.Models;
using Dtos;
using Shared.Dtos;


namespace Services.ProdutService
{
    public interface IUserService
    {
        Task<UserManagerResponseDto> Register(RegisterUserDto model);
        Task<UserManagerResponseDto> Login(LoginUserDto model);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}
