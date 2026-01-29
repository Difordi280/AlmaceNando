using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AlmaceNando.Domain.Models.Inventory;

namespace AlmaceNando.Data.Context
{
    public class StoreContext : DbContext 
    {

        public StoreContext(){}
        public StoreContext(DbContextOptions<StoreContext> options): base(options)
        {

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<BarCode> BarCodes { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Archivo SQLite local con nombre Store.db
            optionsBuilder.UseSqlite("Data Source=AlmaceNando.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
        }

    }
    
    
}
