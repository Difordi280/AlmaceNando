using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Record;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.IRepositories
{
    public interface ISaleHistoryRepository
    {
        public Task<IEnumerable<Sale>> SalesListAsync(SaleSearchCriteria parametros);

        public Task<decimal> SalesTotalSumAsync(SaleSearchCriteria parametros);

    }
}
