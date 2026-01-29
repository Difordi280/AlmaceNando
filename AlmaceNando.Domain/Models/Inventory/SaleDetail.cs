using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Models.Inventory
{
    public class SaleDetail:BaseEntity
    {
        // Id Para referenciar la venta
        public Guid saleId { get; set; }
        public virtual Sale sale { get; set; }

        // Id Para referenciar el producto de la tabla Products
        public Guid productId { get; set; }
        public virtual Product product { get; set; }

        // Cantidad de productos vendidos en esta venta
        public int Quantity { get; set; }
        // Precio al que se vendio cada unidad del producto
        public decimal UnitPrice { get; set; }

    }
}
