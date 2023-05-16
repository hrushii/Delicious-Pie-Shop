using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeliciousPieShop.Models
{
    public class DeliciousPieShopDbContext : IdentityDbContext
    {
        public DeliciousPieShopDbContext(DbContextOptions<DeliciousPieShopDbContext> options) :base(options)
        {
            
        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
