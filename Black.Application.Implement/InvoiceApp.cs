using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using Newtonsoft.Json;
using Procard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class InvoiceApp : AppBaseCRUD<Invoice, int>, IInvoiceApp
    {
        #region Properties
        private readonly ILogErroApp _logErroApp;
        private readonly IInvoiceService _invoiceService;
        private readonly ISubscriptionApp _subscriptionApp;
        private readonly IUserApp _userApp;
        #endregion

        #region Constructor
        public InvoiceApp(INotificationHandler<DomainNotification> notification, IUser user, IUnitOfWork uow,
            IInvoiceService service, ILogErroApp logErroApp, ISubscriptionApp subscriptionApp, IUserApp userApp)
            : base(service, notification, user, uow)
        {
            _logErroApp = logErroApp;
            _invoiceService = service;
            _subscriptionApp = subscriptionApp;
            _userApp = userApp;
        }
        #endregion

        public async Task<List<Invoice>> GetInvoicesByPeriod(DateTime dateInit, DateTime dateEnd, bool paid)
        {
            var listInvoice = new List<Invoice>();

            if(paid)
                listInvoice = await _invoiceService.GetByPeriodPaid(dateInit.Date, dateEnd.Date);
            else
                listInvoice = await _invoiceService.GetByPeriod(dateInit.Date, dateEnd.Date);

            if (listInvoice == null)
            {
                _notification.Handle(new DomainNotification("InvoiceInvalid", "Não foram encontrados faturas para este período informado."));
                return null;
            }

            await ChecknvoiceOverdue();

            return listInvoice;
        }

        public async Task ChecknvoiceOverdue()
        {
            // Busca faturas vencidas e seta o SetOverdueSince
            var invoices = await _invoiceService.GetAllWithOverdueInvoice();

            if (invoices.Count() > 0)
            {
                _uow.BeginTransaction();

                foreach (var item in invoices)
                {
                    item.SetOverdueSince(item.ExpirationDate);
                }
                await _uow.SaveAsync();
                _uow.Commit();
            }
        }

        public Task<List<Invoice>> GetAllPendingBySubscription(int subscriptionId) => _invoiceService.GetAllPendingBySubscription(subscriptionId);
        public Task<List<Invoice>> GetAllByIdSubscriptionAsync(int subscriptionId) => _invoiceService.GetAllByIdSubscriptionAsync(subscriptionId);

    }
}
