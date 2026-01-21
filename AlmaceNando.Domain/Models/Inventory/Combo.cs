using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    internal class Combo:BaseEntity
    {

        public Guid ComboProductId { get; set; }
        [ForeignKey("ComboProductId")]
        public virtual Product ComboProduct { get; set; }


        public Guid ComponentProductId { get; set; }

        [ForeignKey("ComponentProductId ")]
        public virtual Product ComponentProduct { get; set; }

        public int Quantity { get; set; }



    }
}
