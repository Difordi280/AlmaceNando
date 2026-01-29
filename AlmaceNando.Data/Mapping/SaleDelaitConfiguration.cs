using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AlmaceNando.Domain.Models.Inventory;

namespace AlmaceNando.Data.Mapping
{
    // Configuracion de la entidad SaleDetail como se configuraron los anteriores mapeos
    internal class SaleDelaitConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            // referencia a producto es de 1:n
            builder.HasOne(sd => sd.product)
                   .WithMany()
                   .HasForeignKey(sd => sd.productId);
        }
    }
}
