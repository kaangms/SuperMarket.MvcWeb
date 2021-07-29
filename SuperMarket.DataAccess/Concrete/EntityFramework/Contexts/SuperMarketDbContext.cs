using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.DataAccess.Concrete.EntityFramework.Contexts
{
    public class SuperMarketDbContext : DbContext
    {
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
