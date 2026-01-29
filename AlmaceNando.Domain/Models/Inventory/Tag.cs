using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    public class Tag:BaseEntity
    {
        public Guid ProductId { get; set; }
        
        public virtual Product product { get; set; }
        public string tag { get; set; }



    }
}
