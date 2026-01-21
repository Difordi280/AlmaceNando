using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipes;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    internal class PriceHistory
    {

        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product product { get; set; }
        //Precio a lo que lo compre 
        public decimal CostPrice { get; set; }
        //Precio a lo que lo vendi 
        public decimal SalePrice { get; set; }

        public DateTime PriceChangeDate { get; set; }

    }
}
