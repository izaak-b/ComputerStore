using ComputerStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Data.Context
{
    public class ComputerStoreDbContext : DbContext
    {
        public ComputerStoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Order>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
