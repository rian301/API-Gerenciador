using Black.Application.Base;
using Black.Domain.DTO;
using Black.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IDailyPaymentApp : IAppBaseCRUD<DailyPayment, int>
    {
        Task<int> QuantityDailyPayments();
        Task<DailyPayment> AddDailyPayment(DailyPayment model);
        Task<List<DailyPayment>> GetAllPagination(QueryDailyPaymentDTO dto);
    }
}
