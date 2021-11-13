using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.DataAccess.Concrete.EntityFramework.Contexts
{
    public class SuperMarketDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-1779AJF;Initial Catalog=SuperMarketDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}
        public SuperMarketDbContext(DbContextOptions<SuperMarketDbContext> options) : base(options)
        {
        }

        public DbSet<BasketDetail> BasketDetails { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}