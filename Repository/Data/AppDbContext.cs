using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Repository.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Subscribe> Subscribes { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<AboutUs> AboutUs { get; set; }
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Expert> Experts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<WishlistItem> WishlistItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<FeaturedProduct> FeaturedProducts { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Product>()
    .Property(p => p.Price)
    .HasPrecision(18, 2);

        base.OnModelCreating(modelBuilder);
    }
}
