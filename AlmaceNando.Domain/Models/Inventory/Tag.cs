using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    internal class Tag:BaseEntity
    {
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product product { get; set; }
        public string tag { get; set; }



    }
}
