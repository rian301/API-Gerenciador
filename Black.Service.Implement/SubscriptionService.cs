using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class SubscriptionService : ServiceBaseCRUD<Subscription, int>, ISubscriptionService
    {
        #region Properties
        private readonly ISubscriptionRepository _subscriptionRepository;
        #endregion

        public SubscriptionService(ISubscriptionRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _subscriptionRepository = repository;
        }

        public Task<Subscription> GetByMentoredAsync(int mentoredId) => _subscriptionRepository.GetByMentoredAsync(mentoredId);
        public Task<List<Subscription>> GetAllByMentoredAsync(int mentoredId, int? partnerId) => _subscriptionRepository.GetAllByMentoredAsync(mentoredId, partnerId);
        public Task<List<Subscription>> GetAllByProduct(int productId) => _subscriptionRepository.GetAllByProduct(productId);
        public Task<List<Subscription>> GetAllByDateAsync(DateTime? date) => _subscriptionRepository.GetAllByDateAsync(date);
    }
}
