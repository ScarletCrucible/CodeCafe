using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CodeCafe.Models.SeedData;

namespace CodeCafe.Models
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Setting primary key
            modelBuilder.Entity<OrderItem>().HasKey(oi => new { oi.ProductId });
            //Setting foreign key
            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.ApplyConfiguration(new SeedProducts());
            modelBuilder.ApplyConfiguration(new SeedOrderItems());
        }
    }
}