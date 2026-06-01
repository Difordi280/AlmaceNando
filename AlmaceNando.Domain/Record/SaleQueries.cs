using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Record
{

    public enum SaleStatus { ImmediatePay, Debt, PaidDebt }


    public record SaleSearchCriteria(
        DateTime? StartDate = null,
        DateTime? EndDate = null,
        Guid? ClientId = null,
        Guid? CustomerId = null,
        List<SaleStatus>? Debtor = null
    );


}
