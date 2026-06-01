using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Services
{
    public interface IFinanceService
    {
        public Task<(decimal Cash, decimal Debtor)> CloseShift(DateTime firsts, Guid clientId);

    }
}
