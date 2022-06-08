using Ecommerce.Domain;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence
{
    public class StoreDbContext : AuditableDbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Basket> Baskets {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<OrderItem> OrderItems {get; set;}
        public DbSet<DeliveryMethod> DeliveryMethods {get; set;}

    }
}
