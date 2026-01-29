using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    public class Sale:BaseEntity
    {
        // Precio al que se vendio el producto
        public decimal TotalAmount { get; set; }

        //Id del cliente que por ahora no voy a relacionar con
        //ninguna tabla 
        public Guid? ClientId { get; set; }
        //public virtual Client client { get; set; }


        
        //referencia una tabla SaleDetail
        
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }

        
    }
}
