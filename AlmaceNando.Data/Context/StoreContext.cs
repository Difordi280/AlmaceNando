using AlmaceNando.Domain.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

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
            // Tu configuración de Sqlite...
            // En tu StoreContext o donde configures la conexión:
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\USUARIO-SIP\Desktop\Carpeta Diego\AlmaceNando\AlmaceNando.App\AlmaceNando.db");

            // ESTA LÍNEA ES LA MAGIA:
            optionsBuilder.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. OBLIGATORIO: Primero la base y los mappings
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);

            // 2. IDS FIJOS (Para evitar errores de "Pending Changes")
            var idLeche = new Guid("11111111-1111-1111-1111-111111111111");
            var idJugo = new Guid("22222222-2222-2222-2222-222222222222");
            var idArroz = new Guid("33333333-3333-3333-3333-333333333333");
            var idAceite = new Guid("44444444-4444-4444-4444-444444444444");
            var idAtun = new Guid("55555555-5555-5555-5555-555555555555");
            var idJabon = new Guid("66666666-6666-6666-6666-666666666666");
            var idCafe = new Guid("77777777-7777-7777-7777-777777777777");
            var idPasta = new Guid("88888888-8888-8888-8888-888888888888");
            var idSal = new Guid("99999999-9999-9999-9999-999999999999");
            var idPan = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            // 3. SEED DATA - PRODUCTOS
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = idLeche, Name = "Leche Colanta 1L", Brand = "Colanta", Price = 4200, Stock = 20, SearchName = "leche colanta 1l lacteo nevera", keyword = "101" },
                new Product { Id = idJugo, Name = "Jugo Hit Mora", Brand = "Postobon", Price = 2500, Stock = 15, SearchName = "jugo hit mora bebida nevera", keyword = "102" },
                new Product { Id = idArroz, Name = "Arroz Diana 1kg", Brand = "Diana", Price = 3500, Stock = 50, SearchName = "arroz diana grano", keyword = "201" },
                new Product { Id = idAceite, Name = "Aceite Premier", Brand = "Premier", Price = 12000, Stock = 10, SearchName = "aceite premier cocina", keyword = "202" },
                new Product { Id = idAtun, Name = "Atun Van Camps", Brand = "Van Camps", Price = 6000, Stock = 30, SearchName = "atun van camps conserva", keyword = "301" },
                new Product { Id = idJabon, Name = "Jabon Rey", Brand = "Rey", Price = 2200, Stock = 40, SearchName = "jabon rey aseo", keyword = "401" },
                new Product { Id = idCafe, Name = "Cafe Sello Rojo", Brand = "Sello Rojo", Price = 9000, Stock = 25, SearchName = "cafe sello rojo tinto", keyword = "501" },
                new Product { Id = idPasta, Name = "Pasta Doria", Brand = "Doria", Price = 3000, Stock = 35, SearchName = "pasta doria espagueti", keyword = "601" },
                new Product { Id = idSal, Name = "Sal Refisal", Brand = "Refisal", Price = 1500, Stock = 80, SearchName = "sal refisal condimento", keyword = "701" },
                new Product { Id = idPan, Name = "Pan Bimbo", Brand = "Bimbo", Price = 7500, Stock = 12, SearchName = "pan bimbo tajado", keyword = "801" }
            );

            // 4. SEED DATA - TAGS
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = Guid.NewGuid(), ProductId = idLeche, tag = "lacteo" },
                new Tag { Id = Guid.NewGuid(), ProductId = idLeche, tag = "nevera" },
                new Tag { Id = Guid.NewGuid(), ProductId = idJugo, tag = "bebida" },
                new Tag { Id = Guid.NewGuid(), ProductId = idJugo, tag = "nevera" }
            );

            // 5. SEED DATA - BARCODES
            modelBuilder.Entity<BarCode>().HasData(
                new BarCode { Id = Guid.NewGuid(), ProductId = idLeche, Code = "7701001" },
                new BarCode { Id = Guid.NewGuid(), ProductId = idJugo, Code = "7701002" }
            );
        }

    }
    
    
}
