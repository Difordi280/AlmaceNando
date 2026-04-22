using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Models.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Data.Mapping
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            // Configuraciones de propiedades
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Rol).HasDefaultValue("NN");

            builder.HasMany(p => p.Sales)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.UserId);

            builder.HasData(new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Un ID fijo y fácil de recordar
                Name = "Isleros0",
                UserName = "Vendedor Genérico",
                Password = "000", // Luego le pondremos seguridad, de momento para probar
                Rol = "NN"
            });
        }

    }
}
