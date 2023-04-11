using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IDailyPaymentService : IServiceBaseCRUD<DailyPayment, int>
    {
        Task<int> QuantityDailyPayments();
        Task<List<DailyPayment>> GetAllPagination(string name, DateTime? date, string provider, string category, PaginationDTO pagination);
    }
}
