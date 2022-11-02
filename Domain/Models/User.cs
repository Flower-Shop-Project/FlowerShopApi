using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Domain.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class User : IdentityUser<int>
    {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? DeliveryAdress { get; set; }
    }
}