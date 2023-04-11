using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IDailyPaymentRepository : IRepositoryBaseCRUD<DailyPayment, int>
    {
        Task<int> QuantityDailyPayments();
        Task<List<DailyPayment>> GetAllPagination(string name, DateTime? date, string provider, string category, PaginationDTO pagination);
    }
}
