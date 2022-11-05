using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ProdutService;
using Services.RoleService;

namespace FlowerShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IRolesService _rolesService;
        public UserController(IUserService userService,
            IRolesService rolesService)
        {
            _userService = userService;
            _rolesService = rolesService;
        }

        [HttpGet("GetUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpPost("AssignRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AssignRole(int userId, int roleId)
        {
            if (await _userService.GetUser(userId) == null)
                return NotFound("No user with that id");
            if (await _rolesService.GetRole(roleId) == null)
                return NotFound("No role with that id");

            await _rolesService.AssignRole(userId, roleId);
            return Ok();
        }
    }
}