using Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }

    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
    }
}