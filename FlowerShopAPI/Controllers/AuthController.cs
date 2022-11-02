using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ProdutService;
using Services.UserService;
using Shared.Dtos;

namespace FlowerShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);

            }

            return BadRequest("Invalid properties");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Invalid properties");
        }
    }
}
