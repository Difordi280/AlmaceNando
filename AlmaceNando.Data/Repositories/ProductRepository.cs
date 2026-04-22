using AlmaceNando.Data.Context;
using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {   
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context )
        { _context= context; }

        public async Task<IEnumerable<Product>> Search(string write, CancellationToken ct)
        {
            var ByBarCodeFilter = await _context.Set<BarCode>()
                    .Where(x => x.Code == write )
                    .Select(b => b.product)
                    .FirstOrDefaultAsync();

            //if (ByBarCodeFilter != null)
            //    return new List<Product> { ByBarCodeFilter };


            var ByKeyword = _context.Set<Product>()
                .Where(x => x.keyword == write);


            var ByName = _context.Set<Product>()
                .Where(x => EF.Functions.Like(x.SearchName, $"%{write}%"));

            var ByBrand = _context.Set<Product>()
                .Where(x => EF.Functions.Like(x.Brand, $"%{write}%"));

            var ByTag = _context.Set<Product>()
                .Where(p => _context.Set<Tag>().Any(x => x.ProductId == p.Id && EF.Functions.Like(x.tag, $"%{write}%")));


            var ByEnd = ByKeyword
                .Union(ByName)
                .Union(ByBrand)
                .Union(ByTag);

            return await ByEnd.ToListAsync(ct);

            
        
        }

    }
}
