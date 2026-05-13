using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Models.People;
using Microsoft.EntityFrameworkCore;
using System;

namespace AlmaceNando.Data.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext() { }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<BarCode> BarCodes { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<UserHistory> userHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\USUARIO-SIP\Desktop\Carpeta Diego\AlmaceNando\AlmaceNando.App\AlmaceNando.db");
            optionsBuilder.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- OPTIMIZACIÓN Y CONFIGURACIÓN DE USERHISTORY ---
            modelBuilder.Entity<UserHistory>(entity =>
            {
                entity.HasKey(e => e.Id);

                // ÍNDICES: Esto evita que la búsqueda se vuelva lenta con los años
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.CreatedAt);
                entity.HasIndex(e => e.actionType);

                // Relación obligatoria
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId);
            });

            // --- CONFIGURACIÓN DE USER ---
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired();

                entity.HasMany(e => e.Sales)
                      .WithOne()
                      .HasForeignKey("UserId");
            });

            // --- CONFIGURACIÓN DE CUSTOMER ---
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreditLimit).HasPrecision(18, 2);
                entity.Property(e => e.CurrentDebt).HasPrecision(18, 2);

                entity.HasMany(e => e.Sales)
                      .WithOne()
                      .HasForeignKey("CustomerId");
            });

            // --- OPTIMIZACIÓN DE VENTAS (Suelen ser las más pesadas) ---
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasIndex(e => e.CreatedAt); // Para reportes por fecha rápidos
            });

            // --- SEED DATA ---
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("d7f965d1-9f9b-4e1b-b461-8f6920f09a56"),
                    Name = "Diego Administrador",
                    UserName = "admin",
                    Password = "123",
                    Rol = "Admin"
                },
                new User
                {
                    Id = Guid.Parse("a3b2c1d0-e4f5-4a3b-8c7d-6e5f4d3c2b1a"),
                    Name = "Ana Cajera",
                    UserName = "ana",
                    Password = "456",
                    Rol = "Cajero"
                }
            );
        }
    }
}