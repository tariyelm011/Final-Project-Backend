using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
    }
}