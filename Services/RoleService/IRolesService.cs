using Microsoft.AspNetCore.Identity;


namespace Services.RoleService
{
    public interface IRolesService
    {
        Task CreAteInitialRolesAndAssign();
        Task AssignRole(int userId, int roleId);
        Task<IdentityRole<int>> GetRole(int id);
        Task<ICollection<IdentityRole<int>>> GetRoles(); 
    }
}
