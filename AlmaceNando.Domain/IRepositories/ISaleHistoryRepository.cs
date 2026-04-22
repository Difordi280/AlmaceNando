using AlmaceNando.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.IRepositories
{
    public interface ISaleHistoryRepository
    {
        public Task<IEnumerable<Sale>> GetHistoryProducts(DateTime Init, DateTime End, Guid IdUser);

    }
}
