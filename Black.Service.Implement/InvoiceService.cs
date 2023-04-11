using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using Procard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class InvoiceService : ServiceBaseCRUD<Invoice, int>, IInvoiceService
    {
        #region Properties
        private readonly IInvoiceRepository _invoiceRepository;
        #endregion

        public InvoiceService(IInvoiceRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _invoiceRepository = repository;
        }

        public Task<Invoice> GetLastInvoiceBySubscriptionAsync(int subscriptionId) => _invoiceRepository.GetLastInvoiceBySubscriptionAsync(subscriptionId);
        public Task<List<Invoice>> GetAllPendingInvoiceToPaymentAsync() => _invoiceRepository.GetAllPendingInvoiceToPaymentAsync();
        public Task<List<Invoice>> GetByPeriod(DateTime dateInit, DateTime dateEnd) => _invoiceRepository.GetByPeriod(dateInit, dateEnd);
        public Task<List<Invoice>> GetByPeriodPaid(DateTime dateInit, DateTime dateEnd) => _invoiceRepository.GetByPeriodPaid(dateInit, dateEnd);
        public Task<List<Invoice>> GetAllPendingBySubscription(int subscriptionId) => _invoiceRepository.GetAllPendingBySubscription(subscriptionId);
        public Task<List<Invoice>> GetAllByIdSubscriptionAsync(int subscriptionId) => _invoiceRepository.GetAllByIdSubscriptionAsync(subscriptionId);
        public Task<List<Invoice>> GetAllWithOverdueInvoice() => _invoiceRepository.GetAllWithOverdueInvoice();
    }
}
