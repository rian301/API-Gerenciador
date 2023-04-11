using Black.Application.Base;
using Black.Domain.Models;
using Procard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IInvoiceApp : IAppBaseCRUD<Invoice, int>
    {
        Task<List<Invoice>> GetInvoicesByPeriod(DateTime dateInit, DateTime dateEnd, bool paid);
        Task<List<Invoice>> GetAllPendingBySubscription(int subscriptionId);
        Task<List<Invoice>> GetAllByIdSubscriptionAsync(int subscriptionId);
    }
}
