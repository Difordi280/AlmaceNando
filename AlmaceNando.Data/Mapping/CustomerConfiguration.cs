using AlmaceNando.Domain.Models.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Data.Mapping
{
    public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Es el estandar puede cambiar pero de momento este sera el estandar
            builder.Property(x => x.CreditLimit).HasDefaultValue(50000);

            builder.Property(x => x.CurrentDebt).HasDefaultValue(0);

            //es una relacion de Uno a muchos
            builder.HasMany(p => p.Sales)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.CustomerId);


        }
    }
}
