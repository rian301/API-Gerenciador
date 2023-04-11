using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IInvoiceRepository : IRepositoryBaseCRUD<Invoice, int>
    {
        Task<Invoice> GetLastInvoiceBySubscriptionAsync(int subscriptionId);
        Task<List<Invoice>> GetAllPendingInvoiceToPaymentAsync();
        Task<List<Invoice>> GetByPeriod(DateTime dateInit, DateTime dateEnd);
        Task<List<Invoice>> GetByPeriodPaid(DateTime dateInit, DateTime dateEnd);
        Task<List<Invoice>> GetAllPendingBySubscription(int subscriptionId);
        Task<List<Invoice>> GetAllByIdSubscriptionAsync(int subscriptionId);
        Task<List<Invoice>> GetAllWithOverdueInvoice();
    }
}
