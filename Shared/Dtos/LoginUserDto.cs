using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{
    public class LoginUserDto
    {
        public string? EmailOrPhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
