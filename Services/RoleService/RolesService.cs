using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Services.RoleService
{
    public class RolesService : IRolesService
    {   
        private RoleManager<IdentityRole<int>> _roleManager;
        private UserManager<User> _userManager;

        public RolesService(RoleManager<IdentityRole<int>> roleManager,
            UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task CreAteInitialRolesAndAssign()
        {
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole<int> { Name = "Admin" };
                await _roleManager.CreateAsync(role);

                var initialAdmin = new User
                {
                    UserName = Guid.NewGuid().ToString(),
                    PhoneNumber = "0958347526",
                    Email = "flowershopadministration@gmail.com",
                    FirstName = "Employer",
                    LastName = ""
                };

                string password = "admin123";
                await _userManager.CreateAsync(initialAdmin, password);

                var user = await _userManager.FindByEmailAsync(initialAdmin.Email);
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
        public async Task AssignRole(int userId, int roleId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
            await _userManager.AddToRoleAsync(user, role.ToString());
        }
        

        public async Task<ICollection<IdentityRole<int>>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole<int>> GetRole(int id)
        {
            return await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
