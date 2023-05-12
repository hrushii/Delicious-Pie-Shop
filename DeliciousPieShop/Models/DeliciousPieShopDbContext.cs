using Microsoft.EntityFrameworkCore;

namespace DeliciousPieShop.Models
{
    public class DeliciousPieShopDbContext : DbContext
    {
        public DeliciousPieShopDbContext(DbContextOptions<DeliciousPieShopDbContext> options) :base(options)
        {
            
        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
