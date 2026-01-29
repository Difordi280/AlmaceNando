using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipes;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    public class PriceHistory:BaseEntity
    {

        public Guid ProductId { get; set; }
        public virtual Product product { get; set; }
        //Precio a lo que lo compre 
        public decimal CostPrice { get; set; }
        //Precio a lo que lo vendi 
        public decimal SalePrice { get; set; }

        public DateTime PriceChangeDate { get; set; }

   
    }
}
