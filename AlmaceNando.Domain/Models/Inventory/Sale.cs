using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    internal class Sale:BaseEntity
    {
        // Precio al que se vendio el producto
        public decimal SalePrice { get; set; }

        //Id del cliente que por ahora no voy a relacionar con
        //ninguna tabla 
        public Guid ClientId { get; set; }
        //[ForeignKey("ClientId")]
        //public virtual Client client { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product product { get; set; }
    }
}
