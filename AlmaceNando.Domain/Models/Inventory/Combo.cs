using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    // tabla intermedia que relaciona productos que son combos con los productos que los componen
    public class Combo:BaseEntity
    {
        // Producto que es el combo
        public Guid ComboProductId { get; set; }
        public virtual Product ComboProduct { get; set; }

        // Producto que es parte del combo
        public Guid ComponentProductId { get; set; }
        public virtual Product ComponentProduct { get; set; }
        // Cantidad del producto componente en el combo
        public int Quantity { get; set; }



    }
}
