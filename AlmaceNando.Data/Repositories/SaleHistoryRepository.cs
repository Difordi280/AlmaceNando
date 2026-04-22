using AlmaceNando.Data.Context;
using AlmaceNando.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using AlmaceNando.Domain.Models.Inventory;
using Microsoft.EntityFrameworkCore;

namespace AlmaceNando.Data.Repositories
{
    public class SaleHistoryRepository: ISaleHistoryRepository
    {
        private readonly StoreContext _context;

        public SaleHistoryRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetHistoryProducts(DateTime Init, DateTime End, Guid IdUser)
        {
            var Sales = await _context.Set<Sale>()
                        .OrderByDescending(s => s.CreatedAt)
                        .Where(i => Init < i.CreatedAt &&  i.CreatedAt< End
                                && IdUser == i.UserId)
                        .ToListAsync();

            return Sales;
        }

    }
}
