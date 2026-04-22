using AlmaceNando.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Services
{
    public interface IServiceSales<T> where T : class
    {
        public Task<IEnumerable<Product>> ProccessSale(decimal Num, IEnumerable<T> CartItems );



    }
}
