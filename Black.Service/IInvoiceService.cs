using Black.Domain.Models;
using Black.Service.Base;
using Procard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IInvoiceService : IServiceBaseCRUD<Invoice, int>
    {
        Task<Invoice> GetLastInvoiceBySubscriptionAsync(int subscriptionId);
        Task<List<Invoice>> GetAllPendingBySubscription(int subscriptionId);
        Task<List<Invoice>> GetAllPendingInvoiceToPaymentAsync();
        Task<List<Invoice>> GetByPeriod(DateTime dateInit, DateTime dateEnd);
        Task<List<Invoice>> GetByPeriodPaid(DateTime dateInit, DateTime dateEnd);
        Task<List<Invoice>> GetAllByIdSubscriptionAsync(int subscriptionId);
        Task<List<Invoice>> GetAllWithOverdueInvoice();
    }
}
