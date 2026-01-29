using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AlmaceNando.Domain.Models.Inventory;

namespace AlmaceNando.Data.Mapping
{
    internal class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // especificar segun reglas de sqlite y el dominio
            // Para nombre limitar caracteres a 70, "NN" por defecto no permite null
            builder.Property(x => x.Name).IsRequired().HasMaxLength(70).HasDefaultValue("NN");
            // Para UpdateAt es requerido, no puede ser null, valor por defecto es la fecha actual
            builder.Property(x => x.UpdateAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            // Para Stock es requerido, valor por defecto es 0, no puede ser null
            builder.Property(x => x.Stock).IsRequired().HasDefaultValue(0);
            // Para CurrentPrice es requerido,  no puede ser null, obligar a que escriba un valor decimal
            builder.Property(x => x.CurrentPrice).IsRequired().HasColumnType("decimal(18,2)");
            // Para Brand limitar caracteres a 50
            builder.Property(x => x.Brand).HasMaxLength(50);

            

            // Para keyword no ahi ninguna limitacion
            builder.Property(x => x.keyword).IsRequired(false);


            //ahora viene las relaciones

            // 1. Empezamos con las propiedades que SÍ están en Product
            builder.HasMany(p => p.BarCodes)      // Product tiene muchos BarCodes
                   .WithOne(b => b.product)       // Cada BarCode tiene un product
                   .HasForeignKey(b => b.ProductId) // La llave vive en BarCode
                   .IsRequired(false);


        }

    }
}
