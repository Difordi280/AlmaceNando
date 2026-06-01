using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Record;
using AlmaceNando.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Logic.Service
{
    public class FinanceService: IFinanceService
    {
        private readonly ISaleHistoryRepository saleHistoryRepository;
        public FinanceService(ISaleHistoryRepository _saleHistoryRepository) 
        { 
            saleHistoryRepository = _saleHistoryRepository;
        }

        public async Task<(decimal Cash, decimal Debtor)> CloseShift(DateTime firsts, Guid clientId)
        {
            // Preparando los parámetros que sirven para filtrar
            SaleSearchCriteria criteria = new SaleSearchCriteria
            {
                StartDate = firsts,
                EndDate = DateTime.Now,
                ClientId = clientId,
                Debtor = new List<SaleStatus>
            { SaleStatus.PaidDebt, SaleStatus.ImmediatePay }
            };

            // Llamada al filtro con los datos necesarios
            decimal Cash = await saleHistoryRepository.SalesTotalSumAsync(criteria);

            criteria.Debtor.Clear();
            criteria.Debtor.Add(SaleStatus.Debt);

            decimal Debtor = await saleHistoryRepository.SalesTotalSumAsync(criteria);

            // ✅ Agregar el return con la tupla
            return (Cash, Debtor);
        }


    }
}
