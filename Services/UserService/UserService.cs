using Domain.Models;
using Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql.Replication.PgOutput.Messages;
using Repository.Repositories;
using Services.ProdutService;
using Shared.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.UserService
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private UserManager<User> _userManager;
        private IConfiguration _configuration;
        public UserService(IUserRepository repository, UserManager<User> userManager,
            IConfiguration configuration)
        {
            _repository = repository;
            _userManager = userManager;
            _configuration = configuration;
        }
        
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetUser(int id)
        {
            return await _repository.Get(id);
        }


        public async Task<UserManagerResponseDto> Register(RegisterUserDto model)
        {
            if (model == null)
                throw new NullReferenceException("Register model is null");

            if (_userManager.FindByEmailAsync(model.Email).Result != null ||
                _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber).Result != null)
            {
                return new UserManagerResponseDto
                {
                    Message = "Unable to create user",
                    IsSuccess = false,
                    Errors = new List<string> { "Email or phone number already exists" }
                };
            }

            var identityUser = new User
            {
                UserName = Guid.NewGuid().ToString(),
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName
            };


            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponseDto
                {
                    Message = "Succesfully created new user!",
                    IsSuccess = true
                };
            }

            return new UserManagerResponseDto
            {
                Message = "Unable to create user",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
        
        public async Task<UserManagerResponseDto> Login(LoginUserDto model)
        {
            if (model.EmailOrPhoneNumber == null)
            {
                return new UserManagerResponseDto
                {
                    Message = "Phone number or email null",
                    IsSuccess = false,
                };
            }

            User user;
            if (model.EmailOrPhoneNumber.Contains("@"))
                user = _userManager.FindByEmailAsync(model.EmailOrPhoneNumber).Result;
            else
                user = _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.EmailOrPhoneNumber).Result;



            if (user == null)
                return new UserManagerResponseDto
                {
                    Message = "No user with that email or phone number",
                    IsSuccess = false
                };

            var authResult = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!authResult)
                return new UserManagerResponseDto
                {
                    Message = "Invalid login credentials",
                    IsSuccess = false
                };

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponseDto
            {
                Message = stringToken,
                IsSuccess = true,
                TokenExpirationDate = token.ValidTo,
            };
        }
    }
}
