using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;

using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    public class BarCode:BaseEntity
    {
        public string Code { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product product { get; set; }
        public DateTime? UpdateAt { get; set; } = DateTime.Now;

    }
}
