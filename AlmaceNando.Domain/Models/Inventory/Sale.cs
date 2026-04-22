using AlmaceNando.Domain.Models.Base;
using AlmaceNando.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    public class Sale:BaseEntity
    {
        // Precio al que se hizo la compra 
        public decimal TotalAmount { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        //Id del cliente que por ahora no voy a relacionar con
        //ninguna tabla 
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        //referencia una tabla SaleDetail
        
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }

        
    }
}
