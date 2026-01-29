using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AlmaceNando.Domain.Models.Inventory;

namespace AlmaceNando.Data.Mapping
{
    // copea la estructura de ComboConfiguration.cs
    internal class SaleConfiguration: IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            // Relacion de 1:M entre Sale y SaleDetail
            builder.HasMany(s => s.SaleDetails)
                   .WithOne(sd => sd.sale)
                   .HasForeignKey(sd => sd.saleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
