using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AlmaceNando.Domain.Models.Inventory;

namespace AlmaceNando.Data.Mapping
{
    internal class ComboConfiguration : IEntityTypeConfiguration<Combo>
    {
        // no colocar caracteristicas a las propiedades, solo las relaciones
        public void Configure(EntityTypeBuilder<Combo> builder) 
        {
            //Relacion De M a M Autoreferenciada

            builder.HasOne(c=> c.ComboProduct) // Un combo tiene un producto que es el combo
                   .WithMany() // Un producto puede ser parte de muchos combos
                   .HasForeignKey(c => c.ComboProductId) // La llave foranea vive en Combo
                   .OnDelete(DeleteBehavior.Restrict); // Evitar eliminacion en cascada

            builder.HasOne(c => c.ComponentProduct) // Un combo tiene un producto que es componente
                   .WithMany() // Un producto puede ser componente de muchos combos
                   .HasForeignKey(c => c.ComponentProductId) // La llave foranea vive en Combo
                   .OnDelete(DeleteBehavior.Restrict); // Evitar eliminacion en cascada
        }
    }
}
