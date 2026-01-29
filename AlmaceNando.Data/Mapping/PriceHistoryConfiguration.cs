using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AlmaceNando.Domain.Models.Inventory;

namespace AlmaceNando.Data.Mapping
{
    
    internal class PriceHistoryConfiguration: IEntityTypeConfiguration<PriceHistory>
    {
        public void Configure(EntityTypeBuilder<PriceHistory> builder)
        {

            //relacionamientos 1 a M (uno a muchos)
            builder.HasOne(c=> c.product).
                    WithMany().
                    HasForeignKey(c=> c.ProductId).
                    OnDelete(DeleteBehavior.Restrict);// no se puede borrar el registro sin importar que padre haya muerto

        }
    }
}
