using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Logic.DoTS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Logic.Interfaces
{
    public interface IServiceSales
    {

        public Task ProccessSales(decimal Num, IEnumerable<SalesItem> CartItems);


    }
}
