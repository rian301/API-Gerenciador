using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class SubscriptionApp : AppBaseCRUD<Subscription, int>, ISubscriptionApp
    {
        #region Properties
        private readonly ISubscriptionService _subscriptionService;
        private readonly IInvoiceService _invoiceService;
        private readonly IMentoredService _mentoredService;
        private readonly IMentoredPaymentService _mentoredPaymentService;
        #endregion

        #region Constructors
        public SubscriptionApp(ISubscriptionService service, IInvoiceService invoiceService, IMentoredService mentoredService, IMentoredPaymentService mentoredPaymentService, INotificationHandler<DomainNotification> notification, IUser user, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _subscriptionService = service;
            _invoiceService = invoiceService;
            _mentoredService = mentoredService;
            _mentoredPaymentService = mentoredPaymentService;
        }
        #endregion

        #region Methods
        public Task<Subscription> GetByMentoredAsync(int mentoredId) => _subscriptionService.GetByMentoredAsync(mentoredId);
        public Task<List<Subscription>> GetAllByMentoredAsync(int mentoredId, int? partnerId) => _subscriptionService.GetAllByMentoredAsync(mentoredId, partnerId);
        public Task<List<Subscription>> GetAllByProduct(int productId) => _subscriptionService.GetAllByProduct(productId);
        public Task<List<Subscription>> GetAllByDateAsync(DateTime? date) => _subscriptionService.GetAllByDateAsync(date);  
        #endregion
    }
}
