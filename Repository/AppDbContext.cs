using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductFlowerType> ProductFlowerTypes { get; set; }
        public DbSet<ProductAppointment> ProductAppointments { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}