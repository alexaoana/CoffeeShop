using CoffeeShop.Core;
using CoffeeShop.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //dbContextOptionsBuilder.UseSqlServer(@"Server=ROMOB41210\SQLEXPRESS;Database=CoffeeShop;Trusted_Connection=True;MultipleActiveResultSets = True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
