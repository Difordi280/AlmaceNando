using System;
using System.Collections.Generic;
using System.Text;
using AlmaceNando.Domain.Models.Inventory;  

namespace AlmaceNando.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Search(string write,CancellationToken ct);





    }
}
